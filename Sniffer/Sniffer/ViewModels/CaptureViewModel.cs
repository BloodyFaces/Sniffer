using Sniffer.Model;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sniffer.Commands;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;

namespace Sniffer.ViewModels
{
    class CaptureViewModel : ObservableObject
    {
        private Adapter adapter;
        private Dispatcher dispatcher;
        private ObservableCollection<RawCapture> packets;

        public CaptureViewModel(Adapter dev)
        {
            dispatcher = Dispatcher.CurrentDispatcher;
            adapter = dev;
            packets = new ObservableCollection<RawCapture>();
            CaptureStartCommand = new RelayCommand(CaptureStartExecute, CaptureStartCanExecute);
            CaptureStopCommand = new RelayCommand(CaptureStopExecute, CaptureStopCanExecute);
        }

        public ObservableCollection<RawCapture> Packets
        {
            get { return packets; }
            set
            {
                packets = value;
                OnPropertyChanged("Packets");
            }
        }

        public RelayCommand CaptureStartCommand { get; set; }
        public RelayCommand CaptureStopCommand { get; set; }

        private void CaptureStartExecute()
        {
            adapter.Device.OnPacketArrival += new PacketArrivalEventHandler(OnPacketArrival);
            adapter.Device.Open(DeviceMode.Promiscuous, 1000);
            adapter.Device.StartCapture();
        }

        private bool CaptureStartCanExecute()
        {
            return !adapter.Device.Opened;
        }

        private bool CaptureStopCanExecute()
        {
            return adapter.Device.Opened;
        }

        private void CaptureStopExecute()
        {
            adapter.Device.OnPacketArrival -= OnPacketArrival;
            adapter.Device.StopCapture();
            adapter.Device.Close();
        }

        private void OnPacketArrival(object sender, CaptureEventArgs e)
        {
            dispatcher.Invoke(new Action(() =>
            {
                packets.Add(e.Packet);
            }));
        }
    }
}
