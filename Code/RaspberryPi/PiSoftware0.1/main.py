# === About this  ===
#
# Title: SerialCommunication + Tcp Server
# Name: Krizbai Csaba
# Date: 2020. 10. 29
# Sapientia Emte 
# 
# === === === ===

from classes.hokuyo import URG04LX
from classes.tcpServer import tcpServer

def main():
    server = tcpServer()
    starting, ending, cluster, scanint, nbofscan = server.waitForConnection()

    print('Connecting...')
    urg = URG04LX()
    urg.connect(starting, ending, cluster, scanint, nbofscan)

    #urg.laser_off()
    
    while True:
        data, tm = urg.getDataMD()
        server.sendDataToClient(data)


if __name__ == '__main__':
    main()
