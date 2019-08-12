using System.Windows;
using SerwisInstaller.Configuration;

namespace SerwisInstaller.ActiveDirectory
{
    /// <summary>
    /// Interaction logic for UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        private MainWindow _window = MenuParameters.mainWindow;
        public UserMenu()
        {
            InitializeComponent();
        }
        public UserMenu(MainWindow window)
        {
            InitializeComponent();
            _window = window;
        }

        private void buttonAdmin_Click(object sender, RoutedEventArgs e)
        {
            CreateUserClass user = new CreateUserClass();
            user.option = 1;
            LocalParameters.username = textboxUsername.Text;
            user.ShowUser();
            this.Close();
        }
        private void buttonUser_Click(object sender, RoutedEventArgs e)
        {
            CreateUserClass user = new CreateUserClass();
            user.option = 2;
            LocalParameters.username = textboxUsername.Text;
            user.ShowUser();
            this.Close();
        }
    }
}
