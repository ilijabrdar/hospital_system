using bolnica.Controller;
using Model.Doctor;
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
using upravnikKT2.Validation;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for DoctorAddWindow.xaml
    /// </summary>
    public partial class DoctorAddWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ISpecialityController _specialityController;
        private readonly IDoctorController _doctorController;


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private double _test3;
        public double Test3
        {
            get
            {
                return _test3;
            }
            set
            {
                if (value != _test3)
                {
                    _test3 = value;
                    OnPropertyChanged("Test3");
                }
            }
        }

        private string _jmbg;
        public string JMBG  
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

        private string _email;
        public string EMAIL
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

        private string _phone;
        public string Phone
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

        private string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        private string _ime;
        public string Ime
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

        private string _prezime;
        public string Prezime
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


        public DoctorAddWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _specialityController = app.SpecialityController;
            _doctorController = app.DoctorController;
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            //String name, String surname, String jmbg, String email, String phone, DateTime birth, Address adress, String username, String password, Bitmap img, Speciality speciality, List<Article> articles, List<BusinessDay> businessDay, DoctorGrade doctGrade
            var datum = birthDatePicker.SelectedDate;
            var state = new State(1, "state", "code");
            var town = new Town(1, "ns", "21000", state);
            var address = new Address(1, "street", 32, 12, town);
            

            //JMBG for password and username
            var doctor = new Doctor(Ime, Prezime, JMBG, EMAIL, Phone, (DateTime)datum, address, JMBG, JMBG, null, (Speciality)comboSpeciality.SelectedItem, null, null, null);
            _doctorController.Save(doctor);
            this.Close();
        }

        private void Button_Click__Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }

            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (OKBtn.IsEnabled)
                {
                    Button_Click_OK(sender, e);
                    e.Handled = true;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Speciality> list_speciality = new List<Speciality>();
            list_speciality = _specialityController.GetAll().ToList();

            comboSpeciality.ItemsSource = list_speciality;
            comboSpeciality.DisplayMemberPath = "Name";
            comboSpeciality.SelectedValuePath = "Id";
        }
    }
}
