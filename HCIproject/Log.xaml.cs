using Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
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

namespace HCIproject
{
    public partial class Log : Window
    {
        public String Username { get; set; }
        public Log()
        {
            this.DataContext = this;

            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;

            PasswordBox passwordBox = FindName("password_text") as PasswordBox;
            try
            {
                Doctor user = (Doctor)app.UserController.Login(Username, passwordBox.Password);
                if (user == null)
                {
                    obavestiGreska.Text = "Uneti podaci su neispravni. Molimo pokusajte ponovo";
                }
                else
                {
                    SideBar sidBarWin = new SideBar((Doctor)user);
                    this.Visibility = Visibility.Hidden;
                    sidBarWin.Show();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWin.Show();
        }

        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {
            obavestiGreska.Text = "";

        }
    }
}
