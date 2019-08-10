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

namespace SerwisInstaller.About
{
    /// <summary>
    /// Interaction logic for FAQWindow.xaml
    /// </summary>
    public partial class FAQWindow : Window
    {
        private MainWindow _window = MenuParameters.mainWindow;
        public FAQWindow()
        {
            InitializeComponent();
        }
        public FAQWindow(MainWindow window)
        {
            InitializeComponent();
            _window = window;
        }
        private void buttonFAQExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
