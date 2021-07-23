#Name: Krizbai Csaba
#Date: 2021. 03. 19

import csv
import math
import time
import numpy as np
from scipy import linalg, signal
from .MPU9250 import MPU9250

DATA_LEN = 20

class IMU_Filter:
    # === Constructor ===
    def __init__(self, saveToFile = False):
        #self.Ainv = np.array([[ 0.02315159, -0.00037156, -0.00028835], [-0.00037156, 0.02300267, 0.00032913],[-0.00028835,0.00032913,0.02318093]])
        #self.b = np.array([[ -1.93528156],[0.05061331],[-41.91863033]])
#         self.Ainv = np.array([[ 0.02227656,  0.0002804,  -0.00178075],
#                  [ 0.0002804,   0.02369134,  0.00084842],
#                  [-0.00178075,  0.00084842,  0.02163967]])
#         self.b = np.array([[ 30.9941883], [43.7645648], [-145.93402032]])
        self.Ainv = np.array([[ 0.02219179,  0.0005445,  -0.00167825],
                 [ 0.0005445,   0.02340141,  0.00095846],
                 [-0.00167825,  0.00095846,  0.02117964]])
        self.b = np.array([[ 32.79564077], [42.33308641], [-145.63777241]])
        self.data = [0 for i in range(DATA_LEN)]
        self.mpu9250 = MPU9250()

    # === Filter Calculation ===
    # return: theta
    def runFilter(self):
        #Read Magneto Value
        self.magX, self.magY, self.magZ = self.mpu9250.readMagneto(1)
        #Calculate Theta
        calibratedX, calibratedY = self.calculateTheta(self.magX, self.magY, self.magZ, self.Ainv, self.b)
        theta = math.atan2(calibratedX, calibratedY)
        theta = self.rad2deg(theta)
        self.data.pop(0)
        self.data.append(theta)
        
        sos = signal.ellip(2, 1, 100, 0.2, 'lowpass', output='sos')
        filteredTheta = signal.sosfilt(sos, self.data)
        return filteredTheta[len(filteredTheta)-1]
    
    # === Calibration ===
    # parameters: magneto value, A inverse, b
    # return: calibratedX, calibratedY
    def calculateTheta(self, magX, magY, magZ, Ainv, b):
        calibratedX = np.zeros(magX.shape)  # zeros(x) -> return array with dim x
        calibratedY = np.zeros(magY.shape)  # x.shape -> Return the shape of an array x

        h = np.array([[magX[0], magY[0], magZ[0]]]).T
        hHat = np.matmul(Ainv, h - b)
        calibratedX = hHat[0]
        calibratedY = hHat[1]

        return calibratedX, calibratedY

    # === Degree To Radian ===
    #parameters: degre
    #return: radian
    def deg2rad(self,deg):
        return deg / 180 * np.pi
    
    # === Radian To Degre ===
    #parameters: radian  
    #return: degre
    def rad2deg(self,rad):
        return rad * 180 / np.pi
    
    
    # === Return All Sensor Value ===
    #return: 3 array (gyro, accelo, magneto) 
    def readSensorValues(self):
        returnarray = []
        returnarray.append (self.mpu9250.readGyro())
        returnarray.append (self.mpu9250.readAccel())
        returnarray.append (self.mpu9250.readMag())
        return returnarray
    



