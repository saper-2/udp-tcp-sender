using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections.Generic;

namespace UDP_TCP_Sender
{
    class TcpServer2
    {
        private TcpListener tcpListener;
        private Thread listenThread;

        private List<TcpClient> clientHandles = new List<TcpClient>();

        public TcpServer2(int port)
        {
            cancelAllRoutines = false;
            tcpListener = new TcpListener(IPAddress.Any, port);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();

        }



        private bool cancelAllRoutines;

        private void ListenForClients()
        {
            tcpListener.Start();
            try
            {
                while (true && cancelAllRoutines == false)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();

                    
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);

                    OnClientConnect(this, client);

                    clientHandles.Add(client);
                }
            }
            catch (SocketException)
            {
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true && cancelAllRoutines == false)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                //ASCIIEncoding encoder = new ASCIIEncoding();
                //System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                OnDataReceived(this, (TcpClient)client, bytesRead, message);
                
            }

            tcpClient.Close();
        }

        public delegate void DataReceivedHandler(object sender, TcpClient client, int length, byte[] data);
        public event DataReceivedHandler DataReceivedEvent;

        protected void OnDataReceived(object sender, TcpClient client, int length, byte[] data)
        {
            if (DataReceivedEvent != null)
            {
                //DataReceivedHandler drh = new DataReceivedHandler(DataReceivedEvent);
                //drh.BeginInvoke(sender, client, length, data, null, null);
                DataReceivedEvent(sender, client, length, data);
            }
        }

        public delegate void ClientConnectHandler(object sender, TcpClient client);
        public event ClientConnectHandler clientConnectEvent;

        protected void OnClientConnect(object sender, TcpClient client)
        {
            if (clientConnectEvent != null)
            {
                clientConnectEvent(sender, client);
            }
        }

        public void StopTcpServer()
        {
            if (clientHandles.Count > 0)
            {
                foreach (TcpClient cli in clientHandles)
                {
                    if (cli != null)
                    {
                        if (cli.Connected) cli.Close();
                    }
                }
            }

            cancelAllRoutines = true;
            tcpListener.Server.Close();
            tcpListener.Stop();

        }
    }
}
