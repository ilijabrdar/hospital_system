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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for AppointmentSearch.xaml
    /// </summary>
    public partial class AppointmentSearch : Window
    {
        public int Day { get; set; }
        public static int Month { get; set; }
        public static int Year { get; set; }
        public int Hour  { get; set; }
        public int Minute { get; set; }

        public List<String> Doctors { get; set; }
        public String SelectedDoctor { get; set; }

        public AppointmentSearch()
        {
            InitializeComponent();
            this.DataContext = this;
            Day = DateTime.Now.Day;
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;

            Doctors = new List<string>();
            Doctors.Add("");
            Doctors.Add("Pera Peric");
            Doctors.Add("Nikola Nikolic");
            Doctors.Add("Marko Markovic");
            Doctors.Add("Ivan Ivanovic");
            SelectedDoctor = Doctors[0];
            DoctorFirst.IsChecked = true;
        }

        private void CencelDialog(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FilterExaminations(object sender, RoutedEventArgs e)
        {
            ExaminationDTO examinationFilter = new ExaminationDTO(SelectedDoctor, "", "", new DateTime(Year, Month, Day, Hour, Minute, 0), new DateTime());
            if ((bool)DoctorFirst.IsChecked)
                MainWindow.FilterFreeSlots(examinationFilter, true);
            else if((bool)PeriodFirst.IsChecked)
                MainWindow.FilterFreeSlots(examinationFilter, false);
            this.Close();
        }
    }
}
