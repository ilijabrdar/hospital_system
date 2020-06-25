using bolnica.Controller;
using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ShiftWindow.xaml
    /// </summary>
    public partial class ShiftWindow : Window
    {
        private readonly IDoctorController _doctorController;
        private readonly IRoomController _roomController;
        private readonly IBusinessDayController _businessDayController;

        private Doctor selectedDoctor;
        private BusinessDay selectedBusinessDay;
        private BusinessDay oldBusinessDay;
        DateTime old;

        public ShiftWindow(Doctor selectedDoctor)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _doctorController = app.DoctorController;
            _roomController = app.RoomController;
            _businessDayController = app.BusinessDayController;

            this.selectedDoctor = selectedDoctor;
        }

        public ShiftWindow(Doctor selectedDoctor, BusinessDay businessDay)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _doctorController = app.DoctorController;
            _roomController = app.RoomController;
            _businessDayController = app.BusinessDayController;

            this.selectedDoctor = selectedDoctor;
            this.selectedBusinessDay = businessDay;

            startDatePicker.SelectedDate = selectedBusinessDay.Shift.StartDate;
            endDatePicker.SelectedDate = selectedBusinessDay.Shift.EndDate;
            startTimePicker.SelectedTime = selectedBusinessDay.Shift.StartDate;
            endTimePicker.SelectedTime = selectedBusinessDay.Shift.EndDate;

            labelStartDate.Content = "Datum radnog vremena";
            labelEndDate.Visibility = Visibility.Hidden;
            endDatePicker.Visibility = Visibility.Hidden;

            old = businessDay.Shift.StartDate;


        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {

                
            if (DateTime.Compare((DateTime)startDatePicker.SelectedDate, (DateTime)endDatePicker.SelectedDate) > 0 && selectedBusinessDay == null)
            {
                string messageBoxText = "Ne moze datum pocetka smene biti posle datuma kraja smene!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }
            if (selectedBusinessDay == null)
            {
                DateTime start = (DateTime)startDatePicker.SelectedDate;
                DateTime timeStart = (DateTime)startTimePicker.SelectedTime;
                var finalStart = new DateTime(start.Year, start.Month, start.Day, timeStart.Hour, timeStart.Minute, start.Second);

                DateTime end = (DateTime)endDatePicker.SelectedDate;
                DateTime timeEnd = (DateTime)endTimePicker.SelectedTime;
                var finalEnd = new DateTime(end.Year, end.Month, end.Day, timeEnd.Hour, timeEnd.Minute, timeEnd.Second);

                Period temp = new Period(finalStart, finalEnd);

                Doctor doctor = selectedDoctor; //(Doctor)comboDoctor.SelectedItem;
                Room room = (Room)comboRoom.SelectedItem;


                int i = 0;
                while (start.Date < end.Date)
                {
                    start = start.AddDays(i);
                    if (i == 0)
                        i = 1;
                    DateTime startDate = new DateTime(start.Year, start.Month, start.Day, timeStart.Hour, timeStart.Minute, timeStart.Second);
                    DateTime endDate = new DateTime(start.Year, start.Month, start.Day, timeEnd.Hour, timeEnd.Minute, timeEnd.Second);
                    Period newPeriod = new Period(startDate, endDate);

                    BusinessDay businessDay = new BusinessDay(newPeriod, doctor, room, null);

                    BusinessDay saved = _businessDayController.Save(businessDay);
                    if (saved == null)
                    {
                        string messageBoxText = "Unesena smena se preklapa sa drugom.";
                        string caption = "Greska";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;

                        MessageBox.Show(messageBoxText, caption, button, icon);
                        return;
                    }
                    selectedDoctor.BusinessDay.Add(saved);
                    _doctorController.Edit(selectedDoctor);
                }
            }
            else
            {
                DateTime start = (DateTime)startDatePicker.SelectedDate;
                DateTime timeStart = (DateTime)startTimePicker.SelectedTime;
                var finalStart = new DateTime(start.Year, start.Month, start.Day, timeStart.Hour, timeStart.Minute, start.Second);

                DateTime end = (DateTime)endDatePicker.SelectedDate;
                DateTime timeEnd = (DateTime)endTimePicker.SelectedTime;
                var finalEnd = new DateTime(start.Year, start.Month, start.Day, timeEnd.Hour, timeEnd.Minute, timeEnd.Second);

                Period temp = new Period(finalStart, finalEnd);

                Room room = (Room)comboRoom.SelectedItem;

                selectedBusinessDay.room = room;
                selectedBusinessDay.Shift = temp;

                //TODO: kako obavestiti da je neuspeli edit
                if (!validateDates(selectedBusinessDay) && old.Date!=selectedBusinessDay.Shift.StartDate.Date)
                {
                    string messageBoxText = "Unesena smena se preklapa sa drugom.";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }
                if (!_businessDayController.ChangeDoctorShift(selectedBusinessDay))
                {
                    string messageBoxText = "Ne mozete izmeniti smenu ukoliko ima zakazanih pregleda.";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }
                _doctorController.Edit(selectedDoctor);
                _businessDayController.Edit(selectedBusinessDay);
            }

            this.Close();
        }

        private bool validateDates(BusinessDay entity)
        {
            foreach (BusinessDay businessDay in _businessDayController.GetBusinessDaysByDoctor(entity.doctor)) //15/07 - 25/-7
            {
                if (DateTime.Compare(businessDay.Shift.StartDate, entity.Shift.StartDate) <= 0 && DateTime.Compare(businessDay.Shift.EndDate, entity.Shift.EndDate) >= 0)  // 16/07 - 21/07
                    return false;
                else if ((DateTime.Compare(businessDay.Shift.StartDate, entity.Shift.StartDate) <= 0 && DateTime.Compare(businessDay.Shift.EndDate, entity.Shift.StartDate) >= 0) && DateTime.Compare(businessDay.Shift.EndDate, entity.Shift.EndDate) <= 0)  // 13/07 - 17/07
                    return false;
                else if (DateTime.Compare(businessDay.Shift.StartDate, entity.Shift.StartDate) >= 0 && DateTime.Compare(businessDay.Shift.StartDate, entity.Shift.EndDate) <= 0 && DateTime.Compare(businessDay.Shift.EndDate, entity.Shift.EndDate) >= 0)  // 17/07 -27/07
                    return false;
                else if (DateTime.Compare(entity.Shift.StartDate, businessDay.Shift.StartDate) <= 0 && DateTime.Compare(entity.Shift.EndDate, businessDay.Shift.EndDate) >= 0)  //10/07 - 30/07
                    return false;
            }

            if (DateTime.Compare(entity.Shift.StartDate, entity.Shift.EndDate) >= 0)  //   18/04 - 11/04 XXX
                return false;

            return true;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                    Button_Click_Ok(sender, e);
                    e.Handled = true;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //comboDoctor.ItemsSource = _doctorController.GetAll().ToList();
            //comboDoctor.DisplayMemberPath = "Jmbg";
            //comboDoctor.SelectedValuePath = "Id";


            comboRoom.ItemsSource = _roomController.GetAll().ToList();
            comboRoom.DisplayMemberPath = "RoomCode";
            comboRoom.SelectedValuePath = "Id";

            if (selectedBusinessDay != null)
            {
                comboRoom.SelectedValue = selectedBusinessDay.room.Id;
            }

            startDatePicker.DisplayDateStart = DateTime.Now;
            startDatePicker.DisplayDateEnd = DateTime.Now.AddMonths(6);

            endDatePicker.DisplayDateStart = DateTime.Now;
            endDatePicker.DisplayDateEnd = DateTime.Now.AddMonths(6);

        }
    }
}
