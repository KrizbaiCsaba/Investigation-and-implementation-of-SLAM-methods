using Main.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tcp = Main.TcpClient.TcpClient;

namespace Main.Classes
{
    class ChatClient : Tcp
    {
        #region Variable 
        // === _distance list ===
        protected List<long> _distances = new List<long>();
        // === Savin data to CSV ===
        string pathFiles = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\_MySource\PlotData.csv";
        StringBuilder csv = new StringBuilder();
        // === Sensor Parameters ===
        ArrayList sensorParameters = new ArrayList();
        // === Form Popup ===
        InitialForm Popup = new InitialForm();
        #endregion

        public ChatClient(string address, int port) : base(address, port) { }

        public void DisconnectAndStop()
        {
            _stop = true;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }

        protected override void OnConnected()
        {
            Console.WriteLine($"Chat TCP client connected a new session with Id {Id}");
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine($"Chat TCP client disconnected a session with Id {Id}");

            // Wait for a while...
            Thread.Sleep(1000);

            // Try to connect again
            if (!_stop)
                ConnectAsync();
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string input = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            Console.WriteLine(input);
            if (input.StartsWith("SS_DIS") && input.EndsWith("EE")) // if is distance input
            {
                input = input.Remove(0, 6);
                input = input.Remove(input.Length - 3, 3);
                string[] split_command = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                this._distances.Clear();
                foreach (string iterator in split_command)
                    this._distances.Add(Convert.ToInt64(iterator)); //convert string to long
                SaveData(_distances, -1); //   @@@@@@@@@@@@@@@@____@ TIMESTAMP IS MISSING @___@@@@@@@@@@@@@
            }
        }

        #region SaveData

        /// === Get Sensor val ===
        private void getSensorValue()
        {
            sensorParameters.Clear();
            foreach (string it in Popup.ReturnValue)
                sensorParameters.Add(it);
        }


        private void SaveData(List<long> distances, long timestamp)
        {
            try
            {
                getSensorValue();
                csv.Append(timestamp); //TimeStamp ==========================Ide kulonbseg kell majd ======!!!!
                csv.Append("," + sensorParameters[3]); //Cluster
                csv.Append("," + sensorParameters[0] + "," + sensorParameters[1]); //StartingStep, EndStep
                //Distance
                foreach(int iterator in distances)
                    csv.Append("," + distances[iterator]);
                csv.AppendLine(); // New line
                File.WriteAllText(pathFiles, csv.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
        #endregion


        public void getChatClientDistances(ref List<long> distances)
        {
            distances = this._distances;
        }


        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP client caught an error with code {error}");
        }

        private bool _stop;
    }
}
