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

        public List<String> Patients { get; set; }
        public String SelectedPatient { get; set; }
        public List<String> Rooms { get; set; }
        public String SelectedRoom { get; set; }
        public List<String> Doctors { get; set; }
        public String SelectedDoctor { get; set; }

        public AppointmentFilter(List<Patient> patients)
        {
            InitializeComponent();
            this.DataContext = this;
            FromDay = ToDay = DateTime.Now.Day;
            FromMonth = ToMonth = DateTime.Now.Month;
            FromYear = ToYear = DateTime.Now.Year;
            FromHour = ToHour = DateTime.Now.Hour;
            FromMinute = ToMinute = DateTime.Now.Minute;
            //Patients = patients;
            //PopulateRoomCombo();

            Rooms = new List<string>();
            Rooms.Add("");
            Rooms.Add("S10");
            Rooms.Add("S11");
            Rooms.Add("S12");
            Rooms.Add("S13");
            Rooms.Add("S14");
            Rooms.Add("S15");
            Rooms.Add("S16");
            Rooms.Add("S17");
            SelectedRoom = Rooms[0];

            Patients = new List<string>();
            Patients.Add("");
            Patients.Add("Pera Peric");
            Patients.Add("Nikola Nikolic");
            Patients.Add("Marko Markovic");
            Patients.Add("Ivan Ivanovic");
            SelectedPatient = Patients[0];

            Doctors = new List<string>();
            Doctors.Add("");
            Doctors.Add("Pera Peric");
            Doctors.Add("Nikola Nikolic");
            Doctors.Add("Marko Markovic");
            Doctors.Add("Ivan Ivanovic");
            SelectedDoctor = Doctors[0];
        }

        private void PopulateRoomCombo()
        {
            App app = Application.Current as App;
            IRoomController roomController = app.RoomController;
            //Rooms = roomController.GetAll().ToList();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            ExaminationDTO examinationFilter = new ExaminationDTO(SelectedDoctor, SelectedPatient, SelectedRoom, new DateTime(FromYear, FromMonth, FromDay, FromHour, FromMinute, 0), new DateTime(ToYear, ToMonth, ToDay, ToHour, ToMinute, 0));
            MainWindow.FilterExaminations(examinationFilter);
            CloseWindow(sender, e);
        }
    }

    public class ExaminationDTO
    {
        public String Doctor { get; set; }
        public String Patient { get; set; }
        public String Room { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public ExaminationDTO(String doctor, String patient, String room, DateTime fromDate, DateTime toDate)
        {
            Doctor = doctor;
            Patient = patient;
            Room = room;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
