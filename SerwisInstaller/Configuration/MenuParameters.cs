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
using SerwisInstaller.Policy;

namespace SerwisInstaller.Configuration
{
    internal class MenuParameters
    {
        internal static LotusWindow lotusWindow = null;
        internal static OfficeWindow officeWindow = null;
        internal static EKDWindow ekdWindow = null;
        internal static UserWindow userWindow = null;
        internal static NetBIOSWindow netBIOSWindow = null;
        internal static IPConfigLogWindow ipConfigLogWindow = null;

        internal static BitmapImage menuImage = new BitmapImage(new Uri(@"C:\image.jpg"));
    }
}
