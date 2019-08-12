using System;
using System.Windows;
using System.Windows.Media.Imaging;
using SerwisInstaller.Main;

namespace SerwisInstaller.Configuration
{
    internal class MenuParameters
    {
        internal static MainWindow mainWindow = null;
        internal static LotusWindow lotusWindow = null;
        internal static string iconPath = Environment.CurrentDirectory + @"\Images\icon.ico";
        internal static BitmapImage menuImage = new BitmapImage(new Uri(Environment.CurrentDirectory+@"\Images\image.jpg"));

        public static void InstallationConnectionSelect()
        {
            MessageBoxResult _connectionResult = MessageBox.Show("Czy chcesz uruchomić program w trybie autonomicznym? (Offline Mode)", "Typ instalacji", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (_connectionResult == MessageBoxResult.Yes)
            {
                LocalParameters.netconnection = false;
            }
            else
            {
                LocalParameters.netconnection = true;
            }
        }
    }
}
