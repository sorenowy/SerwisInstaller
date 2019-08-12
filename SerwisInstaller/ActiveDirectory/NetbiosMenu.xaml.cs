using System.Windows;
using SerwisInstaller.Configuration;

namespace SerwisInstaller.ActiveDirectory
{
    /// <summary>
    /// Interaction logic for NetbiosMenu.xaml
    /// </summary>
    public partial class NetbiosMenu : Window
    {
        private MainWindow _window = MenuParameters.mainWindow;
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
            this.Close();
        }
    }
}
