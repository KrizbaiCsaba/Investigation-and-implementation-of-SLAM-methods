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

STARTING      = ""
ENDING           = ""
CLUSTER        = ""
SCANINT         = ""
NBOFSCAN    = ""

class URG04LX(serial.Serial):
    # === INI ===
    def __init__(self):
        super(serial.Serial, self).__init__()
        
        
    # === Connect ( PORT,  BAUDRATE, TIMOUT ) ===
    def connect(self, starting = "0044" , ending = "0725" , cluster = '99', scanint = "0" , nbofscan = "01", port = '/dev/ttyACM0', baudrate = 115200, timeout = 0.1,): 
        self.port = port
        self.baudrate = baudrate
        self.timeout  = timeout
        
        global STARTING
        global ENDING
        global CLUSTER
        global SCANINT
        global NBOFSCAN
        
        STARTING    = starting
        ENDING        = ending
        CLUSTER      = cluster
        CLUSTER      = cluster
        SCANINT       = scanint
        NBOFSCAN   = nbofscan
        
        try:
            self.open() 
        except:
            return False
        
        if not self.isOpen():
            return False

        self.set_scip2() 
        return True
    
    
    
    # === Set SCIP 2.0 Communication Protocol ===
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
        
        if not(get == ['QT\n', '00P\n', '\n']):
            return False
        return True
    
    
    
    # === Sensor Laser ON ===
    def laser_on(self):
        if not self.isOpen():
            return False
        
        self.send_command('BM\n')
        
        get = self.__receive_data()
        
        if not(get == ['BM\n', '00P\n', '\n']) and not(get == ['BM\n', '02R\n', '\n']):
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
    def  decodeTimeStamp(self, val):
        bin_str = '0b'
        for char in val:
            val = char - 0x30
            bin_str += '%06d' % int(bin(val)[2:])
        return int(bin_str,2)
    
    
    # === Decode Distance  (MD command) ===
    
    def decodeMD(self, data, size, offset ): # STRING data, INT size, INT offset
        value = 0;
        for it in range(size):    
            value  <<= 6
            value |=  ord(data[offset + it]) - 0x30   
        return value
    
    
    def distanceData (self, lines, startLine): #STRING ARRAY lines, #INT startLine
        newString = ''
        for it in range(startLine, len(lines)-1):
            newString += lines[it][ 0 : len(lines[it]) - 2].decode()
        return self.decodeArray(newString, 3 )
    

    def decodeArray(self, data, size ): # STRING data, INT size
        distance = ''
        for pos in range( 0, len(data) - size, size):
            distance += str(self.decodeMD(data, size, pos)) + ","
        return distance

    
    
    # === GET DATA  <-- MD COMMAND ===
    
    def getDataMD(self):
        if  self.laser_on():
            print("laser_on error!")
            return [], -1
        
        self.flush_input_buf()   
        cmd = "MD"+ STARTING + ENDING +CLUSTER + SCANINT + NBOFSCAN + "\n"
        self.send_command(cmd)
        
        time.sleep(0.1)
        
        get = self.__receive_data()
        
        # checking the answer
        if (get[:5] == [cmd, '00P\n']):
            print("EXIT")
            return [], -1
               
        global timestamp
        global goodMeasurmentIndex
        
        timestamp = -1
        goodMeasurmentIndex = 0
    
        
        # decode the timestamp
        for index in get:
            goodMeasurmentIndex += 1
            if index.startswith(b'99'): #good measurments
                tm_str = get[goodMeasurmentIndex][:-1]
                timestamp = self.decodeTimeStamp(tm_str)
                break
            
        global distance
        
        distance = self.distanceData(get, goodMeasurmentIndex + 1)          
        return distance, timestamp
    
        
def main():
    print('Connecting...')
    urg = URG04LX()
    urg.connect()

    urg.laser_off()
    data, tm = urg.getDataMD()
    print (data[0:len(data)],'\n',tm)


if __name__ == '__main__':
    main()
