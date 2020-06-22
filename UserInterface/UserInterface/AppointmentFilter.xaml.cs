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
using bolnica.Controller;
using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for AppointmentFilter.xaml
    /// </summary>
    public partial class AppointmentFilter : Window
    {
        public static int FromDay { get; set; }
        public static int ToDay { get; set; }
        public static int FromMonth { get; set; }
        public static int ToMonth { get; set; }
        public static int FromYear { get; set; }
        public static int ToYear { get; set; }
        public static int FromHour { get; set; }
        public static int ToHour { get; set; }
        public static int FromMinute { get; set; }
        public static int ToMinute { get; set; }

        //public List<Patient> Patients { get; set; }
        //public List<Room> Rooms { get; set; }

        public List<Patient> Patients { get; set; }
        public Patient SelectedPatient { get; set; }
        public List<Room> Rooms { get; set; }
        public Room SelectedRoom { get; set; }
        public List<Doctor> Doctors { get; set; }
        public Doctor SelectedDoctor { get; set; }

        public AppointmentFilter(List<Patient> patients)
        {
            InitializeComponent();
            this.DataContext = this;
            FromDay = ToDay = DateTime.Now.Day;
            FromMonth = ToMonth = DateTime.Now.Month;
            FromYear = ToYear = DateTime.Now.Year;
            FromHour = ToHour = DateTime.Now.Hour;
            FromMinute = ToMinute = DateTime.Now.Minute;

            App app = Application.Current as App;

            Rooms = app.RoomController.GetAll().ToList();
            SelectedRoom = Rooms[0];

            Patients = app.PatientController.GetAll().ToList();
            SelectedPatient = Patients[0];

            Doctors = app.DoctorController.GetAll().ToList();
            SelectedDoctor = Doctors[0];
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            ExaminationDTO examinationFilter = new ExaminationDTO(SelectedDoctor, SelectedRoom, new Period(new DateTime(FromYear, FromMonth, FromDay, FromHour, FromMinute, 0), new DateTime(ToYear, ToMonth, ToDay, ToHour, ToMinute, 0)), SelectedPatient);
            MainWindow.FilterExaminations(examinationFilter);
            CloseWindow(sender, e);
        }
    }

    //public class ExaminationDTO
    //{
    //    public String Doctor { get; set; }
    //    public String Patient { get; set; }
    //    public String Room { get; set; }
    //    public DateTime FromDate { get; set; }
    //    public DateTime ToDate { get; set; }

    //    public ExaminationDTO(String doctor, String patient, String room, DateTime fromDate, DateTime toDate)
    //    {
    //        Doctor = doctor;
    //        Patient = patient;
    //        Room = room;
    //        FromDate = fromDate;
    //        ToDate = toDate;
    //    }
    //}
}
