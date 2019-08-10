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
using SerwisInstaller.Configuration;

namespace SerwisInstaller.ActiveDirectory
{
    /// <summary>
    /// Interaction logic for NetbiosMenu.xaml
    /// </summary>
    public partial class NetbiosMenu : Window
    {
        private MainWindow _window = null;
        public NetbiosMenu()
        {
            InitializeComponent();
        }
        public NetbiosMenu(MainWindow window)
        {
            InitializeComponent();
            _window = window;
        }
        private void buttonNetbiosOK_Click(object sender, RoutedEventArgs e)
        {
            NetBIOSChange netbios = new NetBIOSChange();
            LocalParameters.netBIOSname = textboxNetbios.Text;
            netbios.ChangeNetBIOS();
        }
    }
}
