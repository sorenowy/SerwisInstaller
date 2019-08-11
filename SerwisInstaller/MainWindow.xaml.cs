using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        {
            InitializeComponent();
            imageMenu.Source = MenuParameters.menuImage;
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonInternet_Click(object sender, RoutedEventArgs e)
        {
            Installer install = new Installer();
            install.ShitRemover();
            LotusWindow window1 = new LotusWindow(this);
            window1.ShowDialog();
            install.InternetInstaller();
            MessageBoxResult _userResult = MessageBox.Show("Czy chcesz utworzyć konto użytkownika na komputerze?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_userResult == MessageBoxResult.Yes)
            {
                UserMenu window3 = new UserMenu();
                window3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga");
            }
            MessageBoxResult _policyResult = MessageBox.Show("Czy chcesz zainstalować polityke bezpieczeństwa KWP na komputerze? Tak aby dojebać Skwarczewską z Finansów??", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_policyResult == MessageBoxResult.Yes)
            {
                SecurityPolicy secpol = new SecurityPolicy();
                secpol.ApplySecurityPolicy();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie instalowania polityki (kagańca :)).", "Uwaga");
            }
            MessageBoxResult _ipconfiglogResult = MessageBox.Show("Czy chcesz utworzyć Loga Ipconfig -all na komputerze, który zostanie zapisany w folderze programu/Logs/IPConfigLogs?","Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_ipconfiglogResult == MessageBoxResult.Yes)
            {
                IPConfigLogMenu window4 = new IPConfigLogMenu();
                window4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia loga.", "Uwaga");
            }
            MessageBoxResult _netbiosResult = MessageBox.Show("Czy chcesz Dołączyć do domeny? Wcisnij klawisz Tak, aby dołączyć, Klawisz Nie, aby zmienić nazwę NetBIOS komputera. Anuluj aby pominąć.", "Uwaga", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (_netbiosResult == MessageBoxResult.Yes)
            {
                NetbiosMenu window4 = new NetbiosMenu();
                NetBIOSChange domain = new NetBIOSChange();
                window4.ShowDialog();
                domain.JoinDomain();
            }
            else if (_netbiosResult == MessageBoxResult.No)
            {
                NetbiosMenu window4 = new NetbiosMenu();
                window4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga");
            }
            MessageBoxResult _restartResult = MessageBox.Show("Czy chcesz dokonać restartu komputera w celu zapisania zmian.", "Restart", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (_restartResult == MessageBoxResult.Yes)
            {
                Process.Start("shutdown /r /f/ t 0");
                Close();
            }
            else
            {
                Close();
            }
        }

        private void buttonPSTD_Click(object sender, RoutedEventArgs e)
        {
            Installer install = new Installer();
            DriverInstaller driver = new DriverInstaller();
            AddCert cert = new AddCert();
            install.ShitRemover();
            LotusWindow window1 = new LotusWindow(this);
            window1.ShowDialog();
            EKDWindow window2 = new EKDWindow(this);
            window2.ShowDialog();
            install.PSTDInstaller();
            driver.InstallDriver();
            cert.InstallInfrastrukturaCert("infrastruktura_2019.der");
            MessageBoxResult _userResult = MessageBox.Show("Czy chcesz utworzyć konto użytkownika na komputerze?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(_userResult == MessageBoxResult.Yes)
            {
                UserMenu window3 = new UserMenu();
                window3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga");
            }
            MessageBoxResult _ipconfiglogResult = MessageBox.Show("Czy chcesz utworzyć Loga Ipconfig -all na komputerze, który zostanie zapisany w folderze programu/Logs/IPConfigLogs?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_ipconfiglogResult == MessageBoxResult.Yes)
            {
                IPConfigLogMenu window4 = new IPConfigLogMenu();
                window4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia loga.", "Uwaga");
            }
            MessageBoxResult _netbiosResult = MessageBox.Show("Czy chcesz zmienić nazwę NetBIOS komputera?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_netbiosResult == MessageBoxResult.Yes)
            {
                NetbiosMenu window4 = new NetbiosMenu();
                window4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga");
            }
            MessageBoxResult _restartResult = MessageBox.Show("Czy chcesz dokonać restartu komputera w celu zapisania zmian.", "Restart", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (_restartResult == MessageBoxResult.Yes)
            {
                Process.Start("shutdown /r /f/ t 0");
                Close();
            }
            else
            {
                Close();
            }
        }
        private void buttonCWI_Click(object sender, RoutedEventArgs e)
        {
            Installer install = new Installer();
            AddCert cert = new AddCert();
            install.ShitRemover();
            LotusWindow window1 = new LotusWindow(this);
            window1.ShowDialog();
            install.CWIInstaller();
            cert.InstallCWICert("CWI_CERT.cer");
            MessageBoxResult _userResult = MessageBox.Show("Czy chcesz utworzyć konto użytkownika na komputerze?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_userResult == MessageBoxResult.Yes)
            {
                UserMenu window3 = new UserMenu();
                window3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga");
            }
            MessageBoxResult _policyResult = MessageBox.Show("Czy chcesz zainstalować polityke bezpieczeństwa KWP na komputerze? Tak aby dojebać Skwarczewską z Finansów??", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_policyResult == MessageBoxResult.Yes)
            {
                SecurityPolicy secpol = new SecurityPolicy();
                secpol.ApplySecurityPolicy();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie instalowania polityki (kagańca :)).", "Uwaga");
            }
            MessageBoxResult _netbiosResult = MessageBox.Show("Czy chcesz zmienić nazwę NetBIOS komputera?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_netbiosResult == MessageBoxResult.Yes)
            {
                NetbiosMenu window4 = new NetbiosMenu();
                window4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga");
            }
            MessageBoxResult _restartResult = MessageBox.Show("Czy chcesz dokonać restartu komputera w celu zapisania zmian.", "Restart", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (_restartResult == MessageBoxResult.Yes)
            {
                Process.Start("shutdown /r /f/ t 0");
                Close();
            }
            else
            {
                Close();
            }
        }
        private void buttonFAQ_Click(object sender, RoutedEventArgs e)
        {
            FAQWindow window = new FAQWindow(this);
            window.ShowDialog();
        }
        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("mailto:" + LocalParameters.addressMail + "?subject=" + LocalParameters.helpSubject + "&body="
                + "Data wystąpienia problemu: " + DateTime.Now);
        }
    }
}
