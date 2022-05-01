using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LaserGame_V2_2
{
    public class NetworkService
    {
        public string SSID, Password;

        public List<Tuple<NetworkInterface, string, IPAddress>> networks = new List<Tuple<NetworkInterface, string, IPAddress>>();

        public Tuple<NetworkInterface, string, IPAddress> lastNetworkUser;

        internal void restart()
        {
            //cmd(" wlan start hostednetwork");
           
        }

        public List<Tuple<NetworkInterface, string, IPAddress>> getNetworks()
        {
            networks = new List<Tuple<NetworkInterface, string, IPAddress>>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var adapter in interfaces)
            {
                var props = adapter.GetIPProperties();
                var result = props.UnicastAddresses.FirstOrDefault(x => x.Address.AddressFamily == AddressFamily.InterNetwork);
                if (result != null)
                {
                    string display =
                        adapter.OperationalStatus
                        + " - " + result.Address
                        + " - " + adapter.Name;

                    networks.Add(new Tuple<NetworkInterface, string, IPAddress>(adapter,
                       display,
                       result.Address
                    ));
                }
            }
            return networks;

        }

        public string? checkClient(string ipCheckString, int timeoutScan_ms)
        {

            Ping p = new Ping();
            PingReply rep = p.Send(ipCheckString, timeoutScan_ms);
            if (rep.Status == IPStatus.Success)
            {
                return ipCheckString;
            }
            return null;
             
        }


        public List<string> getClients(int minSubip, int maxSubip, int timeoutScan_ms, List<string> ips = null)
        {

            if(ips == null) ips = new List<string>();

            if (lastNetworkUser != null)
            {
                IPAddress iPAddress = lastNetworkUser.Item3;
                string ipBase = "";
                ipBase += iPAddress.ToString().Split('.')[0] + ".";
                ipBase += iPAddress.ToString().Split('.')[1] + ".";
                ipBase += iPAddress.ToString().Split('.')[2] + ".";

                int posI = minSubip;
                if (minSubip <= maxSubip)
                {
                    string? respIp = checkClient(ipBase + posI, timeoutScan_ms);
                    if (respIp != null)
                    {
                        ips.Add(respIp);
                        minSubip++;

                        getClients(minSubip, maxSubip, timeoutScan_ms, ips);
                    }
                    posI++;
                }
            }

            return ips;
        }


    }
}