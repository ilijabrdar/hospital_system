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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using bolnica.Controller;
using Controller;
using Model.Users;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Secretary Secretary { get; set; }
        public List<Patient> Patients;
        public Patient GuestPatient { get; set; }
        public int Day { get; set; }
        public String NewDay { get; set; }
        public static int Month { get; set; }
        public static String NewMonth { get; set; }
        public static int Year { get; set; }
        public static String NewYear { get; set; }
        public BitmapSource Image { get; set; }
        public List<Examination> examinations { get; set; }
        public List<Examination> freeSlots { get; set; }

        public List<State> States { get; set; }
        public List<Town> Towns { get; set; }
        public List<Address> Addresses { get; set; }

        private ToolTip _toolTip = new ToolTip();
        private Boolean _isToolTipAvailable = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public State SelectedState { get; set; }
        public Town SelectedTown { get; set; }
        public Address SelectedAddress { get; set; }

        public String FullDate { get; set; }

        public Examination SelectedExamination {get;set;}
        private DispatcherTimer dispatcherTimer;

        public List<Shortcut> Shortcuts { get; set; }
        public MainWindow(Secretary secretary)
        {
            InitializeComponent();
            this.DataContext = this;
            
            GuestPatient = new Patient(true);
            Patients = new List<Patient>();
            Secretary = secretary;
            Day = secretary.DateOfBirth.Day;
            Month = secretary.DateOfBirth.Month;
            Year = secretary.DateOfBirth.Year;
            FullDate = string.Join("/", Day, Month, Year);
            PopulateCombos();
            PopulatePatients();

            //Image = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Secretary.Image, Int)
            this.examinations = new List<Examination>();
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 12, 00, 00), "Pera Peric", "Petar Petrovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 15, 00, 00), "Pera Peric", "Milan Milanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 16, 30, 00), "Marko Markovic", "Ivan Ivanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 17, 15, 00), "Pera Peric", "Luka Lukovic", "S13"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 8, 00, 00), "Nikola Nikolic", "Milan Milanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 9, 30, 00), "Nikola Nikolic", "Marko Markovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 10, 00, 00), "Ivan Ivanovic", "Luka Lukovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 10, 15, 00), "Pera Peric", "Milan Milanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 00, 00), "Marko Markovic", "Marko Markovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 15, 00), "Marko Markovic", "Milan Milanovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 30, 00), "Nikola Nikolic", "Marko Markovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 50, 00), "Marko Markovic", "Milan Milanovic", "S14"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 15, 00, 00), "Nikola Nikolic", "Ivan Ivanovic", "S14"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 16, 00, 00), "Marko Markovic", "Milan Milanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 17, 00, 00), "Nikola Nikolic", "Petar Petrovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 18, 00, 00), "Marko Markovic", "Milan Milanovic", "S13"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 18, 30, 00), "Nikola Nikolic", "Ivan Ivanovic", "S14"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 18, 55, 00), "Marko Markovic", "Petar Petrovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 19, 10, 00), "Nikola Nikolic", "Marko Markovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 20, 00, 00), "Marko Markovic", "Milan Milanovic", "S12"));

            this.freeSlots = new List<Examination>();
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 2, 12, 00, 00), "Pera Peric", "S12"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 2, 15, 00, 00), "Pera Peric", "S12"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 2, 16, 30, 00), "Marko Markovic", "S12"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 2, 17, 15, 00), "Pera Peric", "S13"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 3, 8, 00, 00), "Nikola Nikolic", "S12"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 3, 9, 30, 00), "Nikola Nikolic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 3, 10, 00, 00), "Ivan Ivanovic", "S12"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 3, 10, 15, 00), "Pera Peric", "S14"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 12, 00, 00), "Marko Markovic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 12, 15, 00), "Marko Markovic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 12, 30, 00), "Nikola Nikolic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 12, 50, 00), "Marko Markovic", "S14"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 15, 00, 00), "Nikola Nikolic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 16, 00, 00), "Marko Markovic", "S14"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 17, 00, 00), "Nikola Nikolic", "S13"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 18, 00, 00), "Marko Markovic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 18, 30, 00), "Nikola Nikolic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 18, 55, 00), "Marko Markovic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 19, 10, 00), "Nikola Nikolic", "S13"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 20, 00, 00), "Marko Markovic", "S15"));

            Shortcuts = new List<Shortcut>();
            CreateShortcuts();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        }

        private void PopulateCombos()
        {
            ComboBox states = FindName("StateCombo") as ComboBox;
            ComboBox towns = FindName("TownCombo") as ComboBox;
            ComboBox addresses = FindName("AddressCombo") as ComboBox;
            App app = Application.Current as App;
            States = app.StateController.GetAll().ToList();
            states.ItemsSource = States;
            foreach(State state in States)
                if(Secretary.Address.Town.State.Name == state.Name)
                {
                    states.SelectedItem = state;
                    SelectedState = state;
                    break;
                }
            Towns = Secretary.Address.Town.State.GetTown();
            towns.ItemsSource = Towns;
            foreach (Town town in Towns)
                if (Secretary.Address.Town.Name == town.Name)
                {
                    towns.SelectedItem = town;
                    SelectedTown = town;
                    break;
                }
            Addresses = Secretary.Address.Town.GetAddress();
            addresses.ItemsSource = Addresses;
            foreach (Address address in Addresses)
                if (Secretary.Address.FullAddress == address.FullAddress)
                {
                    addresses.SelectedItem = address;
                    SelectedAddress = address;
                    break;
                }
        }

        private void PopulatePatients()
        {
            App app = Application.Current as App;
            IPatientController patientController = app.PatientController;
            Patients = patientController.GetAll().ToList();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            Secretary.DateOfBirth = new DateTime(Year, Month, Day);
            Secretary.Address = SelectedAddress;
            Secretary.Address.Town = SelectedTown;
            Secretary.Address.Town.State = SelectedState;
            FullDate = string.Join("/", Day, Month, Year);

            TextBlock date = FindName("txtDate") as TextBlock;
            date.Text = FullDate;
            TextBlock state = FindName("txtState") as TextBlock;
            state.Text = SelectedState.Name;
            TextBlock town = FindName("txtTown") as TextBlock;
            town.Text = SelectedTown.Name;
            TextBlock address = FindName("txtAddress") as TextBlock;
            address.Text = SelectedAddress.FullAddress;

            app.SecretaryController.Edit(Secretary);
            CancelProfileChangeDialog(sender, e);
        }

        private void GenerateReport(object sender, RoutedEventArgs e)
        {
            Report reportWindow = new Report();
            _toolTip.IsOpen = false;
            reportWindow.Show();
        }

        private void FindAppointment(object sender, RoutedEventArgs e)
        {
            AppointmentFilter filterWindow = new AppointmentFilter(Patients);
            _toolTip.IsOpen = false;
            filterWindow.ShowDialog();
        }

        private void FindFreeAppointment(object sender, RoutedEventArgs e)
        {
            AppointmentSearch searchDialog = new AppointmentSearch();
            _toolTip.IsOpen = false;
            searchDialog.ShowDialog();
        }

        private void OpenEditPanel(object sender, RoutedEventArgs e)
        {
            var changeProfilePanel = this.FindName("changeProfile") as Grid;
            var profilePanel = this.FindName("profile") as Grid;
            changeProfilePanel.Visibility = Visibility.Visible;
            profilePanel.Visibility = Visibility.Collapsed;
        }

       

        private void CancelProfileChangeDialog(object sender, RoutedEventArgs e)
        {
            var changeProfilePanel = this.FindName("changeProfile") as Grid;
            var profilePanel = this.FindName("profile") as Grid;
            changeProfilePanel.Visibility = Visibility.Collapsed;
            profilePanel.Visibility = Visibility.Visible;
        }

        private void EditSelectedAppointment(object sender, RoutedEventArgs e)
        {
            EditAppointment editDialog = new EditAppointment(SelectedExamination);
            editDialog.ShowDialog();
        }

        private void FreeSelectedAppointment(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayToolTip(object sender, RoutedEventArgs e)
        {
            if (_isToolTipAvailable)
            {
                Button button = sender as Button;
                String toolTipText = (String)button.ToolTip;
                _toolTip.Content = toolTipText;
                _toolTip.PlacementTarget = button;
                _toolTip.Placement = System.Windows.Controls.Primitives.PlacementMode.Top;
                _toolTip.IsOpen = true;
            }
        }

        private void RemoveToolTip(object sender, RoutedEventArgs e)
        {
            if(_isToolTipAvailable)
            _toolTip.IsOpen = false;
        }

        private void RequiredFieldError(object sender, RoutedEventArgs e)
        {
            TextBox textField = sender as TextBox;
            textField.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void DayPlaceHolderDisappear(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextBlock placeHolder = (TextBlock)FindName("DayPlaceHolder");
            if(String.IsNullOrEmpty(textBox.Text))
                placeHolder.Visibility = Visibility.Visible;
            else
                placeHolder.Visibility = Visibility.Collapsed;
        }

        private void MonthPlaceHolderDisappear(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextBlock placeHolder = (TextBlock)FindName("MonthPlaceHolder");
            if (String.IsNullOrEmpty(textBox.Text))
                placeHolder.Visibility = Visibility.Visible;
            else
                placeHolder.Visibility = Visibility.Collapsed;
        }

        private void YearPlaceHolderDisappear(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextBlock placeHolder = (TextBlock)FindName("YearPlaceHolder");
            if (String.IsNullOrEmpty(textBox.Text))
                placeHolder.Visibility = Visibility.Visible;
            else
                placeHolder.Visibility = Visibility.Collapsed;
        }

        private void UpdateTownAddress(object sender, RoutedEventArgs e)
        {
            ComboBox states = FindName("StateCombo") as ComboBox;
            ComboBox towns = FindName("TownCombo") as ComboBox;

            State state = states.SelectedItem as State;
            if (SelectedState.GetId() == state.GetId())
                return;
            SelectedState = state;
            Towns = SelectedState.GetTown();
            towns.ItemsSource = Towns;
            towns.SelectedItem = Towns[0];

            ComboBox addresses = FindName("AddressCombo") as ComboBox;
            SelectedTown = towns.SelectedItem as Town;
            Addresses = SelectedTown.GetAddress();
            addresses.ItemsSource = Addresses;
            addresses.SelectedItem = Addresses[0];
            SelectedAddress = Addresses[0];
        }

        private void UpdateAddress(object sender, RoutedEventArgs e)
        {
            ComboBox towns = FindName("TownCombo") as ComboBox;
            ComboBox addresses = FindName("AddressCombo") as ComboBox;
            Town town = towns.SelectedItem as Town;
            if (SelectedTown.GetId() == town.GetId())
                return;
            SelectedTown = town;
            Addresses = SelectedTown.GetAddress();
            addresses.ItemsSource = Addresses;
            addresses.SelectedItem = Addresses[0];
            SelectedAddress = Addresses[0];
        }

        private void FindGuest(object sender, RoutedEventArgs e)
        {
            TextBox txtJmbg = sender as TextBox;
            TextBox txtFirstName = FindName("IGuestFirstName") as TextBox;
            TextBox txtLastName = FindName("IGuestLastName") as TextBox;
            TextBox txtPhone = FindName("IGuestPhone") as TextBox;
            TextBox txtEmail = FindName("IGuestEmail") as TextBox;
            TextBox txtYear = FindName("IGuestYear") as TextBox;
            TextBox txtMonth = FindName("IGuestMonth") as TextBox;
            TextBox txtDay = FindName("IGuestDay") as TextBox;
            TextBlock yearPlaceholder = FindName("YearPlaceHolder") as TextBlock;
            TextBlock monthPlaceholder = FindName("MonthPlaceHolder") as TextBlock;
            TextBlock dayPlaceholder = FindName("DayPlaceHolder") as TextBlock;

            yearPlaceholder.Visibility = Visibility.Visible;
            monthPlaceholder.Visibility = Visibility.Visible;
            dayPlaceholder.Visibility = Visibility.Visible;

            txtJmbg.IsEnabled = true;
            txtFirstName.IsEnabled = true;
            txtLastName.IsEnabled = true;
            txtPhone.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtYear.IsEnabled = true;
            txtMonth.IsEnabled = true;
            txtDay.IsEnabled = true;

            String jmbg = txtJmbg.Text;
            if (jmbg.Trim() == "")
            {
                RequiredFieldError(sender, e);
                return;
            }
            
            App app = Application.Current as App;
            IPatientController patientController = app.PatientController;
            Patient guest = patientController.GetPatientByJMBG(jmbg);
            
            if (guest != null)
            {
                GuestPatient = guest;

                txtFirstName.Text = guest.FirstName;
                txtFirstName.IsEnabled = false;

                txtLastName.Text = guest.LastName;
                txtLastName.IsEnabled = false;

                txtPhone.Text = guest.Phone;
                txtPhone.IsEnabled = false;

                txtEmail.Text = guest.Email;
                txtEmail.IsEnabled = false;

                NewDay = "" + guest.DateOfBirth.Day;
                dayPlaceholder.Visibility = Visibility.Collapsed;
                txtDay.Text = NewDay;
                txtDay.IsEnabled = false;

                NewMonth = "" + guest.DateOfBirth.Month;
                monthPlaceholder.Visibility = Visibility.Collapsed;
                txtMonth.Text = NewMonth;
                txtMonth.IsEnabled = false;

                NewYear = "" + guest.DateOfBirth.Year;
                yearPlaceholder.Visibility = Visibility.Collapsed;
                txtYear.Text = NewYear;
                txtYear.IsEnabled = false;

                Button search = FindName("SearchBtn") as Button;
                search.Focus();
            }
            else
            {
                txtFirstName.Clear();
                txtLastName.Clear();
                txtPhone.Clear();
                txtEmail.Clear();
                txtYear.Clear();
                txtMonth.Clear();
                txtDay.Clear();
                txtFirstName.Focus();
            }

            RequiredFieldError(sender, e);
        }

        private void PassValidation(object sender, KeyEventArgs e)
        {
            PasswordBox newPass = FindName("newPass") as PasswordBox;
            PasswordBox confPass = FindName("confPass") as PasswordBox;
            TextBlock err = FindName("ErrorMessage") as TextBlock;
            Button cnf = FindName("confirmBtn") as Button;

            if(newPass.Password.Trim() != confPass.Password.Trim())
            {
                err.Text = "Lozinke se ne poklapaju!";
                err.Visibility = Visibility.Visible;
                cnf.IsEnabled = false;
            }
            else
            {
                err.Visibility = Visibility.Collapsed;
                cnf.IsEnabled = true;
            }
        }

        private void CheckPass(object sender, RoutedEventArgs e)
        {
            PasswordBox pass = FindName("oldPass") as PasswordBox;
            TextBlock err = FindName("WrongPass") as TextBlock;
            Button cnf = FindName("confirmBtn") as Button;
            if (pass.Password.Trim() != Secretary.Password)
            {
                err.Text = "Pogrešna lozinka!";
                err.Visibility = Visibility.Visible;
                cnf.IsEnabled = false;
            }
            else
            {
                err.Visibility = Visibility.Collapsed;
                cnf.IsEnabled = true;
            }
            ValidatePasswords(sender, e);
        }

        private void ChangePass(object sender, RoutedEventArgs e)
        {
            PasswordBox confPass = FindName("confPass") as PasswordBox;

            Secretary.Password = confPass.Password;

            App app = Application.Current as App;
            app.SecretaryController.Edit(Secretary);
            CancelProfileChangeDialog(sender, e);
        }

        private void ControllToolTips(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(_isToolTipAvailable)
            {
                _isToolTipAvailable = false;
                btn.Content = "Uključi pomoćne tekstove";
            }
            else
            {
                _isToolTipAvailable = true;
                btn.Content = "Isključi pomoćne tekstove";
            }
        }

        private void SendFeedBack(Object sender, RoutedEventArgs e)
        {
            FeedBack.Clear();
            ThankYouMsg.Visibility = System.Windows.Visibility.Visible;
            dispatcherTimer.Start();

        }

        private void ValidatePasswords(Object sender, RoutedEventArgs e)
        {
            if (oldPass.Password.Trim() == "" || newPass.Password.Trim() == "" || confPass.Password.Trim() == "")
                confirmBtn.IsEnabled = false;
            else 
                confirmBtn.IsEnabled = true;
        }

        private void CreateShortcuts()
        {
            Shortcuts.Add(new Shortcut("ALT", "Prikaz postojećih prečica na svakom prozoru. Kombinacijom ALT + podvučeno slovo, aktivira se željena funkcionalnost."));
            Shortcuts.Add(new Shortcut("TAB", "Kretanje unapred."));
            Shortcuts.Add(new Shortcut("SHIFT + TAB", "Kretanje unazad."));
            Shortcuts.Add(new Shortcut("CTRL + TAB", "Kretanje unapred po tabovima."));
            Shortcuts.Add(new Shortcut("CTRL + SHIFT + TAB", "Kretanje unazad po tabovima."));
            Shortcuts.Add(new Shortcut("STRELICA DOLE", "Kretanje unapred u tabeli za ceo red. Kretanje unapred u listi sa više izbora."));
            Shortcuts.Add(new Shortcut("STRELICA GORE", "Kretanje unazad u tabeli za ceo red. Kretanje unazad u listi sa više izbora."));
            Shortcuts.Add(new Shortcut("KONTEKSTNO DUGME", "Otvaranje kontekstnog menija u tabeli."));
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ThankYouMsg.Visibility = System.Windows.Visibility.Hidden;

            dispatcherTimer.IsEnabled = false;
        }
    }

    public class Shortcut
    {
        public String ExactShortcut { get; set; }
        public String Description { get; set; }

        public Shortcut(String shortcut, String description)
        {
            ExactShortcut = shortcut;
            Description = description;
        }
    }
}
