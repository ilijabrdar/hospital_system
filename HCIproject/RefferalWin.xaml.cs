using bolnica.Model.Dto;
using bolnica.Service;
using Controller;
using Model.Director;
using Model.Doctor;
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
        public List<Doctor> listOfDoctors { get; set; }

        public static Referral referral = new Referral();


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
            

            this.DataContext = this;

        }
        private void setPatientInfo()
        {
            var app = Application.Current as App;
            Patient patient = app.PatientDecorator.Get(patientId);
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
            foreach(var speciality in app.SpecialityDecorator.GetAll())
            {
                if(speciality.Name!="Opsta praksa")
                    odeljenjeCMB.Items.Add(speciality.Name);
            }


        }

    

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            this.Close();
        }
        private void scrol_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrol.Height = this.ActualHeight - 150;
        }

        private void SearchPeriods(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;

            if (Picker.SelectedDate == null)
                return;

            if(odeljenjeCMB.SelectedItem==null) return;
            if (lekarCMB.SelectedItem == null) return;

            String doctorsInfo = lekarCMB.SelectedItem.ToString();
            String [] tokens = doctorsInfo.Split(")".ToCharArray());
            long doctorId = long.Parse(tokens[0]);
            Doctor doctor = app.DoctorDecorator.Get(doctorId);

            app.BusinessDayService._searchPeriods = new NoPrioritySearch();
            Period period = new Period();
            period.StartDate = DateTime.Parse(Picker.Text);
            BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period);
            specialistExaminations = app.BusinessDayDecorator.Search(businessDayDTO);
            specialistGrid.ItemsSource = specialistExaminations;
            specialistGrid.Visibility = Visibility.Visible;
        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            var selectedItem = specialistGrid.SelectedItem;

            if (lekarCMB.SelectedItem == null) return;
            if (selectedItem == null) return;

            String doctorsInfo = lekarCMB.SelectedItem.ToString();
            String[] tokens = doctorsInfo.Split(")".ToCharArray());
            long doctorId = long.Parse(tokens[0]);
            Doctor doctor = app.DoctorDecorator.Get(doctorId);
            
            ExaminationDTO scheduleExam = (ExaminationDTO)selectedItem;
            Period period = scheduleExam.Period;
            Patient patient = app.PatientDecorator.Get(patientId);
            Examination examination = new Examination(patient, doctor, period);
            app.ExaminationDecorator.Save(examination);
            BusinessDay day = app.BusinessDayDecorator.GetExactDay(doctor, period.StartDate);
            List<Period> pom = new List<Period>();
            pom.Add(period);
            app.BusinessDayDecorator.MarkAsOccupied(pom, day);


            if (specialistGrid.SelectedItem != null)
            {
                referral = new Referral(period, doctor);
                app.RefferalDecorator.Save(referral);
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

     

        private void odeljenjeCMB_DropDownClosed(object sender, EventArgs e)
        {
            var app = Application.Current as App;
            if (odeljenjeCMB.SelectedItem == null) return;

            Speciality speciality = new Speciality();
            foreach (Speciality spec in app.SpecialityDecorator.GetAll())
            {
                if (spec.Name == odeljenjeCMB.SelectedItem.ToString())
                {
                    speciality = new Speciality(spec.Id, spec.Name);
                }
            }
            lekarCMB.Items.Clear();
            List<Doctor> doctors= app.DoctorDecorator.GetDoctorsBySpeciality(speciality);
            foreach(Doctor doctor in doctors)
            {
                lekarCMB.Items.Add(doctor.Id+")"+ doctor.FullName);
            }
            //  listOfDoctors = app.DoctorController.GetDoctorsBySpeciality(speciality);

        }
    }
}
