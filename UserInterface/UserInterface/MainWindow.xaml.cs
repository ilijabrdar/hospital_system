using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using bolnica.Controller;
using Controller;
using Microsoft.Win32;
using Model.Users;
using Model.PatientSecretary;

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
        public static List<Examination> examinations { get; set; }
        public static List<Examination> Examinations { get; set; }
        public static List<Examination> freeSlots { get; set; }
        public static List<Examination> FreeSlots { get; set; }

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
        private static DispatcherTimer dispatcherTimer;

        public List<Shortcut> Shortcuts { get; set; }

        private string _fileName;

        static DataGrid se;
        static DataGrid ee;
        static TextBlock tb;
        static Label msg;
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

            ProfilePic.Source = new BitmapImage(Secretary.Image);
            ChProfilePic.Source = new BitmapImage(Secretary.Image);

            FillExaminationTable();


            FreeSlots = new List<Examination>();
            freeSlots = new List<Examination>(FreeSlots);

            Shortcuts = new List<Shortcut>();
            CreateShortcuts();

            se = ScheduledExaminations;
            ee = EmptyExaminations;
            tb = FilterInfo;
            msg = SuccessMsg;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        }
        private void FillExaminationTable()
        {
            App app = Application.Current as App;
            examinations = new List<Examination>();
            Examinations = app.ExaminationController.GetAll().ToList();

            examinations = new List<Examination>(Examinations);
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
            Secretary.Image = new Uri(_fileName);
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

            ProfilePic.Source = new BitmapImage(Secretary.Image);
            CancelProfileChangeDialog(sender, e);
        }

        private void GenerateReport(object sender, RoutedEventArgs e)
        {
            Report reportWindow = new Report();
            _toolTip.IsOpen = false;
            reportWindow.ShowDialog();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            Index index = new Index();
            index.Show();
            this.Close();
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
            ChProfilePic.Source = ProfilePic.Source;
        }

        private void EditSelectedAppointment(object sender, RoutedEventArgs e)
        {
            //EditAppointment editDialog = new EditAppointment(SelectedExamination);
            //editDialog.ShowDialog();
        }

        private void FreeSelectedAppointment(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da otkažete pregled?", "Otkazivanje pregleda", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No) return; 

            Examination examination = ScheduledExaminations.SelectedItem as Examination;
            Examinations.Remove(examination);
            examinations.Remove(examination);
            se.ItemsSource = null;
            se.ItemsSource = examinations;
            msg.Content = "Pregled upsešno otkazan.";
            msg.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
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

        private void RequiredFieldError(object sender, KeyEventArgs e)
        {
            TextBox textField = sender as TextBox;
            textField.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ScheduleBtn.IsEnabled = false;
            if (IGuestJMBG.Text != "" && IGuestFirstName.Text != "" && IGuestLastName.Text != "" && IGuestYear.Text != "" && IGuestMonth.Text != "" && IGuestDay.Text != "")
                ScheduleBtn.IsEnabled = true;
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
                txtDay.Text = NewDay;
                txtDay.IsEnabled = false;

                NewMonth = "" + guest.DateOfBirth.Month;
                txtMonth.Text = NewMonth;
                txtMonth.IsEnabled = false;

                NewYear = "" + guest.DateOfBirth.Year;
                txtYear.Text = NewYear;
                txtYear.IsEnabled = false;

                Button search = FindName("SearchBtn") as Button;
                search.Focus();
            }
            else
            {
                txtFirstName.Focus();
            //    txtFirstName.Clear();
            //    txtLastName.Clear();
            //    txtPhone.Clear();
            //    txtEmail.Clear();
            //    txtYear.Clear();
            //    txtMonth.Clear();
            //    txtDay.Clear();
            //    txtFirstName.Focus();
            }

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
                if (oldPass.Password.Trim() == "" || newPass.Password.Trim() == "" || confPass.Password.Trim() == "")
                    confirmBtn.IsEnabled = false;
                else
                    confirmBtn.IsEnabled = true;
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
                if (oldPass.Password.Trim() == "" || newPass.Password.Trim() == "" || confPass.Password.Trim() == "")
                    confirmBtn.IsEnabled = false;
                else
                    confirmBtn.IsEnabled = true;
            }
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
            Shortcuts.Add(new Shortcut("ESC", "Izaz iz tabele."));
            Shortcuts.Add(new Shortcut("SHIFT + TAB", "Kretanje unazad."));
            Shortcuts.Add(new Shortcut("CTRL + TAB", "Kretanje unapred po tabovima."));
            Shortcuts.Add(new Shortcut("CTRL + SHIFT + TAB", "Kretanje unazad po tabovima."));
            Shortcuts.Add(new Shortcut("CTRL + P", "Otvaranje profila."));
            Shortcuts.Add(new Shortcut("CTRL + E", "Otvaranje evidencije pregleda."));
            Shortcuts.Add(new Shortcut("CTRL + N", "Otvaranje unosa novog pacijenta."));
            Shortcuts.Add(new Shortcut("CTRL + H, F1", "Pomoć."));
            Shortcuts.Add(new Shortcut("CTRL + U", "Utisci o aplikaciji."));
            Shortcuts.Add(new Shortcut("STRELICA DOLE", "Kretanje unapred u tabeli za ceo red. Kretanje unapred u listi sa više izbora."));
            Shortcuts.Add(new Shortcut("STRELICA GORE", "Kretanje unazad u tabeli za ceo red. Kretanje unazad u listi sa više izbora."));
            Shortcuts.Add(new Shortcut("KONTEKSTNO DUGME", "Otvaranje kontekstnog menija u tabeli."));
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ThankYouMsg.Visibility = System.Windows.Visibility.Hidden;
            SuccessLabel.Visibility = Visibility.Collapsed;
            msg.Visibility = Visibility.Collapsed;

            dispatcherTimer.IsEnabled = false;
        }

        private void EscapeTable(object sender, ExecutedRoutedEventArgs e)
        {
            if (ScheduledExaminations.SelectedItem != null)
                SearchButton.Focus();

            if (EmptyExaminations.SelectedItem != null)
                if (ScheduleBtn.IsEnabled)
                    ScheduleBtn.Focus();
                else
                    SearchBtn.Focus();

            if (Shorts.SelectedItem != null)
                ToolTipCtrl.Focus();
        }

        private void OpenProfileTab(object sender, ExecutedRoutedEventArgs e)
        {
            ProfileTab.IsSelected = true;
        }

        private void OpenExaminationTab(object sender, ExecutedRoutedEventArgs e)
        {
            ExaminationTab.IsSelected = true;
        }

        private void OpenNewPatientTab(object sender, ExecutedRoutedEventArgs e)
        {
            NewPatientTab.IsSelected = true;
        }

        private void OpenHelpTab(object sender, ExecutedRoutedEventArgs e)
        {
            HelpTab.IsSelected = true;
        }

        private void OpenFeedbackTab(object sender, ExecutedRoutedEventArgs e)
        {
            FeedbackTab.IsSelected = true;
        }

        private void ChangePic(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                _fileName = op.FileName;
                ChProfilePic.Source = new BitmapImage(new Uri(_fileName));
            }

            
        }

        private void SwapLists(object sender, RoutedEventArgs e)
        {
            examinations = new List<Examination>(Examinations);
            se.ItemsSource = null;
            se.ItemsSource = examinations;
            tb.Text = "";
        }

        private void SwapFreeLists(object sender, RoutedEventArgs e)
        {
            freeSlots = new List<Examination>(FreeSlots);
            ee.ItemsSource = null;
            ee.ItemsSource = freeSlots;
        }

        public static void FilterExaminations(ExaminationDTO examinationFilter)
        {
            //examinations = new List<Examination>(Examinations);
            //for (int i = 0; i < Examinations.Count; i++)
            //{
            //    if (!String.IsNullOrEmpty(examinationFilter.Doctor) && Examinations[i].doctor != examinationFilter.Doctor) 
            //    {
            //        examinations.Remove(Examinations[i]);
            //        continue;
            //    }
            //    if(!String.IsNullOrEmpty(examinationFilter.Patient) && Examinations[i].patient != examinationFilter.Patient)
            //    {
            //        examinations.Remove(Examinations[i]);
            //        continue;
            //    }
            //    if (!String.IsNullOrEmpty(examinationFilter.Room) && Examinations[i].room != examinationFilter.Room)
            //    {
            //        examinations.Remove(Examinations[i]);
            //        continue;
            //    }
            //    if(Examinations[i].dateTime < examinationFilter.FromDate || Examinations[i].dateTime > examinationFilter.ToDate)
            //    {
            //        examinations.Remove(Examinations[i]);
            //        continue;
            //    }
            //}
            //tb.Text = "Lekar:\t\t" + examinationFilter.Doctor + "\n\nPacijent:\t\t" + examinationFilter.Patient + "\n\nOd:\t\t" + examinationFilter.FromDate + "\nDo:\t\t" + examinationFilter.ToDate + "\n\nSala:\t\t" + examinationFilter.Room;
            //tb.FontSize = 13;
            //se.ItemsSource = null;
            //se.ItemsSource = examinations;
        }

        public static void EditExamination(Examination oldExamination, Examination newExamination)
        {
            int index = Examinations.IndexOf(oldExamination);
            Examinations.RemoveAt(index);
            Examinations.Insert(index, newExamination);
            index = examinations.IndexOf(oldExamination);
            examinations.RemoveAt(index);
            examinations.Insert(index, newExamination);
            se.ItemsSource = null;
            se.ItemsSource = examinations;
            msg.Content = "Pregled upsešno izmenjen.";
            msg.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ScheduledExaminations.SelectedItem == null)
            {
                e.CanExecute = false;
                MessageBox.Show("Prvo selektujte red u tabeli.", "Oops", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (tabs.SelectedIndex != 1)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        public static void FilterFreeSlots(ExaminationDTO examinationFilter, bool doctorPriority)
        {
            //freeSlots = new List<Examination>(FreeSlots);
            //for(int i = 0; i < FreeSlots.Count; i++)
            //{
            //    if (!String.IsNullOrEmpty(examinationFilter.Doctor) && FreeSlots[i].doctor != examinationFilter.Doctor)
            //    {
            //        if (doctorPriority)
            //        {
            //            freeSlots.Remove(FreeSlots[i]);
            //            continue;
            //        }
            //    }

            //    if (FreeSlots[i].dateTime != examinationFilter.FromDate)
            //    {
            //        if (!doctorPriority)
            //        {
            //            if (Math.Abs(FreeSlots[i].dateTime.Day - examinationFilter.FromDate.Day) > 2)
            //            {
            //                freeSlots.Remove(FreeSlots[i]);
            //                continue;
            //            }
            //        }
            //    }
            //}
            //ee.ItemsSource = null;
            //ee.ItemsSource = freeSlots;
        }

        Examination SelectedFreeSlot;
        private void Schedule(object sender, RoutedEventArgs e)
        {
            //SelectedFreeSlot = ee.SelectedItem as Examination;
            //if (SelectedFreeSlot == null)
            //{
            //    MessageBox.Show("Selektujte pregled pre zakazivanja.", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}
            //Examination newExamination = new Examination(SelectedFreeSlot.dateTime, SelectedFreeSlot.doctor, GuestPatient.FirstName + " " + GuestPatient.LastName, SelectedFreeSlot.room);
            //Examinations.Add(newExamination);
            //SwapLists(sender, e);
            //SuccessLabel.Visibility = Visibility.Visible;
            //dispatcherTimer.Start();
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
