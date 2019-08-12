using System.Windows;
using System.IO;
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
            textboxFAQ.Text = File.ReadAllText(LocalParameters.faqTextPath);
            _window = window;
        }
        private void buttonFAQExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
