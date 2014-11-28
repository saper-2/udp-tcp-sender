using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace UDP_TCP_Sender
{


    public class IPAddressIntfList
    {
        public string GetLocalIPv4()
        {
            //List<string> output = new List<string>();
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output += ip.Address.ToString() + " ";
                        }
                    }
                }
            }
            return output;
        }
    }

}
