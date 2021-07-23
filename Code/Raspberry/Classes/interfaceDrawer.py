# Name: Krizbai Csaba
# Date: 2020. 03. 18

# === Imports ===
from tkinter import *
from .MapperSLAM import DrawMAP
import queue
from multiprocessing import Queue
import multiprocessing
import serial #for exception (try)
import math
import numpy as np

# === Globals ===
global gyroXEntry,gyroYEntry,gyroZEntry, accXEntry, accYEntry, accZEntry, magXEntry, magYEntry, magZEntry
global leftMotorCanvas, leftMotorPWM, rightMotorCanvas, rightMotorPWM
global canvs
global angleEntry
global viz

# === Const ===
MAP_SIZE_PIXELS = 500
MAP_SIZE_METERS = 10
# ==== ==== ==== ==== ==== ==== ==== 
# ==== ==== ==== UPDATABLE ==== ====
# ==== ==== ==== ==== ==== ==== ====
def updateAll(queueInterface):
    try:
        queue = queueInterface.get(False)
    except:
        return
    if(queue[0] == "MOTOR"):
        updatePWMIndicator(queue[1],queue[2])
    if(queue[0] == "IMU"):
        updateIMU(queue[1], queue[2]) #raw IMU, angle




# === Update IMU Values ===
# allIMUValue = [Gyro, Accelo, Magneto)
def updateIMU(allIMUValue,angle):
    # = Gyro =
    global gyroXEntry,gyroYEntry,gyroZEntry, accXEntry, accYEntry, accZEntry, magXEntry, magYEntry, magZEntry, angleEntry
    gyroXEntry.delete(0, END)
    gyroXEntry.insert(0, allIMUValue[0][0])
    gyroYEntry.delete(0, END)
    gyroYEntry.insert(0, allIMUValue[0][1])
    gyroZEntry.delete(0, END)
    gyroZEntry.insert(0, allIMUValue[0][2])
    # = Acelo =
    accXEntry.delete(0, END)
    accXEntry.insert(0, allIMUValue[1][0])
    accYEntry.delete(0, END)
    accYEntry.insert(0, allIMUValue[1][1])
    accZEntry.delete(0, END)
    accZEntry.insert(0, allIMUValue[1][2])
    # = Magneto =
    magXEntry.delete(0, END)
    magXEntry.insert(0, allIMUValue[2][0])
    magYEntry.delete(0, END)
    magYEntry.insert(0, allIMUValue[2][1])
    magZEntry.delete(0, END)
    magZEntry.insert(0, allIMUValue[2][2])
    # = Angle =
    angleEntry.delete(0, END)
    angleEntry.insert(0, angle)
    
# === Update PMW Label  ===
def updatePWMIndicator(leftPWM, rightPWM):
    global leftMotorCanvas, leftMotorPWM, rightMotorCanvas, rightMotorPWM
    if leftPWM >= 0 and rightPWM >= 0 :  # forward
        rightMotorCanvas.itemconfig(rightMotorPWM, extent = rightPWM, outline = '#007CC7')
        leftMotorCanvas.itemconfig(leftMotorPWM, extent = leftPWM, outline = '#007CC7')

    elif leftPWM <=0 and rightPWM <= 0:  # backward
        rightMotorCanvas.itemconfig(rightMotorPWM, extent = -rightPWM, outline = 'red')
        leftMotorCanvas.itemconfig(leftMotorPWM, extent = -leftPWM, outline = 'red')
                
    elif leftPWM >= 0 and rightPWM <= 0 : #left
        rightMotorCanvas.itemconfig(rightMotorPWM, extent = -rightPWM, outline = 'red')
        leftMotorCanvas.itemconfig(leftMotorPWM, extent = leftPWM, outline = '#007CC7')
                
    elif leftPWM <= 0 and rightPWM >= 0: #right
        rightMotorCanvas.itemconfig(rightMotorPWM, extent = rightPWM, outline = '#007CC7')
        leftMotorCanvas.itemconfig(leftMotorPWM, extent = -leftPWM, outline = 'red')
        
    return
    
    
    

# ==== ==== ==== ==== ==== ==== ==== 
# ==== ==== ==== DRAW  ==== ==== ====
# ==== ==== ==== ==== ==== ==== ====
# === SaveToFile ===
def saveToFile(time, angle, theta, distance):
    with open("./distances.csv", "a") as log:
        log.write("{0},{1},{2}\n".format(time,  theta ,distance))
    
    
