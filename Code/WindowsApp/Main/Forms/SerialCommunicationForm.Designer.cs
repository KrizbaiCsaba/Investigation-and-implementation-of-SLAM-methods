namespace Main.Forms
{
    partial class SerialCommunicationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialCommunicationForm));
            this.textRBox = new System.Windows.Forms.TextBox();
            this.textTBox = new System.Windows.Forms.TextBox();
            this.countGroup = new System.Windows.Forms.GroupBox();
            this.OuputTXT = new System.Windows.Forms.Label();
            this.dataOutValue = new System.Windows.Forms.TextBox();
            this.inputTXT = new System.Windows.Forms.Label();
            this.dataInValue = new System.Windows.Forms.TextBox();
            this.MDGroup = new System.Windows.Forms.GroupBox();
            this.clousterTXT = new System.Windows.Forms.Label();
            this.clousterBox = new System.Windows.Forms.TextBox();
            this.endTXT = new System.Windows.Forms.Label();
            this.endBox = new System.Windows.Forms.TextBox();
            this.startingTXT = new System.Windows.Forms.Label();
            this.startingBox = new System.Windows.Forms.TextBox();
            this.settingGroup = new System.Windows.Forms.GroupBox();
            this.savedataCheck = new System.Windows.Forms.CheckBox();
            this.deleteinputCheck = new System.Windows.Forms.CheckBox();
            this.sendEnterCheck = new System.Windows.Forms.CheckBox();
            this.decodeCheck = new System.Windows.Forms.CheckBox();
            this.commandListGroup = new System.Windows.Forms.GroupBox();
            this.HSButton = new System.Windows.Forms.Button();
            this.MDButton = new System.Windows.Forms.Button();
            this.BMButton = new System.Windows.Forms.Button();
            this.RSButton = new System.Windows.Forms.Button();
            this.IIButton = new System.Windows.Forms.Button();
            this.VVButton = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.Label();
            this.received = new System.Windows.Forms.Label();
            this.ConnectToURGGroupbox = new System.Windows.Forms.GroupBox();
            this.connectToURGButton = new System.Windows.Forms.Button();
            this.sendDataButton = new System.Windows.Forms.Button();
            this.UrgGroupBox = new System.Windows.Forms.GroupBox();
            this.vendBox = new System.Windows.Forms.TextBox();
            this.vendTXT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.productBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serialBox = new System.Windows.Forms.TextBox();
            this.SendDataGroupbox = new System.Windows.Forms.GroupBox();
            this.countGroup.SuspendLayout();
            this.MDGroup.SuspendLayout();
            this.settingGroup.SuspendLayout();
            this.commandListGroup.SuspendLayout();
            this.ConnectToURGGroupbox.SuspendLayout();
            this.UrgGroupBox.SuspendLayout();
            this.SendDataGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textRBox
            // 
            this.textRBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textRBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textRBox.Enabled = false;
            this.textRBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRBox.Location = new System.Drawing.Point(16, 42);
            this.textRBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textRBox.Multiline = true;
            this.textRBox.Name = "textRBox";
            this.textRBox.ReadOnly = true;
            this.textRBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textRBox.Size = new System.Drawing.Size(1063, 614);
            this.textRBox.TabIndex = 0;
            // 
            // textTBox
            // 
            this.textTBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTBox.Enabled = false;
            this.textTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTBox.Location = new System.Drawing.Point(0, 25);
            this.textTBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textTBox.Multiline = true;
            this.textTBox.Name = "textTBox";
            this.textTBox.Size = new System.Drawing.Size(664, 31);
            this.textTBox.TabIndex = 6;
            this.textTBox.TextChanged += new System.EventHandler(this.textTBox_TextChanged);
            this.textTBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textTBox_KeyDown);
            // 
            // countGroup
            // 
            this.countGroup.BackColor = System.Drawing.Color.Transparent;
            this.countGroup.Controls.Add(this.OuputTXT);
            this.countGroup.Controls.Add(this.dataOutValue);
            this.countGroup.Controls.Add(this.inputTXT);
            this.countGroup.Controls.Add(this.dataInValue);
            this.countGroup.Enabled = false;
            this.countGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countGroup.ForeColor = System.Drawing.Color.RoyalBlue;
            this.countGroup.Location = new System.Drawing.Point(1093, 42);
            this.countGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.countGroup.Name = "countGroup";
            this.countGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.countGroup.Size = new System.Drawing.Size(192, 154);
            this.countGroup.TabIndex = 23;
            this.countGroup.TabStop = false;
            this.countGroup.Text = "Counter:";
            // 
            // OuputTXT
            // 
            this.OuputTXT.AutoSize = true;
            this.OuputTXT.BackColor = System.Drawing.Color.Transparent;
            this.OuputTXT.Location = new System.Drawing.Point(12, 75);
            this.OuputTXT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OuputTXT.Name = "OuputTXT";
            this.OuputTXT.Size = new System.Drawing.Size(128, 20);
            this.OuputTXT.TabIndex = 18;
            this.OuputTXT.Text = "Output length:";
            // 
            // dataOutValue
            // 
            this.dataOutValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataOutValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataOutValue.Location = new System.Drawing.Point(16, 98);
            this.dataOutValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataOutValue.Multiline = true;
            this.dataOutValue.Name = "dataOutValue";
            this.dataOutValue.ReadOnly = true;
            this.dataOutValue.Size = new System.Drawing.Size(169, 28);
            this.dataOutValue.TabIndex = 17;
            // 
            // inputTXT
            // 
            this.inputTXT.AutoSize = true;
            this.inputTXT.BackColor = System.Drawing.Color.Transparent;
            this.inputTXT.Location = new System.Drawing.Point(12, 22);
            this.inputTXT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inputTXT.Name = "inputTXT";
            this.inputTXT.Size = new System.Drawing.Size(113, 20);
            this.inputTXT.TabIndex = 16;
            this.inputTXT.Text = "Input length:";
            // 
            // dataInValue
            // 
            this.dataInValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataInValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataInValue.Location = new System.Drawing.Point(16, 46);
            this.dataInValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataInValue.Multiline = true;
            this.dataInValue.Name = "dataInValue";
            this.dataInValue.ReadOnly = true;
            this.dataInValue.Size = new System.Drawing.Size(169, 28);
            this.dataInValue.TabIndex = 15;
            // 
            // MDGroup
            // 
            this.MDGroup.BackColor = System.Drawing.Color.Transparent;
            this.MDGroup.Controls.Add(this.clousterTXT);
            this.MDGroup.Controls.Add(this.clousterBox);
            this.MDGroup.Controls.Add(this.endTXT);
            this.MDGroup.Controls.Add(this.endBox);
            this.MDGroup.Controls.Add(this.startingTXT);
            this.MDGroup.Controls.Add(this.startingBox);
            this.MDGroup.Enabled = false;
            this.MDGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MDGroup.ForeColor = System.Drawing.Color.RoyalBlue;
            this.MDGroup.Location = new System.Drawing.Point(1088, 203);
            this.MDGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MDGroup.Name = "MDGroup";
            this.MDGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MDGroup.Size = new System.Drawing.Size(203, 241);
            this.MDGroup.TabIndex = 24;
            this.MDGroup.TabStop = false;
            this.MDGroup.Text = "MD Command Setup:";
            // 
            // clousterTXT
            // 
            this.clousterTXT.AutoSize = true;
            this.clousterTXT.BackColor = System.Drawing.Color.Transparent;
            this.clousterTXT.Location = new System.Drawing.Point(8, 149);
            this.clousterTXT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clousterTXT.Name = "clousterTXT";
            this.clousterTXT.Size = new System.Drawing.Size(141, 20);
            this.clousterTXT.TabIndex = 20;
            this.clousterTXT.Text = "Clouster Count:";
            // 
            // clousterBox
            // 
            this.clousterBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clousterBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clousterBox.Location = new System.Drawing.Point(12, 172);
            this.clousterBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clousterBox.Multiline = true;
            this.clousterBox.Name = "clousterBox";
            this.clousterBox.Size = new System.Drawing.Size(169, 28);
            this.clousterBox.TabIndex = 19;
            // 
            // endTXT
            // 
            this.endTXT.AutoSize = true;
            this.endTXT.BackColor = System.Drawing.Color.Transparent;
            this.endTXT.Location = new System.Drawing.Point(8, 95);
            this.endTXT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.endTXT.Name = "endTXT";
            this.endTXT.Size = new System.Drawing.Size(91, 20);
            this.endTXT.TabIndex = 18;
            this.endTXT.Text = "End Step:";
            // 
            // endBox
            // 
            this.endBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.endBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.endBox.Location = new System.Drawing.Point(12, 118);
            this.endBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.endBox.Multiline = true;
            this.endBox.Name = "endBox";
            this.endBox.Size = new System.Drawing.Size(169, 28);
            this.endBox.TabIndex = 17;
            // 
            // startingTXT
            // 
            this.startingTXT.AutoSize = true;
            this.startingTXT.BackColor = System.Drawing.Color.Transparent;
            this.startingTXT.Location = new System.Drawing.Point(8, 41);
            this.startingTXT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startingTXT.Name = "startingTXT";
            this.startingTXT.Size = new System.Drawing.Size(125, 20);
            this.startingTXT.TabIndex = 16;
            this.startingTXT.Text = "Starting Step:";
            // 
            // startingBox
            // 
            this.startingBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.startingBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startingBox.Location = new System.Drawing.Point(12, 64);
            this.startingBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startingBox.Multiline = true;
            this.startingBox.Name = "startingBox";
            this.startingBox.Size = new System.Drawing.Size(169, 28);
            this.startingBox.TabIndex = 15;
            // 
            // settingGroup
            // 
            this.settingGroup.Controls.Add(this.savedataCheck);
            this.settingGroup.Controls.Add(this.deleteinputCheck);
            this.settingGroup.Controls.Add(this.sendEnterCheck);
            this.settingGroup.Controls.Add(this.decodeCheck);
            this.settingGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingGroup.ForeColor = System.Drawing.Color.RoyalBlue;
            this.settingGroup.Location = new System.Drawing.Point(1056, 678);
            this.settingGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.settingGroup.Name = "settingGroup";
            this.settingGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.settingGroup.Size = new System.Drawing.Size(233, 121);
            this.settingGroup.TabIndex = 25;
            this.settingGroup.TabStop = false;
            this.settingGroup.Text = "Settings:";
            // 
            // savedataCheck
            // 
            this.savedataCheck.AutoSize = true;
            this.savedataCheck.BackColor = System.Drawing.Color.Transparent;
            this.savedataCheck.FlatAppearance.BorderSize = 0;
            this.savedataCheck.Location = new System.Drawing.Point(9, 92);
            this.savedataCheck.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.savedataCheck.Name = "savedataCheck";
            this.savedataCheck.Size = new System.Drawing.Size(200, 24);
            this.savedataCheck.TabIndex = 20;
            this.savedataCheck.Text = "Save data to Txt file";
            this.savedataCheck.UseVisualStyleBackColor = false;
            // 
            // deleteinputCheck
            // 
            this.deleteinputCheck.AutoSize = true;
            this.deleteinputCheck.BackColor = System.Drawing.Color.Transparent;
            this.deleteinputCheck.FlatAppearance.BorderSize = 0;
            this.deleteinputCheck.Location = new System.Drawing.Point(9, 68);
            this.deleteinputCheck.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.deleteinputCheck.Name = "deleteinputCheck";
            this.deleteinputCheck.Size = new System.Drawing.Size(202, 24);
            this.deleteinputCheck.TabIndex = 19;
            this.deleteinputCheck.Text = "delete old input data";
            this.deleteinputCheck.UseVisualStyleBackColor = false;
            // 
            // sendEnterCheck
            // 
            this.sendEnterCheck.AutoSize = true;
            this.sendEnterCheck.BackColor = System.Drawing.Color.Transparent;
            this.sendEnterCheck.FlatAppearance.BorderSize = 0;
            this.sendEnterCheck.Location = new System.Drawing.Point(9, 43);
            this.sendEnterCheck.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.sendEnterCheck.Name = "sendEnterCheck";
            this.sendEnterCheck.Size = new System.Drawing.Size(174, 24);
            this.sendEnterCheck.TabIndex = 18;
            this.sendEnterCheck.Text = "Send with \'Enter\'";
            this.sendEnterCheck.UseVisualStyleBackColor = false;
            // 
            // decodeCheck
            // 
            this.decodeCheck.AutoSize = true;
            this.decodeCheck.BackColor = System.Drawing.Color.Transparent;
            this.decodeCheck.Checked = true;
            this.decodeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.decodeCheck.FlatAppearance.BorderSize = 0;
            this.decodeCheck.Location = new System.Drawing.Point(9, 18);
            this.decodeCheck.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.decodeCheck.Name = "decodeCheck";
            this.decodeCheck.Size = new System.Drawing.Size(180, 24);
            this.decodeCheck.TabIndex = 17;
            this.decodeCheck.Text = "decode input data";
            this.decodeCheck.UseVisualStyleBackColor = false;
            // 
            // commandListGroup
            // 
            this.commandListGroup.BackColor = System.Drawing.Color.Transparent;
            this.commandListGroup.Controls.Add(this.HSButton);
            this.commandListGroup.Controls.Add(this.MDButton);
            this.commandListGroup.Controls.Add(this.BMButton);
            this.commandListGroup.Controls.Add(this.RSButton);
            this.commandListGroup.Controls.Add(this.IIButton);
            this.commandListGroup.Controls.Add(this.VVButton);
            this.commandListGroup.Enabled = false;
            this.commandListGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandListGroup.ForeColor = System.Drawing.Color.RoyalBlue;
            this.commandListGroup.Location = new System.Drawing.Point(16, 724);
            this.commandListGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.commandListGroup.Name = "commandListGroup";
            this.commandListGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.commandListGroup.Size = new System.Drawing.Size(771, 75);
            this.commandListGroup.TabIndex = 26;
            this.commandListGroup.TabStop = false;
            this.commandListGroup.Text = "Command List:";
            // 
            // HSButton
            // 
            this.HSButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.HSButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.HSButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.HSButton.Location = new System.Drawing.Point(137, 27);
            this.HSButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.HSButton.Name = "HSButton";
            this.HSButton.Size = new System.Drawing.Size(93, 37);
            this.HSButton.TabIndex = 18;
            this.HSButton.Text = "HS";
            this.HSButton.UseVisualStyleBackColor = false;
            this.HSButton.Click += new System.EventHandler(this.HSButton_Click);
            // 
            // MDButton
            // 
            this.MDButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MDButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.MDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MDButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.MDButton.Location = new System.Drawing.Point(353, 27);
            this.MDButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MDButton.Name = "MDButton";
            this.MDButton.Size = new System.Drawing.Size(93, 37);
            this.MDButton.TabIndex = 17;
            this.MDButton.Text = "MD";
            this.MDButton.UseVisualStyleBackColor = false;
            this.MDButton.Click += new System.EventHandler(this.MDButton_Click);
            // 
            // BMButton
            // 
            this.BMButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BMButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.BMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.BMButton.Location = new System.Drawing.Point(569, 27);
            this.BMButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.BMButton.Name = "BMButton";
            this.BMButton.Size = new System.Drawing.Size(93, 37);
            this.BMButton.TabIndex = 16;
            this.BMButton.Text = "BM";
            this.BMButton.UseVisualStyleBackColor = false;
            this.BMButton.Click += new System.EventHandler(this.BMButton_Click);
            // 
            // RSButton
            // 
            this.RSButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RSButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.RSButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.RSButton.Location = new System.Drawing.Point(461, 27);
            this.RSButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.RSButton.Name = "RSButton";
            this.RSButton.Size = new System.Drawing.Size(93, 37);
            this.RSButton.TabIndex = 15;
            this.RSButton.Text = "RS";
            this.RSButton.UseVisualStyleBackColor = false;
            this.RSButton.Click += new System.EventHandler(this.RSButton_Click);
            // 
            // IIButton
            // 
            this.IIButton.AccessibleDescription = "Sensor transmits its running state on receiving this command";
            this.IIButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.IIButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.IIButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IIButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.IIButton.Location = new System.Drawing.Point(245, 27);
            this.IIButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.IIButton.Name = "IIButton";
            this.IIButton.Size = new System.Drawing.Size(93, 37);
            this.IIButton.TabIndex = 14;
            this.IIButton.Tag = "";
            this.IIButton.Text = "II";
            this.IIButton.UseVisualStyleBackColor = false;
            this.IIButton.Click += new System.EventHandler(this.IIButton_Click);
            // 
            // VVButton
            // 
            this.VVButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.VVButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.VVButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.VVButton.Location = new System.Drawing.Point(29, 27);
            this.VVButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.VVButton.Name = "VVButton";
            this.VVButton.Size = new System.Drawing.Size(93, 37);
            this.VVButton.TabIndex = 13;
            this.VVButton.Text = "VV";
            this.VVButton.UseVisualStyleBackColor = false;
            this.VVButton.Click += new System.EventHandler(this.VVButton_Click);
            // 
            // inputText
            // 
            this.inputText.AutoSize = true;
            this.inputText.BackColor = System.Drawing.Color.Transparent;
            this.inputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.inputText.ForeColor = System.Drawing.Color.RoyalBlue;
            this.inputText.Location = new System.Drawing.Point(-3, 4);
            this.inputText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(89, 17);
            this.inputText.TabIndex = 31;
            this.inputText.Text = "Send Data:";
            // 
            // received
            // 
            this.received.AutoSize = true;
            this.received.BackColor = System.Drawing.Color.Transparent;
            this.received.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.received.ForeColor = System.Drawing.Color.RoyalBlue;
            this.received.Location = new System.Drawing.Point(16, 22);
            this.received.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.received.Name = "received";
            this.received.Size = new System.Drawing.Size(149, 21);
            this.received.TabIndex = 32;
            this.received.Text = "Received Data:";
            // 
            // ConnectToURGGroupbox
            // 
            this.ConnectToURGGroupbox.BackColor = System.Drawing.Color.Transparent;
            this.ConnectToURGGroupbox.Controls.Add(this.connectToURGButton);
            this.ConnectToURGGroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectToURGGroupbox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ConnectToURGGroupbox.Location = new System.Drawing.Point(1096, 502);
            this.ConnectToURGGroupbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConnectToURGGroupbox.Name = "ConnectToURGGroupbox";
            this.ConnectToURGGroupbox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConnectToURGGroupbox.Size = new System.Drawing.Size(189, 155);
            this.ConnectToURGGroupbox.TabIndex = 33;
            this.ConnectToURGGroupbox.TabStop = false;
            this.ConnectToURGGroupbox.Text = "Connect to URG:";
            // 
            // connectToURGButton
            // 
            this.connectToURGButton.BackColor = System.Drawing.Color.Transparent;
            this.connectToURGButton.BackgroundImage = global::Main.Properties.Resources.usb;
            this.connectToURGButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.connectToURGButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.connectToURGButton.FlatAppearance.BorderSize = 0;
            this.connectToURGButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectToURGButton.Location = new System.Drawing.Point(28, 36);
            this.connectToURGButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectToURGButton.Name = "connectToURGButton";
            this.connectToURGButton.Size = new System.Drawing.Size(129, 112);
            this.connectToURGButton.TabIndex = 22;
            this.connectToURGButton.UseVisualStyleBackColor = false;
            this.connectToURGButton.Click += new System.EventHandler(this.connectToURGButton_Click);
            // 
            // sendDataButton
            // 
            this.sendDataButton.FlatAppearance.BorderSize = 0;
            this.sendDataButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.sendDataButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.sendDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendDataButton.ForeColor = System.Drawing.Color.DarkCyan;
            this.sendDataButton.Image = ((System.Drawing.Image)(resources.GetObject("sendDataButton.Image")));
            this.sendDataButton.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.sendDataButton.Location = new System.Drawing.Point(675, 6);
            this.sendDataButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.sendDataButton.Name = "sendDataButton";
            this.sendDataButton.Size = new System.Drawing.Size(105, 49);
            this.sendDataButton.TabIndex = 7;
            this.sendDataButton.Text = "Send";
            this.sendDataButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.sendDataButton.UseVisualStyleBackColor = true;
            this.sendDataButton.Click += new System.EventHandler(this.sendDataButton_Click);
            // 
            // UrgGroupBox
            // 
            this.UrgGroupBox.Controls.Add(this.vendBox);
            this.UrgGroupBox.Controls.Add(this.vendTXT);
            this.UrgGroupBox.Controls.Add(this.label1);
            this.UrgGroupBox.Controls.Add(this.productBox);
            this.UrgGroupBox.Controls.Add(this.label2);
            this.UrgGroupBox.Controls.Add(this.serialBox);
            this.UrgGroupBox.Enabled = false;
            this.UrgGroupBox.Location = new System.Drawing.Point(165, 4);
            this.UrgGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UrgGroupBox.Name = "UrgGroupBox";
            this.UrgGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UrgGroupBox.Size = new System.Drawing.Size(915, 34);
            this.UrgGroupBox.TabIndex = 34;
            this.UrgGroupBox.TabStop = false;
            // 
            // vendBox
            // 
            this.vendBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.vendBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vendBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendBox.Location = new System.Drawing.Point(125, 4);
            this.vendBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vendBox.Multiline = true;
            this.vendBox.Name = "vendBox";
            this.vendBox.ReadOnly = true;
            this.vendBox.Size = new System.Drawing.Size(387, 23);
            this.vendBox.TabIndex = 15;
            // 
            // vendTXT
            // 
            this.vendTXT.AutoSize = true;
            this.vendTXT.BackColor = System.Drawing.Color.Transparent;
            this.vendTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendTXT.ForeColor = System.Drawing.Color.RoyalBlue;
            this.vendTXT.Location = new System.Drawing.Point(60, 4);
            this.vendTXT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vendTXT.Name = "vendTXT";
            this.vendTXT.Size = new System.Drawing.Size(65, 17);
            this.vendTXT.TabIndex = 16;
            this.vendTXT.Text = "Vendor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(521, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Product:";
            // 
            // productBox
            // 
            this.productBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.productBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.productBox.Location = new System.Drawing.Point(603, -2);
            this.productBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productBox.Multiline = true;
            this.productBox.Name = "productBox";
            this.productBox.ReadOnly = true;
            this.productBox.Size = new System.Drawing.Size(93, 28);
            this.productBox.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(727, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Serial:";
            // 
            // serialBox
            // 
            this.serialBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.serialBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serialBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.serialBox.Location = new System.Drawing.Point(785, -2);
            this.serialBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.serialBox.Multiline = true;
            this.serialBox.Name = "serialBox";
            this.serialBox.ReadOnly = true;
            this.serialBox.Size = new System.Drawing.Size(120, 28);
            this.serialBox.TabIndex = 30;
            // 
            // SendDataGroupbox
            // 
            this.SendDataGroupbox.Controls.Add(this.textTBox);
            this.SendDataGroupbox.Controls.Add(this.sendDataButton);
            this.SendDataGroupbox.Controls.Add(this.inputText);
            this.SendDataGroupbox.Enabled = false;
            this.SendDataGroupbox.Location = new System.Drawing.Point(16, 665);
            this.SendDataGroupbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SendDataGroupbox.Name = "SendDataGroupbox";
            this.SendDataGroupbox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SendDataGroupbox.Size = new System.Drawing.Size(796, 57);
            this.SendDataGroupbox.TabIndex = 35;
            this.SendDataGroupbox.TabStop = false;
            // 
            // SerialCommunicationForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1293, 800);
            this.Controls.Add(this.SendDataGroupbox);
            this.Controls.Add(this.UrgGroupBox);
            this.Controls.Add(this.ConnectToURGGroupbox);
            this.Controls.Add(this.received);
            this.Controls.Add(this.MDGroup);
            this.Controls.Add(this.commandListGroup);
            this.Controls.Add(this.settingGroup);
            this.Controls.Add(this.countGroup);
            this.Controls.Add(this.textRBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1293, 800);
            this.MinimumSize = new System.Drawing.Size(1293, 800);
            this.Name = "SerialCommunicationForm";
            this.Text = "SerialCommunicationForm";
            this.Leave += new System.EventHandler(this.SerialCommunicationForm_Leave);
            this.countGroup.ResumeLayout(false);
            this.countGroup.PerformLayout();
            this.MDGroup.ResumeLayout(false);
            this.MDGroup.PerformLayout();
            this.settingGroup.ResumeLayout(false);
            this.settingGroup.PerformLayout();
            this.commandListGroup.ResumeLayout(false);
            this.ConnectToURGGroupbox.ResumeLayout(false);
            this.UrgGroupBox.ResumeLayout(false);
            this.UrgGroupBox.PerformLayout();
            this.SendDataGroupbox.ResumeLayout(false);
            this.SendDataGroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textRBox;
        private System.Windows.Forms.TextBox textTBox;
        private System.Windows.Forms.Button sendDataButton;
        private System.Windows.Forms.GroupBox countGroup;
        private System.Windows.Forms.Label OuputTXT;
        private System.Windows.Forms.TextBox dataOutValue;
        private System.Windows.Forms.Label inputTXT;
        private System.Windows.Forms.TextBox dataInValue;
        private System.Windows.Forms.GroupBox MDGroup;
        private System.Windows.Forms.Label clousterTXT;
        private System.Windows.Forms.TextBox clousterBox;
        private System.Windows.Forms.Label endTXT;
        private System.Windows.Forms.TextBox endBox;
        private System.Windows.Forms.TextBox startingBox;
        private System.Windows.Forms.GroupBox settingGroup;
        private System.Windows.Forms.CheckBox savedataCheck;
        public System.Windows.Forms.CheckBox deleteinputCheck;
        private System.Windows.Forms.CheckBox sendEnterCheck;
        private System.Windows.Forms.CheckBox decodeCheck;
        private System.Windows.Forms.GroupBox commandListGroup;
        private System.Windows.Forms.Button HSButton;
        private System.Windows.Forms.Button MDButton;
        private System.Windows.Forms.Button BMButton;
        private System.Windows.Forms.Button RSButton;
        private System.Windows.Forms.Button IIButton;
        private System.Windows.Forms.Button VVButton;
        private System.Windows.Forms.Label inputText;
        private System.Windows.Forms.Label received;
        private System.Windows.Forms.GroupBox ConnectToURGGroupbox;
        private System.Windows.Forms.Button connectToURGButton;
        private System.Windows.Forms.GroupBox UrgGroupBox;
        private System.Windows.Forms.Label vendTXT;
        private System.Windows.Forms.TextBox vendBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox productBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serialBox;
        private System.Windows.Forms.GroupBox SendDataGroupbox;
        private System.Windows.Forms.Label startingTXT;
    }
}