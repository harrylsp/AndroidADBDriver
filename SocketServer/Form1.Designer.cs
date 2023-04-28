namespace SocketServer
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
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnStartListen = new System.Windows.Forms.Button();
            this.btnStopListen = new System.Windows.Forms.Button();
            this.cmbIPList = new System.Windows.Forms.ComboBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(26, 25);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(153, 21);
            this.tbIP.TabIndex = 0;
            this.tbIP.Text = "127.0.0.1";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(194, 25);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(68, 21);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "12345";
            // 
            // btnStartListen
            // 
            this.btnStartListen.Location = new System.Drawing.Point(285, 25);
            this.btnStartListen.Name = "btnStartListen";
            this.btnStartListen.Size = new System.Drawing.Size(75, 21);
            this.btnStartListen.TabIndex = 2;
            this.btnStartListen.Text = "开始监听";
            this.btnStartListen.UseVisualStyleBackColor = true;
            this.btnStartListen.Click += new System.EventHandler(this.btnStartListen_Click);
            // 
            // btnStopListen
            // 
            this.btnStopListen.Location = new System.Drawing.Point(366, 25);
            this.btnStopListen.Name = "btnStopListen";
            this.btnStopListen.Size = new System.Drawing.Size(75, 21);
            this.btnStopListen.TabIndex = 3;
            this.btnStopListen.Text = "停止监听";
            this.btnStopListen.UseVisualStyleBackColor = true;
            this.btnStopListen.Click += new System.EventHandler(this.btnStopListen_Click);
            // 
            // cmbIPList
            // 
            this.cmbIPList.FormattingEnabled = true;
            this.cmbIPList.Location = new System.Drawing.Point(459, 25);
            this.cmbIPList.Name = "cmbIPList";
            this.cmbIPList.Size = new System.Drawing.Size(139, 20);
            this.cmbIPList.TabIndex = 4;
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(26, 75);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(572, 142);
            this.tbLog.TabIndex = 5;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(26, 234);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(572, 119);
            this.tbMessage.TabIndex = 6;
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(26, 410);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(334, 21);
            this.tbFilePath.TabIndex = 7;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(426, 408);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 8;
            this.btnSelectFile.Text = "选择";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(523, 408);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 9;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(523, 368);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 10;
            this.btnSendMessage.Text = "发送消息";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 450);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.cmbIPList);
            this.Controls.Add(this.btnStopListen);
            this.Controls.Add(this.btnStartListen);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnStartListen;
        private System.Windows.Forms.Button btnStopListen;
        private System.Windows.Forms.ComboBox cmbIPList;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnSendMessage;
    }
}

