using System;
using System.Windows;
using System.Diagnostics;
using SerwisInstaller.Main;
using SerwisInstaller.ActiveDirectory;
using SerwisInstaller.Logs;
using SerwisInstaller.Policy;
using SerwisInstaller.Configuration;
using SerwisInstaller.About;

namespace SerwisInstaller
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { // inicjalizowanie obiektu i dodanie elementów i messageboxow do menu głównego.
            InitializeComponent();
            imageMenu.Source = MenuParameters.menuImage;
            Information.Welcome();
            Information.Copyright();
            MenuParameters.InstallationConnectionSelect(); // wybór scieżki instalacji
        }
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonInternet_Click(object sender, RoutedEventArgs e)
        {
            Installer install = new Installer(LocalParameters.netconnection);
            install.ShitRemover();
            LotusWindow lotusWindow = new LotusWindow(this);
            lotusWindow.ShowDialog();
            install.InternetInstaller();
            MessageBoxResult _userResult = MessageBox.Show("Czy chcesz utworzyć konto użytkownika na komputerze?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_userResult == MessageBoxResult.Yes)
            {
                UserMenu userWindow = new UserMenu();
                userWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga",MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            MessageBoxResult _policyResult = MessageBox.Show("Czy chcesz zainstalować polityke bezpieczeństwa KWP na komputerze??", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_policyResult == MessageBoxResult.Yes)
            {
                SecurityPolicy secpol = new SecurityPolicy();
                secpol.ApplySecurityPolicy();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie instalowania polityki bezpieczeństwa KWP.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            MessageBoxResult _ipconfiglogResult = MessageBox.Show("Czy chcesz utworzyć Loga Ipconfig -all na komputerze, który zostanie zapisany w folderze programu/Logs/IPConfigLogs?","Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_ipconfiglogResult == MessageBoxResult.Yes)
            {
                IPConfigLogMenu iplogWindow = new IPConfigLogMenu();
                iplogWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia loga.", "Uwaga",MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            MessageBoxResult _netbiosResult = MessageBox.Show("Czy chcesz Dołączyć do domeny? Wcisnij klawisz Tak, aby dołączyć, Klawisz Nie, aby zmienić nazwę NetBIOS komputera. Anuluj aby pominąć.", "Uwaga", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (_netbiosResult == MessageBoxResult.Yes)
            {
                NetbiosMenu netbiosWindow = new NetbiosMenu();
                NetBIOSChange domain = new NetBIOSChange();
                netbiosWindow.ShowDialog();
                domain.JoinDomain();
            }
            else if (_netbiosResult == MessageBoxResult.No)
            {
                NetbiosMenu netbiosWindow = new NetbiosMenu();
                netbiosWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            MessageBoxResult _restartResult = MessageBox.Show("Czy chcesz dokonać restartu komputera w celu zapisania zmian.", "Restart", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (_restartResult == MessageBoxResult.Yes)
            {
                Information.Thanks();
                Process.Start("shutdown /r /f/ t 0");
                Close();
            }
            else
            {
                Information.Thanks();
                Close();
            }
        }

        private void buttonPSTD_Click(object sender, RoutedEventArgs e)
        {
            Installer install = new Installer(LocalParameters.netconnection);
            DriverInstaller driver = new DriverInstaller(LocalParameters.netconnection);
            AddCert cert = new AddCert(LocalParameters.netconnection);
            install.ShitRemover();
            LotusWindow lotusWindow = new LotusWindow(this);
            lotusWindow.ShowDialog();
            EKDWindow ekdWindow = new EKDWindow(this);
            ekdWindow.ShowDialog();
            install.PSTDInstaller();
            driver.InstallDriver();
            cert.InstallInfrastrukturaCert("infrastruktura2019.der");
            MessageBoxResult _userResult = MessageBox.Show("Czy chcesz utworzyć konto użytkownika na komputerze?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(_userResult == MessageBoxResult.Yes)
            {
                UserMenu userWindow = new UserMenu();
                userWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga",MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            MessageBoxResult _ipconfiglogResult = MessageBox.Show("Czy chcesz utworzyć Loga Ipconfig -all na komputerze, który zostanie zapisany w folderze programu/Logs/IPConfigLogs?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_ipconfiglogResult == MessageBoxResult.Yes)
            {
                IPConfigLogMenu iplogWindow = new IPConfigLogMenu();
                iplogWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia loga.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            MessageBoxResult _netbiosResult = MessageBox.Show("Czy chcesz zmienić nazwę NetBIOS komputera?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_netbiosResult == MessageBoxResult.Yes)
            {
                NetbiosMenu netbiosWindow = new NetbiosMenu();
                netbiosWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie zmieniania nazwy.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            MessageBoxResult _restartResult = MessageBox.Show("Czy chcesz dokonać restartu komputera w celu zapisania zmian.", "Restart", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (_restartResult == MessageBoxResult.Yes)
            {
                Information.Thanks();
                Process.Start("shutdown /r /f/ t 0");
                Close();
            }
            else
            {
                Information.Thanks();
                this.Close();
            }
        }
        private void buttonCWI_Click(object sender, RoutedEventArgs e)
        {
            Installer install = new Installer(LocalParameters.netconnection);
            AddCert cert = new AddCert(LocalParameters.netconnection);
            install.ShitRemover();
            LotusWindow lotusWindow = new LotusWindow(this);
            lotusWindow.ShowDialog();
            install.CWIInstaller();
            cert.InstallCWICert("CWI_CERT.cer");
            MessageBoxResult _userResult = MessageBox.Show("Czy chcesz utworzyć konto użytkownika na komputerze?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_userResult == MessageBoxResult.Yes)
            {
                UserMenu userWindow = new UserMenu();
                userWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            MessageBoxResult _policyResult = MessageBox.Show("Czy chcesz zainstalować polityke bezpieczeństwa KWP na komputerze??", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_policyResult == MessageBoxResult.Yes)
            {
                SecurityPolicy secpol = new SecurityPolicy();
                secpol.ApplySecurityPolicy();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie instalowania polityki bezpieczeństwa KWP.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            MessageBoxResult _netbiosResult = MessageBox.Show("Czy chcesz zmienić nazwę NetBIOS komputera?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_netbiosResult == MessageBoxResult.Yes)
            {
                NetbiosMenu netbiosWindow = new NetbiosMenu();
                netbiosWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie zmieniania nazwy.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            MessageBoxResult _restartResult = MessageBox.Show("Czy chcesz dokonać restartu komputera w celu zapisania zmian.", "Restart", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (_restartResult == MessageBoxResult.Yes)
            {
                Information.Thanks();
                Process.Start("shutdown /r /f/ t 0");
                this.Close();
            }
            else
            {
                Information.Thanks();
                this.Close();
            }
        }
        private void buttonFAQ_Click(object sender, RoutedEventArgs e)
        {
            FAQWindow faqWindow = new FAQWindow(this);
            faqWindow.ShowDialog();
        }
        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("mailto:" + LocalParameters.addressMail + "?subject=" + LocalParameters.helpSubject + "&body="
                + "Data wystąpienia problemu: " + DateTime.Now);
        }
    }
}
