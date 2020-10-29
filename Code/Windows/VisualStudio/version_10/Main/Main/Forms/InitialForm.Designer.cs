namespace Main.Forms
{
    partial class InitialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialForm));
            this.menubarPanel = new System.Windows.Forms.Panel();
            this.TilteTXT = new System.Windows.Forms.Label();
            this.exitIMG = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.startingBox = new System.Windows.Forms.TextBox();
            this.startingTXT = new System.Windows.Forms.Label();
            this.endBox = new System.Windows.Forms.TextBox();
            this.endTXT = new System.Windows.Forms.Label();
            this.clousterBox = new System.Windows.Forms.TextBox();
            this.clousterTXT = new System.Windows.Forms.Label();
            this.MDGroup = new System.Windows.Forms.GroupBox();
            this.scanIntText = new System.Windows.Forms.Label();
            this.scanInitBox = new System.Windows.Forms.TextBox();
            this.nbOfScanText = new System.Windows.Forms.Label();
            this.nbOfScanBox = new System.Windows.Forms.TextBox();
            this.menubarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitIMG)).BeginInit();
            this.MDGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menubarPanel
            // 
            this.menubarPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.menubarPanel.Controls.Add(this.TilteTXT);
            this.menubarPanel.Controls.Add(this.exitIMG);
            this.menubarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menubarPanel.Location = new System.Drawing.Point(0, 0);
            this.menubarPanel.Name = "menubarPanel";
            this.menubarPanel.Size = new System.Drawing.Size(484, 30);
            this.menubarPanel.TabIndex = 6;
            this.menubarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.movePopupWindow);
            // 
            // TilteTXT
            // 
            this.TilteTXT.AutoSize = true;
            this.TilteTXT.BackColor = System.Drawing.Color.Transparent;
            this.TilteTXT.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.TilteTXT.ForeColor = System.Drawing.Color.Gainsboro;
            this.TilteTXT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TilteTXT.Location = new System.Drawing.Point(3, 8);
            this.TilteTXT.Name = "TilteTXT";
            this.TilteTXT.Size = new System.Drawing.Size(108, 22);
            this.TilteTXT.TabIndex = 2;
            this.TilteTXT.Text = "Initial Value";
            this.TilteTXT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.movePopupWindow);
            // 
            // exitIMG
            // 
            this.exitIMG.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitIMG.Image = ((System.Drawing.Image)(resources.GetObject("exitIMG.Image")));
            this.exitIMG.ImeMode = System.Windows.Forms.ImeMode.On;
            this.exitIMG.Location = new System.Drawing.Point(453, 0);
            this.exitIMG.Name = "exitIMG";
            this.exitIMG.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.exitIMG.Size = new System.Drawing.Size(31, 30);
            this.exitIMG.TabIndex = 0;
            this.exitIMG.TabStop = false;
            this.exitIMG.Click += new System.EventHandler(this.exitIMG_Click);
            this.exitIMG.MouseLeave += new System.EventHandler(this.exitIMG_MouseLeave);
            this.exitIMG.MouseHover += new System.EventHandler(this.exitIMG_MouseHover);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.saveButton.Location = new System.Drawing.Point(396, 218);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(76, 31);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // startingBox
            // 
            this.startingBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.startingBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingBox.Location = new System.Drawing.Point(31, 31);
            this.startingBox.Margin = new System.Windows.Forms.Padding(4);
            this.startingBox.Multiline = true;
            this.startingBox.Name = "startingBox";
            this.startingBox.Size = new System.Drawing.Size(108, 23);
            this.startingBox.TabIndex = 15;
            this.startingBox.Text = "0044";
            // 
            // startingTXT
            // 
            this.startingTXT.AutoSize = true;
            this.startingTXT.Location = new System.Drawing.Point(20, 16);
            this.startingTXT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startingTXT.Name = "startingTXT";
            this.startingTXT.Size = new System.Drawing.Size(101, 16);
            this.startingTXT.TabIndex = 16;
            this.startingTXT.Text = "Starting Step:";
            // 
            // endBox
            // 
            this.endBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.endBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.endBox.Location = new System.Drawing.Point(31, 77);
            this.endBox.Margin = new System.Windows.Forms.Padding(4);
            this.endBox.Multiline = true;
            this.endBox.Name = "endBox";
            this.endBox.Size = new System.Drawing.Size(108, 23);
            this.endBox.TabIndex = 17;
            this.endBox.Text = "0725";
            // 
            // endTXT
            // 
            this.endTXT.AutoSize = true;
            this.endTXT.Location = new System.Drawing.Point(20, 58);
            this.endTXT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.endTXT.Name = "endTXT";
            this.endTXT.Size = new System.Drawing.Size(75, 16);
            this.endTXT.TabIndex = 18;
            this.endTXT.Text = "End Step:";
            // 
            // clousterBox
            // 
            this.clousterBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clousterBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clousterBox.Location = new System.Drawing.Point(31, 125);
            this.clousterBox.Margin = new System.Windows.Forms.Padding(4);
            this.clousterBox.Multiline = true;
            this.clousterBox.Name = "clousterBox";
            this.clousterBox.Size = new System.Drawing.Size(108, 23);
            this.clousterBox.TabIndex = 19;
            this.clousterBox.Text = "09";
            // 
            // clousterTXT
            // 
            this.clousterTXT.AutoSize = true;
            this.clousterTXT.Location = new System.Drawing.Point(20, 105);
            this.clousterTXT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clousterTXT.Name = "clousterTXT";
            this.clousterTXT.Size = new System.Drawing.Size(112, 16);
            this.clousterTXT.TabIndex = 20;
            this.clousterTXT.Text = "Clouster Count:";
            // 
            // MDGroup
            // 
            this.MDGroup.Controls.Add(this.nbOfScanText);
            this.MDGroup.Controls.Add(this.nbOfScanBox);
            this.MDGroup.Controls.Add(this.scanIntText);
            this.MDGroup.Controls.Add(this.scanInitBox);
            this.MDGroup.Controls.Add(this.clousterTXT);
            this.MDGroup.Controls.Add(this.clousterBox);
            this.MDGroup.Controls.Add(this.endTXT);
            this.MDGroup.Controls.Add(this.endBox);
            this.MDGroup.Controls.Add(this.startingTXT);
            this.MDGroup.Controls.Add(this.startingBox);
            this.MDGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MDGroup.ForeColor = System.Drawing.Color.RoyalBlue;
            this.MDGroup.Location = new System.Drawing.Point(4, 34);
            this.MDGroup.Margin = new System.Windows.Forms.Padding(4);
            this.MDGroup.Name = "MDGroup";
            this.MDGroup.Padding = new System.Windows.Forms.Padding(4);
            this.MDGroup.Size = new System.Drawing.Size(340, 201);
            this.MDGroup.TabIndex = 24;
            this.MDGroup.TabStop = false;
            this.MDGroup.Text = "MD Command Setup:";
            // 
            // scanIntText
            // 
            this.scanIntText.AutoSize = true;
            this.scanIntText.Location = new System.Drawing.Point(20, 152);
            this.scanIntText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scanIntText.Name = "scanIntText";
            this.scanIntText.Size = new System.Drawing.Size(102, 16);
            this.scanIntText.TabIndex = 22;
            this.scanIntText.Text = "Scan interval:";
            // 
            // scanInitBox
            // 
            this.scanInitBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scanInitBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scanInitBox.Location = new System.Drawing.Point(31, 172);
            this.scanInitBox.Margin = new System.Windows.Forms.Padding(4);
            this.scanInitBox.Multiline = true;
            this.scanInitBox.Name = "scanInitBox";
            this.scanInitBox.Size = new System.Drawing.Size(108, 23);
            this.scanInitBox.TabIndex = 21;
            this.scanInitBox.Text = "0";
            // 
            // nbOfScanText
            // 
            this.nbOfScanText.AutoSize = true;
            this.nbOfScanText.Location = new System.Drawing.Point(147, 19);
            this.nbOfScanText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nbOfScanText.Name = "nbOfScanText";
            this.nbOfScanText.Size = new System.Drawing.Size(124, 16);
            this.nbOfScanText.TabIndex = 24;
            this.nbOfScanText.Text = "Number Of Scan:";
            // 
            // nbOfScanBox
            // 
            this.nbOfScanBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nbOfScanBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nbOfScanBox.Location = new System.Drawing.Point(158, 34);
            this.nbOfScanBox.Margin = new System.Windows.Forms.Padding(4);
            this.nbOfScanBox.Multiline = true;
            this.nbOfScanBox.Name = "nbOfScanBox";
            this.nbOfScanBox.Size = new System.Drawing.Size(108, 23);
            this.nbOfScanBox.TabIndex = 23;
            this.nbOfScanBox.Text = "01";
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.MDGroup);
            this.Controls.Add(this.menubarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InitialForm";
            this.Text = "InitialForm";
            this.menubarPanel.ResumeLayout(false);
            this.menubarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitIMG)).EndInit();
            this.MDGroup.ResumeLayout(false);
            this.MDGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menubarPanel;
        private System.Windows.Forms.Label TilteTXT;
        private System.Windows.Forms.PictureBox exitIMG;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox startingBox;
        private System.Windows.Forms.Label startingTXT;
        private System.Windows.Forms.TextBox endBox;
        private System.Windows.Forms.Label endTXT;
        private System.Windows.Forms.TextBox clousterBox;
        private System.Windows.Forms.Label clousterTXT;
        private System.Windows.Forms.GroupBox MDGroup;
        private System.Windows.Forms.Label scanIntText;
        private System.Windows.Forms.TextBox scanInitBox;
        private System.Windows.Forms.Label nbOfScanText;
        private System.Windows.Forms.TextBox nbOfScanBox;
    }
}