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

    public partial class Registration : MetroWindow, INotifyPropertyChanged
    {
        public List<State> States { get; set; }
        public List<Town> Towns { get; set; }
        public List<Address> Addresses { get; set; }
        public State SelectedState { get; set; }
        public Town SelectedTown { get; set; }
        public Address SelectedAddress { get; set; }


        public Registration()
        {

            InitializeComponent();


            App app = Application.Current as App;
            States = app.StateController.GetAll().ToList();
            States.Sort((x, y) => x.Name.CompareTo(y.Name));
            Country.ItemsSource = States;


            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

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

        private void UpdateTownAddress(object sender, RoutedEventArgs e)
        {
            State state = Country.SelectedItem as State;
            Towns = state.GetTown();
            Towns.Sort((x, y) => x.Name.CompareTo(y.Name));
            Town.ItemsSource = Towns;
            Addressessss.ItemsSource = null;
        }

        private void UpdateAddress(object sender, RoutedEventArgs e)
        {

            Town town = Town.SelectedItem as Town;
            if (town == null)
                return;
            Addresses = town.GetAddress();
            Addresses.Sort((x, y) => x.FullAddress.CompareTo(y.FullAddress));
            Addressessss.ItemsSource = Addresses;
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

        }


        private void PasswordCheck(object sender, RoutedEventArgs e)
        {

            Check.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();

        }
        private void UpdateInfo(object sender, RoutedEventArgs e)
        {

            if (Name.Text.ToString().Equals(""))
            {
                Name.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                return;
            }
            if (Surname.Text.ToString().Equals(""))
            {
                Surname.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                return;
            }
            if (Username.Text.ToString().Equals(""))
            {
                Username.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                return;
            }
            if (ID.Text.ToString().Equals(""))
            {
                ID.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                return;
            }
            if (Email.Text.ToString().Equals(""))
            {
                Email.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                return;
            }
           /* if (Adress.Text.ToString().Equals(""))
            {
                Adress.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                return;
            }*/
            if (PhoneNumber.Text.ToString().Equals(""))
            {
                PhoneNumber.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                return;
            }
            if (NewPassword.Text.ToString().Equals(""))
            {
                NewPassword.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
                return;
            }


            String username = Username.Text.ToString();
            String name = Name.Text.ToString();
            String surname = Surname.Text.ToString();
            String Id = ID.Text.ToString();
            DateTime date = DateTime.Parse(DateBirth.Text);
            String email = Email.Text.ToString();
           // String address = Adress.Text.ToString();
            String phone = PhoneNumber.Text.ToString();
            String passw = NewPassword.Text.ToString();

            Patient patient = new Patient(-1, name, surname, Id, email, phone, date, null, username, passw, null);
            var app = Application.Current as App;
            var temp = app.UserController.Save(patient);
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


        private DateTime _dateTime = DateTime.Today;
        public DateTime DATETIME
        {
            get
            {
                return _dateTime;
            }
            set
            {
                if (value != _dateTime)
                {
                    _dateTime = value;
                    OnPropertyChanged("DATETIME");
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
        private String _password2;
        public String Password2
        {
            get
            {
                return _password2;
            }
            set
            {
                if (value != _password2)
                {
                    _password2 = value;
                    OnPropertyChanged("Pw");
                }
            }
        }
        private String _password1;
        public String Password1
        {
            get
            {
                return _password1;
            }
            set
            {
                if (value != _password1)
                {
                    _password1 = value;
                    OnPropertyChanged("Pw");
                }
            }
        }


    }
}

