﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace UDP_TCP_Sender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void aLog(string msg, bool noNewLine = false, bool noDate = false)
        {
            eLog.AppendText(
                (noDate ? "" : DateTime.Now.ToString("HH:mm:ss") + ": ") +
                msg +
                (noNewLine ? "" : Environment.NewLine)
                );
        }

        int sendTCPString(string host, int port, string data)
        {
            try
            {
                TcpClient cli = new TcpClient(host, port);
                byte[] dta = Encoding.ASCII.GetBytes(data);

                NetworkStream ns = cli.GetStream();
                ns.Write(dta, 0, dta.Length);
                ns.Close();
                cli.Close();
                return dta.Length;
            }
            catch (Exception ee)
            {
               aLog(ee.ToString(), false, true);
               return -1;
            }
        }

        int sendUDPString(string host, int port, string data)
        {
            int res = -1;
            try
            {
                IPAddress[] addrs = Dns.GetHostAddresses(host);
                IPAddress addr = addrs[0];
                IPEndPoint endp = new IPEndPoint(addr, port);
                byte[] dta = Encoding.ASCII.GetBytes(data);
                using (Socket cli = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    res = cli.SendTo(dta, endp);
                    cli.Close();
                }
            }
            catch (Exception ee)
            {
                aLog(ee.ToString(), false, true);
            }
            return res;
        }

        private string byteArrayToHexDump(byte[] data, int len)
        {
            string res = "";

            if (len < 1) return "";
            if (data.Length < len) return "-data.length < len-";

            res += Environment.NewLine;

            for (int i = 0; i < len; i++)
            {
                    res += data[i].ToString("X2") + " ";
                    if ((i % 16) == 0 && i > 0)
                    {
                        res += Environment.NewLine;
                    }
                    else
                    {
                        if ((i % 7) == 0 && i > 0 && (i % 16) < 12)
                        {
                            res += "  ";
                        }
                    }
            }
            res += Environment.NewLine;

            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aLog("Sending TCP data to: " + eDest.Text + ":" + ePort.Value.ToString() + 
                ", len=" + eData.Text.Length.ToString() + " data=" + eData.Text);
            sendTCPString(eDest.Text, (int)ePort.Value, eData.Text);
            aLog("If no error then ok.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aLog("Sending UDP data to: " + eDest.Text + ":" + ePort.Value.ToString() + ", len=" + eData.Text.Length.ToString() + " data=" + eData.Text);
            int r = sendUDPString(eDest.Text, (int)ePort.Value, eData.Text);
            aLog("UDP_Send=" + r.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            eDest.Text = "192.168.2.32";
            ePort.Value = 2222;
        }

        TcpServer2 server = null;

        private void button3_Click(object sender, EventArgs e)
        {
            aLog("Starting tcp server...");
            server = new TcpServer2((int)ePort.Value);
            server.DataReceivedEvent += new TcpServer2.DataReceivedHandler(server_DataReceivedEvent);

            server.clientConnectEvent += new TcpServer2.ClientConnectHandler(server_clientConnectEvent);
            aLog("Server started.");
            button3.Enabled = false;
        }

        // on client connect
        delegate void server_clientConnectEventDelegate(object sender, TcpClient client);
        void server_clientConnectEvent(object sender, TcpClient client)
        {
            if (InvokeRequired)
            {
                Invoke(
                    new server_clientConnectEventDelegate(server_clientConnectEvent), sender, client
                    );
            }
            else
            {
                aLog("SERVER: client connect: " + client.Client.RemoteEndPoint.ToString());
            }

        }

        // Have to be delegated :/
        delegate void server_DataReceivedEventDelegated(object sender, TcpClient client, int length, byte[] data);
        void server_DataReceivedEvent(object sender, TcpClient client, int length, byte[] data)
        {
            if (InvokeRequired)
            {
                Invoke(
                    new server_DataReceivedEventDelegated(server_DataReceivedEvent), sender, client, length, data);
            }
            else
            {
                aLog(
                    "SERVER received data, client=" + client.Client.AddressFamily.ToString() +
                        " len=" + length.ToString() +
                        " data=" + (new ASCIIEncoding()).GetString(data, 0, length)
                    );
                aLog("hexDump(data):" + byteArrayToHexDump(data, length));

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null) server.StopTcpServer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            aLog("I am doing nothing! Don't hit me!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            aLog("Created by saper_2. Mainly for testing ESP8266 comm.");
        }
    }
}
