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

using MyProject.Language;
using System.Globalization;
using System.Configuration;
using System.Reflection;
using PacijentBolnicaZdravo.Properties;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Windows.Markup;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using MahApps.Metro.Controls;
using MahApps.Metro;

namespace PacijentBolnicaZdravo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public ChangeLanguage cl = new ChangeLanguage();
        public static CultureInfo culture = new CultureInfo("sr");
        public static int Theme = 0;
        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Title = "JovanJelicki";
            

            InitializeComponent();
            if (Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                Language.SelectedItem = Language.Items[0];
            else
                Language.SelectedItem = Language.Items[1];

            if (Theme == 1)
            {
                ThemeManager.ChangeAppStyle(this,
                                   ThemeManager.GetAccent("Teal"),
                                   ThemeManager.GetAppTheme("BaseDark"));
                DarkMode.Value = DarkMode.Maximum;
            }else
            {
                ThemeManager.ChangeAppStyle(this,
                                   ThemeManager.GetAccent("Blue"),
                                   ThemeManager.GetAppTheme("BaseLight"));
                DarkMode.Value = DarkMode.Minimum;
            }

            


        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni da želite da se odjavite?", "Odjava", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.j = 0;
                WindowLogIn wl = new WindowLogIn();
                wl.Show();
                this.Close();
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if((int) DarkMode.Value == 1)
            {
                ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Teal"),//teal Steel
                                    ThemeManager.GetAppTheme("BaseDark"));
                Theme = 1;
            }
            else
            {
                ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Blue"),
                                    ThemeManager.GetAppTheme("BaseLight"));
                Theme = 0;
            }
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = (int)Language.SelectedIndex;

            if (App.j != 0)
            {

                if (selected == 1)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
                    MainWindow.culture = new CultureInfo("en-GB");
                    cl.changeMainWindow(this);
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("sr");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("sr");
                    MainWindow.culture = new CultureInfo("sr");
                    cl.changeMainWindow(this);

                }
            }
           
            Console.WriteLine("Vrednost od j je :" + App.j);

            App.j++;
        }

     

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            Label dr = new Label();
            Label date = new Label();
            Label time = new Label();
            Label room = new Label();

            dr.Content = "dr Jovan Jovanović";
            dr.Margin = new Thickness(8);
            date.Content = Picker.Text;
            date.Margin = new Thickness(8);
            time.Content = "10:30";
            time.Margin = new Thickness(8);
            room.Content = "308";
            room.Margin = new Thickness(8);

            FirstExam.Children.Add(dr);
            FirstExam.Children.Add(date);
            FirstExam.Children.Add(time);
            FirstExam.Children.Add(room);

            RadioButton r = new RadioButton();
            r.Margin = new Thickness(60, 8, 8, 8);
            r.Content = "Izaberi";
            FirstExam.Children.Add(r);

            RadioButtons.Content = "";
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            FirstExam.Children.Clear();
        }

        private void ChoosePhoto(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateInfo(object sender, RoutedEventArgs e)
        {

        }

        private void UpdatePw(object sender, RoutedEventArgs e)
        {
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if(ArticlesPanel.Children.Count < 5) {
                Border b = new Border();

                b.BorderThickness = new Thickness(1);
                b.BorderBrush = Brushes.Black;
                b.Height = 200;
                b.CornerRadius = new CornerRadius(3);

                b.Margin = new Thickness(5);
                ArticlesPanel.Children.Add(b);
            } else
            {
                ArticlesPanel.Children.Clear();
            }
            
        }

        private void CurrentTherapy(object sender, RoutedEventArgs e)
        {

        }

        private void Feedback(object sender, RoutedEventArgs e)
        {
            if(FeedBack.Text.Length != 0)
            {

                FeedBack.Clear();
                MessageBox.Show("Hvala Vam na odgovoru!", "Komentar", MessageBoxButton.OK, MessageBoxImage.None);

            }

        }

        private void CalendarClosedDate(object sender, RoutedEventArgs e)
        {
            RadioButton r = new RadioButton();
            r.Content = "10:30";
            r.Margin = new Thickness(5);
            Border g = new Border();
            g.BorderThickness = new Thickness(1);
            g.BorderBrush = Brushes.Black;
            g.Height = 40;
            g.Width = 100;
            g.CornerRadius = new CornerRadius(3);

            g.Margin = new Thickness(5);

            g.Child = r;

            RadioButtons.Content = g;

        }
    }
}
