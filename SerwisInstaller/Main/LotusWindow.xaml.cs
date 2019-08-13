using System.Windows;
using SerwisInstaller.Configuration;

namespace SerwisInstaller.Main
{
    /// <summary>
    /// Logika interakcji dla klasy OknoLotus.xaml
    /// </summary>
    public partial class LotusWindow : Window
    {
        private MainWindow _window = MenuParameters.mainWindow;
        public LotusWindow()
        {
            InitializeComponent();
        }
        public LotusWindow(MainWindow mainwin)
        {
            InitializeComponent();
            _window = mainwin;
        }
        private void buttonOKLotus_Click(object sender, RoutedEventArgs ea)
        {
            Installer install = new Installer(LocalParameters.netconnection);
            install.LotusInstaller(listLotus.SelectedIndex);
            OfficeWindow officeWindow = new OfficeWindow(this);
            officeWindow.ShowDialog();
            this.Close();
        }
        private void buttonExitLotus_Click(object sender, RoutedEventArgs ea)
        {
            OfficeWindow window1 = new OfficeWindow(this);
            window1.ShowDialog();
            this.Close();
        }
    }
}

