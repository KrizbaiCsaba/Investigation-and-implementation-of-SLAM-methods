# === About this  ===
#
# Title: Hokuyo URG Communication
# Name: Krizbai Csaba
# Date: 2020. 10. 26
# Sapientia Emte
#
# === === === ===


import serial
import re
import math
import time


class URG04LX(serial.Serial):
    # === INI ===
    def __init__(self):
        super(serial.Serial, self).__init__()
        # Lidar Parameters
        self.STARTING = '0043'
        self.ENDING = '0725'
        self.CLUSTER = '00'
        self.SCANINT = '0'
        self.NBOFSCAN = '01'
        #
        self.distance = []
        self.angle = []
        
        self.scan_size = 682
        self.scan_rate_hz = 10
        self.detection_angle_degrees = 240
        self.distance_no_detection_mm = 4000
        self.detection_margin = 0
        self.offset_mm = 0
        
    def __str__(self):
        return  'scan_size=%d | scan_rate=%3.3f hz | detection_angle=%3.3f deg | distance_no_detection=%7.4f mm | detection_margin=%d | offset=%4.4f m' % \
            (self.scan_size,  self.scan_rate_hz,  self.detection_angle_degrees, self.distance_no_detection_mm,  self.detection_margin, self.offset_mm)

    # === Initial Sensor value ===
    # parameters: STARTING, ENDING, CLUSTER, SCAN INTERVAl, NUMBER OF SCAN
    def initialParameters(self, starting="0044", ending="0725", cluster='85', scanint="0", nbofscan="01"):
        # Lidar Parameters
        self.STARTING = starting
        self.ENDING = ending
        self.CLUSTER = cluster
        self.SCANINT = scanint
        self.NBOFSCAN = nbofscan

    # === Connect ( PORT,  BAUDRATE, TIMOUT ) ===
    def connect(self, port='/dev/ttyACM0',baudrate=115200, timeout=0.1, ):
        self.port = port
        self.baudrate = baudrate
        self.timeout = timeout
        try:
            self.open()
        except:
            return False

        if not self.isOpen():
            return False

        self.set_scip2()
        return True

    # === Set SCIP 2.0 Communication Protocol ===
    # return received answer
    def set_scip2(self):
        '''Set SCIP2.0 protcol'''
        self.flush_input_buf()
        self.send_command('SCIP2.0\n')
        return self.__receive_data()

    # === Sensor Laser ON  ===
    def laser_off(self):
        if not self.isOpen():
            return False
        self.flush_input_buf()
        self.send_command('QT\n')
        get = self.__receive_data()

        if not (get == ['QT\n', '00P\n', '\n']):
            return False
        return True

    # === Sensor Laser ON ===
    def laser_on(self):
        if not self.isOpen():
            return False

        self.send_command('BM\n')

        get = self.__receive_data()

        if not (get == ['BM\n', '00P\n', '\n']) and not (get == ['BM\n', '02R\n', '\n']):
            return False
        return True

    # === Get version information ===
    def get_version(self):
        if not self.isOpen():
            return False

        self.flush_input_buf()
        self.send_command('VV\n')
        get = self.__receive_data()
        return get


    # === Clear input buffer ===
    def flush_input_buf(self):
        self.flushInput()

    # === Data Received ===
    def __receive_data(self):
        return self.readlines()

    # === Send command ===
    def send_command(self, cmd):
        self.write(cmd.encode())

    # === Decode Time Stamp (MD command) ===
    def decodeTimeStamp(self, val):
        bin_str = '0b'
        for char in val:
            val = char - 0x30
            bin_str += '%06d' % int(bin(val)[2:])
        return int(bin_str, 2)

    # === Decode Distance  (MD command) ===
    def decodeMD(self, data, size, offset):  # STRING data, INT size, INT offset
        value = 0;
        for it in range(size):
            value <<= 6
            value |= ord(data[offset + it]) - 0x30
        return value


    def decodeArray(self, data, size):  # STRING data, INT size
        for pos in range(0, len(data) - size, size):
            self.distance.append(self.decodeMD(data, size, pos))


    # === GET DATA  <-- MD COMMAND ===
    # return: timestamp, angle, distance
    def getDataMD(self):
        if self.laser_on():
            print("laser_on error!")
            return -1, [], []

        self.flush_input_buf()
        cmd = "MD" + self.STARTING + self.ENDING + self.CLUSTER + self.SCANINT + self.NBOFSCAN + "\n"
        self.send_command(cmd)
        time.sleep(0.1)
        get = self.__receive_data()
        # checking the answer
        if (get[:5] == [cmd, '00P\n']):
            print("EXIT")
            return -1, [], []

        global goodMeasurmentIndex
        goodMeasurmentIndex = 0

        # decode the timestamp and distance
        for index in get:
            goodMeasurmentIndex += 1
            if index.startswith(b'99'):  # good measurments
                #time
                tm_str = get[goodMeasurmentIndex][:-1]
                timestamp = self.decodeTimeStamp(tm_str)
                #distance
                self.distance = []
                decodeThis = ''
                dis_str = ''
                while True:
                    goodMeasurmentIndex+=1
                    dis_str = get[goodMeasurmentIndex].decode()
                    if(dis_str == '\n'):
                        break
                    decodeThis += dis_str[:-2]
                self.decodeArray(decodeThis, 3)
                #angle
                self.getAngle()
                #return all value
                return timestamp, self.angle, self.distance

    #Get Angle
    def getAngle(self):
        self.angle = []
        startAngle = -30
        stepSize = 240 / (len(self.distance))
        for dis in self.distance:
            self.angle.append(startAngle)
            startAngle += stepSize

# Just for debug
# def main():
#     print('Connecting...')
#     urg = URG04LX()
#     urg.connect()
#
#     urg.laser_off()
#     data, tm = urg.getDataMD()
#     print (data[0:len(data)],'\n',tm)
#
#
# if __name__ == '__main__':
#     main()
