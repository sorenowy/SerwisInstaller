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
    /// Logika interakcji dla klasy OknoOffice.xaml
    /// </summary>
    public partial class OknoOffice : Window
    {
        private OknoLotus _oknoLotus = null;
        public OknoOffice()
        {
            InitializeComponent();
        }
        public OknoOffice(OknoLotus window)
        {
            InitializeComponent();
            _oknoLotus = window;
        }
    }
}
