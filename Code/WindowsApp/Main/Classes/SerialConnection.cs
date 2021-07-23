using System;
using System.IO;
using System.IO.Ports;

namespace Main
{
    class SerialConnection
    {

        // === Variables ===
        #region Variables 
        private static string defBaud = "115200";
        private static string defstopBits = "One";
        private static string defdataBits = "6";
        private static string defParity = "None";

        private static SerialPort _serialPort = new SerialPort();

        private static string dataIN = null;

        #endregion


        // === Get and Set ===
        #region Get and Set

        public static SerialPort SerialPort
        {
            get { return _serialPort; }
            set { _serialPort = value; }
        }

        public static string receivedData
        {
            get { return dataIN; }
            set { dataIN = value; }
        }

        #endregion

        
        // === Auto Connect ===
        #region Auto Connect 
        public static int AutoConnect()
        {
            string[] ports = SerialPort.GetPortNames(); //Read COM ports
            if (ports.Length > 0)
                if (SerialPortParameters(ports[0], defBaud, defdataBits, defstopBits, defParity) == 1)
                    if (OpenSerialPort() == 1)
                        return 1;

            return -1;
            //setup def connection value
        }

        // === Open Serial Port ===
        public static int OpenSerialPort()
        {
            try
            {
                if(SerialPort.IsOpen)
                    return -1;
                SerialPort.Open();
                return 1;
            }
            catch (IOException)
            {
                return -1;
            }

        }

        #endregion


        // === Set Serial Port Parameters === 
        #region Set Serial Port Parameters
        public static int SerialPortParameters(string portName, string baudRate, string dataBits, string stopBits, string parity)
        {
            /*
             *  StopBits: None = 0, One = 1, Two = 2, OnPointFive = 3 
             *  ParityBits: None = 0, Odd = 1, Even = 2, Mark = 3, Space = 4
             */
            if (SerialPort.IsOpen) return 0; //dont run this if serial port is open!d
            try
            {
                SerialPort.PortName = portName;
                SerialPort.BaudRate = Convert.ToInt32(baudRate);
                SerialPort.DataBits = Convert.ToInt32(dataBits);
                SerialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
                SerialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
                SerialPort.DtrEnable = true; //Data Terminal Ready
                return 1;
            }
            catch (ArgumentException) //cath multiple errors 
            {
                return -1;
            }

        }
        #endregion


        /// === Close Serial Port ===
        #region Close Serial Port
        public static int CloseSerialPort()
        {
            try
            {
                if (SerialPort.IsOpen)
                {
                    SerialPort.Close();
                    return 1;
                }
                return -1;
            }
            catch (IOException)
            {
                return -1;
            }

        }
        #endregion



        // === Send Data === 
        #region Send Data
        public static int SendData(string data)
        {
            if (SerialPort.IsOpen)
            {
                SerialPort.Write(data + '\n');
                return 1;
            }
            return -1;

        }
        #endregion



        // === Data Received Handler ====
        #region Data Received Handler 
        public static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            receivedData = SerialPort.ReadExisting();
        }
        #endregion


    }
}
