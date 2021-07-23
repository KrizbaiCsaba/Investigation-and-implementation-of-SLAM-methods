# === About this  ===
#
# Title: Gyroscope - BMP9250
# Name: Krizbai Csaba
# Date: 2020. 02. 08
# Sapientia Emte 
# 
# === === === ===

# === IMPORT'S ===
#ui
from tkinter import *
#plot
#import matplotlib as mpl
#from mpl_toolkits.mplot3d import Axes3D
import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
import datetime
#gyroscope
import Class.FaBo9Axis_MPU9250
import time
import sys
#saveToFile
from time import strftime
import csv
#normalization
import Class.normalize as Normalize

# === Global Variables ===
mpu9250 = Class.FaBo9Axis_MPU9250.MPU9250()
ax = [] #accelo
ay = []
az = []
gx = [] #gyro
gy = []
gz = []
mx = [] #mag
my = []
mz = []

# === Open CSV file ===
with open("./log.csv", "a") as log:
    log.write("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}\n".format(
        "Time", "AccelX", "AccelY", "AccelZ", "GyroX", "GyroY", "GyroZ", "MagX", "MagY", "MagZ"
        ))

# === Form ===
root = Tk()
root.title('9 - Axis')
root.geometry('510x280')
buttonFont = font.Font(size = 5)
saveToFile = IntVar() #save to csv

# !=== Creating a Label Widget ===!
# === ACCELOMETER ===
accLabel = Label(root, text = "Accelometer").place(x = 20, y = 40)
#X
accXLabel = Label(root, text = "X = ").place(x = 20, y = 70)
accXEnt = Entry(root, width = 5, borderwidth = 5)
accXEnt.insert(0,-999)
accXEnt.place(x=60 , y = 65)
#Y
accYLabel = Label(root, text = "Y = ").place(x = 20, y = 120)
accYEnt = Entry(root, width = 5, borderwidth = 5)
accYEnt.insert(0,-999)
accYEnt.place(x=60 , y = 115)
#Z
accZLabel = Label(root, text = "Z = ").place(x = 20, y = 170)
accZEnt = Entry(root, width = 5, borderwidth = 5)
accZEnt.insert(0,-999)
accZEnt.place(x=60 , y = 165)

# === GYROSCOPE ===
gyroLabel = Label(root, text = "Gyroscope").place(x = 200, y = 40)
#X
gyroXLabel = Label(root, text = "X = ").place(x = 200, y = 70)
gyroXEnt = Entry(root, width = 5, borderwidth = 5)
gyroXEnt.insert(0,-999)
gyroXEnt.place(x=240 , y = 65)
#Y
gyroYLabel = Label(root, text = "Y = ").place(x = 200, y = 120)
gyroYEnt = Entry(root, width = 5, borderwidth = 5)
gyroYEnt.insert(0,-999)
gyroYEnt.place(x=240 , y = 115)
#Z
gyroZLabel = Label(root, text = "Z = ").place(x = 200, y = 170)
gyroZEnt = Entry(root, width = 5, borderwidth = 5)
gyroZEnt.insert(0,0-999)
gyroZEnt.place(x=240 , y = 165)

# === MAGNETOMETER ===
magLabel = Label(root, text = "Magnetometer").place(x = 380, y = 40)
#X
magXLabel = Label(root, text = "X = ").place(x = 380, y = 70)
magXEnt = Entry(root, width = 5, borderwidth = 5)
magXEnt.insert(0,-999)
magXEnt.place(x=420 , y = 65)
#Y
magYLabel = Label(root, text = "Y = ").place(x = 380, y = 120)
magYEnt = Entry(root, width = 5, borderwidth = 5)
magYEnt.insert(0,-999)
magYEnt.place(x=420 , y = 115)
#Z
magZLabel = Label(root, text = "Z = ").place(x = 380, y = 170)
magZEnt = Entry(root, width = 5, borderwidth = 5)
magZEnt.insert(0,-999)
magZEnt.place(x=420 , y = 165)

# === Draw Button ===
drawButton = Button(root, text = "Draw Chart!", height = 1, width = 7, fg = 'black', bg = '#c2c2d6',  command = lambda: draw()).place(x = 380, y = 230)

