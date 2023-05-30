using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个Socket并连接到服务器
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12345);
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(remoteEP);

            // 发送数据
            string message = "Hello from client!";
            byte[] msg = Encoding.ASCII.GetBytes(message);
            int bytesSent = sender.Send(msg);
            Console.WriteLine($"Sent: {message}");

            // 接受数据
            byte[] buffer = new byte[1024];
            int bytesRec = sender.Receive(buffer);
            string data = Encoding.ASCII.GetString(buffer, 0, bytesRec);
            Console.WriteLine($"Received: {data}");

            // 关闭连接
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();

            Console.ReadKey();
        }
    }
}
