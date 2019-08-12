using System.Windows;
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
            Installer install = new Installer(LocalParameters.netconnection);
            install.EKDAuthInstaller(listEKD.SelectedIndex);
            this.Close();
        }
        private void buttonExitEKD_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
