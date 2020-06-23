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

            foreach (Allergy allergy in patient.patientFile.Allergy)
            {
                alergijePacijenta.Content += allergy.Name;
            }
        }


        private void setTableData()
        {
            var app = Application.Current as App;
            List<ExaminationDTO> specialistExaminations = new List<ExaminationDTO>();
            specialistExaminations.Clear();

          foreach(Examination exam in app.ExaminationController.GetUpcomingExaminationsByUser(user))
            {
                Room room = null;
                foreach (BusinessDay businessDay in exam.Doctor.BusinessDay)
                {
                    room = businessDay.room;
                    break;
                }

                specialistExaminations.Add(new ExaminationDTO(exam.Period));
            }

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
