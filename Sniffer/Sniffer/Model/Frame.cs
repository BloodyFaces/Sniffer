using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sniffer.Model
{
    public class Frame
    {
        private Packet packet;
        private DateTime time;
        private int length;
        private string position;

        public Frame(RawCapture pack, int pos)
        {
            packet = Packet.ParsePacket(pack.LinkLayerType, pack.Data);
            time = pack.Timeval.Date;
            length = pack.Data.Length;
            position = pos.ToString();
            Content = packet.ToString();
            HexContent = packet.PrintHex();
        }

        public string Time
        {
            get { return "at " + time.Hour + ":" + time.Minute + ":" + time.Second + "," + time.Millisecond; }
        }

        public string Length
        {
            get { return length.ToString() + " bytes"; }
        }

        public string Content { get; set; }

        public string HexContent { get; set; }

        public string Position
        {
            get
            {
                return position.ToString() + ": ";
            }
            set
            {
                position = value;
            }
         }
    }
}
