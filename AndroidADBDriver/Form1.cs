using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidADBDriver
{
    public partial class Form1 : Form
    {
        private Timer checkSMSServerTimer;

        public Form1()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 执行adb命令
        /// </summary>
        /// <param name="arguments">命令参数(adb除外)</param>
        /// <returns></returns>
        public string RunADB(string arguments)
        {
            string cmd = Application.StartupPath + "\\adb-1.0.41\\adb.exe";
            Process p = new Process();
            p.StartInfo.FileName = cmd;           //设定程序名  
            p.StartInfo.Arguments = arguments;    //设定程式执行參數  
            p.StartInfo.UseShellExecute = false;        //关闭Shell的使用  
            p.StartInfo.RedirectStandardInput = true;   //重定向标准输入  
            p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出  
            p.StartInfo.RedirectStandardError = true;   //重定向错误输出  
            p.StartInfo.CreateNoWindow = true;          //设置不显示窗口  
            p.Start();
            string result = p.StandardOutput.ReadToEnd();
            p.Close();
            return result;
        }

        /// <summary>
        /// 输入返回信息
        /// </summary>
        public void WriteToTextBox(string info)
        {
            if (string.IsNullOrWhiteSpace(info))
            {
                info = "adb 无返回信息";
            }

            this.txtInfo.Text += info + "\r\n";

            // 滚到最后
            this.txtInfo.SelectionStart = this.txtInfo.Text.Length;
            this.txtInfo.ScrollToCaret();
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcute_Click(object sender, EventArgs e)
        {
            WriteToTextBox(RunADB(this.tbCommand.Text.ToString()));
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            WriteToTextBox(RunADB("kill-server"));
            WriteToTextBox(RunADB("start-server"));
        }

        /// <summary>
        /// 结束服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKillServer_Click(object sender, EventArgs e)
        {
            WriteToTextBox(RunADB("kill-server"));
        }

        /// <summary>
        /// 查询设备信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckDevice_Click(object sender, EventArgs e)
        {
            WriteToTextBox(RunADB("devices -l"));
        }

        /// <summary>
        /// 查询指定app的pid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckAppid_Click(object sender, EventArgs e)
        {
            WriteToTextBox(RunADB("shell pidof com.kungeek.android.smstool.ftsp.release"));
        }

        /// <summary>
        /// 获取usb设备的 serialNumber (多个设备插入时候，要用户选择)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetUsbSerialNumber_Click(object sender, EventArgs e)
        {
            WriteToTextBox(RunADB("devices -l | grep usb | awk '{print $1}'"));
        }

        /// <summary>
        /// 查找目标APP进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchAppProcess_Click(object sender, EventArgs e)
        {
            WriteToTextBox(RunADB("shell ps -A | grep com.kungeek.android.smstool.ftsp.release | awk '{print $9}'"));
        }

        /// <summary>
        /// 启动APP的 SmsService
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunSMSService_Click(object sender, EventArgs e)
        {
            WriteToTextBox(RunADB("shell am startservice -n com.kungeek.android.smstool.ftsp.release/com.kungeek.android.smstool.SmsService"));
        }

        /// <summary>
        /// 读取设备信息、系统信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetDeviceInfo_Click(object sender, EventArgs e)
        {
            WriteToTextBox(RunADB("shell getprop | grep 'ro.product'"));
        }

        /// <summary>
        /// 开启检测短信服务定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartCheck_Click(object sender, EventArgs e)
        {
            var it = int.Parse(this.tbInterval.Text.Trim().ToString());

            checkSMSServerTimer = new Timer();
            checkSMSServerTimer.Interval = it;
            checkSMSServerTimer.Enabled = false;
            checkSMSServerTimer.Tick += new EventHandler(startCheckSMSServer);
            checkSMSServerTimer.Start();
        }

        /// <summary>
        /// 检测短信后台服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startCheckSMSServer(object sender, EventArgs e)
        {
            var p = RunADB("shell ps -A | grep com.kungeek.android.smstool.ftsp.release | awk '{print $9}'");

            WriteToTextBox("查找短信服务APP=>" + p);
            if (p.ToString().Trim() == "com.kungeek.android.smstool.ftsp.release")
            {
                WriteToTextBox("短信服务APP存活");
            }
            else
            {
                WriteToTextBox("短信服务APP已挂");
                WriteToTextBox("开始启动短信服务: " + RunADB("shell am startservice -n com.kungeek.android.smstool.ftsp.release/com.kungeek.android.smstool.SmsService"));
            }
        }
    }
}
