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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SerwisInstaller.Main;

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
            obrazekMenu.Source = new BitmapImage(new Uri(@"C:\image.jpg"));
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonInternet_Click(object sender, RoutedEventArgs e)
        {
            OknoLotus okno1 = new OknoLotus(this);
            okno1.ShowDialog();
        }

        private void buttonPSTD_Click(object sender, RoutedEventArgs e)
        {
            // this.buttonInternet_Click;
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
