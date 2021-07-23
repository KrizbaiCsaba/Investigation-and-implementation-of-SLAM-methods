namespace Main.Forms
{
    partial class SlamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlamForm));
            this.connectButton = new System.Windows.Forms.Button();
            this.initializeButton = new System.Windows.Forms.Button();
            this.downloadXML = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.canvas = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.Transparent;
            this.connectButton.BackgroundImage = global::Main.Properties.Resources.wifiNotConnected;
            this.connectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.connectButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.connectButton.FlatAppearance.BorderSize = 0;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.connectButton.Location = new System.Drawing.Point(1172, 661);
            this.connectButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(107, 123);
            this.connectButton.TabIndex = 29;
            this.connectButton.Text = "Connect";
            this.connectButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.connectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // initializeButton
            // 
            this.initializeButton.BackColor = System.Drawing.Color.Transparent;
            this.initializeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("initializeButton.BackgroundImage")));
            this.initializeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.initializeButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.initializeButton.FlatAppearance.BorderSize = 0;
            this.initializeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.initializeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initializeButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.initializeButton.Location = new System.Drawing.Point(1169, 15);
            this.initializeButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.initializeButton.Name = "initializeButton";
            this.initializeButton.Size = new System.Drawing.Size(107, 135);
            this.initializeButton.TabIndex = 28;
            this.initializeButton.Text = "Inital Value";
            this.initializeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.initializeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.initializeButton.UseVisualStyleBackColor = false;
            this.initializeButton.Click += new System.EventHandler(this.initializeButton_Click);
            // 
            // downloadXML
            // 
            this.downloadXML.BackColor = System.Drawing.Color.Transparent;
            this.downloadXML.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("downloadXML.BackgroundImage")));
            this.downloadXML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.downloadXML.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.downloadXML.FlatAppearance.BorderSize = 0;
            this.downloadXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadXML.ForeColor = System.Drawing.Color.RoyalBlue;
            this.downloadXML.Location = new System.Drawing.Point(1171, 158);
            this.downloadXML.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.downloadXML.Name = "downloadXML";
            this.downloadXML.Size = new System.Drawing.Size(107, 123);
            this.downloadXML.TabIndex = 27;
            this.downloadXML.Text = "Download XML";
            this.downloadXML.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.downloadXML.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.downloadXML.UseVisualStyleBackColor = false;
            this.downloadXML.Click += new System.EventHandler(this.downloadXML_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Transparent;
            this.stopButton.BackgroundImage = global::Main.Properties.Resources.stop;
            this.stopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.stopButton.FlatAppearance.BorderSize = 0;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.stopButton.Location = new System.Drawing.Point(1172, 528);
            this.stopButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(107, 123);
            this.stopButton.TabIndex = 26;
            this.stopButton.Text = "STOP!";
            this.stopButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.stopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // canvas
            // 
            this.canvas.AccumBits = ((byte)(0));
            this.canvas.AutoCheckErrors = false;
            this.canvas.AutoFinish = false;
            this.canvas.AutoMakeCurrent = true;
            this.canvas.AutoSwapBuffers = true;
            this.canvas.BackColor = System.Drawing.Color.Gainsboro;
            this.canvas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("canvas.BackgroundImage")));
            this.canvas.ColorBits = ((byte)(32));
            this.canvas.DepthBits = ((byte)(16));
            this.canvas.Location = new System.Drawing.Point(16, 15);
            this.canvas.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1145, 770);
            this.canvas.StencilBits = ((byte)(0));
            this.canvas.TabIndex = 0;
            this.canvas.Load += new System.EventHandler(this.canvas_Load);
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.canvas_KeyDown);
            // 
            // SlamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1293, 800);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.initializeButton);
            this.Controls.Add(this.downloadXML);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1293, 800);
            this.MinimumSize = new System.Drawing.Size(1293, 800);
            this.Name = "SlamForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl canvas;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button downloadXML;
        private System.Windows.Forms.Button initializeButton;
        private System.Windows.Forms.Button connectButton;
    }
}