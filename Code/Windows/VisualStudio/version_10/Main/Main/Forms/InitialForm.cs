#region AboutThis
/*
 * Author: Krizbai Csaba
 * Date: 2020. 10. 25.
 * Title: Popup Form, Inital
 * 
 * Sapientia EMTE
*/
#endregion

#region using
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;
#endregion

namespace Main.Forms
{
    public partial class InitialForm : Form
    {

        #region  DllImport
        // === move UI === 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        #region Variables
        // === Def initial value ===
        private string startingValue = "0044";
        private string endValue = "0725";
        private string clousterValue = "09";
        private string scanIntervalValue = "0";
        private string nbOfScanValue = "01";

        #endregion

        #region ReturnValue get method 

        public ArrayList ReturnValue  {
            get
            {
                ArrayList value = new ArrayList();
                value.Add(startingValue);
                value.Add(endValue);
                value.Add(clousterValue);
                value.Add(scanIntervalValue);
                value.Add(nbOfScanValue);
                return value;
            }
        }

        #endregion

        public InitialForm()
        {
            
            InitializeComponent();
        }
        

        #region Move Main Windows with Click!
        public void Move_Form(IntPtr Handle, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void movePopupWindow(object sender, MouseEventArgs e)
        {
            Move_Form(Handle, e);
        }

        #endregion

        #region Exit Button setup --> onClick and Hover
        // === ExitImg on Click ===
        private void exitIMG_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // === EXIT BUTTON: Chane img when hover ===
        private void exitIMG_MouseHover(object sender, EventArgs e)
        {
            this.exitIMG.Image = (Properties.Resources.circlehover);
        }


        // === EXIT BUTTON: Chane back img when leave ===
        private void exitIMG_MouseLeave(object sender, EventArgs e)
        {
            this.exitIMG.Image = (Properties.Resources.circle);
        }
        #endregion

        #region Save Button --> get value from TextBox

        // === get valeu from textBox ===
        private void saveButton_Click(object sender, EventArgs e)
        {
            startingValue = this.startingBox.Text;
            endValue = this.endBox.Text;
            clousterValue = this.clousterBox.Text;
            scanIntervalValue = this.scanInitBox.Text;
            nbOfScanValue = this.nbOfScanBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}
