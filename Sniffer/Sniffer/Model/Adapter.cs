using SharpPcap.LibPcap;
using SharpPcap.WinPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sniffer.Model
{
    public class Adapter
    {
        public WinPcapDevice Device { get; set; }

        public string Name
        {
            get { return Device.Name; }
        }

        public string FriendlyName
        {
            get { return Device.Interface.FriendlyName; }
        }

        public string MacAddress
        {
            get {return Device.Interface.MacAddress.ToString(); }
        }

        public string Description
        {
            get { return Device.Description; }
        }

        public string IPv6
        {
            get { return Device.Addresses[0].Addr.ToString(); }
        }

        public string IPv4
        {
            get
            {
                if (Device.Addresses[1].Addr.ToString() != "0.0.0.0" && Device.Addresses[1].Addr.ToString() != IPv6)
                    return Device.Addresses[1].Addr.ToString();
                else
                    return "Not applied";
            }
        }

        public Adapter(WinPcapDevice dev)
        {
            Device = dev;
        }


        public override string ToString()
        {
            string deviceInfo = "";
            deviceInfo += ("Ipv4: " + IPv4 + "\n");
            deviceInfo += ("Ipv6: " + IPv6 + "\n");
            deviceInfo += ("MAC: " + MacAddress + "\n");
            deviceInfo += ("Description: " + Description + "\n");
            return deviceInfo;
        }
    }
}
