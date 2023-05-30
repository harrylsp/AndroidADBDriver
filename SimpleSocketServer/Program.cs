using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个用于监听的Socket
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 绑定IP地址和端口号
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 12345);
            listener.Bind(localEndPoint);

            // 开始监听
            Console.WriteLine("Waiting for a connection...");
            listener.Listen(10);

            while (true)
            {
                // 接受连接
                Socket handler = listener.Accept();
                Console.WriteLine($"Connected: {handler.RemoteEndPoint}");

                // 读取数据
                byte[] buffer = new byte[1024];
                int bytesRec = handler.Receive(buffer);
                string data = Encoding.ASCII.GetString(buffer, 0, bytesRec);
                Console.WriteLine($"Received: {data}");

                // 发送数据
                byte[] msg = Encoding.ASCII.GetBytes("Hello from server!");
                handler.Send(msg);

                // 关闭连接
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }
    }
}
