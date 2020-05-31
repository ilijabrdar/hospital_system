using PacijentBolnicaZdravo.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro;

namespace PacijentBolnicaZdravo
{
    /// <summary>
    /// Interaction logic for WindowLogIn.xaml
    /// </summary>
    public partial class WindowLogIn : MetroWindow
    {
        public ChangeLanguage cl = new ChangeLanguage();

        public WindowLogIn()
        {
            Thread.CurrentThread.CurrentCulture = MainWindow.culture;
            Thread.CurrentThread.CurrentUICulture = MainWindow.culture;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                Language.SelectedItem = Language.Items[0];
            else
                Language.SelectedItem = Language.Items[1];


            if (MainWindow.Theme == 1)
            {
                ThemeManager.ChangeAppStyle(this,
                                   ThemeManager.GetAccent("Teal"),
                                   ThemeManager.GetAppTheme("BaseDark"));
                DarkMode.Value = DarkMode.Maximum;
            }
            else
            {
                ThemeManager.ChangeAppStyle(this,
                                   ThemeManager.GetAccent("Blue"),
                                   ThemeManager.GetAppTheme("BaseLight"));
                DarkMode.Value = DarkMode.Minimum;
            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(UsernameLogIn.Text == "admin" && PasswordLogIn.Password.ToString() == "admin")
            {
                App.j = 0;
                MainWindow mw = new MainWindow();
                mw.Show();

               
                this.Close();
                return;
            }
            if (UsernameLogIn.Text != "admin")
            {
                WrongUsername.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                WrongUsername.Visibility = Visibility.Hidden;
            }
            if (PasswordLogIn.Password.ToString() != "admin")
            {
                WrongPw.Visibility = Visibility.Visible;
            }
        

           
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if ((int)DarkMode.Value == 1)
            {
                ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Teal"),
                                    ThemeManager.GetAppTheme("BaseDark"));
                MainWindow.Theme = 1;
            }
            else
            {
                ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Blue"),
                                    ThemeManager.GetAppTheme("BaseLight"));
                MainWindow.Theme = 0;
            }
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            App.j = 0;
            Registration lg = new Registration();
            lg.Show();
            this.Close();
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(Language.SelectedIndex);
            int selected = (int)Language.SelectedIndex;

            if (App.j != 0)
            {

                if (selected == 1)
                {
                     System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                     System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
                    MainWindow.culture = new CultureInfo("en-GB");
                    cl.changeLogInWindow(this);
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("sr");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("sr");
                    MainWindow.culture = new CultureInfo("sr");
                    cl.changeLogInWindow(this);
                }
            }

            Console.WriteLine("Vrednost od j je :" + App.j);

            App.j++;
        }
    }
}
