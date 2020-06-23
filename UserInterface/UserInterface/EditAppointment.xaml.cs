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
    /// Interaction logic for EditAppointment.xaml
    /// </summary>
    public partial class EditAppointment : Window
    {
        public static int Day { get; set; }
        public static int Month { get; set; }
        public static int Year { get; set; }
        public static int Hour { get; set; }
        public static int Minute { get; set; }

        public List<Room> Rooms { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Doctor> Doctors { get; set; }
        public Room SelectedRoom { get; set; }
        public Patient SelectedPatient { get; set; }
        public Doctor SelectedDoctor { get; set; }
        public ExaminationDTO SelectedExamination { get; set; }
        
        public EditAppointment(ExaminationDTO examination)
        {
            InitializeComponent();
            this.DataContext = this;
            SelectedExamination = examination;
            App app = Application.Current as App;

            Rooms = app.RoomController.GetAll().ToList();
            SelectedRoom = Rooms.SingleOrDefault(entity => entity.Id == examination.Room.Id);

            Patients = app.PatientController.GetAll().ToList();
            SelectedPatient = Patients.SingleOrDefault(entity => entity.Id == examination.Patient.Id);

            Doctors = app.DoctorController.GetAll().ToList();
            SelectedDoctor = Doctors.SingleOrDefault(entity => entity.Id == examination.Doctor.Id);

            Year = examination.Period.StartDate.Year;
            Month = examination.Period.StartDate.Month;
            Day = examination.Period.StartDate.Day;
            Hour = examination.Period.StartDate.Hour;
            Minute = examination.Period.StartDate.Minute;
        }

        private void CloseDialog(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            //Examination examination = new Examination(new DateTime(Year, Month, Day, Hour, Minute, 0), SelectedDoctor, SelectedPatient, SelectedRoom);
            //MainWindow.EditExamination(SelectedExamination, examination);
            //this.Close();
        }
    }
}
