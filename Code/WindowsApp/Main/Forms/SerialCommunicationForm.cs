using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace Main.Forms
{
    public partial class SerialCommunicationForm : Form
    {

        #region Variables

        Thread connectThread; //Thread
        string dataIn;
        public static List<long> distances = new List<long>(); //distance measurment
        long time_stamp = 0;  //time measurment
        string pathFiles = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        StreamWriter objStreamWriter; //Write to TXT
        delegate void SetTextCallback(string replaceText);
        delegate void SetTextCallback2(bool state); //Callback for enable, disable elements

        #endregion


        public SerialCommunicationForm()
        {
            InitializeComponent();
            //Initialize Def. Values
            dataOutValue.Text = "0";
            dataInValue.Text = "0";
            startingBox.Text = "0044";
            endBox.Text = "0725";
            clousterBox.Text = "09";
            SerialConnection.SerialPort.DataReceived += new SerialDataReceivedEventHandler(SerialConnection.DataReceivedHandler);
            SerialConnection.SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }


        // === new Thread === 
        public void connectionThread()
        {

            if (SerialConnection.AutoConnect() == 1)
            {
                Console.WriteLine("Conneted!");
                SerialConnection.SendData("VV\n");
                UiElementsState(true);
            }
            else
            {
                if (SerialConnection.CloseSerialPort() == 1) //if 1 -> port is open and this function will be close
                {
                    ReplaceBoxes("");
                    return;
                    UiElementsState(false);
                }
                Console.WriteLine("Connection Error!");
            }
        }

        // === Enable or Disable UI Elements === 
        private void UiElementsState(bool state)
        {
            if (commandListGroup.InvokeRequired)
            {
                SetTextCallback2 d = new SetTextCallback2(UiElementsState);
                this.Invoke(d, new object[] { state });
            }
            else
            {
                this.commandListGroup.Enabled = state;
                this.ConnectToURGGroupbox.Enabled = state;
                this.countGroup.Enabled = state;
                this.MDGroup.Enabled = state;
                this.SendDataGroupbox.Enabled = state;
                this.UrgGroupBox.Enabled = state;
                this.textRBox.Enabled = state;
                this.textTBox.Enabled = state;
            }
            
        }
        
        // === Setup Boxes With Sensor Parameters ===
        private void ReplaceBoxes(string replaceText)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (vendBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ReplaceBoxes);
                this.Invoke(d, new object[] { replaceText });
            }
            else
            {
                this.vendBox.Text = replaceText;
                this.serialBox.Text = replaceText;
                this.productBox.Text = replaceText;
            }
        }

        // === Input number ===
        private void textTBox_TextChanged(object sender, EventArgs e)
        {
            dataOutValue.Text = string.Format("{0:00}", textTBox.TextLength);
        }

        // === Send Data with Enter ===
        private void textTBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (sendEnterCheck.Checked == true)
            {
                if (e.KeyData == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    SerialConnection.SendData(textTBox.Text + '\n');
                    textTBox.Text = "";
                }
            }
        }


        //=== Button's Clicked - Connection, send data ====
        #region Buttons
        private void connectToURGButton_Click(object sender, EventArgs e)
        {
            connectThread = new Thread(connectionThread);
            if (!connectThread.IsAlive)
            {

                connectThread.IsBackground = true;
                connectThread.Start();
            }
        }
        private void sendDataButton_Click(object sender, EventArgs e)
        {
            SerialConnection.SendData(textTBox.Text + '\n');
            textTBox.Text = "";
        }
        #endregion

        // === Data income ===
        #region Data income
        private void DataReceived(object sender, EventArgs e)
        {
            //Console.WriteLine("SerialCommunication received data: " + dataIn);   //Just for debug
            dataIn = SerialConnection.receivedData;
            this.Invoke(new EventHandler(ShowDataReaded));
        }


        private void ShowDataReaded(object sender, EventArgs e)
        {
            dataInValue.Text = string.Format("{0:00}", dataIn.Length); //input data length
            if (deleteinputCheck.Checked == true) textRBox.Text = ""; //delete text length value
            string[] split_command = dataIn.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries); //split input data
            if (split_command.Length == 0) return;
            SaveDataToTxtFile(dataIn);
            if (split_command[0].StartsWith("MD"))
            {
                if (decodeCheck.Checked == true) //decode request
                {

                    Console.WriteLine("decode THIS");

                    DecodeClass.decodeMD(dataIn, ref time_stamp, ref distances);
                    textRBox.Text += "Time Stamp: " + time_stamp + Environment.NewLine;
                    foreach (int elem in distances)
                    {
                        textRBox.Text += "distance: " + elem + Environment.NewLine;
                    }
                    return;
                }
                else //decode not request!
                {
                    foreach (var elem in split_command)
                    {
                        textRBox.Text += elem.ToString();
                        textRBox.Text += Environment.NewLine;
                    }
                }
            }
            else if (split_command[0].StartsWith("VV"))
            {
                if (vendBox.Text == "") // if device not asigned
                {
                    vendBox.Text = split_command[3].Remove(0, 5).Remove(split_command[3].Length - 7, 2); //delete first and last carater
                    productBox.Text = split_command[5].Remove(0, 5).Remove(split_command[5].Length - 7, 2);
                    serialBox.Text = split_command[6].Remove(0, 5).Remove(split_command[6].Length - 7, 2);
                    dataInValue.Text = "0";
                }
                else foreach (var elem in split_command)
                    {
                        textRBox.Text += elem;
                        textRBox.Text += Environment.NewLine;
                    }

            }
            else//default input data
            {
                foreach (var elem in split_command)
                {
                    textRBox.Text += elem;
                    textRBox.Text += Environment.NewLine;
                }
            }
        }
        //========================================================================================
        #endregion

        // === Buttons: VV, II, RS, BM, MD, HS
        #region Command Button List

        private void VVButton_Click(object sender, EventArgs e)
        {
            SerialConnection.SendData("VV\n");
        }

        private void IIButton_Click(object sender, EventArgs e)
        {
            SerialConnection.SendData("II\n");
        }

        private void RSButton_Click(object sender, EventArgs e)
        {
            SerialConnection.SendData("RS\n");
        }

        private void BMButton_Click(object sender, EventArgs e)
        {
            SerialConnection.SendData("BM\n");
        }

        private void MDButton_Click(object sender, EventArgs e)
        {
            if (startingBox.TextLength == 4 && endBox.TextLength == 4 && clousterBox.TextLength == 2)
            {
                string sendIt = "MD" + this.startingBox.Text + this.endBox.Text + '\n';
                SerialConnection.SendData(sendIt);
                sendIt = "MD" + this.startingBox.Text + this.endBox.Text + this.clousterBox.Text + "001\n";
                SerialConnection.SendData(sendIt);
            }
            else Console.WriteLine("MD button error!");
        }

        private void HSButton_Click(object sender, EventArgs e)
        {
            if (this.savedataCheck.Checked == true)
                SerialConnection.SendData("HS1\n"); //high sensitivity mode
            else
                SerialConnection.SendData("HS0\n"); //normal mode
        }

        #endregion

        // === Save Data ===
        #region saveData   
        private void SaveDataToTxtFile(string saveThis)
        {
            if (savedataCheck.Checked == true)
            {
                try
                {
                    pathFiles += @"\_MySource\SerialData.txt";

                    objStreamWriter = new StreamWriter(pathFiles, true); // parameters: (PathFiles, AppendText) 
                    objStreamWriter.WriteLine(saveThis);    // WriteLine or Write
                    objStreamWriter.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message); //debug
                }
            }
        }

        #endregion

        // === Ui Leaved ===
        #region Ui Leaved 
        private void SerialCommunicationForm_Leave(object sender, EventArgs e)
        {
            connectThread.Abort(); //Kill Thread
            UiElementsState(false);
        }
        #endregion
    }
}
