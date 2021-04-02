namespace NetAdapter
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxLogArea = new System.Windows.Forms.RichTextBox();
            this.statusStripLog = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPublicIP = new System.Windows.Forms.TextBox();
            this.textBoxHostname = new System.Windows.Forms.TextBox();
            this.textBoxLocalIP = new System.Windows.Forms.TextBox();
            this.textBoxMac = new System.Windows.Forms.TextBox();
            this.textBoxDefaultGW = new System.Windows.Forms.TextBox();
            this.textBoxDNS = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxSubnet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.comboBoxAdapters = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelWarning = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelDonate = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbRenewDHCP = new System.Windows.Forms.CheckBox();
            this.cbClearHosts = new System.Windows.Forms.CheckBox();
            this.cbSetDHCP = new System.Windows.Forms.CheckBox();
            this.cbGoogleDNS = new System.Windows.Forms.CheckBox();
            this.cbFlushDNS = new System.Windows.Forms.CheckBox();
            this.cbClearARP = new System.Windows.Forms.CheckBox();
            this.cbReloadNETBIOS = new System.Windows.Forms.CheckBox();
            this.cbClearSSL = new System.Windows.Forms.CheckBox();
            this.cbEnableLAN = new System.Windows.Forms.CheckBox();
            this.cbEnableWireless = new System.Windows.Forms.CheckBox();
            this.cbResetInternetSecurity = new System.Windows.Forms.CheckBox();
            this.cbServicesDefault = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNetworkStats = new System.Windows.Forms.Label();
            this.textBoxDHCP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonSpoof = new System.Windows.Forms.Button();
            this.buttonViewHosts = new System.Windows.Forms.Button();
            this.buttonPingDNS = new System.Windows.Forms.Button();
            this.buttonPingIP = new System.Windows.Forms.Button();
            this.buttonResetStats = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonRunAll = new System.Windows.Forms.Button();
            this.buttonServicesDefault = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonResetInternetSecurity = new System.Windows.Forms.Button();
            this.buttonEnableWireless = new System.Windows.Forms.Button();
            this.buttonEnableLAN = new System.Windows.Forms.Button();
            this.buttonClearSSL = new System.Windows.Forms.Button();
            this.buttonReloadNETBIOS = new System.Windows.Forms.Button();
            this.buttonClearARP = new System.Windows.Forms.Button();
            this.buttonFlushDNS = new System.Windows.Forms.Button();
            this.buttonGoogleDNS = new System.Windows.Forms.Button();
            this.buttonSetDHCP = new System.Windows.Forms.Button();
            this.buttonClearHosts = new System.Windows.Forms.Button();
            this.buttonRenewDHCP = new System.Windows.Forms.Button();
            this.buttonRepair = new System.Windows.Forms.Button();
            this.statusStripLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(271, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Current Network Settings";
            // 
            // richTextBoxLogArea
            // 
            this.richTextBoxLogArea.Location = new System.Drawing.Point(271, 388);
            this.richTextBoxLogArea.Name = "richTextBoxLogArea";
            this.richTextBoxLogArea.ReadOnly = true;
            this.richTextBoxLogArea.Size = new System.Drawing.Size(390, 166);
            this.richTextBoxLogArea.TabIndex = 12;
            this.richTextBoxLogArea.Text = "";
            // 
            // statusStripLog
            // 
            this.statusStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStripLog.Location = new System.Drawing.Point(0, 584);
            this.statusStripLog.Name = "statusStripLog";
            this.statusStripLog.Size = new System.Drawing.Size(667, 22);
            this.statusStripLog.SizingGrip = false;
            this.statusStripLog.TabIndex = 14;
            this.statusStripLog.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(159, 17);
            this.toolStripStatusLabel.Text = "NetAdapter Repair All in One";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Public IP Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Computer Host Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Local IP Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "MAC Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(271, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Default Gateway";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 313);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "DNS Servers";
            // 
            // textBoxPublicIP
            // 
            this.textBoxPublicIP.Location = new System.Drawing.Point(385, 153);
            this.textBoxPublicIP.Name = "textBoxPublicIP";
            this.textBoxPublicIP.ReadOnly = true;
            this.textBoxPublicIP.Size = new System.Drawing.Size(276, 20);
            this.textBoxPublicIP.TabIndex = 21;
            // 
            // textBoxHostname
            // 
            this.textBoxHostname.Location = new System.Drawing.Point(385, 179);
            this.textBoxHostname.Name = "textBoxHostname";
            this.textBoxHostname.ReadOnly = true;
            this.textBoxHostname.Size = new System.Drawing.Size(276, 20);
            this.textBoxHostname.TabIndex = 22;
            // 
            // textBoxLocalIP
            // 
            this.textBoxLocalIP.Location = new System.Drawing.Point(385, 232);
            this.textBoxLocalIP.Name = "textBoxLocalIP";
            this.textBoxLocalIP.ReadOnly = true;
            this.textBoxLocalIP.Size = new System.Drawing.Size(276, 20);
            this.textBoxLocalIP.TabIndex = 23;
            // 
            // textBoxMac
            // 
            this.textBoxMac.Location = new System.Drawing.Point(385, 258);
            this.textBoxMac.Name = "textBoxMac";
            this.textBoxMac.ReadOnly = true;
            this.textBoxMac.Size = new System.Drawing.Size(212, 20);
            this.textBoxMac.TabIndex = 24;
            // 
            // textBoxDefaultGW
            // 
            this.textBoxDefaultGW.Location = new System.Drawing.Point(385, 284);
            this.textBoxDefaultGW.Name = "textBoxDefaultGW";
            this.textBoxDefaultGW.ReadOnly = true;
            this.textBoxDefaultGW.Size = new System.Drawing.Size(276, 20);
            this.textBoxDefaultGW.TabIndex = 25;
            // 
            // textBoxDNS
            // 
            this.textBoxDNS.Location = new System.Drawing.Point(385, 310);
            this.textBoxDNS.Name = "textBoxDNS";
            this.textBoxDNS.ReadOnly = true;
            this.textBoxDNS.Size = new System.Drawing.Size(276, 20);
            this.textBoxDNS.TabIndex = 26;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 100;
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            // 
            // textBoxSubnet
            // 
            this.textBoxSubnet.Location = new System.Drawing.Point(385, 362);
            this.textBoxSubnet.Name = "textBoxSubnet";
            this.textBoxSubnet.ReadOnly = true;
            this.textBoxSubnet.Size = new System.Drawing.Size(276, 20);
            this.textBoxSubnet.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Subnet Mask";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCopyright.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelCopyright.Location = new System.Drawing.Point(522, 588);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(96, 13);
            this.labelCopyright.TabIndex = 40;
            this.labelCopyright.Text = "www.connerb.com";
            this.labelCopyright.Click += new System.EventHandler(this.labelCopyright_Click);
            // 
            // comboBoxAdapters
            // 
            this.comboBoxAdapters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdapters.FormattingEnabled = true;
            this.comboBoxAdapters.Location = new System.Drawing.Point(385, 205);
            this.comboBoxAdapters.Name = "comboBoxAdapters";
            this.comboBoxAdapters.Size = new System.Drawing.Size(276, 21);
            this.comboBoxAdapters.TabIndex = 41;
            this.comboBoxAdapters.SelectedValueChanged += new System.EventHandler(this.comboBoxAdapters_SelectedValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(271, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Network Adapter";
            // 
            // labelWarning
            // 
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(154, 106);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(510, 19);
            this.labelWarning.TabIndex = 43;
            this.labelWarning.Text = "Warning Line";
            this.labelWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(433, 588);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Conner Bernhard |";
            // 
            // timer1
            // 
            this.timer1.Interval = 550;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelDonate
            // 
            this.labelDonate.AutoSize = true;
            this.labelDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDonate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDonate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelDonate.Location = new System.Drawing.Point(621, 588);
            this.labelDonate.Name = "labelDonate";
            this.labelDonate.Size = new System.Drawing.Size(42, 13);
            this.labelDonate.TabIndex = 45;
            this.labelDonate.Text = "Donate";
            this.labelDonate.Click += new System.EventHandler(this.labelDonate_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(615, 589);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(9, 13);
            this.label13.TabIndex = 46;
            this.label13.Text = "|";
            // 
            // cbRenewDHCP
            // 
            this.cbRenewDHCP.AutoSize = true;
            this.cbRenewDHCP.Location = new System.Drawing.Point(12, 208);
            this.cbRenewDHCP.Name = "cbRenewDHCP";
            this.cbRenewDHCP.Size = new System.Drawing.Size(15, 14);
            this.cbRenewDHCP.TabIndex = 47;
            this.cbRenewDHCP.UseVisualStyleBackColor = true;
            // 
            // cbClearHosts
            // 
            this.cbClearHosts.AutoSize = true;
            this.cbClearHosts.Location = new System.Drawing.Point(12, 238);
            this.cbClearHosts.Name = "cbClearHosts";
            this.cbClearHosts.Size = new System.Drawing.Size(15, 14);
            this.cbClearHosts.TabIndex = 48;
            this.cbClearHosts.UseVisualStyleBackColor = true;
            // 
            // cbSetDHCP
            // 
            this.cbSetDHCP.AutoSize = true;
            this.cbSetDHCP.Location = new System.Drawing.Point(12, 267);
            this.cbSetDHCP.Name = "cbSetDHCP";
            this.cbSetDHCP.Size = new System.Drawing.Size(15, 14);
            this.cbSetDHCP.TabIndex = 49;
            this.cbSetDHCP.UseVisualStyleBackColor = true;
            // 
            // cbGoogleDNS
            // 
            this.cbGoogleDNS.AutoSize = true;
            this.cbGoogleDNS.Location = new System.Drawing.Point(12, 296);
            this.cbGoogleDNS.Name = "cbGoogleDNS";
            this.cbGoogleDNS.Size = new System.Drawing.Size(15, 14);
            this.cbGoogleDNS.TabIndex = 50;
            this.cbGoogleDNS.UseVisualStyleBackColor = true;
            // 
            // cbFlushDNS
            // 
            this.cbFlushDNS.AutoSize = true;
            this.cbFlushDNS.Location = new System.Drawing.Point(12, 325);
            this.cbFlushDNS.Name = "cbFlushDNS";
            this.cbFlushDNS.Size = new System.Drawing.Size(15, 14);
            this.cbFlushDNS.TabIndex = 51;
            this.cbFlushDNS.UseVisualStyleBackColor = true;
            // 
            // cbClearARP
            // 
            this.cbClearARP.AutoSize = true;
            this.cbClearARP.Location = new System.Drawing.Point(12, 354);
            this.cbClearARP.Name = "cbClearARP";
            this.cbClearARP.Size = new System.Drawing.Size(15, 14);
            this.cbClearARP.TabIndex = 52;
            this.cbClearARP.UseVisualStyleBackColor = true;
            // 
            // cbReloadNETBIOS
            // 
            this.cbReloadNETBIOS.AutoSize = true;
            this.cbReloadNETBIOS.Location = new System.Drawing.Point(12, 383);
            this.cbReloadNETBIOS.Name = "cbReloadNETBIOS";
            this.cbReloadNETBIOS.Size = new System.Drawing.Size(15, 14);
            this.cbReloadNETBIOS.TabIndex = 53;
            this.cbReloadNETBIOS.UseVisualStyleBackColor = true;
            // 
            // cbClearSSL
            // 
            this.cbClearSSL.AutoSize = true;
            this.cbClearSSL.Location = new System.Drawing.Point(12, 412);
            this.cbClearSSL.Name = "cbClearSSL";
            this.cbClearSSL.Size = new System.Drawing.Size(15, 14);
            this.cbClearSSL.TabIndex = 54;
            this.cbClearSSL.UseVisualStyleBackColor = true;
            // 
            // cbEnableLAN
            // 
            this.cbEnableLAN.AutoSize = true;
            this.cbEnableLAN.Location = new System.Drawing.Point(12, 441);
            this.cbEnableLAN.Name = "cbEnableLAN";
            this.cbEnableLAN.Size = new System.Drawing.Size(15, 14);
            this.cbEnableLAN.TabIndex = 55;
            this.cbEnableLAN.UseVisualStyleBackColor = true;
            // 
            // cbEnableWireless
            // 
            this.cbEnableWireless.AutoSize = true;
            this.cbEnableWireless.Location = new System.Drawing.Point(12, 470);
            this.cbEnableWireless.Name = "cbEnableWireless";
            this.cbEnableWireless.Size = new System.Drawing.Size(15, 14);
            this.cbEnableWireless.TabIndex = 56;
            this.cbEnableWireless.UseVisualStyleBackColor = true;
            // 
            // cbResetInternetSecurity
            // 
            this.cbResetInternetSecurity.AutoSize = true;
            this.cbResetInternetSecurity.Location = new System.Drawing.Point(12, 499);
            this.cbResetInternetSecurity.Name = "cbResetInternetSecurity";
            this.cbResetInternetSecurity.Size = new System.Drawing.Size(15, 14);
            this.cbResetInternetSecurity.TabIndex = 57;
            this.cbResetInternetSecurity.UseVisualStyleBackColor = true;
            // 
            // cbServicesDefault
            // 
            this.cbServicesDefault.AutoSize = true;
            this.cbServicesDefault.Location = new System.Drawing.Point(12, 529);
            this.cbServicesDefault.Name = "cbServicesDefault";
            this.cbServicesDefault.Size = new System.Drawing.Size(15, 14);
            this.cbServicesDefault.TabIndex = 60;
            this.cbServicesDefault.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Additional Tools";
            // 
            // labelNetworkStats
            // 
            this.labelNetworkStats.Location = new System.Drawing.Point(271, 557);
            this.labelNetworkStats.Name = "labelNetworkStats";
            this.labelNetworkStats.Size = new System.Drawing.Size(353, 20);
            this.labelNetworkStats.TabIndex = 63;
            this.labelNetworkStats.Text = "Sent: 0KB / 0MB | Received: 0KB / 0MB";
            this.labelNetworkStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDHCP
            // 
            this.textBoxDHCP.Location = new System.Drawing.Point(385, 336);
            this.textBoxDHCP.Name = "textBoxDHCP";
            this.textBoxDHCP.ReadOnly = true;
            this.textBoxDHCP.Size = new System.Drawing.Size(276, 20);
            this.textBoxDHCP.TabIndex = 66;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(271, 339);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 65;
            this.label12.Text = "DHCP Server";
            // 
            // buttonSpoof
            // 
            this.buttonSpoof.AutoSize = true;
            this.buttonSpoof.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSpoof.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSpoof.Image = global::NetAdapter.Properties.Resources.spoof_mac;
            this.buttonSpoof.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSpoof.Location = new System.Drawing.Point(603, 257);
            this.buttonSpoof.Name = "buttonSpoof";
            this.buttonSpoof.Size = new System.Drawing.Size(61, 24);
            this.buttonSpoof.TabIndex = 70;
            this.buttonSpoof.Text = "Spoof";
            this.buttonSpoof.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSpoof.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSpoof.UseVisualStyleBackColor = true;
            this.buttonSpoof.Click += new System.EventHandler(this.buttonSpoof_Click);
            // 
            // buttonViewHosts
            // 
            this.buttonViewHosts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonViewHosts.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonViewHosts.Image = global::NetAdapter.Properties.Resources.host_view;
            this.buttonViewHosts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonViewHosts.Location = new System.Drawing.Point(185, 233);
            this.buttonViewHosts.Name = "buttonViewHosts";
            this.buttonViewHosts.Size = new System.Drawing.Size(80, 24);
            this.buttonViewHosts.TabIndex = 69;
            this.buttonViewHosts.Text = "View";
            this.buttonViewHosts.UseVisualStyleBackColor = true;
            this.buttonViewHosts.Click += new System.EventHandler(this.buttonViewHosts_Click);
            // 
            // buttonPingDNS
            // 
            this.buttonPingDNS.AutoSize = true;
            this.buttonPingDNS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPingDNS.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonPingDNS.Image = global::NetAdapter.Properties.Resources.ping_dns;
            this.buttonPingDNS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPingDNS.Location = new System.Drawing.Point(530, 128);
            this.buttonPingDNS.Name = "buttonPingDNS";
            this.buttonPingDNS.Size = new System.Drawing.Size(80, 24);
            this.buttonPingDNS.TabIndex = 68;
            this.buttonPingDNS.Text = "Ping DNS";
            this.buttonPingDNS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPingDNS.UseVisualStyleBackColor = true;
            this.buttonPingDNS.Click += new System.EventHandler(this.buttonPingDNS_Click);
            // 
            // buttonPingIP
            // 
            this.buttonPingIP.AutoSize = true;
            this.buttonPingIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPingIP.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonPingIP.Image = global::NetAdapter.Properties.Resources.ping_ip;
            this.buttonPingIP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPingIP.Location = new System.Drawing.Point(457, 128);
            this.buttonPingIP.Name = "buttonPingIP";
            this.buttonPingIP.Size = new System.Drawing.Size(67, 24);
            this.buttonPingIP.TabIndex = 67;
            this.buttonPingIP.Text = "Ping IP";
            this.buttonPingIP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPingIP.UseVisualStyleBackColor = true;
            this.buttonPingIP.Click += new System.EventHandler(this.buttonPingIP_Click);
            // 
            // buttonResetStats
            // 
            this.buttonResetStats.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonResetStats.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonResetStats.Image = global::NetAdapter.Properties.Resources.clear_monitor_output;
            this.buttonResetStats.Location = new System.Drawing.Point(633, 555);
            this.buttonResetStats.Name = "buttonResetStats";
            this.buttonResetStats.Size = new System.Drawing.Size(28, 24);
            this.buttonResetStats.TabIndex = 64;
            this.buttonResetStats.UseVisualStyleBackColor = true;
            this.buttonResetStats.Click += new System.EventHandler(this.buttonResetStats_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRefresh.Image = global::NetAdapter.Properties.Resources.refresh_network1;
            this.buttonRefresh.Location = new System.Drawing.Point(633, 128);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(28, 24);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonRunAll
            // 
            this.buttonRunAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRunAll.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRunAll.Image = global::NetAdapter.Properties.Resources.run_all1;
            this.buttonRunAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRunAll.Location = new System.Drawing.Point(29, 553);
            this.buttonRunAll.Name = "buttonRunAll";
            this.buttonRunAll.Size = new System.Drawing.Size(236, 24);
            this.buttonRunAll.TabIndex = 61;
            this.buttonRunAll.Text = "Run All Selected";
            this.buttonRunAll.UseVisualStyleBackColor = true;
            this.buttonRunAll.Click += new System.EventHandler(this.buttonRunAll_Click);
            // 
            // buttonServicesDefault
            // 
            this.buttonServicesDefault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonServicesDefault.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonServicesDefault.Image = global::NetAdapter.Properties.Resources.windows_services;
            this.buttonServicesDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonServicesDefault.Location = new System.Drawing.Point(29, 523);
            this.buttonServicesDefault.Name = "buttonServicesDefault";
            this.buttonServicesDefault.Size = new System.Drawing.Size(236, 24);
            this.buttonServicesDefault.TabIndex = 59;
            this.buttonServicesDefault.Text = "Set Network Windows Services Default";
            this.buttonServicesDefault.UseVisualStyleBackColor = true;
            this.buttonServicesDefault.Click += new System.EventHandler(this.buttonServicesDefault_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NetAdapter.Properties.Resources.bannerlogo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(667, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // buttonResetInternetSecurity
            // 
            this.buttonResetInternetSecurity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonResetInternetSecurity.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonResetInternetSecurity.Image = global::NetAdapter.Properties.Resources.reset_securityprivacy;
            this.buttonResetInternetSecurity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonResetInternetSecurity.Location = new System.Drawing.Point(29, 493);
            this.buttonResetInternetSecurity.Name = "buttonResetInternetSecurity";
            this.buttonResetInternetSecurity.Size = new System.Drawing.Size(236, 24);
            this.buttonResetInternetSecurity.TabIndex = 36;
            this.buttonResetInternetSecurity.Text = "Reset Internet Options Security/Privacy";
            this.buttonResetInternetSecurity.UseVisualStyleBackColor = true;
            this.buttonResetInternetSecurity.Click += new System.EventHandler(this.buttonResetInternetSecurity_Click);
            // 
            // buttonEnableWireless
            // 
            this.buttonEnableWireless.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEnableWireless.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEnableWireless.Image = global::NetAdapter.Properties.Resources.enable_wifi;
            this.buttonEnableWireless.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEnableWireless.Location = new System.Drawing.Point(29, 464);
            this.buttonEnableWireless.Name = "buttonEnableWireless";
            this.buttonEnableWireless.Size = new System.Drawing.Size(236, 24);
            this.buttonEnableWireless.TabIndex = 35;
            this.buttonEnableWireless.Text = "Enable Wireless Adapters";
            this.buttonEnableWireless.UseVisualStyleBackColor = true;
            this.buttonEnableWireless.Click += new System.EventHandler(this.buttonEnableWireless_Click);
            // 
            // buttonEnableLAN
            // 
            this.buttonEnableLAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEnableLAN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEnableLAN.Image = global::NetAdapter.Properties.Resources.enable_lan;
            this.buttonEnableLAN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEnableLAN.Location = new System.Drawing.Point(29, 435);
            this.buttonEnableLAN.Name = "buttonEnableLAN";
            this.buttonEnableLAN.Size = new System.Drawing.Size(236, 24);
            this.buttonEnableLAN.TabIndex = 34;
            this.buttonEnableLAN.Text = "Enable LAN Adapters";
            this.buttonEnableLAN.UseVisualStyleBackColor = true;
            this.buttonEnableLAN.Click += new System.EventHandler(this.buttonEnableLAN_Click);
            // 
            // buttonClearSSL
            // 
            this.buttonClearSSL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearSSL.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClearSSL.Image = global::NetAdapter.Properties.Resources.clear_ssl;
            this.buttonClearSSL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClearSSL.Location = new System.Drawing.Point(29, 406);
            this.buttonClearSSL.Name = "buttonClearSSL";
            this.buttonClearSSL.Size = new System.Drawing.Size(236, 24);
            this.buttonClearSSL.TabIndex = 33;
            this.buttonClearSSL.Text = "Internet Options - Clear SSL State";
            this.buttonClearSSL.UseVisualStyleBackColor = true;
            this.buttonClearSSL.Click += new System.EventHandler(this.buttonClearSSL_Click);
            // 
            // buttonReloadNETBIOS
            // 
            this.buttonReloadNETBIOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReloadNETBIOS.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonReloadNETBIOS.Image = global::NetAdapter.Properties.Resources.netbios_reload;
            this.buttonReloadNETBIOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReloadNETBIOS.Location = new System.Drawing.Point(29, 377);
            this.buttonReloadNETBIOS.Name = "buttonReloadNETBIOS";
            this.buttonReloadNETBIOS.Size = new System.Drawing.Size(236, 24);
            this.buttonReloadNETBIOS.TabIndex = 32;
            this.buttonReloadNETBIOS.Text = "NetBIOS Reload and Release";
            this.buttonReloadNETBIOS.UseVisualStyleBackColor = true;
            this.buttonReloadNETBIOS.Click += new System.EventHandler(this.buttonReloadNETBIOS_Click);
            // 
            // buttonClearARP
            // 
            this.buttonClearARP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearARP.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClearARP.Image = global::NetAdapter.Properties.Resources.arproute_clear;
            this.buttonClearARP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClearARP.Location = new System.Drawing.Point(29, 348);
            this.buttonClearARP.Name = "buttonClearARP";
            this.buttonClearARP.Size = new System.Drawing.Size(236, 24);
            this.buttonClearARP.TabIndex = 31;
            this.buttonClearARP.Text = "Clear ARP/Route Table";
            this.buttonClearARP.UseVisualStyleBackColor = true;
            this.buttonClearARP.Click += new System.EventHandler(this.buttonClearARP_Click);
            // 
            // buttonFlushDNS
            // 
            this.buttonFlushDNS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFlushDNS.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonFlushDNS.Image = global::NetAdapter.Properties.Resources.dns_flush;
            this.buttonFlushDNS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFlushDNS.Location = new System.Drawing.Point(29, 319);
            this.buttonFlushDNS.Name = "buttonFlushDNS";
            this.buttonFlushDNS.Size = new System.Drawing.Size(236, 24);
            this.buttonFlushDNS.TabIndex = 30;
            this.buttonFlushDNS.Text = "Flush DNS Cache";
            this.buttonFlushDNS.UseVisualStyleBackColor = true;
            this.buttonFlushDNS.Click += new System.EventHandler(this.buttonFlushDNS_Click);
            // 
            // buttonGoogleDNS
            // 
            this.buttonGoogleDNS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGoogleDNS.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonGoogleDNS.Image = global::NetAdapter.Properties.Resources.google_dns;
            this.buttonGoogleDNS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGoogleDNS.Location = new System.Drawing.Point(29, 290);
            this.buttonGoogleDNS.Name = "buttonGoogleDNS";
            this.buttonGoogleDNS.Size = new System.Drawing.Size(236, 24);
            this.buttonGoogleDNS.TabIndex = 29;
            this.buttonGoogleDNS.Text = "Change to Google DNS";
            this.buttonGoogleDNS.UseVisualStyleBackColor = true;
            this.buttonGoogleDNS.Click += new System.EventHandler(this.buttonGoogleDNS_Click);
            // 
            // buttonSetDHCP
            // 
            this.buttonSetDHCP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSetDHCP.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSetDHCP.Image = global::NetAdapter.Properties.Resources.clear_static;
            this.buttonSetDHCP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSetDHCP.Location = new System.Drawing.Point(29, 261);
            this.buttonSetDHCP.Name = "buttonSetDHCP";
            this.buttonSetDHCP.Size = new System.Drawing.Size(236, 24);
            this.buttonSetDHCP.TabIndex = 28;
            this.buttonSetDHCP.Text = "Clear Static IP Settings (enable DHCP)";
            this.buttonSetDHCP.UseVisualStyleBackColor = true;
            this.buttonSetDHCP.Click += new System.EventHandler(this.buttonSetDHCP_Click);
            // 
            // buttonClearHosts
            // 
            this.buttonClearHosts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearHosts.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClearHosts.Image = global::NetAdapter.Properties.Resources.clear_host1;
            this.buttonClearHosts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClearHosts.Location = new System.Drawing.Point(29, 232);
            this.buttonClearHosts.Name = "buttonClearHosts";
            this.buttonClearHosts.Size = new System.Drawing.Size(150, 24);
            this.buttonClearHosts.TabIndex = 27;
            this.buttonClearHosts.Text = "Clear Hosts File";
            this.buttonClearHosts.UseVisualStyleBackColor = true;
            this.buttonClearHosts.Click += new System.EventHandler(this.buttonClearHosts_Click);
            // 
            // buttonRenewDHCP
            // 
            this.buttonRenewDHCP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRenewDHCP.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRenewDHCP.Image = global::NetAdapter.Properties.Resources.release_renew;
            this.buttonRenewDHCP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRenewDHCP.Location = new System.Drawing.Point(29, 203);
            this.buttonRenewDHCP.Name = "buttonRenewDHCP";
            this.buttonRenewDHCP.Size = new System.Drawing.Size(236, 24);
            this.buttonRenewDHCP.TabIndex = 3;
            this.buttonRenewDHCP.Text = "Release and Renew DHCP Address";
            this.buttonRenewDHCP.UseVisualStyleBackColor = true;
            this.buttonRenewDHCP.Click += new System.EventHandler(this.buttonRenewDHCP_Click);
            // 
            // buttonRepair
            // 
            this.buttonRepair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRepair.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRepair.Image = ((System.Drawing.Image)(resources.GetObject("buttonRepair.Image")));
            this.buttonRepair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRepair.Location = new System.Drawing.Point(12, 135);
            this.buttonRepair.Name = "buttonRepair";
            this.buttonRepair.Size = new System.Drawing.Size(253, 48);
            this.buttonRepair.TabIndex = 1;
            this.buttonRepair.Text = "Advanced Repair";
            this.buttonRepair.Click += new System.EventHandler(this.buttonRepair_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 606);
            this.Controls.Add(this.buttonSpoof);
            this.Controls.Add(this.buttonViewHosts);
            this.Controls.Add(this.buttonPingDNS);
            this.Controls.Add(this.buttonPingIP);
            this.Controls.Add(this.textBoxDHCP);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonResetStats);
            this.Controls.Add(this.labelNetworkStats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRunAll);
            this.Controls.Add(this.cbServicesDefault);
            this.Controls.Add(this.buttonServicesDefault);
            this.Controls.Add(this.cbResetInternetSecurity);
            this.Controls.Add(this.cbEnableWireless);
            this.Controls.Add(this.cbEnableLAN);
            this.Controls.Add(this.cbClearSSL);
            this.Controls.Add(this.cbReloadNETBIOS);
            this.Controls.Add(this.cbClearARP);
            this.Controls.Add(this.cbFlushDNS);
            this.Controls.Add(this.cbGoogleDNS);
            this.Controls.Add(this.cbSetDHCP);
            this.Controls.Add(this.cbClearHosts);
            this.Controls.Add(this.cbRenewDHCP);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.labelDonate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxAdapters);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSubnet);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonResetInternetSecurity);
            this.Controls.Add(this.buttonEnableWireless);
            this.Controls.Add(this.buttonEnableLAN);
            this.Controls.Add(this.buttonClearSSL);
            this.Controls.Add(this.buttonReloadNETBIOS);
            this.Controls.Add(this.buttonClearARP);
            this.Controls.Add(this.buttonFlushDNS);
            this.Controls.Add(this.buttonGoogleDNS);
            this.Controls.Add(this.buttonSetDHCP);
            this.Controls.Add(this.buttonClearHosts);
            this.Controls.Add(this.textBoxDNS);
            this.Controls.Add(this.textBoxDefaultGW);
            this.Controls.Add(this.textBoxMac);
            this.Controls.Add(this.textBoxLocalIP);
            this.Controls.Add(this.textBoxHostname);
            this.Controls.Add(this.textBoxPublicIP);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStripLog);
            this.Controls.Add(this.richTextBoxLogArea);
            this.Controls.Add(this.buttonRenewDHCP);
            this.Controls.Add(this.buttonRepair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "NetAdapter Repair All in One v1.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStripLog.ResumeLayout(false);
            this.statusStripLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRepair;
        private System.Windows.Forms.Button buttonRenewDHCP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.RichTextBox richTextBoxLogArea;
        private System.Windows.Forms.StatusStrip statusStripLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPublicIP;
        private System.Windows.Forms.TextBox textBoxHostname;
        private System.Windows.Forms.TextBox textBoxLocalIP;
        private System.Windows.Forms.TextBox textBoxMac;
        private System.Windows.Forms.TextBox textBoxDefaultGW;
        private System.Windows.Forms.TextBox textBoxDNS;
        private System.Windows.Forms.Button buttonClearHosts;
        private System.Windows.Forms.Button buttonSetDHCP;
        private System.Windows.Forms.Button buttonGoogleDNS;
        private System.Windows.Forms.Button buttonFlushDNS;
        private System.Windows.Forms.Button buttonClearARP;
        private System.Windows.Forms.Button buttonReloadNETBIOS;
        private System.Windows.Forms.Button buttonClearSSL;
        private System.Windows.Forms.Button buttonEnableLAN;
        private System.Windows.Forms.Button buttonEnableWireless;
        private System.Windows.Forms.Button buttonResetInternetSecurity;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox textBoxSubnet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.ComboBox comboBoxAdapters;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelDonate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbRenewDHCP;
        private System.Windows.Forms.CheckBox cbClearHosts;
        private System.Windows.Forms.CheckBox cbSetDHCP;
        private System.Windows.Forms.CheckBox cbGoogleDNS;
        private System.Windows.Forms.CheckBox cbFlushDNS;
        private System.Windows.Forms.CheckBox cbClearARP;
        private System.Windows.Forms.CheckBox cbReloadNETBIOS;
        private System.Windows.Forms.CheckBox cbClearSSL;
        private System.Windows.Forms.CheckBox cbEnableLAN;
        private System.Windows.Forms.CheckBox cbEnableWireless;
        private System.Windows.Forms.CheckBox cbResetInternetSecurity;
        private System.Windows.Forms.CheckBox cbServicesDefault;
        private System.Windows.Forms.Button buttonServicesDefault;
        private System.Windows.Forms.Button buttonRunAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNetworkStats;
        private System.Windows.Forms.Button buttonResetStats;
        private System.Windows.Forms.TextBox textBoxDHCP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonPingIP;
        private System.Windows.Forms.Button buttonPingDNS;
        private System.Windows.Forms.Button buttonViewHosts;
        private System.Windows.Forms.Button buttonSpoof;
    }
}