# === Save to file Function ===
# CSV file: time | accX | accY | accZ | gyroX | gyroY | gyroZ | magX | magY | magZ
def save():
    if(saveToFile.get() == 1):  
        with open("./log.csv", "a") as log:
            log.write("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}\n".format(
                strftime("%M:%S"),
                ax[-1], ay[-1], az[-1],
                gx[-1], gy[-1], gz[-1],
                mx[-1], my[-1], mz[-1]
                ))
        
        
# === Checkbox ===
saveCheckBox = Checkbutton(root, text="Save To CSV", variable = saveToFile, onvalue = 1, offvalue = 0, command = save).place(x = 20, y = 230)

# === Delete CSV file ====

def deleteCSV():
    with open("./log.csv", "w+") as log:
        log.write("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}\n".format(
        "Time", "AccelX", "AccelY", "AccelZ", "GyroX", "GyroY", "GyroZ", "MagX", "MagY", "MagZ"
        ))
        print("File Deleted!")
        
deleteFile = Button( root, text = "Delete CSV.", height = 1, width = 7, fg = 'black', bg = "#c2c2d6", command = lambda: deleteCSV()).place( x= 180, y = 230)

# === Normalize Function ===
def Norm():
    norm = Normalize
    norm.Normalize()
normalizeButton = Button( root, text = "Normalize", height = 1, width = 7, fg = 'black', bg = "#c2c2d6", command = lambda: Norm()).place( x= 280, y = 230)
# === Draw Function ===
def draw():
    data = np.random.rand(2,6)
    fig, axs = plt.subplots(3,1, figsize = (40, 40))
    
    #accelo
    global ax,ay,az
    line, = axs[0].plot(ax, label = 'X')
    line, = axs[0].plot(ay, label = 'Y')
    line, = axs[0].plot(az, label = 'Z')
    axs[0].grid()
    axs[0].set_xlabel("t")
    axs[0].set_ylabel("g")
    axs[0].set_title("Accelometer")
    axs[0].legend()
     
    #gyro
    global gx,gy,gz
    line, = axs[1].plot(gx, label = 'X')
    line, = axs[1].plot(gy, label = 'Y')
    line, = axs[1].plot(gz, label = 'Z')
    axs[1].grid()
    axs[1].set_xlabel("t")
    axs[1].set_ylabel("g")
    axs[1].set_title("Gyroscope")
    axs[1].legend()
    
    #magneto
    global mx,my,mz
    line, = axs[2].plot(mx, label = 'X')
    line, = axs[2].plot(my, label = 'Y')
    line, = axs[2].plot(mz, label = 'Z')
    axs[2].grid()
    axs[2].set_xlabel("t")
    axs[2].set_ylabel("g")
    axs[2].set_title("Magnetometer")
    axs[2].legend()
    print(mx)
    plt.show()

# === Refresh Entry Label's ===    
def update():
    # ACCEL
    accel = mpu9250.readAccel() #read acccel
    accXEnt.delete(0,END)
    accXEnt.insert(0,accel['x'])
    accYEnt.delete(0,END)
    accYEnt.insert(0,accel['y'])
    accZEnt.delete(0,END)
    accZEnt.insert(0,accel['z'])
    
    # GYRO
    gyro = mpu9250.readGyro() #read gyro
    gyroXEnt.delete(0,END)
    gyroXEnt.insert(0,gyro['x'])
    gyroYEnt.delete(0,END)
    gyroYEnt.insert(0,gyro['y'])
    gyroZEnt.delete(0,END)
    gyroZEnt.insert(0,gyro['z'])

    # MAG
    mag = mpu9250.readMagnet() #read mag
    magXEnt.delete(0,END)
    magXEnt.insert(0,mag['x'])
    magYEnt.delete(0,END)
    magYEnt.insert(0,mag['y'])
    magZEnt.delete(0,END)
    magZEnt.insert(0,mag['z'])
    
    #SaveMeasurments
    global ax,ay,az
    ax.append(accel['x'])
    ay.append(accel['y'])
    az.append(accel['z'])
    
    global gx,gy,gz
    gx.append(gyro['x'])
    gy.append(gyro['y'])
    gz.append(gyro['z'])
    
    global mx,my,mz
    mx.append(mag['x'])
    my.append(mag['y'])
    mz.append(mag['z'])
    
    save()

    root.after(150,update)
    
    
# === WhenClosing Windows ===
def onClosing():
    if(messagebox.askokcancel("Quit", "Do you want to quit?")):
        root.destroy()
    
update()
root.protocol("WM_DELETE_WINDOW", onClosing)
# root.after(20, self.animate)
root.mainloop()

