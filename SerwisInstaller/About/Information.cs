using System.Windows;

namespace SerwisInstaller.About
{
    internal class Information
    {
        public static void Welcome()
        {
            MessageBox.Show("Witaj w aplikacji KWP Serwis Installer v1.0, Wybierz jedną z trzech opcji instalacji i wykonuj polecenia ukazane na ekranie. W przypadku chęci dołączenia do domeny, upewnij się że masz dostęp do serwera DHCP " +
    "w sieci.", "Powitanie", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void Copyright()
        {
            MessageBox.Show("Made by Hubert Kuszyński, Komenda Wojewódzka Policji w Gorzowie Wlkp., tel. 11659 / 608 355 925.", "Copyright", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public static void Thanks()
        {
            MessageBox.Show("Dziękuję za skorzystanie z KWP Serwis Installer v1.0. Do zobaczenia next time! c(*.*c)", "Podziękowanie", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}
