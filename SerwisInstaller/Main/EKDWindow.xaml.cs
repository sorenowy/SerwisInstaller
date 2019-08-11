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

namespace SerwisInstaller.Main
{
    /// <summary>
    /// Interaction logic for EKDWindow.xaml
    /// </summary>
    public partial class EKDWindow : Window
    {
        private MainWindow _window = MenuParameters.mainWindow;
        public EKDWindow()
        {
            InitializeComponent();
        }
        public EKDWindow(MainWindow window)
        {
            InitializeComponent();
            _window = window;
        }

        private void buttonOKEKD_Click(object sender, RoutedEventArgs e)
        {
            Installer install = new Installer();
            install.EKDAuthInstaller(listEKD.SelectedIndex);
            this.Close();
        }
        private void buttonExitEKD_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
