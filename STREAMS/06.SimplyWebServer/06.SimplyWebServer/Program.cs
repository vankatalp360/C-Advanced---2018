using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _06.SimplyWebServer
{
    class Program
    {
        private const int PortNumber = 1337;
        static void Main(string[] args)
        {
            var tcpListener = new TcpListener(IPAddress.Any, PortNumber);
            tcpListener.Start();
            Console.WriteLine($"Listening on port {PortNumber}...");

            while (true)
            {
                NetworkStream stream = tcpListener.AcceptTcpClient().GetStream();

                using (stream)
                {
                    byte[] request = new byte[4096];
                    int readBytes = stream.Read(request, 0, 4096);
                    Console.WriteLine(Encoding.UTF8.GetString(request, 0, readBytes));

                    string html = string.Format("HTTP/1.1.200 OK\nContent-Type:text\n\n" + "{0}{1}{2}{3} - {4}{2}{1}{0}",
                        "<html>", "<body>", "<h1>", "Welcome to my awesome site!", DateTime.Now);
                    byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                    stream.Write(htmlBytes, 0, htmlBytes.Length);
                }
            }
        }
    }
}
