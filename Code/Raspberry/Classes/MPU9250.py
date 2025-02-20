# coding: utf-8
## @package MPU9250
#  This is a FaBo9Axis_MPU9250 library for the FaBo 9AXIS I2C Brick.
#
#  http://fabo.io/202.html
#
#  Released under APACHE LICENSE, VERSION 2.0
#
#  http://www.apache.org/licenses/
#
#  FaBo <info@fabo.io>


# === Modificated!!! ===
# Date: 2021. 03. 01

import smbus
import time
import numpy as np
# === MPU9250 Default I2C slave address ===
SLAVE_ADDRESS        = 0x68
## AK8963 I2C slave address
AK8963_SLAVE_ADDRESS = 0x0C
## Device id
DEVICE_ID            = 0x71

# ===  MPU-9250 Register Addresses ===
## sample rate driver
SMPLRT_DIV = 0x19
CONFIG = 0x1A
GYRO_CONFIG = 0x1B
ACCEL_CONFIG = 0x1C
ACCEL_CONFIG_2 = 0x1D
LP_ACCEL_ODR = 0x1E
WOM_THR = 0x1F
FIFO_EN = 0x23
I2C_MST_CTRL = 0x24
I2C_MST_STATUS = 0x36
INT_PIN_CFG = 0x37
INT_ENABLE = 0x38
INT_STATUS = 0x3A
ACCEL_OUT = 0x3B
TEMP_OUT = 0x41
GYRO_OUT = 0x43

I2C_MST_DELAY_CTRL = 0x67
SIGNAL_PATH_RESET = 0x68
MOT_DETECT_CTRL = 0x69
USER_CTRL = 0x6A
PWR_MGMT_1 = 0x6B
PWR_MGMT_2 = 0x6C
FIFO_R_W = 0x74
WHO_AM_I = 0x75

## Gyro Full Scale Select 250dps
GFS_250 = 0x00
## Gyro Full Scale Select 500dps
GFS_500 = 0x01
## Gyro Full Scale Select 1000dps
GFS_1000 = 0x02
## Gyro Full Scale Select 2000dps
GFS_2000 = 0x03
## Accel Full Scale Select 2G
AFS_2G = 0x00
## Accel Full Scale Select 4G
AFS_4G = 0x01
## Accel Full Scale Select 8G
AFS_8G = 0x02
## Accel Full Scale Select 16G
AFS_16G = 0x03

# AK8963 Register Addresses
AK8963_ST1 = 0x02
AK8963_MAGNET_OUT = 0x03
AK8963_CNTL1 = 0x0A
AK8963_CNTL2 = 0x0B
AK8963_ASAX = 0x10

# CNTL1 Mode select
# Power down mode
AK8963_MODE_DOWN = 0x00
# One shot data output
AK8963_MODE_ONE = 0x01

# Continous data output 8Hz
AK8963_MODE_C8HZ = 0x02
# Continous data output 100Hz
AK8963_MODE_C100HZ = 0x06

# Magneto Scale Select
# 14bit output
AK8963_BIT_14 = 0x00
# 16bit output
AK8963_BIT_16 = 0x01

bus = smbus.SMBus(1)


