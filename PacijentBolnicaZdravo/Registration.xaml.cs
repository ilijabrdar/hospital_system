using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro;
using MahApps.Metro.Controls;
using Model.Users;
using PacijentBolnicaZdravo.Properties;

namespace PacijentBolnicaZdravo
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : MetroWindow, INotifyPropertyChanged
    {
        public ChangeLanguage cl = new ChangeLanguage();
        public Registration()
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
            this.DataContext = this;

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

        private void CreateUser(object sender, RoutedEventArgs e)
        {

        }

        private void LogInPage(object sender, RoutedEventArgs e)
        {
            App.j = 0;
            WindowLogIn lg = new WindowLogIn();
            lg.Show();
            this.Close();
        }

        private void ChoosePhoto(object sender, RoutedEventArgs e)
        {

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
                    cl.changeRegistrationWindow(this);
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("sr");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("sr");
                    MainWindow.culture = new CultureInfo("sr");
                    cl.changeRegistrationWindow(this);
                }
            }

            Console.WriteLine("Vrednost od j je :" + App.j);

            App.j++;
        }

        private void UpdateInfo(object sender, RoutedEventArgs e)
        {
            String name = Name.Text.ToString();
            String surname = Surname.Text.ToString();
            String Id = ID.Text.ToString();
            DateTime date = DateTime.Parse(DateBirth.Text);
            String email = Email.Text.ToString();
            String address = Adress.Text.ToString();
            String phone = PhoneNumber.Text.ToString();
            String passw = NewPassword.Password.ToString();
            
            Patient patient = new Patient(-1, name, surname, Id, email, phone, date, address, name, passw, null);
            var app = Application.Current as App;
            var temp = app.userController.Save(patient);
            if (temp == null)
            {
                Console.WriteLine("Nije uspeo");
            }
            App.j = 0;
            WindowLogIn lg = new WindowLogIn();
            lg.Show();
            this.Close();
        }

        private void UpdatePw(object sender, RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private String _ime;
        public String Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        private String _prezime;
        public String Prezime
        {
            get
            {
                return _prezime;
            }
            set
            {
                if(value != _prezime)
                {
                    _prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }
        private String _jmbg;
        public String JMBG
        {
            get
            {
                return _jmbg;
            }
            set
            {
                if (value != _jmbg)
                {
                    _jmbg = value;
                    OnPropertyChanged("JMBG");
                }
            }
        }

        private String _username;
        public String USERNAME
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("USERNAME");
                }
            }
        }
        private String _email;
        public String EMAIL
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("EMAIL");
                }
            }
        }
        private String _adress;
        public String ADRESS
        {
            get
            {
                return _adress;
            }
            set
            {
                if (value != _adress)
                {
                    _adress = value;
                    OnPropertyChanged("ADRESS");
                }
            }
        }

        private String _phone;
        public String Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

    }
}

