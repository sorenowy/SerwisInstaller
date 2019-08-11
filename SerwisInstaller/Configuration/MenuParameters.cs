using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using SerwisInstaller.ActiveDirectory;
using SerwisInstaller.Main;
using SerwisInstaller.Logs;
using SerwisInstaller.About;

namespace SerwisInstaller.Configuration
{
    internal class MenuParameters
    {
        internal static MainWindow mainWindow = null;
        internal static FAQWindow faqWindow = null;
        internal static LotusWindow lotusWindow = null;

        internal static string iconPath = Environment.CurrentDirectory + @"\Images\icon.ico";
        internal static BitmapImage menuImage = new BitmapImage(new Uri(Environment.CurrentDirectory+@"\Images\image.jpg"));
    }
}
