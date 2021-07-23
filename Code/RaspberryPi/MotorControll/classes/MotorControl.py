# Name: Krizbai Csaba
# Date: 2020.11.26

import RPi.GPIO as IO

class MotorControl():
    def __init__(self):
        IO.setwarnings(False)  # do not show any warnings
        IO.setmode(IO.BCM)  # we are programing the GPIO by BCM pin numbers. (PIN32 as GPIO19)
        # = Robot parameters =
        self.wheelRadius = 0.65
        self.Kp = 1
        self.a = 1.8
        self.b = 2.1 #INDULAS
        self.half_axis = 0.5
        self.maxPWM = 100
        # = Left motor =
        IO.setup(18, IO.OUT)
        IO.setup(12, IO.OUT)
        self.motorA1 = IO.PWM(12, 490)  # IO.PWM(pin number, frequency)
        self.motorA2 = IO.PWM(18, 490)  # IO.PWM(pin number, frequency)
        # stop motor left
        self.motorA1.start(0)
        self.motorA2.start(0)
        # = Right motor =
        IO.setup(19, IO.OUT)
        IO.setup(13, IO.OUT)
        self.motorB1 = IO.PWM(19, 490)
        self.motorB2 = IO.PWM(13, 490)
        # stop motor right
        self.motorB1.start(0)
        self.motorB2.start(0)


    # === Set motor pwm ===
    # parameters: speed in percent (%)
    # return:   1 is speed parameter under 100, else return -1
    def setMotorPWM(self, leftPWM, rightPWM):
        if leftPWM <= 100 and leftPWM >= -100 and rightPWM <= 100 and rightPWM >= -100:
            print(leftPWM, rightPWM)
            if leftPWM > rightPWM:
                self.motorA1.ChangeDutyCycle(leftPWM)
                self.motorA2.ChangeDutyCycle(0)
                self.motorB1.ChangeDutyCycle(0)
                self.motorB2.ChangeDutyCycle(rightPWM)
            elif leftPWM < rightPWM:
                self.motorA1.ChangeDutyCycle(0)
                self.motorA2.ChangeDutyCycle(leftPWM)
                self.motorB1.ChangeDutyCycle(rightPWM)
                self.motorB2.ChangeDutyCycle(0)
            else:
                self.motorA1.ChangeDutyCycle(leftPWM)
                self.motorA2.ChangeDutyCycle(0)
                self.motorB1.ChangeDutyCycle(rightPWM)
                self.motorB2.ChangeDutyCycle(0)
            return 1
        else:  # speed is to much
            print("## ERROR ##\t Speed is to much")
            return -1
        
    def setMotorPWM2(self, leftPWM, rightPWM):
        if leftPWM <= 100 and leftPWM >= -100 and rightPWM <= 100 and rightPWM >= -100:
            print(leftPWM, rightPWM)
            if leftPWM >= 0 and rightPWM >= 0 :  # forward
                self.motorA1.ChangeDutyCycle(leftPWM)
                self.motorA2.ChangeDutyCycle(0)
                self.motorB1.ChangeDutyCycle(rightPWM)
                self.motorB2.ChangeDutyCycle(0)

            elif leftPWM <=0 and rightPWM <= 0:  # backward
                self.motorA1.ChangeDutyCycle(0)
                self.motorA2.ChangeDutyCycle(-leftPWM)
                self.motorB1.ChangeDutyCycle(0)
                self.motorB2.ChangeDutyCycle(-rightPWM)
                
            elif leftPWM >= 0 and rightPWM <= 0 : #left
                self.motorA1.ChangeDutyCycle(leftPWM)
                self.motorA2.ChangeDutyCycle(0)
                self.motorB1.ChangeDutyCycle(0)
                self.motorB2.ChangeDutyCycle(-rightPWM)
                
            elif leftPWM <= 0 and rightPWM >= 0: #right
                self.motorA1.ChangeDutyCycle(0)
                self.motorA2.ChangeDutyCycle(-leftPWM)
                self.motorB1.ChangeDutyCycle(rightPWM)
                self.motorB2.ChangeDutyCycle(0)
            return 1
        else:  # speed is to much
            print("## ERROR ##\t Speed is to much")
            return -1
        
    # === SaveToFile ===
    def saveToFile(self, refangle, angle, pwmL, pwmR):
        with open("./motorcontrol.csv", "a") as log:
            log.write("{0},{1},{2},{3}\n".format(refangle, angle,  pwmL ,pwmR))

    # === Robot Control ===
    # parameters: alfaRef (ref angle), alfa(measured angle), Vref(ref angular velocity)
    # return: 2 PWM signal  ->  leftMotorPWM, rightMotorPWM
    def robotControl(self, alfaRef, alfa, Vref):
        angularSpeedRobot = self.Kp * (alfaRef - alfa)
        linearSpeedRobot = Vref

        leftWheelAngularSpeed = (linearSpeedRobot + self.half_axis * angularSpeedRobot) / self.wheelRadius
        rightWheelAngularSpeed = (linearSpeedRobot - self.half_axis * angularSpeedRobot) / self.wheelRadius
        
        leftMotorPWM = self.a * leftWheelAngularSpeed + self.b
        rightMotorPWM = self.a * rightWheelAngularSpeed + self.b
        
        
        # === Output Control ===
        if leftMotorPWM > self.maxPWM:
            leftMotorPWM = self.maxPWM
        if rightMotorPWM > self.maxPWM:
            rightMotorPWM = self.maxPWM

        if leftMotorPWM < 0:
            leftMotorPWM = 0
        if rightMotorPWM < 0:
            rightMotorPWM = 0
        #self.saveToFile(alfaRef, alfa, leftMotorPWM, rightMotorPWM)
        print(leftMotorPWM, rightMotorPWM)
        # === Output ===
        return leftMotorPWM, rightMotorPWM