# Name: Krizbai Csaba
# Date: 2020. 03. 03

# === Imports ===
from tkinter import *
import multiprocessing
import time
import serial #for exception (try)
import sched
import matplotlib.pyplot as plt
import matplotlib.lines as mlines
import matplotlib.cm as colormap
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
import numpy as np

# Classes
from Classes.interfaceDrawer import *
from Classes.MPU9250 import MPU9250
from Classes.IMU_IRR_filter import IMU_Filter
from Classes.MotorControl import MotorControl
from Classes.Hokuyo import URG04LX
from Classes.mqtt import MQTT
# SLAM 
from breezyslam.algorithms import RMHC_SLAM
from breezyslam.sensors import URG04LX as LaserModel

#Const
MAP_SIZE_PIXEL = 200
MAP_SIZE_METER = 10
FOLLOW_SPEED = 2.5

# === Interface Class ===  

class Interface():
    def __init__(self):
        self.root = Tk()
        self.root.configure(background='#12232E')
        self.root.geometry("925x650")
        self.root.title("Slam algorithm")

        #key listenings
        self.root.bind("<KeyPress-w>", self.onKeyPress)
        self.root.bind("<KeyPress-a>", self.onKeyPress)
        self.root.bind("<KeyPress-s>", self.onKeyPress)
        self.root.bind("<KeyPress-d>", self.onKeyPress)
        self.root.bind("<KeyPress-space>", self.onKeyPress)
        #queue's
        self.queueInterface = multiprocessing.Queue(10) #MOTOR, PWM, IMU
        self.queueSLAM = multiprocessing.Queue(10)
        self.queueMotor = multiprocessing.Queue(10)
        self.queueNeedFollowAngle = multiprocessing.Queue(10)
        self.queueIMUforFollow = multiprocessing.Queue(10)
        self.queueFollowRefAngle = multiprocessing.Queue(10)

        #variables
        self.IMUArray = np.empty(9)
        self.startFollow = True
        self.refAngle = None
        self.drawMAP = False

        
    # === Start All Process ===
    def startAllProcess(self):
        self.SLAMProcessHandler = multiprocessing.Process(target=self.slamProcess)
        self.IMUProcessHandler = multiprocessing.Process(target=self.IMUProcess)
        self.MotorProcessHandler = multiprocessing.Process(target=self.motorProcess)
        self.IMUProcessHandler.start()
        self.MotorProcessHandler.start()
        self.SLAMProcessHandler.start()
          
    # === Motor Control Process ===
    def motorProcess(self):
        mtrCtr = MotorControl()
        motorSched = sched.scheduler(time.time, time.sleep)
        motorSched.enter(1, 1, self.motorLoop, (motorSched,mtrCtr))
        motorSched.run()
        
    def motorLoop(self, motorShed, mtrCtr):
        self.followAngleControl(mtrCtr) 
        self.keyboardMotorControl(mtrCtr) 
        motorShed.enter(0.1, 1, self.motorLoop, (motorShed,mtrCtr))
    
    # === Follow Ref angle ===
    def followAngleControl(self, mtrCtr): 
        try: #read ref. Angle
            self.refAngle = self.queueFollowRefAngle.get(False)
        except:
            pass
        if self.refAngle == None:  # if ref.angle == None, dont follow
            return
        try: #read Angle
            angle = self.queueIMUforFollow.get() #no FALSE!!!
        except:
            return
        pwmLeft, pwmRight = mtrCtr.robotControl(int(self.refAngle), angle, FOLLOW_SPEED)
        mtrCtr.setMotorPWM2(pwmLeft, pwmRight)
        self.queueInterface.put(["MOTOR", pwmLeft, pwmRight])

            
    # -- KEyboard Interupt Motor COntrol --
    def keyboardMotorControl(self, mtrCtr):
        try:
            motorCommand = self.queueMotor.get(False)
            if motorCommand == "w":
                mtrCtr.setMotorPWM2(100,100)
            elif motorCommand == "s":
                mtrCtr.setMotorPWM2(-80,-80)
            elif motorCommand == "a":
                mtrCtr.setMotorPWM2(-80,80)
            elif motorCommand == "d":
                mtrCtr.setMotorPWM2(80,-80)
            elif motorCommand == "STOP":
                mtrCtr.setMotorPWM2(0,0)
            time.sleep(0.05)
        except:
            pass

        
    # === SLAM, MQTT, HOKUYO Process == 
    def slamProcess(self):
        #lidar 
        lidar = URG04LX()
        lidar.connect()
        #MQTT
        #mqttCom = MQTT(lidar)
        mqttCom = None
        slam = RMHC_SLAM(lidar, MAP_SIZE_PIXEL, MAP_SIZE_METER)
        mapbytes = bytearray(MAP_SIZE_PIXEL*MAP_SIZE_PIXEL)
        slamSched = sched.scheduler(time.time, time.sleep)
        slamSched.enter(1, 1, self.slamLoop, (slamSched, lidar, mqttCom, slam, mapbytes))
        slamSched.run()
        
    def slamLoop(self, slamSched, lidar, mqttCom, slam, mapbytes):
        try:
            timeStamp, angle, distance = lidar.getDataMD()
        except serial.SerialException:
            print("Lidar Error")
            return
        slam.update(distance)
        robotPos_X, robotPos_Y, theta = slam.getpos() #get robot pos
        slam.getmap(mapbytes) #get SLAM map
        self.queueSLAM.put([robotPos_X/1000, robotPos_Y/1000, theta, mapbytes])
        #mqttCom.publish("MAP", mapbytes)
        slamSched.enter(0.1, 1, self.slamLoop, (slamSched, lidar, mqttCom, slam, mapbytes)) #0.1
        
            

  
    # === IMU Process ===
    def IMUProcess(self):
        IMU_Class = IMU_Filter()
        self.needAngle = False
        self.sendLoop = 3
        IMUSched = sched.scheduler(time.time, time.sleep)
        IMUSched.enter(1, 1, self.IMULoop, (IMUSched, IMU_Class)) # enter (delay(sec), priority, action, argument)
        IMUSched.run()
        
    def IMULoop(self, IMUSched, IMU_Class):
        theta = IMU_Class.runFilter()
        # = Motor Process need follow angle =
        try:
            if self.queueNeedFollowAngle.get(False) == 'True':
                self.needAngle = True
            else:
                self.needAngle = False
        except:
            pass
        if self.needAngle == True:
            self.queueIMUforFollow.put(theta) #send angle for motor control in every loop
            print(self.queueIMUforFollow.qsize())
        # = IMU for interface in every 2.period = 
        self.sendLoop -= 1
        if self.sendLoop == 0:
            self.queueInterface.put(["IMU",IMU_Class.readSensorValues(), round(theta,2)])
            self.sendLoop = 3
        
        IMUSched.enter(0.1, 1, self.IMULoop, (IMUSched,IMU_Class))   #100 ms


    # == Run All Interface Elements ===
    def drawInterface(self):
        
        drawAngleLabel(self.root)
        drawPWMIndicator(self.root)
        drawGyroLabel(self.root)
        self.drawCanvasForSLAM()
        self.drawRefAngle()
        self.drawButtons()
        self.updateInterface()
        
        
           
        
    # === Update UI every x second ===
    def updateInterface(self):
        updateAll(self.queueInterface) # IMU, MOTOR, MAP
        self.updateCanvas()
        self.root.after(100 ,self.updateInterface) #ms
        
    def updateCanvas(self):
        try:
            robotPosX, robotPosY, theta, self.map = self.queueSLAM.get(False)
        except:
            return
        if self.drawMAP == False: #button state
            return
        self.setRobotPosition(robotPosX, robotPosY, theta)
        mapimg = np.reshape(np.frombuffer(self.map, dtype=np.uint8), (MAP_SIZE_PIXEL, MAP_SIZE_PIXEL))
        self.ax.imshow(mapimg, cmap=colormap.gray)
        self.canvas.draw()
        
    # === set Robot Position ===
    def setRobotPosition(self, x, y, theta):
        #delete last position
        if self.prevRobotPos != None:
            self.prevRobotPos.remove() #delete old position
        theta_rad = np.radians(theta)
        dx = np.cos(theta_rad)
        dy = np.sin(theta_rad)
        scale = ( MAP_SIZE_METER / MAP_SIZE_PIXEL);
        self.prevRobotPos = self.ax.arrow(x/scale , y/scale, dx, dy, width = 5, color = 'r') #draw roboot position
        currpos = [x/scale, y/scale]
        if self.prevpos != None:
            self.ax.add_line(mlines.Line2D((self.prevpos[0],currpos[0]), (self.prevpos[1],currpos[1]), color = 'g'))
        self.prevpos = currpos #save last position
    
    def drawCanvasForSLAM(self):
        self.figure = plt.Figure(figsize = (5.5, 5.5), facecolor = '#12232E') #width 550, heigth = 550
        self.canvas = FigureCanvasTkAgg(self.figure, master=self.root)
        self.canvas.get_tk_widget().place(x = 10, y = 10) #put figure on canvas
        self.ax = self.figure.gca() #getCurentAxes
        self.ax.set_xlabel('X (m)').set_color('w')
        self.ax.set_ylabel('Y (m)').set_color('w')
        self.ax.set_title('SLAM Mapping').set_color('w')
        self.map = bytearray(MAP_SIZE_PIXEL*MAP_SIZE_PIXEL)
        self.prevpos = None
        self.prevRobotPos = None
        self.zero_angle = 0
        self.start_angle = None
        self.rotate_angle = 0
    
    # === On Key Pressd ===
    def onKeyPress(self, event):
        if event.keysym == 'w':
            self.queueMotor.put("w")
            updatePWMIndicator(350,350)
        elif event.keysym == 'a':
            self.queueMotor.put("a")
            updatePWMIndicator(-170,170)
        elif event.keysym == 's':
            self.queueMotor.put("s")
            updatePWMIndicator(-350,-350)
        elif event.keysym == 'd':
            self.queueMotor.put("d")
            updatePWMIndicator(170,-170)
        elif event.keysym == 'space':
            self.queueMotor.put("STOP")
            updatePWMIndicator(0,0)
    
        
    # === Follow, STOP Button ===
    def drawButtons(self):
        # === STOP BUTTON ===
        self.stopIMG = PhotoImage(file=r"./img/stop.png")
        Button(self.root, command = self.stopRobot, width=70, activebackground='#203647', height=70, bg='#12232E', borderwidth=0, image=self.stopIMG).place(x=840, y=570)
        
        # === Follow the Ref. Angle ===
        Button(self.root, command = self.followButton, text = "Follow",fg='#EEFBFB', width=8, activebackground='#203647',  bg='#12232E', borderwidth=0).place(x=780, y=50)

        # === Save SLAM IMG BUTTON ===
        Button(self.root, command = self.saveIMGButton, text = "Save Map",fg='#EEFBFB', width=8, activebackground='#203647',  bg='#12232E', borderwidth=0).place(x=80, y=570)
        
        # === Draw Byte Array BUTTON ===
        Button(self.root, command = self.changeMAPButton, text = "Draw MAP",fg='#EEFBFB', width=8, activebackground='#203647',  bg='#12232E', borderwidth=0).place(x=220, y=570)

    # === Stop Robot ===
    def stopRobot(self):
        self.queueMotor.put("stop")
        self.root.after_cancel(self.updateInterface)
        self.root.after_cancel(self.root)
        try:
            self.IMUProcessHandler.terminate()
            self.IMUProcessHandler.join()
        except:
            pass
        try:
            self.MotorProcessHandler.terminate()
            self.MotorProcessHandler.join()
        except:
            pass
        try:
            self.SLAMProcessHandler.terminate()
            self.SLAMProcessHandler.join()
        except:
            pass
        self.root.destroy()
        print("All Process Killed!")
    
    # === Follow Button ===
    def followButton(self):
        if self.startFollow == True: #starta
            self.queueFollowRefAngle.put(self.refAngleEntry.get())
            self.queueNeedFollowAngle.put('True')
            self.startFollow = False
            print("starting")
        else:
            self.queueFollowRefAngle.put(None)
            self.queueMotor.put('STOP')
            self.queueNeedFollowAngle.put('False')
            self.startFollow = True
            print("ending")
            
    # === Save SLAM MAP Button ===
    def saveIMGButton(self):
        self.figure.savefig('SLAM_MAP.png')
    
    # === Draw State ON / OFF ===
    def changeMAPButton(self):
        self.drawMAP = not self.drawMAP
    
    # === Draw Referenc Angle ===
    def drawRefAngle(self):
        Label( self.root, bg='#12232E', fg='#EEFBFB', text="Ref. Angle:", font="Times 13 bold").place(x=680, y=25)
        self.refAngleEntry = Entry( self.root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
        self.refAngleEntry.insert(0, 20)
        self.refAngleEntry.place(x=680, y=50)


if __name__ == "__main__":
    print("Program is started...")
    UI = Interface()
    UI.startAllProcess()
    UI.drawInterface()


