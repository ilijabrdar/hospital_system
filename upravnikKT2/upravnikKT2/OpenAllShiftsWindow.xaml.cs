using bolnica.Controller;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for OpenAllShiftsWindow.xaml
    /// </summary>
    public partial class OpenAllShiftsWindow : Window
    {
        private readonly IDoctorController _doctorController;
        private readonly IBusinessDayController _businessDayController;

        private Doctor selectedDoctor;

        public OpenAllShiftsWindow(Doctor selectedDoctor)
        {
            InitializeComponent();
            this.DataContext = this;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.selectedDoctor = selectedDoctor;

            var app = Application.Current as App;
            _doctorController = app.DoctorController;
            _businessDayController = app.BusinessDayController;
        }

        private void AddShift(object sender, RoutedEventArgs e)
        {
            ShiftWindow window = new ShiftWindow(selectedDoctor);
            window.ShowDialog();

            DataGridShifts.Items.Refresh();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridShifts.ItemsSource = selectedDoctor.BusinessDay;
        }

        private void DeleteShiftBtnClick(object sender, RoutedEventArgs e)
        {
            if (DataGridShifts.SelectedItem != null)
            {
                BusinessDay businessDay = (BusinessDay)DataGridShifts.SelectedItem;

                string messageBoxText = "Da li ste sigurni da zelite da obrisete radni dan?";
                string caption = "Potvrda brisanja";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                if (result == MessageBoxResult.Yes)
                {
                    _businessDayController.Delete(businessDay);
                    selectedDoctor.BusinessDay.Remove(businessDay);
                    _doctorController.Edit(selectedDoctor);

                    this.DataGridShifts.ItemsSource = null;
                    List<BusinessDay> days = _doctorController.Get(selectedDoctor.Id).BusinessDay;
                    ObservableCollection<BusinessDay> data_days = new ObservableCollection<BusinessDay>(days);
                    this.DataGridShifts.ItemsSource = data_days;
                    
                }
            }
            else
            {
                string messageBoxText = "Morate selektovati smenu da biste je obrisali!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void EditShiftBtnClick(object sender, RoutedEventArgs e)
        {
            if (DataGridShifts.SelectedItem != null)
            {
                ShiftWindow window = new ShiftWindow(selectedDoctor, (BusinessDay)DataGridShifts.SelectedItem);
                window.ShowDialog();


                this.DataGridShifts.ItemsSource = null;
                    List<BusinessDay> days = _doctorController.Get(selectedDoctor.Id).BusinessDay;
                    ObservableCollection<BusinessDay> data_days = new ObservableCollection<BusinessDay>(days);
                    this.DataGridShifts.ItemsSource = data_days;

            }
            else
            {
                string messageBoxText = "Morate selektovati smenu da biste je izmenili!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
            if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                AddShiftBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editShiftBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                deletShiftBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }

        }

    }
}
