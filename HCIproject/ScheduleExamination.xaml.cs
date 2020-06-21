using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
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

namespace HCIproject
{
    /// <summary>
    /// Interaction logic for ScheduleExamination.xaml
    /// </summary>
    public partial class ScheduleExamination : Window
    {
        public Doctor user;
        private long id;
        public List<ExaminationDTO> specialistExaminations { get; set; }

        public ScheduleExamination(Doctor user, long patientId)
        {
            this.user = user;
            this.id = patientId;
            InitializeComponent();

            specialistExaminations = new List<ExaminationDTO>();
            setTableData();
            setPatientInfo();
            this.DataContext = this;

        }
        private void setPatientInfo()
        {
            var app = Application.Current as App;
            Patient patient = app.PatientController.Get(id);
            String imePrez = patient.FirstName + " " + patient.LastName;
            imePacijenta.Content = imePrez;

            int godine = DateTime.Now.Year - patient.DateOfBirth.Year;
            godinePacijenta.Content = godine.ToString();

            //alergijePacijenta.Content = patient.patientFile.Allergy.ToString();

        }


        private void setTableData()
        {
            specialistExaminations.Clear();

            Room room1 = new Room("101", null, null);
            Room room3 = new Room("113", null, null);
            Room room4 = new Room("103", null, null);
            Room room6 = new Room("100", null, null);
            Room room7 = new Room("201", null, null);
            Period period1 = new Period(new DateTime(2020, 6, 20, 9, 20, 0));
            Period period2 = new Period(new DateTime(2020, 6, 20, 9, 40, 0));
            Period period3 = new Period(new DateTime(2020, 6, 20, 10, 20, 0));
            Period period4 = new Period(new DateTime(2020, 6, 20, 10, 0, 0));
            Period period5 = new Period(new DateTime(2020, 6, 19, 14, 20, 0));
            Period period6 = new Period(new DateTime(2020, 7, 19, 15, 20, 0));
            Period period7 = new Period(new DateTime(2020, 7, 19, 16, 40, 0));
            Period period8 = new Period(new DateTime(2020, 7, 19, 17, 20, 0));
            Period period9 = new Period(new DateTime(2020, 7, 19, 18, 0, 0));
            ExaminationDTO exam1 = new ExaminationDTO(room1, period1);
            ExaminationDTO exam2 = new ExaminationDTO(room1, period2);
            ExaminationDTO exam3 = new ExaminationDTO(room3, period3);
            ExaminationDTO exam5 = new ExaminationDTO(room4, period5);
            ExaminationDTO exam6 = new ExaminationDTO(room4, period6);
            ExaminationDTO exam7 = new ExaminationDTO(room6, period7);
            ExaminationDTO exam8 = new ExaminationDTO(room7, period8);


            specialistExaminations.Add(exam1);
            specialistExaminations.Add(exam2);
            specialistExaminations.Add(exam3);
            specialistExaminations.Add(exam5);
            specialistExaminations.Add(exam6);
            specialistExaminations.Add(exam7);
            specialistExaminations.Add(exam8);

            specialistGrid.ItemsSource = specialistExaminations;
        }


        public ScheduleExamination()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//otkazi
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (specialistGrid.SelectedItem != null)
            {
                ExaminationDTO examDTO = (ExaminationDTO)specialistGrid.SelectedItem;
                string messageBoxText = "Uspesno ste zakazali kontrolu za dan" + examDTO.Period.StartDate;
                string caption = "Kontrola";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                this.Close();

            }
            else
            {
                string messageBoxText = "Morate izabrati odgovarajuce podatke iz tabele kako biste uspesno zakazali kontrolu.";
                string caption = "Kontrola";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }

        }
    }
}
