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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for EditAppointment.xaml
    /// </summary>
    public partial class EditAppointment : Window
    {
        public static int Day { get; set; }
        public static int Month { get; set; }
        public static int Year { get; set; }
        public static int Hour { get; set; }
        public static int Minute { get; set; }

        public List<String> Rooms { get; set; }
        public List<String> Patients { get; set; }
        public List<String> Doctors { get; set; }
        public String SelectedRoom { get; set; }
        public String SelectedPatient { get; set; }
        public String SelectedDoctor { get; set; }
        public Examination SelectedExamination { get; set; }
        
        public EditAppointment(Examination examination)
        {
            InitializeComponent();
            this.DataContext = this;
            SelectedExamination = examination;
            Day = examination.dateTime.Day;
            Month = examination.dateTime.Month;
            Year = examination.dateTime.Year;
            Hour = examination.dateTime.Hour;
            Minute = examination.dateTime.Minute;
            Rooms = new List<String>();
            Rooms.Add("S10");
            Rooms.Add("S11");
            Rooms.Add("S12");
            Rooms.Add("S13");
            Rooms.Add("S14");
            Rooms.Add("S15");
            Rooms.Add("S16");
            Rooms.Add("S17");
            Patients = new List<String>();
            Patients.Add("Pera Peric");
            Patients.Add("Nikola Nikolic");
            Patients.Add("Marko Markovic");
            Patients.Add("Ivan Ivanovic");
            Doctors = new List<String>();
            Doctors.Add("Pera Peric");
            Doctors.Add("Nikola Nikolic");
            Doctors.Add("Marko Markovic");
            Doctors.Add("Ivan Ivanovic");
            SelectedPatient = examination.patient;
            SelectedDoctor = examination.doctor;
            SelectedRoom = examination.room;
            PopulateCombos();

        }

        private void PopulateCombos()
        {
            //App app = Application.Current as App;
            //IRoomController roomController = app.RoomController;
            //Rooms = roomController.GetAll().ToList(); 
            foreach (String room in Rooms)
            {
                if(room == SelectedExamination.room)
                {
                    SelectedRoom = SelectedExamination.room;
                }
            }

            foreach(String doctor in Doctors)
            {
                if (doctor == SelectedExamination.doctor)
                    SelectedDoctor = doctor;
            }

            foreach(String patient in Patients)
            {
                if (patient == SelectedExamination.patient)
                    SelectedPatient = patient;
            }
        }

        private void CloseDialog(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