# === Draw Angle Label ===
def drawAngleLabel(root):
    global angleEntry
    Label( root, bg='#12232E', fg='#EEFBFB', text="Angle:", font="Times 13 bold").place(x=580, y=25)
    angleEntry = Entry( root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
    angleEntry.insert(0, "NaN")
    angleEntry.place(x=580, y=50)
     

# === Gyroscope, Accelometer, Magnetometer Value ===
def drawGyroLabel(root):
    # === Gyro ===
    #X
    global gyroXEntry,gyroYEntry,gyroZEntry, accXEntry, accYEntry, accZEntry, magXEntry, magYEntry, magZEntry
    Label( root, bg='#12232E', fg='#EEFBFB', text="Gyro X:", font="Times 13 bold").place(x=580, y=325)
    gyroXEntry = Entry( root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
    gyroXEntry.insert(0, "NaN")
    gyroXEntry.place(x=580, y=350)
    #Y
    Label(  root, bg='#12232E', fg='#EEFBFB', text="Gyro Y:", font="Times 13 bold").place(x=700, y=325)
    gyroYEntry = Entry(  root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
    gyroYEntry.insert(0, "NaN")
    gyroYEntry.place(x=700, y=350)
    #Z
    Label(  root, bg='#12232E', fg='#EEFBFB', text="Gyro Z:", font="Times 13 bold").place(x=820, y=325)
    gyroZEntry = Entry(  root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
    gyroZEntry.insert(0, "NaN")
    gyroZEntry.place(x=820, y=350)

    # === Accelo ===
    #X
    Label(  root, bg='#12232E', fg='#EEFBFB', text="Acce X:", font="Times 13 bold").place(x=580, y=385)
    accXEntry = Entry(  root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
    accXEntry.insert(0, "Nan")
    accXEntry.place(x=580, y=410)
    #Y
    Label(  root, bg='#12232E', fg='#EEFBFB', text="Acce Y:", font="Times 13 bold").place(x=700, y=385)
    accYEntry = Entry(  root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
    accYEntry.insert(0, "Nan")
    accYEntry.place(x=700, y=410)
    #Z
    Label(  root, bg='#12232E', fg='#EEFBFB', text="Acce Z:", font="Times 13 bold").place(x=820, y=385)
    accZEntry = Entry(  root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
    accZEntry.insert(0, "Nan")
    accZEntry.place(x=820, y=410)

    # === Magneto ===
    #X
    Label(  root, bg='#12232E', fg='#EEFBFB', text="Mag X:", font="Times 13 bold").place(x=580, y=445)
    magXEntry = Entry(  root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
    magXEntry.insert(0, "Nan")
    magXEntry.place(x=580, y=470)
    #Y
    Label(  root, bg='#12232E', fg='#EEFBFB', text="Mag Y:", font="Times 13 bold").place(x=700, y=445)
    magYEntry = Entry(  root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
    magYEntry.insert(0, "Nan")
    magYEntry.place(x=700, y=470)
    #Z
    Label(  root, bg='#12232E', fg='#EEFBFB', text="Mag Z:", font="Times 13 bold").place(x=820, y=445)
    magZEntry = Entry(  root,width=8, bg="#203647", fg="#EEFBFB", borderwidth=5, font="Times 10 bold")
    magZEntry.insert(0, "Nan")
    magZEntry.place(x=820, y=470)
    
# === Motor PWM Indicator ===
def drawPWMIndicator(root):
    global leftMotorCanvas, leftMotorPWM, rightMotorCanvas, rightMotorPWM
    leftMotorCanvas = Canvas(root, bg="#12232E", height=150, width=150, highlightthickness=0, relief='ridge')
    leftPercent = leftMotorCanvas.create_text(75, 75, fill="#a2b9bc", font="Times 12 italic bold", justify=CENTER,text="Left PWM\n0 %")
    leftMotorCanvas.create_oval(10, 10, 140, 140, outline='#EEFBFB', width=10)
    leftMotorPWM = leftMotorCanvas.create_arc(10, 10, 140, 140, outline='#007CC7', start=90, extent=1, width=20,style='arc')
    leftMotorCanvas.place(x=580, y=150)
    
    

    rightMotorCanvas = Canvas(root, bg="#12232E", height=150, width=150, highlightthickness=0, relief='ridge')
    rightPercent = rightMotorCanvas.create_text(75, 75, fill="#a2b9bc", font="Times 12 italic bold", justify=CENTER,text="Right PWM\n0 %")
    rightMotorCanvas.create_oval(10, 10, 140, 140, outline='#EEFBFB', width=10)
    rightMotorPWM = rightMotorCanvas.create_arc(10, 10, 140, 140, outline='#007CC7', start=90, extent=1, width=20, style='arc')
    rightMotorCanvas.place(x=750, y=150)
    
