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
using bolnica.Controller;
using Model.Users;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public Secretary Secretary { get; set; }
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
        private Boolean _isToolTipAvailable = true;

        public State SelectedState { get; set; }
        public Town SelectedTown { get; set; }
        public Address SelectedAddress { get; set; }

        public String FullDate { get; set; }

        public MainWindow(Secretary secretary)
        {
            InitializeComponent();
            this.DataContext = this;
            
            GuestPatient = new Patient(true);
            Secretary = secretary;
            Day = secretary.DateOfBirth.Day;
            Month = secretary.DateOfBirth.Month;
            Year = secretary.DateOfBirth.Year;
            FullDate = string.Join("/", Day, Month, Year);
            PopulateCombos();
            //Image = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Secretary.Image, Int)
            this.examinations = new List<Examination>();
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 12, 00, 00), "Pera Peric", "Petar Petrovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 15, 00, 00), "Pera Peric", "Milan Milanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 16, 30, 00), "Marko Markovic", "Ivan Ivanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 17, 15, 00), "Pera Peric", "Luka Lukovic", "S13"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 8, 00, 00), "Nikola Nikolic", "Milan Milanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 9, 30, 00), "Nikola Nikolic", "Marko Markovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 10, 00, 00), "Ivan Ivanovic", "Luka Lukovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 10, 15, 00), "Pera Peric", "Milan Milanovic", "S14"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 00, 00), "Marko Markovic", "Marko Markovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 15, 00), "Marko Markovic", "Milan Milanovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 30, 00), "Nikola Nikolic", "Marko Markovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 50, 00), "Marko Markovic", "Milan Milanovic", "S16"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 15, 00, 00), "Nikola Nikolic", "Ivan Ivanovic", "S17"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 16, 00, 00), "Marko Markovic", "Milan Milanovic", "S16"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 17, 00, 00), "Nikola Nikolic", "Petar Petrovic", "S30"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 18, 00, 00), "Marko Markovic", "Milan Milanovic", "S55"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 18, 30, 00), "Nikola Nikolic", "Ivan Ivanovic", "S25"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 18, 55, 00), "Marko Markovic", "Petar Petrovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 19, 10, 00), "Nikola Nikolic", "Marko Markovic", "S55"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 20, 00, 00), "Marko Markovic", "Milan Milanovic", "S15"));

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
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 12, 50, 00), "Marko Markovic", "S16"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 15, 00, 00), "Nikola Nikolic", "S17"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 16, 00, 00), "Marko Markovic", "S16"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 17, 00, 00), "Nikola Nikolic", "S30"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 18, 00, 00), "Marko Markovic", "S55"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 18, 30, 00), "Nikola Nikolic", "S25"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 18, 55, 00), "Marko Markovic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 19, 10, 00), "Nikola Nikolic", "S55"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 20, 00, 00), "Marko Markovic", "S15"));
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
            reportWindow.Show();
        }

        private void FindAppointment(object sender, RoutedEventArgs e)
        {
            AppointmentFilter filterWindow = new AppointmentFilter();
            filterWindow.ShowDialog();
        }

        private void FindFreeAppointment(object sender, RoutedEventArgs e)
        {
            AppointmentSearch searchDialog = new AppointmentSearch();
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
            EditAppointment editDialog = new EditAppointment();
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

        }
    }
}
