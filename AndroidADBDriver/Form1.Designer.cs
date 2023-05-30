namespace AndroidADBDriver
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCheckDevices = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGetDeviceInfo = new System.Windows.Forms.Button();
            this.btnRunSMSService = new System.Windows.Forms.Button();
            this.btnSearchAppProcess = new System.Windows.Forms.Button();
            this.btnGetUsbSerialNumber = new System.Windows.Forms.Button();
            this.btnCheckAppid = new System.Windows.Forms.Button();
            this.btnKillServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.btnStartCheck = new System.Windows.Forms.Button();
            this.tbSendMsg = new System.Windows.Forms.TextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUSBListen = new System.Windows.Forms.Button();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckDevices
            // 
            this.btnCheckDevices.Location = new System.Drawing.Point(199, 45);
            this.btnCheckDevices.Name = "btnCheckDevices";
            this.btnCheckDevices.Size = new System.Drawing.Size(89, 23);
            this.btnCheckDevices.TabIndex = 0;
            this.btnCheckDevices.Text = "检查设备信息";
            this.btnCheckDevices.UseVisualStyleBackColor = true;
            this.btnCheckDevices.Click += new System.EventHandler(this.btnCheckDevice_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(13, 13);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(371, 273);
            this.txtInfo.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExcute);
            this.groupBox1.Controls.Add(this.tbCommand);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 141);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自定义命令";
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(168, 101);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 23);
            this.btnExcute.TabIndex = 1;
            this.btnExcute.Text = "执行命令";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(7, 21);
            this.tbCommand.Multiline = true;
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(400, 61);
            this.tbCommand.TabIndex = 0;
            this.tbCommand.Text = "kill-server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGetDeviceInfo);
            this.groupBox2.Controls.Add(this.btnRunSMSService);
            this.groupBox2.Controls.Add(this.btnSearchAppProcess);
            this.groupBox2.Controls.Add(this.btnGetUsbSerialNumber);
            this.groupBox2.Controls.Add(this.btnCheckAppid);
            this.groupBox2.Controls.Add(this.btnKillServer);
            this.groupBox2.Controls.Add(this.btnStartServer);
            this.groupBox2.Controls.Add(this.btnCheckDevices);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 219);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实例命令展示";
            // 
            // btnGetDeviceInfo
            // 
            this.btnGetDeviceInfo.Location = new System.Drawing.Point(199, 140);
            this.btnGetDeviceInfo.Name = "btnGetDeviceInfo";
            this.btnGetDeviceInfo.Size = new System.Drawing.Size(186, 23);
            this.btnGetDeviceInfo.TabIndex = 7;
            this.btnGetDeviceInfo.Text = "读取设备信息、系统信息\n";
            this.btnGetDeviceInfo.UseVisualStyleBackColor = true;
            this.btnGetDeviceInfo.Click += new System.EventHandler(this.btnGetDeviceInfo_Click);
            // 
            // btnRunSMSService
            // 
            this.btnRunSMSService.Location = new System.Drawing.Point(7, 140);
            this.btnRunSMSService.Name = "btnRunSMSService";
            this.btnRunSMSService.Size = new System.Drawing.Size(169, 23);
            this.btnRunSMSService.TabIndex = 6;
            this.btnRunSMSService.Text = "启动APP的 SmsService";
            this.btnRunSMSService.UseVisualStyleBackColor = true;
            this.btnRunSMSService.Click += new System.EventHandler(this.btnRunSMSService_Click);
            // 
            // btnSearchAppProcess
            // 
            this.btnSearchAppProcess.Location = new System.Drawing.Point(199, 92);
            this.btnSearchAppProcess.Name = "btnSearchAppProcess";
            this.btnSearchAppProcess.Size = new System.Drawing.Size(186, 23);
            this.btnSearchAppProcess.TabIndex = 5;
            this.btnSearchAppProcess.Text = "查找目标APP进程";
            this.btnSearchAppProcess.UseVisualStyleBackColor = true;
            this.btnSearchAppProcess.Click += new System.EventHandler(this.btnSearchAppProcess_Click);
            // 
            // btnGetUsbSerialNumber
            // 
            this.btnGetUsbSerialNumber.Location = new System.Drawing.Point(7, 92);
            this.btnGetUsbSerialNumber.Name = "btnGetUsbSerialNumber";
            this.btnGetUsbSerialNumber.Size = new System.Drawing.Size(169, 23);
            this.btnGetUsbSerialNumber.TabIndex = 4;
            this.btnGetUsbSerialNumber.Text = "获取usb serialNumber";
            this.btnGetUsbSerialNumber.UseVisualStyleBackColor = true;
            this.btnGetUsbSerialNumber.Click += new System.EventHandler(this.btnGetUsbSerialNumber_Click);
            // 
            // btnCheckAppid
            // 
            this.btnCheckAppid.Location = new System.Drawing.Point(310, 45);
            this.btnCheckAppid.Name = "btnCheckAppid";
            this.btnCheckAppid.Size = new System.Drawing.Size(75, 23);
            this.btnCheckAppid.TabIndex = 3;
            this.btnCheckAppid.Text = "查询appid";
            this.btnCheckAppid.UseVisualStyleBackColor = true;
            this.btnCheckAppid.Click += new System.EventHandler(this.btnCheckAppid_Click);
            // 
            // btnKillServer
            // 
            this.btnKillServer.Location = new System.Drawing.Point(101, 45);
            this.btnKillServer.Name = "btnKillServer";
            this.btnKillServer.Size = new System.Drawing.Size(75, 23);
            this.btnKillServer.TabIndex = 2;
            this.btnKillServer.Text = "结束服务";
            this.btnKillServer.UseVisualStyleBackColor = true;
            this.btnKillServer.Click += new System.EventHandler(this.btnKillServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(7, 45);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 23);
            this.btnStartServer.TabIndex = 1;
            this.btnStartServer.Text = "启动服务";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "定时器间隔(ms)";
            // 
            // tbInterval
            // 
            this.tbInterval.Location = new System.Drawing.Point(101, 20);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(75, 21);
            this.tbInterval.TabIndex = 9;
            this.tbInterval.Text = "5000";
            // 
            // btnStartCheck
            // 
            this.btnStartCheck.Location = new System.Drawing.Point(199, 20);
            this.btnStartCheck.Name = "btnStartCheck";
            this.btnStartCheck.Size = new System.Drawing.Size(186, 23);
            this.btnStartCheck.TabIndex = 8;
            this.btnStartCheck.Text = "开始检测短信检测服务";
            this.btnStartCheck.UseVisualStyleBackColor = true;
            this.btnStartCheck.Click += new System.EventHandler(this.btnStartCheck_Click);
            // 
            // tbSendMsg
            // 
            this.tbSendMsg.Location = new System.Drawing.Point(13, 296);
            this.tbSendMsg.Multiline = true;
            this.tbSendMsg.Name = "tbSendMsg";
            this.tbSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSendMsg.Size = new System.Drawing.Size(371, 61);
            this.tbSendMsg.TabIndex = 4;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(247, 372);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(137, 23);
            this.btnSendMsg.TabIndex = 5;
            this.btnSendMsg.Text = "给APP发送消息";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(390, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 377);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(435, 351);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "自定义命令";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(435, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "实例命令";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(435, 351);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "定时器";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUSBListen);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnStartCheck);
            this.groupBox3.Controls.Add(this.tbInterval);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 220);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "定时器";
            // 
            // btnUSBListen
            // 
            this.btnUSBListen.Location = new System.Drawing.Point(199, 79);
            this.btnUSBListen.Name = "btnUSBListen";
            this.btnUSBListen.Size = new System.Drawing.Size(186, 23);
            this.btnUSBListen.TabIndex = 11;
            this.btnUSBListen.Text = "开始监听USB插拔";
            this.btnUSBListen.UseVisualStyleBackColor = true;
            // 
            // cmbDevices
            // 
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(78, 373);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(148, 20);
            this.cmbDevices.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "手机列表";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 413);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDevices);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.tbSendMsg);
            this.Controls.Add(this.txtInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckDevices;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnKillServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnCheckAppid;
        private System.Windows.Forms.Button btnGetUsbSerialNumber;
        private System.Windows.Forms.Button btnSearchAppProcess;
        private System.Windows.Forms.Button btnRunSMSService;
        private System.Windows.Forms.Button btnGetDeviceInfo;
        private System.Windows.Forms.Button btnStartCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInterval;
        private System.Windows.Forms.TextBox tbSendMsg;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUSBListen;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.Label label2;
    }
}

