using Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Schema;

namespace HCIproject
{
    /// <summary>
    /// Interaction logic for DockPanel.xaml
    /// </summary>
    public partial class SideBar : Window,INotifyPropertyChanged
    {
        public string Username;
        public SideBar()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public SideBar(string _username)
        {
            InitializeComponent();
            this.DataContext = this;
            Username = _username;

            var app = Application.Current as App;
            Doctor doctor = app.DoctorController.GetDoctorByUsername(Username);
            ImePrzSet.Text = doctor.FirstName + " " + doctor.LastName;
            SpecSet.Text = doctor.Specialty.Name;
            DatSet.Text = doctor.DateOfBirth.ToString();
            JmbgSet.Text = doctor.Jmbg.ToString();
            EmailSet.Text = doctor.Email;
            TelSet.Text = doctor.Phone;

            izImePrzTxt.Text = doctor.FirstName + " " + doctor.LastName;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        //pocetna stranica binduj imena


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWin.Show();
        }

        private void search_text_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (search_patient.Text == "Unesite parametar pretrage")
            {
                search_patient.Text = "";
            }
        }

        private void search_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (search_patient.Text == "")
                {
                    return;
                }
                else
                {
                    ArticleWin artWind = new ArticleWin();
                    this.Visibility = Visibility.Hidden;
                    artWind.Show();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//otvara karton
            PatientFileWin fileWin = new PatientFileWin();
            this.Visibility = Visibility.Hidden;
            fileWin.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//otvara prozor za validaciju sastava leka
            DrugValidation drugValWind = new DrugValidation();
            this.Visibility = Visibility.Hidden;
            drugValWind.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//dodaj alternativni
            DrugAlternative drugAltWind = new DrugAlternative();
            this.Visibility = Visibility.Hidden;
            drugAltWind.Show();
        }

        private void myGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //MyTabControl.Height = this.ActualHeight - 100;
            misljenje.Height = this.ActualHeight - 300;
            misljenje.Width = this.ActualHeight - 80;

            //utisakGrid.Height = this.ActualHeight - 40;
            //izmenaGrid.Height = this.ActualHeight - 40;
            //evidencijaGrid.Height = this.ActualHeight - 40;
            //kartoniGrid.Height = this.ActualHeight - 40;
            //pregledGrid.Height = this.ActualHeight - 40;
            //clanciGrid.Height = this.ActualHeight - 40;
            //pocetnaGrid.Height = this.ActualHeight - 40;
        }

        private string _testImePrz;
        private string _testSpec;
        private string _testEmail;
        private string _testPhoneNum;
        private string _testJMBG;
        public string TestImePrezime
        {
            get
            {
                return _testImePrz;
            }
            set
            {
                if (value != _testImePrz)
                {
                    _testImePrz = value;
                    OnPropertyChanged("TestImePrezime");
                }
            }
        }

        public string TestSpec
        {
            get
            {
                return _testSpec;
            }
            set
            {
                if (value != _testSpec)
                {
                    _testSpec = value;
                    OnPropertyChanged("TestSpec");
                }
            }
        }

        public string TestEmail
        {
            get
            {
                return _testEmail;
            }
            set
            {
                if (value != _testEmail)
                {
                    _testEmail = value;
                    OnPropertyChanged("TestEmail");
                }
            }
        }

        public string TestPhoneNumber
        {
            get
            {
                return _testPhoneNum;
            }
            set
            {
                if (value != _testPhoneNum)
                {
                    _testPhoneNum = value;
                    OnPropertyChanged("TestPhoneNumber");
                }
            }
        }

        public string TestJMBG
        {
            get
            {
                return _testJMBG;
            }
            set
            {
                if (value != _testJMBG)
                {
                    _testJMBG = value;
                    OnPropertyChanged("TestJMBG");
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {//posalji izmene

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {//sacuvaj lozinku
             //TODO provera da li je dobra stara sifra
            if (NovaLozTxt.Password != PotvNovaLozTxt.Password)
            {
               obavesti.Foreground= new SolidColorBrush(Color.FromRgb(199, 24, 24));
               obavesti.Text = "Unos se ne poklapa.Pokusajte ponovo.";
            }
            else
            {
                obavesti.Foreground = new SolidColorBrush(Color.FromRgb(64, 85, 81));

                obavesti.Text = "Uspešno ste promenili lozinku.";
                NovaLozTxt.Password = "";
                PotvNovaLozTxt.Password = "";
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Examination examWin = new Examination();
            this.Visibility = Visibility.Hidden;
            examWin.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            CreateArticle creWin = new CreateArticle();
            this.Visibility = Visibility.Hidden;
            creWin.Show();
        }

        private void MyTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (tabPocetna.IsSelected)
            //{
            //    var app = Application.Current as App;
            //    Doctor doctor=app.DoctorController.GetDoctorByUsername(Username);
            //    ImePrzSet.Text = doctor.FirstName +" "+ doctor.LastName;
            //    SpecSet.Text = doctor.Specialty.Name;
            //    DatSet.Text = doctor.DateOfBirth.ToString();
            //    JmbgSet.Text = doctor.Jmbg.ToString();
            //    EmailSet.Text = doctor.Email;
            //    TelSet.Text = doctor.Phone;

            //    izImePrzTxt.Text= doctor.FirstName + " " + doctor.LastName;

            //}
        }
    }
}
