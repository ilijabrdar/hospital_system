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
using Model.Dto;
using Model.Users;
using Model.PatientSecretary;
using Model.Director;
using ControlzEx.Standard;

namespace PacijentBolnicaZdravo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        public ChangeLanguage cl = new ChangeLanguage();
        public static CultureInfo culture = new CultureInfo("sr");
        public List<ExaminationDTO> scheduledExaminations { get; set; }
        public List<ExaminationDTO> upcomingExaminations { get; set; }
        public Patient patient { get; set; }
        public static int Theme = 0;

        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;



            scheduledExaminations = getScheduledExaminations();
            
            InitializeComponent();
            this.ID.Text = "1111111111111";
            this.DataContext = this;
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private List<ExaminationDTO> getScheduledExaminations()
        {
            List<ExaminationDTO> retVal = new List<ExaminationDTO>();
            Doctor dr = new Doctor(1, "Pera", "Peric", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), "Mileve Maric", "DDD", "ddd", null, null);
            Period period = new Period(new DateTime(2020, 7, 7, 12, 20, 0), new DateTime(2020, 7, 7, 12, 40, 0));
           
            Room room = new Room("213", null, null, null);
            ExaminationDTO examination = new ExaminationDTO();
            examination.doctor = dr;
            examination.period = period;
            examination.room = room;
            examination.patient = null;
            retVal.Add(examination);
            return retVal;
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
                    cl.ChangeMainWindow(this);
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("sr");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("sr");
                    MainWindow.culture = new CultureInfo("sr");
                    cl.ChangeMainWindow(this);

                }
            }
           
            Console.WriteLine("Vrednost od j je :" + App.j);

            App.j++;
        }

     

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            var selectedItem = scheduledExaminationsGrid.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }
            
            scheduledExaminations.Remove((ExaminationDTO)selectedItem);

            scheduledExaminationsGrid.Items.Refresh();
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
                if (value != _prezime)
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
