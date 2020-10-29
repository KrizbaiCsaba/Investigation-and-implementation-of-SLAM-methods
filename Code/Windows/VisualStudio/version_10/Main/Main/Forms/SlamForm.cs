using Main.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Tao.OpenGl;

namespace Main.Forms
{

    public partial class SlamForm : Form
    {

        #region Variables
        // === Sensor Parameters ===
        ArrayList sensorParameters = new ArrayList();

        // === Form Popup ===
        InitialForm Popup = new InitialForm();

        // === TCP Server address ===
        private static string address = "192.168.1.103";
        private static int port = 22000;
        TcpClientSetup tcpSetup;

        // === OpenGl ===
        private int height, width;
        internal int viewPortCordX = 0;
        internal int viewPortCordY = -100;
        internal int viewPortCordZ = -300;
        internal int stepsize = 10;
        Timer timerFPS = new Timer();
        private int reqFps = 30;

        // === Measurments ===
        protected List<long> distances = new List<long>();
        

        #endregion



        public SlamForm()
        {
            InitializeComponent();
            getSensorValue();
            tcpSetup = new TcpClientSetup(address, port);
            initFpsTimer();

        }


        // === Read Sensor Value from InitalForm ====
        private void getSensorValue()
        {
            sensorParameters.Clear();
            foreach ( string it in Popup.ReturnValue)
                sensorParameters.Add(it);
        }

        #region InitializeButton onClicked! ---> Get Ini data

        private void initializeButton_Click(object sender, EventArgs e)
        {
            var result = Popup.ShowDialog();
            if (result == DialogResult.OK)
                getSensorValue();
        }
        #endregion


        #region ConnectButton onClicked ---> Connect to TCP Server
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (tcpSetup.Connected == false) // - not connected
            {
                // === Change Img === 
                this.connectButton.BackgroundImage = Properties.Resources.wifiConnected;

                // === Connect to the server ===
                tcpSetup.ConnectToServer();
                System.Threading.Thread.Sleep(100);
                // === Send Ini Data ===
                tcpSetup.SendIniData(sensorParameters);

                return;
            } //connected 

            // === Disconect from 
            tcpSetup.DisconnectFromServer();

            // === Change Img ===
            this.connectButton.BackgroundImage = Properties.Resources.wifiNotConnected;

        }


        #endregion

        #region OpenGl

        public void initFpsTimer()
        {
            timerFPS.Interval = (int)(1000.0 / reqFps);
            timerFPS.Tick += new EventHandler(delegate (object o, EventArgs ea) {
                this.canvas.Refresh();
            });
            timerFPS.Enabled = true;
            timerFPS.Start();
        }

        private void canvas_Load(object sender, EventArgs e)
        {
            height = canvas.Height;
            width = canvas.Width;

            canvas.InitializeContexts();
            canvas.AutoFinish = true;
            canvas.AutoSwapBuffers = true;
            Gl.glViewport(0, 0, width, height);
            Gl.glShadeModel(Gl.GL_FLAT);                     // Set the shading model
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);  // Set Line Antialiasing
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45.0f, (double)width / (double)height, 0.01f, 5000.0f);
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            onRefresh(viewPortCordX, viewPortCordY, viewPortCordZ);
        }



        private void onRefresh(int x, int y, int z)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT); //clear buffers to preset values
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();                 // load the identity matrix
            Gl.glTranslated(x, y, z);          //moves our figure (x,y,z)

            //X - coordinates
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glColor3ub(0, 0, 250);
            Gl.glVertex2d(-height, 0);
            Gl.glVertex2d(height, 0);
            Gl.glEnd();
            Gl.glFlush();

            //Y - coordinates
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glColor3ub(250, 0, 0);
            Gl.glVertex2d(0, -width);
            Gl.glVertex2d(0, width);
            Gl.glEnd();
            Gl.glFlush();


            //sensor
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3ub(52, 52, 0);
            Gl.glVertex2d(-5, 5);
            Gl.glVertex2d(5, 5);
            Gl.glVertex2d(5, -5);
            Gl.glVertex2d(-5, -5);
            Gl.glEnd();
            Gl.glFlush();

            tcpSetup.getDistances(ref distances);

            //lines
            plotDistanceWithLines();
            //points 
            plotDistanceWithPoint();

            System.Threading.Thread.Sleep(100);

        }

        void plotDistanceWithLines()
        {

            int a = 1, b = 2, dimin = 1, dimax = 15, plotX, plotY;

            int stepAngle = 240 / (distances.Count - 1);
            int angle = 60;
            foreach (int it in distances)
            {   
                Gl.glBegin(Gl.GL_LINES); //starts drawing of points
                Gl.glColor4b(1, 50, 100, 5);

                long normalized = (b - a) * (it - dimin) / (dimax - dimin) + a;
                plotX = 0 + (int)(normalized * Math.Sin(Math.PI * angle / 180));
                plotY = 0 - (int)(normalized * Math.Cos(Math.PI * angle / 180));

                angle += stepAngle;

                Gl.glVertex2i(0, 0);//lower-left corner
                Gl.glVertex2i(plotX, plotY);//upper-right corner
                Gl.glEnd();//end drawing of points
            }

        }
        void plotDistanceWithPoint()
        {
            int a = 1, b = 2, dimin = 1, dimax = 15, plotX, plotY;
            int stepAngle = 240 / (distances.Count - 1);
            int angle = 60;

            Gl.glPointSize(5);
            foreach (int it in distances)
            {
                Gl.glBegin(Gl.GL_POINTS); //starts drawing of points
                Gl.glColor4b(0, 100, 0, 5);

                long normalized = (b - a) * (it - dimin) / (dimax - dimin) + a;
                plotX = 0 + (int)(normalized * Math.Sin(Math.PI * angle / 180));
                plotY = 0 - (int)(normalized * Math.Cos(Math.PI * angle / 180));

                angle += stepAngle;

                Gl.glVertex2i(plotX, plotY);
                Gl.glEnd();//end drawing of points
            }
        }

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    viewPortCordX = 0;
                    viewPortCordY = 0;
                    viewPortCordY = -5;
                    //Gl.glViewport(viewPortCordX, viewPortCordY, width, height);
                    Gl.glTranslated(viewPortCordX, viewPortCordY, -5);          //moves our figure (x,y,z)
                    break;
                case Keys.W:
                    viewPortCordY -= stepsize;
                    onRefresh(viewPortCordX, viewPortCordY, viewPortCordZ);
                    break;
                case Keys.A:
                    viewPortCordX += stepsize;
                    onRefresh(viewPortCordX, viewPortCordY, viewPortCordZ);
                    break;
                case Keys.S:
                    viewPortCordY += stepsize;
                    onRefresh(viewPortCordX, viewPortCordY, viewPortCordZ);
                    break;
                case Keys.D:
                    viewPortCordX -= stepsize;
                    onRefresh(viewPortCordX, viewPortCordY, viewPortCordZ);
                    break;
                case Keys.R:
                    viewPortCordZ -= stepsize;
                    onRefresh(viewPortCordX, viewPortCordY, viewPortCordZ);
                    break;
                case Keys.F:
                    viewPortCordZ += stepsize;
                    onRefresh(viewPortCordX, viewPortCordY, viewPortCordZ);
                    break;

            }
        }

        #endregion
    }
}
