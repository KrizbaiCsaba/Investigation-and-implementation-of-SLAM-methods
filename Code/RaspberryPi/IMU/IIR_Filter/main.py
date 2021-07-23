from pylive import live_plotter
from MPU9250 import MPU9250
from calibration import Calibration

from scipy import signal, random
import numpy as np
import math

size = 100
x_vec = np.linspace(0,1,size+1)[0:-1]
y_vec1 = np.random.randn(len(x_vec))
y_vec2 = np.random.randn(len(x_vec))
y_vec3 = np.random.randn(len(x_vec))

line1 = []
line2 = []
line3 = []
Ainv = np.array([[ 0.02227656,  0.0002804,  -0.00178075],
                 [ 0.0002804,   0.02369134,  0.00084842],
                 [-0.00178075,  0.00084842,  0.02163967]])
bi = np.array([[ 30.9941883], [43.7645648], [-145.93402032]])

# Ainv = np.array([[ 0.02315159, -0.00037156, -0.00028835], [-0.00037156, 0.02300267, 0.00032913],[-0.00028835,0.00032913,0.02318093]])
#bi = np.array([[ -1.93528156],[0.05061331],[-41.91863033]])

sensor = MPU9250()
calib = Calibration()
DATA_LEN = 20
#data = np.array(0)
data = [0 for i in range(DATA_LEN)]


for i in range(DATA_LEN):
    magX,magY,magZ = sensor.readMagneto(1)
    calibratedX, calibratedY = calib.calculateTheta(magX, magY, magZ, Ainv, bi)
    theta = math.atan2(calibratedX, calibratedY)
    theta *= 180 / math.pi
    #data = np.append(data, theta)
    data.pop(0)
    data.append(theta)
    
alfa  = 0.9
theta_F = 0
while True:
    #Calculate Theta
    magX,magY,magZ = sensor.readMagneto(1)
    calibratedX, calibratedY = calib.calculateTheta(magX, magY, magZ, Ainv, bi)
    theta = math.atan2(calibratedX, calibratedY)
    theta *= 180 / math.pi
    theta2 = theta
    theta_F = alfa * theta_F + (1 - alfa ) * theta2
    #Theta Filter
    data.pop(0)
    data.append(theta)
    #data = np.append(data, theta)
    # === 1 ===
    sos = signal.ellip(2, 1, 100, 0.2, 'lowpass', output='sos')  #lowpass, bandpass, highpass
    filteredTheta = signal.sosfilt(sos, data)
    #print(filteredTheta)
    # === 2 ===
#     data = np.append(data, [theta,theta, theta,  theta, theta])
#     b, a = signal.butter(1, 0.1)
#     filteredTheta = signal.filtfilt(b, a, data)
    # === 3 === 
#     b, a = signal.ellip(2, 1, 100, 0.2, btype='lowpass',output='ba')
#     filteredTheta = signal.filtfilt(b, a, data)


#     print(len(b) ," vs " ,len(a))
#     h,w = signal.freqz(b, a)
#     print("h=" ,h ," \nw=",w)
    
#     filteredTheta= signal.lfilter(b, a, theta)

    
#     print("b =", b)
#     #x = signal.unit_impulse(15)
#     #x = np.cumsum(randn(800))  # Brownian noise
#     impulse = np.zeros(1000)
#     impulse[500] = 1
#     filteredTheta  = signal.lfilter(b, a, impulse)

#     b, a = signal.iirfilter(17, [2*np.pi*50, 2*np.pi*200], rs=60,btype='band', analog=True, ftype='cheby2')
#     w, h = signal.freqs(b, a, 1000)

    
    y_vec1[-1] = theta
    y_vec2[-1] = filteredTheta[19]
    y_vec3[-1] = theta_F

    line1, line2 , line3= live_plotter(x_vec,y_vec1,y_vec2, y_vec3, line1, line2, line3 ,identifier = "IRR Filter")
   
    # === SAVE TO FILE === 
    with open("./measurment.csv", "a") as log:
        log.write("{0},{1},{2}\n".format(
            theta, filteredTheta[19], theta_F))
            
    y_vec1 = np.append(y_vec1[1:],0.0)
    y_vec2 = np.append(y_vec2[1:],0.0)
    y_vec3 = np.append(y_vec3[1:],0.0)