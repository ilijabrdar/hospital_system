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
using bolnica.Model.Dto;
using Model.Users;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for AppointmentSearch.xaml
    /// </summary>
    public partial class AppointmentSearch : Window
    {
        public int FromDay { get; set; }
        public static int FromMonth { get; set; }
        public static int FromYear { get; set; }
        public static int ToDay  { get; set; }
        public static int ToMonth { get; set; }
        public static int ToYear { get; set; }

        public List<Doctor> Doctors { get; set; }
        public Doctor SelectedDoctor { get; set; }

        public AppointmentSearch()
        {
            InitializeComponent();
            this.DataContext = this;
            FromDay = DateTime.Now.Day;
            FromMonth = DateTime.Now.Month;
            FromYear = DateTime.Now.Year;
            ToDay = DateTime.Now.Hour;
            ToMonth = DateTime.Now.Minute;
            ToYear = DateTime.Now.Minute;

            App app = Application.Current as App;
            Doctors = app.DoctorController.GetAll().ToList();
            SelectedDoctor = Doctors[0];
            DoctorFirst.IsChecked = true;
        }

        private void CencelDialog(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FilterExaminations(object sender, RoutedEventArgs e)
        {
            BusinessDayDTO filter = new BusinessDayDTO(SelectedDoctor, new Model.PatientSecretary.Period(new DateTime(FromYear, FromMonth, FromDay, 0, 0, 0), new DateTime(ToYear, ToMonth, ToDay, 0, 0, 0)));
            //if ((bool)DoctorFirst.IsChecked)
            //    MainWindow.FilterFreeSlots(examinationFilter, true);
            //else if((bool)PeriodFirst.IsChecked)
            //    MainWindow.FilterFreeSlots(examinationFilter, false);
            MainWindow.FilterFreeSlots(filter);
            this.Close();
        }
    }
}
