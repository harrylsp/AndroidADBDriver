using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 信息回显
        /// </summary>
        /// <param name="strValue"></param>
        private delegate void SetTextCallBack(string strValue);

        /// <summary>
        /// 声明
        /// </summary>
        private SetTextCallBack setTextCallBack;

        /// <summary>
        /// 接受消息回调
        /// </summary>
        /// <param name="strMsg"></param>
        private delegate void ReceiveMsgCallBack(string strMsg);

        /// <summary>
        /// 声明
        /// </summary>
        private ReceiveMsgCallBack receiveMsgCallBack;

        /// <summary>
        /// 连接Socket
        /// </summary>
        Socket socketSend;

        /// <summary>
        /// 消息接收线程
        /// </summary>
        Thread threadReceive;

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 允许跨线程访问控件
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 连接服务端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(this.tbIP.Text.Trim());
                socketSend.Connect(ip, Convert.ToInt32(this.tbPort.Text.Trim()));

                // 实例化
                setTextCallBack = new SetTextCallBack(SetValue);
                receiveMsgCallBack = new ReceiveMsgCallBack(SetValue);

                // 线程接收服务端消息
                threadReceive = new Thread(new ThreadStart(Receive));
                threadReceive.IsBackground = true;
                threadReceive.Start();

                SetValue("连接成功...");

            }
            catch (Exception ex)
            {
                MessageBox.Show("连接服务端出错：" + ex.Message);
            }
        }

        /// <summary>
        /// 消息回显
        /// </summary>
        /// <param name="strValue"></param>
        private void SetValue(string strValue)
        {
            this.tbLog.AppendText(strValue + "\r\n");
        }

        /// <summary>
        /// 接收服务器消息
        /// </summary>
        private void Receive()
        {
            try
            {
                if (socketSend == null || !socketSend.Connected)
                {
                    SetValue("连接被关闭...");
                    return;
                }

                while (true)
                {
                    byte[] buffer = new byte[2048];
                    // 接收的字节
                    int r = socketSend.Receive(buffer); // 阻塞操作
                    if (r == 0)
                    {
                        return;
                    }

                    // 判断发送的数据类型
                    // 文字消息
                    if (buffer[0] == 0)
                    {

                        string str = Encoding.Default.GetString(buffer, 1, r - 1);
                        this.tbLog.Invoke(receiveMsgCallBack, "接收服务端：" + socketSend.RemoteEndPoint + " 发送消息：" + str);
                    }

                    // 文件消息
                    if (buffer[0] == 1)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.InitialDirectory = @"";
                        sfd.Title = "请选择要保存的文件";
                        sfd.Filter = "所有文件|*.*";
                        sfd.ShowDialog(this);

                        string strPath = sfd.FileName;
                        using (FileStream fsWrite = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            fsWrite.Write(buffer, 1, r - 1);
                        }

                        MessageBox.Show("保存文件成功");
                    }
                }
            }
            catch (SocketException sex)
            {
                MessageBox.Show("网络异常：" + sex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("接收服务端消息异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //this.tbLog.Invoke(setTextCallBack, "测试");
            socketSend.Shutdown(SocketShutdown.Both);
            socketSend.Close();
            socketSend.Dispose();
            threadReceive.Abort();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string strMsg = this.tbMessage.Text.Trim();
                byte[] buffer = new byte[2048];
                buffer = Encoding.Default.GetBytes(strMsg);
                int recevie = socketSend.Send(buffer);
                SetValue("发送消息成功：" + strMsg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送消息异常：" + ex.Message);
            }
        }

    }
}
