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
        public String Password { get; set; }

        public Login()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;

            var userController = app.UserController;
            Secretary user = (Secretary) userController.Login("pera", "pera");
            //if(userController.Login())
            MainWindow mainWindow = new MainWindow(user);
            this.Close();
        }
    }
}
