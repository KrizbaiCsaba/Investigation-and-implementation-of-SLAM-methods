using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Tcp = Main.TcpClient.TcpClient;


namespace Main.Classes
{
    class TcpClientSetup : Tcp
    {
        #region Variable

        ChatClient client;
        bool ConnectionOK = false;
        private string _address;
        private int _port;
        #endregion

        public bool Connected { get { return ConnectionOK; } }

        public TcpClientSetup(string address, int port) : base(address, port)
        {
            this._address = address;
            this._port = port;
            client = new ChatClient(_address, _port);
        }

        public bool ConnectToServer()
        {
            
            Console.WriteLine("Client connecting..."); //debug
            if (client.ConnectAsync() == true)
                return false; //not connected!
            Console.WriteLine("Done!"); //debug
            ConnectionOK = true;
            return true;
        }

        public void SendIniData(ArrayList sendIt)
        {
            string data = "SS_INI" + sendIt[0] + sendIt[1] + sendIt[2] + sendIt[3] + sendIt[4] + "EE";
            client.SendAsync(data);
        }

        public void DisconnectFromServer()
        {
            ConnectionOK = false;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }

        public void getDistances(ref List<long> distances)
        {
            client.getChatClientDistances(ref distances);
        }

    }
}
