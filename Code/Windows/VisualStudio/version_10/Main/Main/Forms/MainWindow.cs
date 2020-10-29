using Main.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace Main
{
    public partial class MainWindow : Form
    {

        
        #region Variable / DllImport


        private Form activeForm = null;
        // === move UI ->
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        #endregion

        public MainWindow()
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

        private void moveMainWindow(object sender, MouseEventArgs e)
        {
            Move_Form(Handle, e);
        }

        #endregion


        #region Exit and minimalize with button onClick!

        // === ExitImg on Click ===
        private void exitIMG_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        // === MinimalizeImg on Click === 
        private void minimalizeIMG_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion


        #region Change image when mouse hover --> Minimalize and Exit buttons


        // === MINIMALIZE BUTTON: Chane img when hover ===
        private void minimalizeIMG_MouseHover(object sender, EventArgs e)
        {
            this.minimalizeIMG.Image = (Properties.Resources.circlehover);
        }


        // === MINIMALIZE BUTTON: Chane back img when leave ===
        private void minimalizeIMG_MouseLeave(object sender, EventArgs e)
        {
            this.minimalizeIMG.Image = (Properties.Resources.circle);
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



        #region Menu buttons OnClick

        //  === Open SLAM form === 
        private void slamButton_Click(object sender, EventArgs e) { openChildForm(new SlamForm()); }
           
        // === Open SerialCommunication form ===
        private void serialCommButton_Click(object sender, EventArgs e) { openChildForm(new SerialCommunicationForm()); }


        // === Open About form ===
        private void aboutButton_Click(object sender, EventArgs e) { openChildForm(new AboutForm()); }


        // === Child Form function ===
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        #endregion
    }
}
