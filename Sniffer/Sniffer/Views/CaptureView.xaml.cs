using SharpPcap.WinPcap;
using Sniffer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sniffer.Views
{
    /// <summary>
    /// Логика взаимодействия для CaptureView.xaml
    /// </summary>
    public partial class CaptureView : Window
    {
        public CaptureView(Adapter dev)
        {
            InitializeComponent();
            DataContext = new ViewModels.CaptureViewModel(dev);
        }
    }
}
