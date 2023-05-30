using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AndroidADBDriver
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 检查服务定时器
        /// </summary>
        private Timer checkSMSServerTimer;

        /// <summary>
        /// USB插拔监听
        /// </summary>
        private Timer checkUSBTimer;

        /// <summary>
        /// 互斥量
        /// </summary>
        private static Mutex mutex = new Mutex();

        /// <summary>
        /// 判断是否需要发送wait-for-usb-device
        /// </summary>
        private bool isNeedContinue = true;

        /// <summary>
        /// 端口
        /// </summary>
        private int orginPort = 11111;

        /// <summary>
        /// 连接电脑的手机设备列表
        /// </summary>
        private List<DeviceInfo> deviceList = new List<DeviceInfo>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面加载监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 允许跨线程访问控件
            Control.CheckForIllegalCrossThreadCalls = false;

            checkUSBTimer = new Timer();
            checkUSBTimer.Interval = 5 * 1000;
            checkUSBTimer.Enabled = false;
            checkUSBTimer.Tick += new EventHandler(startCheckUSB);
            checkUSBTimer.Start();

            cmbDevices.DisplayMember = "DeviceName";
            cmbDevices.ValueMember = "DeviceId";
        }
        
        /// <summary>
        /// USB监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void startCheckUSB(object sender, EventArgs e)
        {
            WriteToTextBox("开始监听Android USB");

            RunUSBADB("wait-for-usb-device", (sd, data) =>
            {
                mutex.WaitOne();
                isNeedContinue = true;
                mutex.ReleaseMutex();

                var ret = data.Data;

                if (string.IsNullOrWhiteSpace(ret))
                {
                    // 厂商
                    var manufacturer = RunADB("shell getprop ro.product.manufacturer");
                    // 品牌名称
                    var brand = RunADB("shell getprop ro.product.brand");
                    WriteToTextBox("检测到设备插入");

                    var devices = RunADB("devices");
                    var aDevices = devices.Replace("\n", "").Split('\r');
                    if (aDevices?.Length > 0)
                    {
                        foreach (var de in aDevices)
                        {
                            // 设备信息
                            if (de.Contains("\t"))
                            {
                                var dInfo = de.Split('\t');
                                if (dInfo?.Length >= 1)
                                {
                                    var dc = deviceList.Where(c => c.DeviceId == dInfo[0])?.FirstOrDefault();
                                    if (dc == null)
                                    {
                                        DeviceInfo device = new DeviceInfo();
                                        device.DeviceId = dInfo[0];
                                        device.DeviceName = RunADB(" -s " + device.DeviceId + " shell getprop ro.product.brand");
                                        device.DeviceStatus = dInfo[1];
                                        device.DeviceSocketPort = orginPort + 1;
                                        orginPort = device.DeviceSocketPort;
                                        deviceList.Add(device);
                                    }
                                    else
                                    {
                                        dc.DeviceStatus = dInfo[1];
                                    }
                                }
                            }
                        }
                    }

                    // 绑定数据源
                    if (cmbDevices.InvokeRequired)
                    {
                        cmbDevices.Invoke((Action)delegate
                        {
                            cmbDevices.DataSource = deviceList;
                        });
                    }
                }
                else
                {
                    WriteToTextBox("检测Android 设备：" + ret);
                }
            }, (esd, edata) => 
            {
                if (!string.IsNullOrWhiteSpace(edata.Data))
                {
                    WriteToTextBox("检查Android 设备异常：" + edata.Data);
                }
            });

            // 避免等到设备插入时，也执行下面逻辑
            Thread.Sleep(500);
            if (!isNeedContinue)
            {
                WriteToTextBox("未检测到Android 设备插入");
            }
            
        }

        /// <summary>
        /// 执行wait-for-usb-device
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="dataReceivedEventHandler"></param>
        public void RunUSBADB(string arguments, DataReceivedEventHandler dataReceivedEventHandler, DataReceivedEventHandler errDataReceivedEventHandler)
        {
            if (isNeedContinue)
            {
                //isNeedContinue = false;
                AsyncRunADB(arguments, dataReceivedEventHandler, errDataReceivedEventHandler);
            }

            mutex.WaitOne();
            // 等待查询不返回，不再继续发起检测命令
            isNeedContinue = false;
            mutex.ReleaseMutex();
        }

        /// <summary>
        /// 异步执行adb命令
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="dataReceivedEventHandler">命令执行正确结果返回回调</param>
        /// <param name="errorDataReceivedEventHandler">命令执行错误结果返回回调</param>
        public void AsyncRunADB(string arguments, DataReceivedEventHandler dataReceivedEventHandler, DataReceivedEventHandler errorDataReceivedEventHandler)
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
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8; // 指定输出流编码为 UTF-8
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8; // 指定错误输出流编码为 UTF-8
            p.OutputDataReceived += dataReceivedEventHandler;
            p.ErrorDataReceived += errorDataReceivedEventHandler;
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.Close();
        }

        /// <summary>
        /// 同步执行adb命令
        /// </summary>
        /// <param name="arguments">命令参数(adb除外)</param>
        /// <returns>执行返回的正确返回和错误返回 格式：正确返回\r\n错误返回</returns>
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
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8; // 指定输出流编码为 UTF-8
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8; // 指定错误输出流编码为 UTF-8
            p.Start();

            string result = p.StandardOutput.ReadToEnd(); // 正确输出
            var errOuput = p.StandardError.ReadToEnd(); // 错误输出
            p.Close();
            
            return result + "\r\n" + errOuput;
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

            if (this.txtInfo.InvokeRequired)
            {
                this.txtInfo.Invoke(new Action<string>(WriteToTextBox), info);
            }
            else
            {
                this.txtInfo.Text += info + "\r\n";

                // 滚到最后
                this.txtInfo.SelectionStart = this.txtInfo.Text.Length;
                this.txtInfo.ScrollToCaret();
            }
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
            WriteToTextBox(RunADB("shell pidof app的id"));
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
            WriteToTextBox(RunADB("shell ps -A | grep app进程名称 | awk '{print $9}'"));
        }

        /// <summary>
        /// 启动APP的 SmsService
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunSMSService_Click(object sender, EventArgs e)
        {
            WriteToTextBox(RunADB("shell am startservice -n 服务名称"));
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
            var p = RunADB("shell ps -A | grep app进程名称 | awk '{print $9}'");

            WriteToTextBox("查找短信服务APP=>" + p);
            if (p.ToString().Trim() == "app进程名称")
            {
                WriteToTextBox("短信服务APP存活");
            }
            else
            {
                WriteToTextBox("短信服务APP已挂");
                WriteToTextBox("开始启动短信服务: " + RunADB("shell am startservice -n 服务名称"));
            }
        }

        /// <summary>
        /// 发送Socket消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取对应设备id
                var deviceId = this.cmbDevices?.SelectedValue?.ToString();
                var port = deviceList.Where(c => c.DeviceId == deviceId)?.FirstOrDefault()?.DeviceSocketPort;

                // 端口转发
                var ret = RunADB("-s " + deviceId + " forward tcp:" + (port ?? 11111).ToString() + " tcp:22222");
                if (true || string.IsNullOrWhiteSpace(ret))
                {
                    MessageBox.Show("端口转发返回：" + ret);
                }

                // 创建Socket
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // 连接服务器
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port ?? 11111);
                client.Connect(serverEndPoint);

                //WriteToTextBox("Connected to the server.");

                // 发送消息
                string strMsg = this.tbSendMsg.Text.Trim();
                byte[] data = new byte[4 + strMsg.Length];

                var head = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(strMsg.Length));
                var body = Encoding.UTF8.GetBytes(strMsg);

                Array.Copy(head, 0, data, 0, head.Length);
                Array.Copy(body, 0, data, head.Length, body.Length);

                client.Send(data);

                // 接收回应
                byte[] buffer = new byte[1024];
                int bytesRead = client.Receive(buffer);

                byte[] rHead = new byte[4];
                Array.Copy(buffer, 0, rHead, 0, 4);
                var bodyLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(rHead, 0));

                string response = Encoding.ASCII.GetString(buffer, 4, bodyLength);

                WriteToTextBox($"Response from server: {response}");

                // 关闭连接
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception ex)
            {
                WriteToTextBox("向APP发送Socket消息异常：" + ex.Message);
            }
        }

    }

    /// <summary>
    /// 设备信息
    /// </summary>
    public class DeviceInfo
    {
        /// <summary>
        /// 设备ID
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public string DeviceStatus { get; set; }

        /// <summary>
        /// 通讯端口
        /// </summary>
        public int DeviceSocketPort { get; set; }
    }
}
