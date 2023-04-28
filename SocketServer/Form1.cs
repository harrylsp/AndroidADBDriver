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

namespace SocketServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 通信Socket
        /// </summary>
        private Socket socketSend;

        /// <summary>
        /// 监听Socket
        /// </summary>
        private Socket socketWatch;

        /// <summary>
        /// 监听连接线程
        /// </summary>
        Thread acceptSocketThread;

        /// <summary>
        /// 接受客户端消息线程
        /// </summary>
        Thread receiveSocketThread;

        /// <summary>
        /// 远程Socket连接集合
        /// </summary>
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        /// <summary>
        /// ComboBox添加元素回调函数
        /// </summary>
        /// <param name="strItem"></param>
        private delegate void SetCmbCallBack(string strItem);

        /// <summary>
        /// 声明
        /// </summary>
        private SetCmbCallBack setCmbCallBack;

        /// <summary>
        /// 跨线程访问UI控件回调
        /// </summary>
        /// <param name="strValue"></param>
        private delegate void SetTextValueCallBack(string strValue);

        /// <summary>
        /// 声明
        /// </summary>
        private SetTextValueCallBack setTextValueCallBack;

        /// <summary>
        /// 显示客户端消息回调
        /// </summary>
        /// <param name="strReceive"></param>
        private delegate void ReceiveMsgCallBack(string strReceive);

        /// <summary>
        /// 声明
        /// </summary>
        private ReceiveMsgCallBack receiveMsgCallBack;

        /// <summary>
        /// 文件发送回调
        /// </summary>
        /// <param name="bf"></param>
        private delegate void SendFileCallBack(byte[] bf);

        /// <summary>
        /// 声明
        /// </summary>
        private SendFileCallBack sendFileCallBack;


        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartListen_Click(object sender, EventArgs e)
        {
            // 创建监听Socket
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // IP
            IPAddress ip = IPAddress.Parse(this.tbIP.Text.Trim());

            // 端口号
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(this.tbPort.Text.Trim()));

            // 绑定IP地址和端口
            socketWatch.Bind(point);
            this.tbLog.AppendText("监听成功" + "\r\n");

            // 设置最大连接数
            socketWatch.Listen(10);

            // 回调实例化
            setTextValueCallBack = new SetTextValueCallBack(SetTextValue);
            receiveMsgCallBack = new ReceiveMsgCallBack(ReceiveMsg);
            setCmbCallBack = new SetCmbCallBack(AddCmbItem);
            sendFileCallBack = new SendFileCallBack(SendFile);

            // 线程开启监听
            acceptSocketThread = new Thread(new ParameterizedThreadStart(StartListen));
            acceptSocketThread.IsBackground = true;
            acceptSocketThread.Start(socketWatch);

        }

        /// <summary>
        /// 监听
        /// </summary>
        /// <param name="obj"></param>
        private void StartListen(object obj)
        {
            Socket sw = obj as Socket;

            while (true)
            {
                // 等待连接
                socketSend = socketWatch.Accept();

                // 获取连接主机IP和端口
                string rip = socketSend.RemoteEndPoint.ToString();
                dicSocket.Add(rip, socketSend);
                this.cmbIPList.Invoke(setCmbCallBack, rip);
                string strMsg = "远程主机：" + socketSend.RemoteEndPoint + "连接成功";

                // 回显
                tbLog.Invoke(setTextValueCallBack, strMsg);

                // 接收客户端消息线程
                Thread threadReceive = new Thread(new ParameterizedThreadStart(Receive));
                threadReceive.IsBackground = true;
                threadReceive.Start(socketSend);
            }
        }

        /// <summary>
        /// 接收
        /// </summary>
        /// <param name="obj"></param>
        private void Receive(object obj)
        {
            Socket socketR = obj as Socket;
            socketR.ReceiveTimeout = 5000;

            try
            {
                if (socketR == null || !socketR.Connected)
                {
                    SetTextValue("客户端关闭连接...");
                    return;
                }

                while (true)
                {
                    // 接收到的消息缓存区
                    byte[] buffer = new byte[2048];
                    
                    // 接收到的有效字节数
                    int count = socketR.Receive(buffer); // 阻塞操作
                    if (count == 0)
                    {
                        // 客户端关闭
                        return;
                    }

                    // 回显接收到的消息
                    string str = Encoding.Default.GetString(buffer, 0, count);
                    string strR = "接收：" + socketR.RemoteEndPoint + " 发送的消息：" + str;
                    tbLog.Invoke(receiveMsgCallBack, strR);
                }
            }
            catch (SocketException sex)
            {
                tbLog.Invoke(receiveMsgCallBack, "网络异常：" + "[" + socketR.RemoteEndPoint.ToString() + "]" + sex.Message);
                dicSocket.Remove(socketR.RemoteEndPoint.ToString());
            }
            catch (ObjectDisposedException dex)
            {
                tbLog.Invoke(receiveMsgCallBack, "连接异常：" + "[" + socketR.RemoteEndPoint.ToString() + "]" + dex.Message);
            }
            catch (Exception ex)
            {
                tbLog.Invoke(receiveMsgCallBack, "接收客户端消息异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 监听消息回显
        /// </summary>
        /// <param name="strValue"></param>
        private void SetTextValue(string strValue)
        {
            this.tbLog.AppendText(strValue + " \r\n");
        }

        /// <summary>
        /// 接收消息回显
        /// </summary>
        /// <param name="strMsg"></param>
        private void ReceiveMsg(string strMsg)
        {
            this.tbLog.AppendText(strMsg + " \r\n");
        }

        /// <summary>
        /// 添加IP集合
        /// </summary>
        /// <param name="strItem"></param>
        private void AddCmbItem(string strItem)
        {
            this.cmbIPList.Items.Add(strItem);
        }

        /// <summary>
        /// 停止监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopListen_Click(object sender, EventArgs e)
        {
            try
            {
                socketWatch?.Dispose();
                socketSend?.Dispose();

                socketWatch?.Close();
                //socketWatch.Shutdown(SocketShutdown.Both);
                socketSend?.Close();
                //socketSend.Shutdown(SocketShutdown.Both);

                // 终止线程
                acceptSocketThread.Abort();
                //receiveSocketThread.Abort();

                this.tbLog.AppendText("停止监听成功" + "\r\n");
            }
            catch (SocketException ex)
            {
                MessageBox.Show("停止监听异常：" + ex.Message);
                //throw;
            }
            
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                string strMsg = this.tbMessage.Text.Trim();
                byte[] buffer = Encoding.Default.GetBytes(strMsg);
                List<byte> list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);

                // 转换为字节数组
                byte[] newBuffer = list.ToArray();

                // 获取发送IP
                string ip = this.cmbIPList.SelectedItem.ToString();
                SetTextValue("发送IP：" + ip + " 消息：" + strMsg);
                dicSocket[ip].Send(newBuffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("给客户端发送消息出错：" + ex.Message);
            }
        }

        /// <summary>
        /// 选择要发送的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            // 设置初始目录
            fileDialog.InitialDirectory = @"";
            fileDialog.Title = "请选择要发送的文件";
            // 过滤文件类型
            fileDialog.Filter = "所有文件|*.*";
            fileDialog.ShowDialog();

            // 回显文件路径
            this.tbFilePath.Text = fileDialog.FileName;
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            List<byte> list = new List<byte>();

            // 获取文件路径
            string strPath = this.tbFilePath.Text.Trim();

            using (FileStream sw = new FileStream(strPath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[2048];
                int r = sw.Read(buffer, 0, buffer.Length);
                list.Add(1);
                list.AddRange(buffer);

                // 转换成字节数组
                byte[] newBuffer = list.ToArray();

                // 发送
                btnSendFile.Invoke(sendFileCallBack, newBuffer);
            }
        }

        /// <summary>
        /// 发送文件回调
        /// </summary>
        /// <param name="sendBuffer"></param>
        private void SendFile(byte[] sendBuffer)
        {
            try
            {
                dicSocket[cmbIPList.SelectedItem.ToString()].Send(sendBuffer, SocketFlags.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送文件出错：" + ex.Message);
            }
        }
    }
}
