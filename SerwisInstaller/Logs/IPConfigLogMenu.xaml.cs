using System.Windows;
using SerwisInstaller.Configuration;

namespace SerwisInstaller.Logs
{
    /// <summary>
    /// Interaction logic for IPConfigLogMenu.xaml
    /// </summary>
    public partial class IPConfigLogMenu : Window
    {
        private MainWindow _window = MenuParameters.mainWindow;
        public IPConfigLogMenu()
        {
            InitializeComponent();
        }
        public IPConfigLogMenu(MainWindow window)
        {
            InitializeComponent();
            _window = window;
        }
        private void buttonIPconfigOK_Click(object sender, RoutedEventArgs e)
        {
            IPConfigLog log = new IPConfigLog();
            LocalParameters.inventoryNumber = textboxInventoryNumber.Text;
            log.GenerateIPConfigLog();
            this.Close();
        }
    }
}
