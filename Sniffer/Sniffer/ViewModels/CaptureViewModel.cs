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
using PacketDotNet;

namespace Sniffer.ViewModels
{
    class CaptureViewModel : ObservableObject
    {
        private Adapter adapter;
        private Dispatcher dispatcher;
        private ObservableCollection<Frame> packets;
        private string details;
        private int counter = 0;
        private bool wasSelected;
        private string hexDetails;

        public CaptureViewModel(Adapter dev)
        {
            wasSelected = false;
            SelectionChangedCommand = new RelayCommand<object>(SelectionChangedExecute);
            dispatcher = Dispatcher.CurrentDispatcher;
            adapter = dev;
            packets = new ObservableCollection<Frame>();
            CaptureStartCommand = new RelayCommand(CaptureStartExecute, CaptureStartCanExecute);
            CaptureStopCommand = new RelayCommand(CaptureStopExecute, CaptureStopCanExecute);
            CleanCommand = new RelayCommand(CleanExecute, CleanCanExecute);
        }

        public ObservableCollection<Frame> Packets
        {
            get { return packets; }
            set
            {
                packets = value;
                OnPropertyChanged("Packets");
            }
        }

        public int SelectedIndex { get; set; }

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
                try
                {
                    counter++;
                    packets.Add(new Frame(e.Packet, counter));
                }
                catch (ArgumentOutOfRangeException exc)
                {

                }
            }));
        }

        public string Details
        {
            get { return details; }
            set
            {
                details = value;
                OnPropertyChanged("Details");
            }
        }

        public string HexDetails
        {
            get { return hexDetails; }
            set
            {
                hexDetails = value;
                OnPropertyChanged("HexDetails");
            }
        }

        public RelayCommand<object> SelectionChangedCommand { get; set; }
        public RelayCommand DetailsCommand { get; set; }

        public RelayCommand CleanCommand { get; set; }

        private void SelectionChangedExecute(object param)
        {
            if (param is int)
            {
                int index = (int)param;
                wasSelected = true;
                SelectedIndex = index;
                if (SelectedIndex == -1)
                {
                    Details = "";
                    HexDetails = "";
                }
                else
                { 
                    Details = packets[SelectedIndex].Content;
                    HexDetails = packets[SelectedIndex].HexContent;
                }
            }
        }

        private void DetailsExecute()
        {

        }

        private bool DetailsCanExecute()
        {
            return wasSelected;
        }

        private void CleanExecute()
        {
            counter = 0;
            packets.Clear();
        }

        private bool CleanCanExecute()
        {
            return packets.Count != 0;
        }
    }
}
