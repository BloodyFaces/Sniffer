using SharpPcap;
using SharpPcap.WinPcap;
using Sniffer.Commands;
using Sniffer.Model;
using Sniffer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sniffer.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<Adapter> adapters;
        private string details;
        private bool wasSelected;

        public MainWindowViewModel()
        {
            SelectionChangedCommand = new RelayCommand<object>(SelectionChangedExecute);
            CaptureCommand = new RelayCommand(CaptureExecute, CaptureCanExecute);
            wasSelected = false;
            adapters = new ObservableCollection<Adapter>();
            WinPcapDeviceList devices = WinPcapDeviceList.Instance;
            foreach (WinPcapDevice dev in devices)
            {
                adapters.Add(new Adapter(dev));
            }
        }

        public int SelectedIndex { get; set; }

        public string Details
        {
            get { return details; }
            set
            {
                details = value;
                OnPropertyChanged("Details");
            }
        }

        public ObservableCollection<Adapter> AdaptersList
        {
            get { return adapters; }
            set
            {
                adapters = value;
                OnPropertyChanged("AdaptersList");
            }
        }

        public RelayCommand<object> SelectionChangedCommand { get; set; }

        public RelayCommand CaptureCommand { get; set; }

        private void SelectionChangedExecute(object param)
        {
            if (param is int)
            {
                int index = (int)param;
                wasSelected = true;
                SelectedIndex = index;
                Details = adapters[SelectedIndex].ToString();
            }
        }

        private void CaptureExecute()
        {
            ViewsContainer.captureView = new CaptureView(adapters[SelectedIndex]);
            ViewsContainer.captureView.Show();
            ViewsContainer.mainView.Close();
        }

        private bool CaptureCanExecute()
        {
            return wasSelected;
        }
    }
}
