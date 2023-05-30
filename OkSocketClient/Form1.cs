using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkSocketClient
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
        /// 储存粘包多余字节
        /// </summary>
        byte[] moreReciveData;

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
        /// 连接Socket服务器
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

                    // 拼接上次多余字节
                    if (moreReciveData?.Length > 0)
                    {
                        Array.Copy(moreReciveData, 0, buffer, 0, moreReciveData.Length);
                    }

                    // OkSocket 前4个字节放消息体长度
                    if (r < 4)
                    {
                        continue;
                    }

                    // 获取消息体长度
                    byte[] rHead = new byte[4];
                    Array.Copy(buffer, 0, rHead, 0, 4);
                    var bodyLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(rHead, 0));

                    // 消息体缺失
                    if (4 + bodyLength > r)
                    {
                        this.tbLog.Invoke(receiveMsgCallBack, "服务端：" + socketSend.RemoteEndPoint + " 接收消息内容不够长度");
                        continue;
                    }
                    else if (4 + bodyLength == r) // 刚好接收一个消息长度
                    {
                        string response = Encoding.UTF8.GetString(buffer, 4, bodyLength);
                        this.tbLog.Invoke(receiveMsgCallBack, "服务端：" + socketSend.RemoteEndPoint + " 接收消息：" + response);
                    }
                    else if (4 + bodyLength < r) // 接收超过一个消息长度
                    {
                        string response = Encoding.UTF8.GetString(buffer, 4, bodyLength);
                        this.tbLog.Invoke(receiveMsgCallBack, "服务端：" + socketSend.RemoteEndPoint + " 接收消息：" + response);

                        var more = Encoding.UTF8.GetString(buffer, 4 + bodyLength, r - 4 - bodyLength);
                        this.tbLog.Invoke(receiveMsgCallBack, "服务端：" + socketSend.RemoteEndPoint + " 接收多余的消息：" + more);
                        moreReciveData = new byte[r - 4 - bodyLength];
                        Array.Copy(buffer, 4 + bodyLength, moreReciveData, 0, r - 4 - bodyLength);
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
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                string strMsg = this.tbMsg.Text.Trim();

                byte[] buffer = new byte[4 + strMsg.Length];

                var head = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(strMsg.Length));
                var body = Encoding.UTF8.GetBytes(strMsg);

                Array.Copy(head, 0, buffer, 0, head.Length);
                Array.Copy(body, 0, buffer, head.Length, body.Length);

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
