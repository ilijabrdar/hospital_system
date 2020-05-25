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

namespace HCIproject
{
    /// <summary>
    /// Interaction logic for Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        public Log()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (username_text.Text == "" || username_text.Text == "unesite vaše korisničko ime" || username_text.Text == "Molimo pokušajte ponovo")
            {
                username_text.Text = "Molimo pokušajte ponovo";

            }
            else if (password_text.Password == "")
            {
                return;
            }
            else
            {
                SideBar sidBarWin = new SideBar();
                this.Visibility = Visibility.Hidden;
                sidBarWin.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWin.Show();
        }

        private void TextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (username_text.Text == "unesite vaše korisničko ime" || username_text.Text == "Molimo pokušajte ponovo")
            {
                username_text.Text = "";
            }
        }

        private void username_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                password_text.Focus();
            }
        }
        private void password_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                prijavaBtn.Focus();
            }
        }
    }
}
