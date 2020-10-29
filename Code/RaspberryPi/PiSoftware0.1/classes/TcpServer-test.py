import socket

# Create a TCP/IP socket
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# IP and port for accepting connections
server_address = ('', 22000)

# print server address and port
print ("[+] Server IP {} | Port {}".format(server_address[0],server_address[1]))

# bind socket with server
sock.bind(server_address)

# Listen for incoming connections
sock.listen(1)

# Create Loop
while True:
    # Wait for a connection
    print ('[+]  Waiting for a client connection')
    # connection established
    connection, client_address = sock.accept()
    try:
        print ('[+] Connection from', client_address)

        # Receive the data in small chunks and retransmit it
        while True:
            data = connection.recv(32)
            print ('received "%s"' % data)
            if data:
                print ('sending data back to the client')
                connection.sendall(data)
            else:
                print ('no more data from', client_address)
                break
            
    finally:
        # Close the connection
        connection.close()