class MPU9250:
    # === Constructor ===
    def __init__(self, address=SLAVE_ADDRESS):
        self.address = address
        self.configMPU9250(GFS_250, AFS_2G)
        self.configAK8963(AK8963_MODE_C100HZ, AK8963_BIT_16)

    # === Configure MPU9250 ===
    # parameters:    gfs = Gyro Full Scale (default value: GFS_250) 250dps
    #               afs = Accel Full Scale (default value: AFS_2G) 2g
    def configMPU9250(self, gfs, afs):
        if gfs == GFS_250:
            self.gres = 250.0 / 32768.0
        elif gfs == GFS_500:
            self.gres = 500.0 / 32768.0
        elif gfs == GFS_1000:
            self.gres = 1000.0 / 32768.0
        else:  # gfs == GFS_2000
            self.gres = 2000.0 / 32768.0

        if afs == AFS_2G:
            self.ares = 2.0 / 32768.0
        elif afs == AFS_4G:
            self.ares = 4.0 / 32768.0
        elif afs == AFS_8G:
            self.ares = 8.0 / 32768.0
        else:  # afs == AFS_16G:
            self.ares = 16.0 / 32768.0

        # sleep off
        bus.write_byte_data(self.address, PWR_MGMT_1, 0x00)
        time.sleep(0.1)
        # auto select clock source
        bus.write_byte_data(self.address, PWR_MGMT_1, 0x01)
        time.sleep(0.1)
        # DLPF_CFG
        bus.write_byte_data(self.address, CONFIG, 0x03)
        # sample rate divider
        bus.write_byte_data(self.address, SMPLRT_DIV, 0x04)
        # gyro full scale select
        bus.write_byte_data(self.address, GYRO_CONFIG, gfs << 3)
        # accel full scale select
        bus.write_byte_data(self.address, ACCEL_CONFIG, afs << 3)
        # A_DLPFCFG
        bus.write_byte_data(self.address, ACCEL_CONFIG_2, 0x03)
        # BYPASS_EN
        bus.write_byte_data(self.address, INT_PIN_CFG, 0x02)
        time.sleep(0.1)

    # === Configure AK8963 ===
    # parameters:   mode = Magneto Mode ,default value: AK8936_MODE_C8HZ (continous 8HZ)
    #               mfs = Magneto Scale ,default value: AK8963_BIT_16 (16bit)
    def configAK8963(self, mode, mfs):
        if mfs == AK8963_BIT_14:
            self.mres = 4912.0 / 8190.0
        else:  # mfs == AK8963_BIT_16:
            self.mres = 4912.0 / 32760.0

        bus.write_byte_data(AK8963_SLAVE_ADDRESS, AK8963_CNTL1, 0x00)
        time.sleep(0.01)

        # set read FuseROM mode
        bus.write_byte_data(AK8963_SLAVE_ADDRESS, AK8963_CNTL1, 0x0F)
        time.sleep(0.01)

        # read coef data
        data = bus.read_i2c_block_data(AK8963_SLAVE_ADDRESS, AK8963_ASAX, 3)

        self.magXcoef = (data[0] - 128) / 256.0 + 1.0
        self.magYcoef = (data[1] - 128) / 256.0 + 1.0
        self.magZcoef = (data[2] - 128) / 256.0 + 1.0

        # set power down mode
        bus.write_byte_data(AK8963_SLAVE_ADDRESS, AK8963_CNTL1, 0x00)
        time.sleep(0.01)

        # set scale&continous mode
        bus.write_byte_data(AK8963_SLAVE_ADDRESS, AK8963_CNTL1, (mfs << 4 | mode))
        time.sleep(0.01)

    # === Search Device ===
    # return: true if device is connected, else false
    def searchDevice(self):
        who_am_i = bus.read_byte_data(self.address, WHO_AM_I)
        if who_am_i == DEVICE_ID:
            return True
        else:
            return False

    # === Check Data is Ready
    # return:   true if data is ready, else false
    def checkDataReady(self):
        drdy = bus.read_byte_data(self.address, INT_STATUS)
        if drdy & 0x01:
            return True
        else:
            return False

    # === Read Accelometer Value ===
    # return: x, y, z accelometer dic. value
    def readAccel(self):
        data = bus.read_i2c_block_data(self.address, ACCEL_OUT, 6)
        x = self.dataConv(data[1], data[0])
        y = self.dataConv(data[3], data[2])
        z = self.dataConv(data[5], data[4])
        
        x = round(x * self.ares, 3)
        y = round(y * self.ares, 3)
        z = round(z * self.ares, 3)
        
        return x, y, z

    # === Read Gyroscope Value ===
    # retrun: x, y, z gyroscope value
    def readGyro(self):
        data = bus.read_i2c_block_data(self.address, GYRO_OUT, 6)

        x = self.dataConv(data[1], data[0])
        y = self.dataConv(data[3], data[2])
        z = self.dataConv(data[5], data[4])

        x = round(x * self.gres, 3)
        y = round(y * self.gres, 3)
        z = round(z * self.gres, 3)

        return x, y, z
    
    # === Read Magneto Value ===
    # retrun: x, y, z magneto value
    def readMag(self):
        # check data ready
        drdy = bus.read_byte_data(AK8963_SLAVE_ADDRESS, AK8963_ST1)
        #wait for data
        while drdy & 0x01 == 0:
            drdy = bus.read_byte_data(AK8963_SLAVE_ADDRESS, AK8963_ST1)
        data = bus.read_i2c_block_data(AK8963_SLAVE_ADDRESS, AK8963_MAGNET_OUT, 7)
        # check overflow
        if (data[6] & 0x08) != 0x08:
            x = self.dataConv(data[0], data[1])
            y = self.dataConv(data[2], data[3])
            z = self.dataConv(data[4], data[5])

            x = round(x * self.mres * self.magXcoef, 3)
            y = round(y * self.mres * self.magYcoef, 3)
            z = round(z * self.mres * self.magZcoef, 3)
        return x, y, z

    # === Read Magneto Value ===
    # parameters: number = number of measurments
    # retrun: np.array of magneto value (x, y, z) 
    def readMagneto(self, number):
        magX = np.empty(0)
        magY = np.empty(0)
        magZ = np.empty(0)
        for _ in range(number):
            # check data ready
            drdy = bus.read_byte_data(AK8963_SLAVE_ADDRESS, AK8963_ST1)

            #wait for data
            while drdy & 0x01 == 0:
                drdy = bus.read_byte_data(AK8963_SLAVE_ADDRESS, AK8963_ST1)

            data = bus.read_i2c_block_data(AK8963_SLAVE_ADDRESS, AK8963_MAGNET_OUT, 7)

            # check overflow
            if (data[6] & 0x08) != 0x08:
                x = self.dataConv(data[0], data[1])
                y = self.dataConv(data[2], data[3])
                z = self.dataConv(data[4], data[5])

                x = round(x * self.mres * self.magXcoef, 3)
                y = round(y * self.mres * self.magYcoef, 3)
                z = round(z * self.mres * self.magZcoef, 3)

            magX = np.append(magX, x)
            magY = np.append(magY, y)
            magZ = np.append(magZ, z)
        return magX, magY, magZ

    # === Data Conversion ===
    # parameters: LSB, MSB
    # return MSB + LSB in 16 bit
    def dataConv(self, data1, data2):
        value = data1 | (data2 << 8)
        if (value & (1 << 16 - 1)):
            value -= (1 << 16)
        return value
