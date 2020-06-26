using bolnica.Controller;
using Model.Director;
using Model.PatientSecretary;
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
using System.Windows.Shapes;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for RenovationDialog.xaml
    /// </summary>
    /// 
    public partial class RenovationDialog : Window
    {
        private readonly IRenovationController _renovationController;
        private readonly IRoomController _roomController;
        private Renovation selectedItem;

        public RenovationDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var app = Application.Current as App;
            _renovationController = app.authorityRenovation;
            _roomController = app.authorityRoom;
        }

        public RenovationDialog(Renovation selectedItem)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.selectedItem = selectedItem;
            startDatePicker.SelectedDate = selectedItem.Period.StartDate;
            endDatePicker.SelectedDate = selectedItem.Period.EndDate;
            comboRenovationStatus.SelectedItem = selectedItem.Status;
            comboRoomCode.SelectedItem = selectedItem.Room.GetId();  
            txtDescription.Text = selectedItem.Description;

            var app = Application.Current as App;
            _renovationController = app.authorityRenovation;
            _roomController = app.authorityRoom;
            
        }

        private void Button_Click_OK_Renovation(object sender, RoutedEventArgs e)
        {

            if (DateTime.Compare((DateTime) startDatePicker.SelectedDate, (DateTime)endDatePicker.SelectedDate)>0)
            {
                string messageBoxText = "Ne moze datum pocetka renoviranja biti posle datuma kraja renoviranja!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }

            if (selectedItem == null)
            {
                var reno = new Renovation((RenovationStatus)comboRenovationStatus.SelectedItem,
                    new Period(startDatePicker.SelectedDate, endDatePicker.SelectedDate),
                    txtDescription.Text,
                    (Room)comboRoomCode.SelectedItem
                    );
                _renovationController.Save(reno);
            }
            else
            {
                selectedItem.Room = (Room)comboRoomCode.SelectedItem;
                selectedItem.Description = txtDescription.Text;
                selectedItem.Status = (RenovationStatus)comboRenovationStatus.SelectedItem;
                selectedItem.Period.StartDate = (DateTime) startDatePicker.SelectedDate;
                selectedItem.Period.EndDate = (DateTime)endDatePicker.SelectedDate;
                _renovationController.Edit(selectedItem);
            }

            this.Close();


        }

        private void Button_Click_Cancel_Renovation(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboRenovationStatus.ItemsSource = Enum.GetValues(typeof(RenovationStatus));
            //TODO: display custom enum names

            List<Room> rooms = _roomController.GetAll().ToList();
            rooms.Sort((x, y) => x.RoomCode.CompareTo(y.RoomCode));
            comboRoomCode.ItemsSource = rooms;
            comboRoomCode.DisplayMemberPath = "RoomCode";
            comboRoomCode.SelectedValuePath = "Id";
            comboRoomCode.SelectedValue = "2";

            startDatePicker.DisplayDateStart = new DateTime(DateTime.Now.Year,1,1);
            startDatePicker.DisplayDateEnd = DateTime.Now.AddYears(2);

            endDatePicker.DisplayDateStart = new DateTime(DateTime.Now.Year, 1, 1);
            endDatePicker.DisplayDateEnd = DateTime.Now.AddYears(2);

            if(selectedItem != null) //this is for edit
                comboRoomCode.SelectedValue = selectedItem.Room.GetId();
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
                    Button_Click_OK_Renovation(sender, e);
                    e.Handled = true;
                }
            }
        }
    }
}
