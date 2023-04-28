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
            this.btnKillServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnCheckAppid = new System.Windows.Forms.Button();
            this.btnGetUsbSerialNumber = new System.Windows.Forms.Button();
            this.btnSearchAppProcess = new System.Windows.Forms.Button();
            this.btnRunSMSService = new System.Windows.Forms.Button();
            this.btnGetDeviceInfo = new System.Windows.Forms.Button();
            this.btnStartCheck = new System.Windows.Forms.Button();
            this.tbInterval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.txtInfo.Size = new System.Drawing.Size(371, 377);
            this.txtInfo.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExcute);
            this.groupBox1.Controls.Add(this.tbCommand);
            this.groupBox1.Location = new System.Drawing.Point(399, 13);
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
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbInterval);
            this.groupBox2.Controls.Add(this.btnStartCheck);
            this.groupBox2.Controls.Add(this.btnGetDeviceInfo);
            this.groupBox2.Controls.Add(this.btnRunSMSService);
            this.groupBox2.Controls.Add(this.btnSearchAppProcess);
            this.groupBox2.Controls.Add(this.btnGetUsbSerialNumber);
            this.groupBox2.Controls.Add(this.btnCheckAppid);
            this.groupBox2.Controls.Add(this.btnKillServer);
            this.groupBox2.Controls.Add(this.btnStartServer);
            this.groupBox2.Controls.Add(this.btnCheckDevices);
            this.groupBox2.Location = new System.Drawing.Point(399, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 219);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实例命令展示";
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
            // btnStartCheck
            // 
            this.btnStartCheck.Location = new System.Drawing.Point(199, 178);
            this.btnStartCheck.Name = "btnStartCheck";
            this.btnStartCheck.Size = new System.Drawing.Size(186, 23);
            this.btnStartCheck.TabIndex = 8;
            this.btnStartCheck.Text = "开始检测短信检测服务";
            this.btnStartCheck.UseVisualStyleBackColor = true;
            this.btnStartCheck.Click += new System.EventHandler(this.btnStartCheck_Click);
            // 
            // tbInterval
            // 
            this.tbInterval.Location = new System.Drawing.Point(101, 178);
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(75, 21);
            this.tbInterval.TabIndex = 9;
            this.tbInterval.Text = "5000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "定时器间隔(ms)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 425);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}

