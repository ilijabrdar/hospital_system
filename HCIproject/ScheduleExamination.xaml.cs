using bolnica.Model.Dto;
using bolnica.Service;
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
        public List<ExaminationDTO> upcomingExaminations { get; set; }


        public ScheduleExamination(Doctor user, long patientId)
        {
            this.user = user;
            this.id = patientId;
            InitializeComponent();

            specialistExaminations = new List<ExaminationDTO>();
            setPatientInfo();
          //  SearchPeriods();
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

        public ScheduleExamination()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//otkazi
            this.Close();
        }

       

        private void SearchPeriods(object sender, RoutedEventArgs e)
        {
                var app = Application.Current as App;

                if (Picker.SelectedDate == null)
                   return;

                app.BusinessDayService._searchPeriods = new NoPrioritySearch();
                Period period = new Period();
                period.StartDate = DateTime.Parse(Picker.Text);
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(user, period);
                upcomingExaminations = app.BusinessDayController.Search(businessDayDTO);
                specialistGrid.Visibility = Visibility.Visible;
                specialistGrid.ItemsSource = upcomingExaminations; 
        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            var selectedItem = specialistGrid.SelectedItem;

            if (selectedItem == null)
            {
                return;
            }

            ExaminationDTO scheduleExam = (ExaminationDTO)selectedItem;

            Period period = scheduleExam.Period;
            Patient patient = app.PatientController.Get(id);
            Examination examination = new Examination(patient, user, period);
            app.ExaminationController.Save(examination);
            BusinessDay day = app.BusinessDayController.GetExactDay(user, period.StartDate);
            List<Period> pom = new List<Period>();
            pom.Add(period);
            app.BusinessDayController.MarkAsOccupied(pom, day);


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
