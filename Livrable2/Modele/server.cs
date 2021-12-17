using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Livrable2.Modele
{
    class server
    {
        private Socket socket;
        private Socket client;
        public server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void SeConnecter(string ip, int port)
        {
            IPAddress ipAddress2 = IPAddress.Parse(ip);
            IPEndPoint endPoint = new IPEndPoint(ipAddress2, port);
            socket.Bind(endPoint);
            socket.Listen(1);
        }

        public void AccepterConnection()
        {
            client = socket.Accept();
        }

        public string EcouterReseau()
        {
            byte[] data = new Byte[1024];
            string a = "";
            try
            {
                int bytesRec = client.Receive(data);
                a = Encoding.ASCII.GetString(data, 0, bytesRec);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return a;
        }
        public void envoiData(string data)
        {
            byte[] dataSend = new Byte[1024];
            dataSend = Encoding.ASCII.GetBytes(data);
            Debug.WriteLine("test" + data);
            client.Send(dataSend, dataSend.Length, SocketFlags.None);
        }
        public static void Deconnecter(Socket client)
        {
            client.Close();
        }
    }
}

