namespace Main.Forms
{
    partial class AboutForm
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
            this.labelAuthor = new System.Windows.Forms.Label();
            this.myNameLabel = new System.Windows.Forms.Label();
            this.myEmail = new System.Windows.Forms.Label();
            this.myJob = new System.Windows.Forms.Label();
            this.labelAbout = new System.Windows.Forms.Label();
            this.softName = new System.Windows.Forms.Label();
            this.softDate = new System.Windows.Forms.Label();
            this.softVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelAuthor.Location = new System.Drawing.Point(20, 24);
            this.labelAuthor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(120, 36);
            this.labelAuthor.TabIndex = 0;
            this.labelAuthor.Text = "Author:";
            // 
            // myNameLabel
            // 
            this.myNameLabel.AutoSize = true;
            this.myNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.myNameLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.myNameLabel.Location = new System.Drawing.Point(60, 67);
            this.myNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myNameLabel.Name = "myNameLabel";
            this.myNameLabel.Size = new System.Drawing.Size(148, 25);
            this.myNameLabel.TabIndex = 1;
            this.myNameLabel.Text = "Krizbai Csaba";
            // 
            // myEmail
            // 
            this.myEmail.AutoSize = true;
            this.myEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.myEmail.ForeColor = System.Drawing.Color.RoyalBlue;
            this.myEmail.Location = new System.Drawing.Point(60, 106);
            this.myEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myEmail.Name = "myEmail";
            this.myEmail.Size = new System.Drawing.Size(265, 25);
            this.myEmail.TabIndex = 2;
            this.myEmail.Text = "csaba.krizbai@yahoo.com";
            // 
            // myJob
            // 
            this.myJob.AutoSize = true;
            this.myJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.myJob.ForeColor = System.Drawing.Color.RoyalBlue;
            this.myJob.Location = new System.Drawing.Point(60, 145);
            this.myJob.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myJob.Name = "myJob";
            this.myJob.Size = new System.Drawing.Size(463, 25);
            this.myJob.TabIndex = 3;
            this.myJob.Text = "Sapientia Hungarian University of Transylvania";
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.labelAbout.Location = new System.Drawing.Point(20, 294);
            this.labelAbout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(243, 36);
            this.labelAbout.TabIndex = 4;
            this.labelAbout.Text = "About Software:";
            // 
            // softName
            // 
            this.softName.AutoSize = true;
            this.softName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.softName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.softName.Location = new System.Drawing.Point(60, 359);
            this.softName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.softName.Name = "softName";
            this.softName.Size = new System.Drawing.Size(247, 25);
            this.softName.TabIndex = 5;
            this.softName.Text = "HOKUYO URG Software";
            // 
            // softDate
            // 
            this.softDate.AutoSize = true;
            this.softDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.softDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.softDate.Location = new System.Drawing.Point(60, 437);
            this.softDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.softDate.Name = "softDate";
            this.softDate.Size = new System.Drawing.Size(227, 25);
            this.softDate.TabIndex = 6;
            this.softDate.Text = "Copyright 2020 - 2021";
            // 
            // softVersion
            // 
            this.softVersion.AutoSize = true;
            this.softVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.softVersion.ForeColor = System.Drawing.Color.RoyalBlue;
            this.softVersion.Location = new System.Drawing.Point(60, 398);
            this.softVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.softVersion.Name = "softVersion";
            this.softVersion.Size = new System.Drawing.Size(207, 25);
            this.softVersion.TabIndex = 7;
            this.softVersion.Text = "Version: 0.11 (Beta)";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(970, 650);
            this.Controls.Add(this.softVersion);
            this.Controls.Add(this.softDate);
            this.Controls.Add(this.softName);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.myJob);
            this.Controls.Add(this.myEmail);
            this.Controls.Add(this.myNameLabel);
            this.Controls.Add(this.labelAuthor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(970, 650);
            this.MinimumSize = new System.Drawing.Size(970, 650);
            this.Name = "AboutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label myNameLabel;
        private System.Windows.Forms.Label myEmail;
        private System.Windows.Forms.Label myJob;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.Label softName;
        private System.Windows.Forms.Label softDate;
        private System.Windows.Forms.Label softVersion;
    }
}