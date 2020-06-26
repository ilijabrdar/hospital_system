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
        private Doctor _selectedDoctor;

        public State SelectedState { get; set; }
        public Town SelectedTown { get; set; }
        public Address SelectedAddress { get; set; }

        public List<State> States { get; set; }
        public List<Town> Towns { get; set; }
        public List<Address> Addresses { get; set; }


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                if (value != _birthDate)
                {
                    _birthDate = value;
                    OnPropertyChanged("BirthDate");
                }
            }
        }


        public DoctorAddWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            BirthDate = new DateTime(1999, 12, 31);

            var app = Application.Current as App;
            _specialityController = app.authoritySpeciality;
            _doctorController = app.authorityDoctor;

            PopulateCombos();
        }

        public DoctorAddWindow(Doctor selectedDoctor)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            BirthDate = selectedDoctor.DateOfBirth;

            var app = Application.Current as App;
            _specialityController = app.authoritySpeciality;
            _doctorController = app.authorityDoctor;

            PopulateCombos();

            this._selectedDoctor = selectedDoctor;
            //comboSpeciality.SelectedValue = _selectedDoctor.Specialty.GetId();
            Ime = _selectedDoctor.FirstName;
            Prezime = _selectedDoctor.LastName;
            JMBG = _selectedDoctor.Jmbg;
            EMAIL = _selectedDoctor.Email;
            Phone = _selectedDoctor.Phone;
            birthDatePicker.SelectedDate = _selectedDoctor.DateOfBirth;
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            if (_selectedDoctor == null)
            {
                //String name, String surname, String jmbg, String email, String phone, DateTime birth, Address adress, String username, String password, Bitmap img, Speciality speciality, List<Article> articles, List<BusinessDay> businessDay, DoctorGrade doctGrade
                this.birthDatePicker.SelectedDate = this.BirthDate;
                var datum = birthDatePicker.SelectedDate;
                var state = StateCombo.SelectedItem as State;
                var town = TownCombo.SelectedItem as Town;
                var selectedAddress = AddressCombo.SelectedItem as Address;
                var address = new Address(selectedAddress.GetId(), town.GetId(), state.GetId());

                
                if (_doctorController.CheckJMBGUnique(JMBG))
                {
                    //JMBG for password and username

                    // String name, String surname, String jmbg, String email, String phone, DateTime birth, Address adress, String username, String password, Uri img, Speciality speciality, List<Article> articles, List<BusinessDay> businessDay, DoctorGrade doctGrade
                    var doctor = new Doctor(Ime, Prezime, JMBG, EMAIL, Phone, (DateTime)datum, address, JMBG, JMBG, null, (Speciality)comboSpeciality.SelectedItem, null, null,null);
                    _doctorController.Save(doctor);
                }
                else
                {
                    string messageBoxText = "Doktor sa JMBG " + JMBG + " vec postoji";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }

                
            }
            else
            {
                if (!_selectedDoctor.Jmbg.Equals(JMBG) && _doctorController.CheckJMBGUnique(JMBG)==false)
                {
                    string messageBoxText = "Doktor sa JMBG " + JMBG + " vec postoji";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }
                else
                {
                    _selectedDoctor.FirstName = Ime;
                    _selectedDoctor.LastName = Prezime;
                    _selectedDoctor.Jmbg = JMBG;
                    _selectedDoctor.Email = EMAIL;
                    _selectedDoctor.DateOfBirth = (DateTime)birthDatePicker.SelectedDate;
                    _selectedDoctor.Specialty = (Speciality)comboSpeciality.SelectedItem;
                    _selectedDoctor.Phone = Phone;

                    var state = StateCombo.SelectedItem as State;
                    var town = TownCombo.SelectedItem as Town;
                    var selectedAddress = AddressCombo.SelectedItem as Address;
                    var address = new Address(selectedAddress.GetId(), town.GetId(), state.GetId());
                    _selectedDoctor.Address = address;

                    _doctorController.Edit(_selectedDoctor);
                }


            }
            this.Close();
        }

        //private bool checkDoctorJMBGExists()
        //{
        //    List<Doctor> doctors = _doctorController.GetAll().ToList();
        //    foreach (Doctor doctor in doctors)
        //    {
        //        if(doctor.Jmbg.Equals(JMBG))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

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
            list_speciality.Sort((x, y) => x.Name.CompareTo(y.Name));

            comboSpeciality.ItemsSource = list_speciality;
            comboSpeciality.DisplayMemberPath = "Name";
            comboSpeciality.SelectedValuePath = "Id";


            StateCombo.DisplayMemberPath = "Name";
            StateCombo.SelectedValuePath = "Id";
            App app = Application.Current as App;
            States = app.StateController.GetAll().ToList();
            States.Sort((x, y) => x.Name.CompareTo(y.Name));
            StateCombo.ItemsSource = States;

            TownCombo.DisplayMemberPath = "Name";
            TownCombo.SelectedValuePath = "Id";

            AddressCombo.DisplayMemberPath = "FullAddress";
            AddressCombo.SelectedValuePath = "Id";

            

            

            if (_selectedDoctor != null)
            {
                comboSpeciality.SelectedValue = _selectedDoctor.Specialty.GetId();
                StateCombo.SelectedValue = _selectedDoctor.Address.Town.State.GetId(); 
                TownCombo.SelectedValue = _selectedDoctor.Address.Town.GetId();
                AddressCombo.SelectedValue = _selectedDoctor.Address.GetId();
            }
        }





        private void UpdateTownAddress(object sender, RoutedEventArgs e)
        {
            State state = StateCombo.SelectedItem as State;
            Towns = state.GetTown();
            Towns.Sort((x, y) => x.Name.CompareTo(y.Name));
            TownCombo.ItemsSource = Towns;
            AddressCombo.ItemsSource = null;

        }

        private void UpdateAddress(object sender, RoutedEventArgs e)
        {
            Town town = TownCombo.SelectedItem as Town;
            if (town == null)
                return;
            Addresses = town.GetAddress();
            Addresses.Sort((x, y) => x.FullAddress.CompareTo(y.FullAddress));
            AddressCombo.ItemsSource = Addresses;

        }

        private void PopulateCombos()
        {
            //ComboBox states = FindName("StateCombo") as ComboBox;
            //ComboBox towns = FindName("TownCombo") as ComboBox;
            //ComboBox addresses = FindName("AddressCombo") as ComboBox;
            //App app = Application.Current as App;
            //States = app.StateController.GetAll().ToList();
            //states.ItemsSource = States;

            //if (_selectedDoctor != null)
            //{
            //    StateCombo.SelectedValue = _selectedDoctor.Address.Town.State.GetId();
            //    TownCombo.SelectedValue = _selectedDoctor.Address.Town.GetId();
            //    AddressCombo.SelectedValue = _selectedDoctor.Address.GetId();
                
            //}
                 
        }
    }
}
