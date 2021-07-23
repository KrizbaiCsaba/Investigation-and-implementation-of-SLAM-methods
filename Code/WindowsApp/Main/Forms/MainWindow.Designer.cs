namespace Main
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuPanel = new System.Windows.Forms.Panel();
            this.versionText = new System.Windows.Forms.Label();
            this.aboutButton = new System.Windows.Forms.Button();
            this.serialCommButton = new System.Windows.Forms.Button();
            this.slamButton = new System.Windows.Forms.Button();
            this.menubarPanel = new System.Windows.Forms.Panel();
            this.TilteTXT = new System.Windows.Forms.Label();
            this.minimalizeIMG = new System.Windows.Forms.PictureBox();
            this.exitIMG = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.menuPanel.SuspendLayout();
            this.menubarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimalizeIMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitIMG)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.menuPanel.Controls.Add(this.versionText);
            this.menuPanel.Controls.Add(this.aboutButton);
            this.menuPanel.Controls.Add(this.serialCommButton);
            this.menuPanel.Controls.Add(this.slamButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(213, 837);
            this.menuPanel.TabIndex = 4;
            this.menuPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moveMainWindow);
            // 
            // versionText
            // 
            this.versionText.AutoSize = true;
            this.versionText.BackColor = System.Drawing.Color.Transparent;
            this.versionText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.versionText.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
            this.versionText.ForeColor = System.Drawing.Color.Gainsboro;
            this.versionText.ImeMode = System.Windows.Forms.ImeMode.On;
            this.versionText.Location = new System.Drawing.Point(0, 818);
            this.versionText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.versionText.Name = "versionText";
            this.versionText.Size = new System.Drawing.Size(148, 19);
            this.versionText.TabIndex = 7;
            this.versionText.Text = "version: 0.11 (Beta)";
            // 
            // aboutButton
            // 
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold);
            this.aboutButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.aboutButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutButton.Image")));
            this.aboutButton.ImeMode = System.Windows.Forms.ImeMode.On;
            this.aboutButton.Location = new System.Drawing.Point(164, 788);
            this.aboutButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(49, 47);
            this.aboutButton.TabIndex = 6;
            this.aboutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // serialCommButton
            // 
            this.serialCommButton.FlatAppearance.BorderSize = 0;
            this.serialCommButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serialCommButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold);
            this.serialCommButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.serialCommButton.Image = global::Main.Properties.Resources.serialCommunication;
            this.serialCommButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.serialCommButton.ImeMode = System.Windows.Forms.ImeMode.On;
            this.serialCommButton.Location = new System.Drawing.Point(0, 324);
            this.serialCommButton.Margin = new System.Windows.Forms.Padding(0);
            this.serialCommButton.Name = "serialCommButton";
            this.serialCommButton.Size = new System.Drawing.Size(213, 172);
            this.serialCommButton.TabIndex = 4;
            this.serialCommButton.Text = "Serial Communication";
            this.serialCommButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.serialCommButton.UseVisualStyleBackColor = true;
            this.serialCommButton.Click += new System.EventHandler(this.serialCommButton_Click);
            // 
            // slamButton
            // 
            this.slamButton.FlatAppearance.BorderSize = 0;
            this.slamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold);
            this.slamButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.slamButton.Image = ((System.Drawing.Image)(resources.GetObject("slamButton.Image")));
            this.slamButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.slamButton.ImeMode = System.Windows.Forms.ImeMode.On;
            this.slamButton.Location = new System.Drawing.Point(0, 139);
            this.slamButton.Margin = new System.Windows.Forms.Padding(0);
            this.slamButton.Name = "slamButton";
            this.slamButton.Size = new System.Drawing.Size(213, 172);
            this.slamButton.TabIndex = 3;
            this.slamButton.Text = "SLAM";
            this.slamButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.slamButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.slamButton.UseVisualStyleBackColor = true;
            this.slamButton.Click += new System.EventHandler(this.slamButton_Click);
            // 
            // menubarPanel
            // 
            this.menubarPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.menubarPanel.Controls.Add(this.TilteTXT);
            this.menubarPanel.Controls.Add(this.minimalizeIMG);
            this.menubarPanel.Controls.Add(this.exitIMG);
            this.menubarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menubarPanel.Location = new System.Drawing.Point(213, 0);
            this.menubarPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.menubarPanel.Name = "menubarPanel";
            this.menubarPanel.Size = new System.Drawing.Size(1294, 37);
            this.menubarPanel.TabIndex = 5;
            this.menubarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moveMainWindow);
            // 
            // TilteTXT
            // 
            this.TilteTXT.AutoSize = true;
            this.TilteTXT.BackColor = System.Drawing.Color.Transparent;
            this.TilteTXT.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.TilteTXT.ForeColor = System.Drawing.Color.Gainsboro;
            this.TilteTXT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TilteTXT.Location = new System.Drawing.Point(4, 10);
            this.TilteTXT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TilteTXT.Name = "TilteTXT";
            this.TilteTXT.Size = new System.Drawing.Size(213, 26);
            this.TilteTXT.TabIndex = 2;
            this.TilteTXT.Text = "Hokuyo URG 04LX";
            this.TilteTXT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moveMainWindow);
            // 
            // minimalizeIMG
            // 
            this.minimalizeIMG.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimalizeIMG.Image = ((System.Drawing.Image)(resources.GetObject("minimalizeIMG.Image")));
            this.minimalizeIMG.ImeMode = System.Windows.Forms.ImeMode.On;
            this.minimalizeIMG.Location = new System.Drawing.Point(1212, 0);
            this.minimalizeIMG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.minimalizeIMG.Name = "minimalizeIMG";
            this.minimalizeIMG.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.minimalizeIMG.Size = new System.Drawing.Size(41, 37);
            this.minimalizeIMG.TabIndex = 1;
            this.minimalizeIMG.TabStop = false;
            this.minimalizeIMG.Click += new System.EventHandler(this.minimalizeIMG_Click);
            this.minimalizeIMG.MouseLeave += new System.EventHandler(this.minimalizeIMG_MouseLeave);
            this.minimalizeIMG.MouseHover += new System.EventHandler(this.minimalizeIMG_MouseHover);
            // 
            // exitIMG
            // 
            this.exitIMG.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitIMG.Image = ((System.Drawing.Image)(resources.GetObject("exitIMG.Image")));
            this.exitIMG.ImeMode = System.Windows.Forms.ImeMode.On;
            this.exitIMG.Location = new System.Drawing.Point(1253, 0);
            this.exitIMG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exitIMG.Name = "exitIMG";
            this.exitIMG.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.exitIMG.Size = new System.Drawing.Size(41, 37);
            this.exitIMG.TabIndex = 0;
            this.exitIMG.TabStop = false;
            this.exitIMG.Click += new System.EventHandler(this.exitIMG_Click);
            this.exitIMG.MouseLeave += new System.EventHandler(this.exitIMG_MouseLeave);
            this.exitIMG.MouseHover += new System.EventHandler(this.exitIMG_MouseHover);
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.Gainsboro;
            this.panelChildForm.BackgroundImage = global::Main.Properties.Resources.hokuyo_logo;
            this.panelChildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(213, 37);
            this.panelChildForm.Margin = new System.Windows.Forms.Padding(0);
            this.panelChildForm.MinimumSize = new System.Drawing.Size(1293, 800);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1294, 800);
            this.panelChildForm.TabIndex = 6;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1507, 837);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.menubarPanel);
            this.Controls.Add(this.menuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.menubarPanel.ResumeLayout(false);
            this.menubarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimalizeIMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitIMG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label versionText;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button serialCommButton;
        private System.Windows.Forms.Button slamButton;
        private System.Windows.Forms.Panel menubarPanel;
        private System.Windows.Forms.Label TilteTXT;
        private System.Windows.Forms.PictureBox minimalizeIMG;
        private System.Windows.Forms.PictureBox exitIMG;
        private System.Windows.Forms.Panel panelChildForm;
    }
}

