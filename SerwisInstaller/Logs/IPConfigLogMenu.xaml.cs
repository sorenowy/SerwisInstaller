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
