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
using Model.Dto;
using Model.Director;
using bolnica.Model.Dto;
using bolnica.Service;
using Model.Doctor;
using System.Configuration;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        [Obsolete]
        public static double ExaminationDuration = Double.Parse(ConfigurationSettings.AppSettings["examinationDuration"]);

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


        public static List<ExaminationDTO> examinationDisplay { get; set; }
        public static List<Examination> Examinations { get; set; }
        public static List<ExaminationDTO> ExaminationDisplay { get; set; }
        public ExaminationDTO SelectedExamination { get; set; }

        public static List<ExaminationDTO> freeSlots { get; set; }
        public static List<ExaminationDTO> FreeSlots { get; set; }

        public List<Operation> Operations { get; set; }
        public Operation SelectedOperation { get; set; }

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

            se = ScheduledExaminations;
            ee = EmptyExaminations;
            tb = FilterInfo;
            msg = SuccessMsg;

            FillExaminationTable();
            FillOperationTable();


            FreeSlots = new List<ExaminationDTO>();
            freeSlots = new List<ExaminationDTO>(FreeSlots);

            Shortcuts = new List<Shortcut>();
            CreateShortcuts();

            

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        }

        private void FillOperationTable()
        {
            App app = Application.Current as App;
            Operations = app.OperationController.GetAll().ToList();
            ScheduledOperations.ItemsSource = Operations;
        }

        private static void FillExaminationTable()
        {
            App app = Application.Current as App;
            Examinations = app.ExaminationController.GetAll().ToList();
            ExaminationDisplay = ConvertExaminationToExaminationDTO(Examinations);
            examinationDisplay = new List<ExaminationDTO>(ExaminationDisplay);
            se.ItemsSource = examinationDisplay;
        }

        private static List<ExaminationDTO> ConvertExaminationToExaminationDTO(List<Examination> examinations)
        {
            List<ExaminationDTO> retVal = new List<ExaminationDTO>();
            foreach (Examination examination in examinations)
            {
                Room room = null;
                foreach (BusinessDay businessDay in examination.Doctor.BusinessDay)
                    if (businessDay.Shift.StartDate.Date == examination.Period.StartDate.Date)
                    {
                        room = businessDay.room;
                        break;
                    }
                retVal.Add(new ExaminationDTO(examination.Id, examination.Doctor, room, examination.Period, (Patient)examination.User));
            }
            return retVal;
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
            EditAppointment editDialog = new EditAppointment(SelectedExamination);
            editDialog.ShowDialog();
        }

        private void FreeSelectedAppointment(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da otkažete pregled?", "Otkazivanje pregleda", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No) return;

            ExaminationDTO examination = ScheduledExaminations.SelectedItem as ExaminationDTO;
            App app = Application.Current as App;
            Examination toDelete = Examinations.SingleOrDefault(entity => entity.Id == examination.Id);
            app.ExaminationController.Delete(toDelete);
            BusinessDay selectedDay = app.BusinessDayController.GetExactDay(toDelete.Doctor, toDelete.Period.StartDate);
            List<DateTime> dateList = new List<DateTime>();
            dateList.Add(toDelete.Period.StartDate);
            app.BusinessDayController.FreePeriod(selectedDay, dateList);
            FillExaminationTable();

            PatientNotification notification = new PatientNotification((Patient)examination.Patient, false, "Pregled zakazan za " + examination.Period.StartDate + " je otkazan!");
            app.NotificationController.Save(notification);

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
            OperationMsg.Visibility = Visibility.Collapsed;

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
            examinationDisplay = new List<ExaminationDTO>(ExaminationDisplay);
            se.ItemsSource = examinationDisplay;
            tb.Text = "";
        }

        private void SwapFreeLists(object sender, RoutedEventArgs e)
        {
            //freeSlots = new List<Examination>(FreeSlots);
            //ee.ItemsSource = null;
            //ee.ItemsSource = freeSlots;
        }

        public static void FilterExaminations(ExaminationDTO examinationFilter)
        {
            App app = Application.Current as App;
            examinationDisplay = ConvertExaminationToExaminationDTO(app.ExaminationController.GetExaminationsByFilter(examinationFilter, true));
            tb.Text = "Lekar:\t\t" + ((examinationFilter.Doctor != null) ? examinationFilter.Doctor.FullName : "") + "\n\nPacijent:\t\t" + ((examinationFilter.Patient != null) ? examinationFilter.Patient.FullName : "") + "\n\nOd:\t\t" + examinationFilter.Period.StartDate + "\nDo:\t\t" + examinationFilter.Period.EndDate + "\n\nSala:\t\t" + ((examinationFilter.Room != null) ? examinationFilter.Room.RoomCode : "");
            tb.FontSize = 13;
            se.ItemsSource = examinationDisplay;
        }

        public static void EditExamination(Examination newExamination)
        {
            ExaminationDTO examinationDTO = se.SelectedItem as ExaminationDTO;
            App app = Application.Current as App;
            BusinessDay previousDay = app.BusinessDayController.GetExactDay(examinationDTO.Doctor, examinationDTO.Period.StartDate);
            Examination toEdit = Examinations.SingleOrDefault(entity => entity.Id == examinationDTO.Id);

            toEdit.Doctor = newExamination.Doctor;
            toEdit.Period = newExamination.Period;
            toEdit.User = newExamination.User;

            if (examinationDTO.Doctor.Id != newExamination.Doctor.Id || examinationDTO.Period.StartDate != newExamination.Period.StartDate)
            {
                BusinessDay selectedDay = app.BusinessDayController.GetExactDay(toEdit.Doctor, toEdit.Period.StartDate);
                if (selectedDay == null)
                {
                    MessageBox.Show("Izabrani doktor ne radi u izabranom terminu.", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!app.BusinessDayController.isExaminationPossible(toEdit))
                {
                    MessageBox.Show("Izabrani termin nije validan.", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                app.ExaminationController.Edit(toEdit);
                List<DateTime> dateList = new List<DateTime>();
                dateList.Add(examinationDTO.Period.StartDate);
                app.BusinessDayController.FreePeriod(previousDay, dateList);
                selectedDay = app.BusinessDayController.GetExactDay(toEdit.Doctor, toEdit.Period.StartDate);
                List<Period> periodList = new List<Period>();
                periodList.Add(toEdit.Period);
                app.BusinessDayController.MarkAsOccupied(periodList, selectedDay);
            }
            else
                app.ExaminationController.Edit(toEdit);

            FillExaminationTable();

            PatientNotification notification = new PatientNotification((Patient) toEdit.User, false, "Pregled zakazan za " + examinationDTO.Period.StartDate + " je izmenjen!");
            app.NotificationController.Save(notification);
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

        public static void FilterFreeSlots(BusinessDayDTO examinationFilter, String choice)
        {
            App app = Application.Current as App;
            if(choice == "noPriority")
                app.businessDayService._searchPeriods = new NoPrioritySearch();
            else if(choice == "doctorFirst")
                app.businessDayService._searchPeriods = new DoctorPrioritySearch();
            else
                app.businessDayService._searchPeriods = new DatePrioritySearch();
            FreeSlots = app.BusinessDayController.Search(examinationFilter);
            ee.ItemsSource = FreeSlots;
        }

        ExaminationDTO SelectedFreeSlot;
        private void Schedule(object sender, RoutedEventArgs e)
        {
            App app = Application.Current as App;
            SelectedFreeSlot = ee.SelectedItem as ExaminationDTO;
            if (SelectedFreeSlot == null)
            {
                MessageBox.Show("Selektujte pregled pre zakazivanja.", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (GuestPatient.Guest)
            {
                GuestPatient.DateOfBirth = new DateTime(int.Parse(IGuestYear.Text), int.Parse(IGuestMonth.Text), int.Parse(IGuestDay.Text));
                GuestPatient.Address = Addresses[0];
                GuestPatient.Address.Town = Towns[0];
                GuestPatient.Address.Town.State = States[0];
                GuestPatient.Username = GuestPatient.Jmbg;
                GuestPatient.Password = GuestPatient.Jmbg;
                GuestPatient = app.PatientController.Save(GuestPatient);
            }
                
            Examination newExamination = new Examination(GuestPatient, SelectedFreeSlot.Doctor, SelectedFreeSlot.Period);
            BusinessDay businessDay = app.BusinessDayController.GetExactDay(newExamination.Doctor, newExamination.Period.StartDate);
            List<Period> periodList = new List<Period>();
            periodList.Add(newExamination.Period);
            app.BusinessDayController.MarkAsOccupied(periodList, businessDay);

            app.ExaminationController.Save(newExamination);
            FillExaminationTable();
            FreeSlots.Clear();
            ee.ItemsSource = FreeSlots;

            SuccessLabel.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
        }

        [Obsolete]
        private void CancelOperation(object sender, RoutedEventArgs e)
        {
            if (SelectedOperation == null)
            {
                MessageBox.Show("Niste izabrali operaciju za otkazivanje.", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da otkažete operaciju?", "Otkazivanje operacije", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No) return;

            App app = Application.Current as App;
            app.OperationController.Delete(SelectedOperation);

            List<DateTime> toDelete = new List<DateTime>();
            DateTime time = SelectedOperation.Period.StartDate;
            while(time <= SelectedOperation.Period.EndDate)
            {
                toDelete.Add(time);
                time = time.AddMinutes(ExaminationDuration);
            }
            BusinessDay businessDay = app.BusinessDayController.GetExactDay(SelectedOperation.Doctor, SelectedOperation.Period.StartDate);
            app.BusinessDayController.FreePeriod(businessDay, toDelete);
            FillOperationTable();
            OperationMsg.Visibility = Visibility.Visible;
            dispatcherTimer.Start();
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
