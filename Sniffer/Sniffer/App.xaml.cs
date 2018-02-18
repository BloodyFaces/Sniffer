using Sniffer.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sniffer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            ViewsContainer container = new ViewsContainer();
            ViewsContainer.mainView = new MainWindow();
            ViewsContainer.mainView.Show();
        }
    }
}
