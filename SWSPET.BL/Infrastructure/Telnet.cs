using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SWSPET.BL.Infrastructure
{
    public class Telnet
    {
        private string _address;
        private int _port;
        private int timeout;
        public Telnet(string address, int port, int commandTimeout)
        {
            _address = address;
            _port = port;
            timeout = commandTimeout;

        }


        public string Check()
        {
            try
            {
                using (_tcpClient = new TcpClient())
                {


                    _tcpClient.Connect(_address, _port);

                    using (_stream = _tcpClient.GetStream())
                    {
                        if (_stream.CanRead) { var s = ReadOut(); }

                        //Console.WriteLine("Enter your username:");
                        WriteIn("helo hi\r");

                        Console.WriteLine(ReadOut());

                        Console.WriteLine("Enter your password:");
                        //WriteIn(Console.ReadLine());

                        Console.WriteLine(ReadOut());


                    }
                }
                //keep it open
                Console.ReadLine();
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Socket Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
            }

            return "";
        }
        private static void WriteIn(string input)
        {
            if (_stream.CanWrite)
            {
                _writeBuffer = System.Text.Encoding.ASCII.GetBytes(input);
                _stream.Write(_writeBuffer, 0, _writeBuffer.Length);
            }
        }
        private static NetworkStream _stream;
        private static TcpClient _tcpClient;
        private static byte[] _writeBuffer;
        private static byte[] _readBuffer;

        private static string ReadOut()
        {
            string output = null;

            if (_stream.CanRead)
            {
                output = ReadLines(_stream).Aggregate(output, (current, variable) => current + variable);
            }

            return output;
        }
        public static IEnumerable<string> ReadLines(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.ASCII))
            {
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
            }
        }
        public bool SearchMx(string user, string domain)
        {
            var mxRecords = DnsMx.GetMXRecords(domain);
            var isvalid = false;
            foreach (var record in mxRecords)
            {
                _address = record;
                if (WaitFor(user, domain))
                {
                    isvalid = true; break;
                }

            }
            return isvalid;
        }

        public bool WaitFor(string user, string domain)
        {



            try
            {
                var ipHostInfo = Dns.GetHostEntry(_address);
                var ipAddress = ipHostInfo.AddressList[0];
                var remoteEP = new IPEndPoint(ipAddress, _port);
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(remoteEP);

                var data = Encoding.ASCII.GetBytes("Helo hi\r\n");
                sock.Send(data);
                var buffer = new byte[sock.ReceiveBufferSize];
                //var s = Encoding.ASCII.GetString(buffer);

                var data1 = Encoding.ASCII.GetBytes("mail from: <emfami@gmail.com>\r\n");
                sock.Send(data1);
                var buffer1 = new byte[sock.ReceiveBufferSize];
                //s = Encoding.ASCII.GetString(buffer1);
                var data2 = Encoding.ASCII.GetBytes("rcpt to: <" + user + "@" + domain + ">\r\n");
                sock.Send(data2);
                var buffer2 = new byte[sock.ReceiveBufferSize];

                var s = Encoding.ASCII.GetString(buffer2);
                var data3 = Encoding.ASCII.GetBytes("quit\r\n");
                sock.Send(data3);
                return s.ToLower().Contains("ok");
                
            }
            catch (Exception ex) { return false; }

        }


        private Socket sock;

        private Encoding encoding = Encoding.UTF8;




    }
}
