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
    /// Logika interakcji dla klasy OknoOffice.xaml
    /// </summary>
    public partial class OfficeWindow : Window
    {
        private LotusWindow _lotuswindow = MenuParameters.lotusWindow;
        public OfficeWindow()
        {
            InitializeComponent();
        }
        public OfficeWindow(LotusWindow window)
        {
            InitializeComponent();
            _lotuswindow = window;
        }

        private void buttonOfficeOK_Click(object sender, RoutedEventArgs e)
        {
            Installer install = new Installer();
            install.OfficeInstaller(listOffice.SelectedIndex);
            this.Close();
        }

        private void buttonOfficeExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
