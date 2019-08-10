﻿using System;
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
            LotusWindow window1 = new LotusWindow(this);
            window1.ShowDialog();
            install.InternetInstaller();
        }

        private void buttonPSTD_Click(object sender, RoutedEventArgs e)
        {
            Installer install = new Installer();
            DriverInstaller driver = new DriverInstaller();
            AddCert cert = new AddCert();
            NetBIOSChange netbios = new NetBIOSChange();
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
                CreateUserClass user = new CreateUserClass();
                user.ShowUser();
            }
            else
            {
                MessageBox.Show("Wybrałeś opcję nie tworzenia konta.", "Uwaga");
            }
            MessageBoxResult _netbiosResult = MessageBox.Show("Czy chcesz zmienić nazwę NetBIOS komputera?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_netbiosResult == MessageBoxResult.Yes)
            {
                netbios.ChangeNetBIOS();
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
            // this.buttonInternet_Click;
        }

        private void buttonFAQ_Click(object sender, RoutedEventArgs e)
        {
            // OknoFAQ okno1 = new OknoFAQ(this);
            // okno1.ShowDialog();
        }
    }
}