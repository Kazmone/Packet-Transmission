
namespace Packet_Lab
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsrPortName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsrPortStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsrConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsrMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsrFileStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenPort = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClosePort = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transmitFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtHexView = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtASCIIView = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radSOHErrorR = new System.Windows.Forms.RadioButton();
            this.radCRCErrorNR = new System.Windows.Forms.RadioButton();
            this.radCRCErrorR = new System.Windows.Forms.RadioButton();
            this.radNoError = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radReceive = new System.Windows.Forms.RadioButton();
            this.radTransmit = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtParity = new System.Windows.Forms.TextBox();
            this.txtStop = new System.Windows.Forms.TextBox();
            this.txtDataBits = new System.Windows.Forms.TextBox();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPortName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsrPortName,
            this.toolStripStatusLabel3,
            this.tsrPortStatus,
            this.toolStripStatusLabel2,
            this.tsrConnectionStatus,
            this.toolStripStatusLabel4,
            this.tsrMode,
            this.toolStripStatusLabel5,
            this.tsrFileStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 492);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1020, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabel1.Text = "Port:";
            // 
            // tsrPortName
            // 
            this.tsrPortName.Name = "tsrPortName";
            this.tsrPortName.Size = new System.Drawing.Size(36, 17);
            this.tsrPortName.Text = "None";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel3.Text = "Port Status:";
            // 
            // tsrPortStatus
            // 
            this.tsrPortStatus.Name = "tsrPortStatus";
            this.tsrPortStatus.Size = new System.Drawing.Size(43, 17);
            this.tsrPortStatus.Text = "Closed";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(111, 17);
            this.toolStripStatusLabel2.Text = "Connection Status:";
            // 
            // tsrConnectionStatus
            // 
            this.tsrConnectionStatus.Name = "tsrConnectionStatus";
            this.tsrConnectionStatus.Size = new System.Drawing.Size(88, 17);
            this.tsrConnectionStatus.Text = "Not Connected";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel4.Text = "Mode:";
            // 
            // tsrMode
            // 
            this.tsrMode.Name = "tsrMode";
            this.tsrMode.Size = new System.Drawing.Size(52, 17);
            this.tsrMode.Text = "Transmit";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabel5.Text = "File:";
            // 
            // tsrFileStatus
            // 
            this.tsrFileStatus.Name = "tsrFileStatus";
            this.tsrFileStatus.Size = new System.Drawing.Size(69, 17);
            this.tsrFileStatus.Text = "Not Loaded";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.portToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.transmitFileToolStripMenuItem,
            this.tsmiClear});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.openFileToolStripMenuItem.Text = "File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConfigure,
            this.tsmiOpenPort,
            this.tsmiClosePort});
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.portToolStripMenuItem.Text = "Port";
            // 
            // tsmiConfigure
            // 
            this.tsmiConfigure.Name = "tsmiConfigure";
            this.tsmiConfigure.Size = new System.Drawing.Size(127, 22);
            this.tsmiConfigure.Text = "Configure";
            this.tsmiConfigure.Click += new System.EventHandler(this.tsmiConfigure_Click);
            // 
            // tsmiOpenPort
            // 
            this.tsmiOpenPort.Name = "tsmiOpenPort";
            this.tsmiOpenPort.Size = new System.Drawing.Size(127, 22);
            this.tsmiOpenPort.Text = "Open";
            this.tsmiOpenPort.Click += new System.EventHandler(this.tsmiOpenPort_Click);
            // 
            // tsmiClosePort
            // 
            this.tsmiClosePort.Name = "tsmiClosePort";
            this.tsmiClosePort.Size = new System.Drawing.Size(127, 22);
            this.tsmiClosePort.Text = "Close";
            this.tsmiClosePort.Click += new System.EventHandler(this.tsmiClosePort_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // transmitFileToolStripMenuItem
            // 
            this.transmitFileToolStripMenuItem.Name = "transmitFileToolStripMenuItem";
            this.transmitFileToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.transmitFileToolStripMenuItem.Text = "Transmit File";
            this.transmitFileToolStripMenuItem.Click += new System.EventHandler(this.transmitFileToolStripMenuItem_Click);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(46, 20);
            this.tsmiClear.Text = "Clear";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtHexView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 468);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtHexView
            // 
            this.txtHexView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHexView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHexView.Location = new System.Drawing.Point(0, 0);
            this.txtHexView.Name = "txtHexView";
            this.txtHexView.Size = new System.Drawing.Size(394, 468);
            this.txtHexView.TabIndex = 1;
            this.txtHexView.Text = "";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtASCIIView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(622, 468);
            this.splitContainer2.SplitterDistance = 389;
            this.splitContainer2.TabIndex = 3;
            // 
            // txtASCIIView
            // 
            this.txtASCIIView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtASCIIView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtASCIIView.Location = new System.Drawing.Point(0, 0);
            this.txtASCIIView.Name = "txtASCIIView";
            this.txtASCIIView.Size = new System.Drawing.Size(389, 468);
            this.txtASCIIView.TabIndex = 2;
            this.txtASCIIView.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radSOHErrorR);
            this.groupBox3.Controls.Add(this.radCRCErrorNR);
            this.groupBox3.Controls.Add(this.radCRCErrorR);
            this.groupBox3.Controls.Add(this.radNoError);
            this.groupBox3.Location = new System.Drawing.Point(3, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 212);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transmission Mode";
            // 
            // radSOHErrorR
            // 
            this.radSOHErrorR.AutoSize = true;
            this.radSOHErrorR.Location = new System.Drawing.Point(6, 89);
            this.radSOHErrorR.Name = "radSOHErrorR";
            this.radSOHErrorR.Size = new System.Drawing.Size(186, 17);
            this.radSOHErrorR.TabIndex = 3;
            this.radSOHErrorR.Text = "Missing SOH Error WIth Recovery";
            this.radSOHErrorR.UseVisualStyleBackColor = true;
            this.radSOHErrorR.CheckedChanged += new System.EventHandler(this.radSOHErrorR_CheckedChanged);
            // 
            // radCRCErrorNR
            // 
            this.radCRCErrorNR.AutoSize = true;
            this.radCRCErrorNR.Location = new System.Drawing.Point(6, 66);
            this.radCRCErrorNR.Name = "radCRCErrorNR";
            this.radCRCErrorNR.Size = new System.Drawing.Size(138, 17);
            this.radCRCErrorNR.TabIndex = 2;
            this.radCRCErrorNR.Text = "CRC Error No Recovery";
            this.radCRCErrorNR.UseVisualStyleBackColor = true;
            this.radCRCErrorNR.CheckedChanged += new System.EventHandler(this.radCRCErrorNR_CheckedChanged);
            // 
            // radCRCErrorR
            // 
            this.radCRCErrorR.AutoSize = true;
            this.radCRCErrorR.Location = new System.Drawing.Point(6, 43);
            this.radCRCErrorR.Name = "radCRCErrorR";
            this.radCRCErrorR.Size = new System.Drawing.Size(146, 17);
            this.radCRCErrorR.TabIndex = 1;
            this.radCRCErrorR.Text = "CRC Error With Recovery";
            this.radCRCErrorR.UseVisualStyleBackColor = true;
            this.radCRCErrorR.CheckedChanged += new System.EventHandler(this.radCRCErrorR_CheckedChanged);
            // 
            // radNoError
            // 
            this.radNoError.AutoSize = true;
            this.radNoError.Checked = true;
            this.radNoError.Location = new System.Drawing.Point(6, 20);
            this.radNoError.Name = "radNoError";
            this.radNoError.Size = new System.Drawing.Size(64, 17);
            this.radNoError.TabIndex = 0;
            this.radNoError.TabStop = true;
            this.radNoError.Text = "No Error";
            this.radNoError.UseVisualStyleBackColor = true;
            this.radNoError.CheckedChanged += new System.EventHandler(this.radNoError_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radReceive);
            this.groupBox2.Controls.Add(this.radTransmit);
            this.groupBox2.Location = new System.Drawing.Point(3, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transmit/Receive";
            // 
            // radReceive
            // 
            this.radReceive.AutoSize = true;
            this.radReceive.Location = new System.Drawing.Point(9, 42);
            this.radReceive.Name = "radReceive";
            this.radReceive.Size = new System.Drawing.Size(65, 17);
            this.radReceive.TabIndex = 1;
            this.radReceive.TabStop = true;
            this.radReceive.Text = "Receive";
            this.radReceive.UseVisualStyleBackColor = true;
            this.radReceive.CheckedChanged += new System.EventHandler(this.radReceive_CheckedChanged);
            // 
            // radTransmit
            // 
            this.radTransmit.AutoSize = true;
            this.radTransmit.Checked = true;
            this.radTransmit.Location = new System.Drawing.Point(9, 19);
            this.radTransmit.Name = "radTransmit";
            this.radTransmit.Size = new System.Drawing.Size(65, 17);
            this.radTransmit.TabIndex = 0;
            this.radTransmit.TabStop = true;
            this.radTransmit.Text = "Transmit";
            this.radTransmit.UseVisualStyleBackColor = true;
            this.radTransmit.CheckedChanged += new System.EventHandler(this.radTransmit_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtParity);
            this.groupBox1.Controls.Add(this.txtStop);
            this.groupBox1.Controls.Add(this.txtDataBits);
            this.groupBox1.Controls.Add(this.txtBaudRate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPortName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // txtParity
            // 
            this.txtParity.Location = new System.Drawing.Point(74, 121);
            this.txtParity.Name = "txtParity";
            this.txtParity.ReadOnly = true;
            this.txtParity.Size = new System.Drawing.Size(103, 20);
            this.txtParity.TabIndex = 9;
            // 
            // txtStop
            // 
            this.txtStop.Location = new System.Drawing.Point(74, 95);
            this.txtStop.Name = "txtStop";
            this.txtStop.ReadOnly = true;
            this.txtStop.Size = new System.Drawing.Size(103, 20);
            this.txtStop.TabIndex = 8;
            // 
            // txtDataBits
            // 
            this.txtDataBits.Location = new System.Drawing.Point(74, 69);
            this.txtDataBits.Name = "txtDataBits";
            this.txtDataBits.ReadOnly = true;
            this.txtDataBits.Size = new System.Drawing.Size(103, 20);
            this.txtDataBits.TabIndex = 7;
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(74, 43);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.ReadOnly = true;
            this.txtBaudRate.Size = new System.Drawing.Size(103, 20);
            this.txtBaudRate.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Parity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Stop Bits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data Bits:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate:";
            // 
            // txtPortName
            // 
            this.txtPortName.Location = new System.Drawing.Point(74, 17);
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.ReadOnly = true;
            this.txtPortName.Size = new System.Drawing.Size(103, 20);
            this.txtPortName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 514);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Packet Transmission ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtHexView;
        private System.Windows.Forms.RichTextBox txtASCIIView;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfigure;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenPort;
        private System.Windows.Forms.ToolStripMenuItem tsmiClosePort;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel tsrPortName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsrPortStatus;
        private System.Windows.Forms.TextBox txtParity;
        private System.Windows.Forms.TextBox txtStop;
        private System.Windows.Forms.TextBox txtDataBits;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radReceive;
        private System.Windows.Forms.RadioButton radTransmit;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsrConnectionStatus;
        private System.Windows.Forms.ToolStripMenuItem transmitFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsrMode;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tsrFileStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radSOHErrorR;
        private System.Windows.Forms.RadioButton radCRCErrorNR;
        private System.Windows.Forms.RadioButton radCRCErrorR;
        private System.Windows.Forms.RadioButton radNoError;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
    }
}

