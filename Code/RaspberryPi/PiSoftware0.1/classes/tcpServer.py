# === About this  ===
#
# Title: Tcp Server
# Name: Krizbai Csaba
# Date: 2020. 10. 29
# Sapientia Emte 
# 
# === === === ===


import socket




STARTING      = ""
ENDING           = ""
CLUSTER        = ""
SCANINT         = ""
NBOFSCAN    = ""


class tcpServer():
    
    # === INI ===
    def __init__(self):
        global sock
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM) # Create a TCP/IP socket
        server_address = ('', 22000) # IP and port for accepting connections
        print ("[+] Server IP {} | Port {}".format(server_address[0],server_address[1])) # print server address and port
        sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1 )
        sock.bind(server_address) # bind socket with server
        sock.listen(1) # Listen for incoming connections
        
    
    
    # === Wait for Client ===
    def waitForConnection(self):
        global sock
        global connection
        connection, client_address = sock.accept()
        data = connection.recv(32)
        data = str(data)
        data = data[2:-1]
        print ('received "%s"' % data)
        if(data.startswith("SS_INI") == True):
            starting   = data[6:10]
            ending     = data [10: 14]
            cluster     = data[14:16]
            scanint    = data[16:17]
            nbofscan = data[17:19]
            return starting, ending, cluster, scanint, nbofscan
        return '', '', '', '',''
    
    
    # === SendDataToClient ===
    def sendDataToClient(self,data):
        sendIt = "SS_DIS" + data[:-1] + "EE"
        global connection
        connection.sendall(sendIt.encode())
        
        
        