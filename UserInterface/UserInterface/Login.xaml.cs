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
using Model.Users;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public String Username { get; set; }

        public Login()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;

            var userController = app.UserController;
            var SecretaryController = app.SecretaryController;
            PasswordBox passwordBox = FindName("password") as PasswordBox;
            try
            {
                Secretary user = (Secretary)userController.Login(Username, passwordBox.Password);
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
                if (!user.Loged)
                {
                    user.Loged = true;
                    SecretaryController.Edit(user);
                    IntroductionWizard wizard = new IntroductionWizard();
                    wizard.ShowDialog();
                }
            }
            catch(Exception exception)
            {
                TextBlock err = (TextBlock)FindName("ErrorMessage");
                err.Visibility = Visibility.Visible;
            }     
        }
    }
}
