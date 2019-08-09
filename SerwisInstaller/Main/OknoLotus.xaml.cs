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

namespace SerwisInstaller.Main
{
    /// <summary>
    /// Logika interakcji dla klasy OknoLotus.xaml
    /// </summary>
    public partial class OknoLotus : Window
    {
        private MainWindow _window = null;
        public OknoLotus()
        {
            InitializeComponent();
        }
        public OknoLotus(MainWindow mainwin)
        {
            InitializeComponent();
            _window = mainwin;
        }
        private void buttonOKLotus_Click(object sender, RoutedEventArgs ea)
        {
            Installer install = new Installer();
            install.InstallLotus(listaLotus.SelectedIndex);
            OknoOffice okno1 = new OknoOffice(this);
            okno1.ShowDialog();
        }
        private void buttonExitLotus_Click(object sender, RoutedEventArgs ea)
        {
            OknoOffice okno1 = new OknoOffice(this);
            okno1.ShowDialog();
        }
    }
}

