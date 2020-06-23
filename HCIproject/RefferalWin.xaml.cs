using Controller;
using Model.Director;
using Model.Dto;
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

namespace HCIproject
{
    public partial class RefferalWin : Window
    {
        public Doctor user;
        public long patientId;
        private string dijagnoza;
        public List<ExaminationDTO> specialistExaminations { get; set; }

        public RefferalWin(Doctor user, long _patientId, string _dijagnoza)
        {
            this.user = user;
            this.patientId = _patientId;
            this.dijagnoza = _dijagnoza;

            InitializeComponent();
            setOdeljenjeCMB();
            setPatientInfo();
            dijagnozaTxt.Text = dijagnoza;
            specialistExaminations = new List<ExaminationDTO>();

            setInfoExamination();
            this.DataContext = this;

        }
        private void setPatientInfo()
        {
            var app = Application.Current as App;
            Patient patient = app.PatientController.Get(patientId);
            String imePrez = patient.FirstName + " " + patient.LastName;
            imePacijenta.Content = imePrez;

            int godine = DateTime.Now.Year - patient.DateOfBirth.Year;
            godinePacijenta.Content = godine.ToString();

            foreach(Allergy allergy in patient.patientFile.Allergy)
            {
                alergijePacijenta.Content += allergy.Name;
            }

        }


        private void setOdeljenjeCMB()
        {
            var app = Application.Current as App;
            foreach(var speciality in app.SpecialityController.GetAll())
            {
                odeljenjeCMB.Items.Add(speciality.Name);
            }

        }
        private void setInfoExamination()
        {
            
                var app = Application.Current as App;
                List<ExaminationDTO> specialistExaminations = new List<ExaminationDTO>();
                specialistExaminations.Clear();

                foreach (Examination exam in app.ExaminationController.GetUpcomingExaminationsByUser(user))
                {
                    Room room = null;
                    foreach (BusinessDay businessDay in exam.Doctor.BusinessDay)
                    {
                        room = businessDay.room;
                        break;
                    }

                    specialistExaminations.Add(new ExaminationDTO(exam.Doctor, exam.Period));
                }

                specialistGrid.ItemsSource = specialistExaminations;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //potvrdi

            if (specialistGrid.SelectedItem != null)
            {
                ExaminationDTO examDTO = (ExaminationDTO)specialistGrid.SelectedItem;
                string messageBoxText = "Uspesno ste zakazali pregled kod lekara" + examDTO.Doctor.FirstName + " " + examDTO.Doctor.LastName + " dana" + " " + examDTO.Period.StartDate;
                string caption = "Potvrda uputa za lekara specijalistu!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                this.Close();

            }
            else
            {
                string messageBoxText = "Morate izabrati odgovarajuce podatke iz tabele kako biste uspesno izdali uput.";
                string caption = "Uput";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { //otkazi
            //ExaminationWin exam = new ExaminationWin((Doctor)user);
            //this.Visibility = Visibility.Hidden;
            //exam.Show();
            this.Close();
        }
        private void scrol_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrol.Height = this.ActualHeight - 150;
        }


    }
}
