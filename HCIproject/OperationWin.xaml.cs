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
    public partial class OperationWin : Window
    {
        public Doctor user;
        private long id;
        private String dijagnoza;
        public List<ExaminationDTO> specialistExaminations { get; set; }

        public OperationWin() { }
        public OperationWin(Doctor user, long _patientId, String _dijagnoza)
        {
            this.user = user;
            this.id = _patientId;
            InitializeComponent();

            dijagnoza = _dijagnoza;

            setPatientInfo();
            dijagnozaTxt.Text = dijagnoza;
            lekarTxt.Text = user.FirstName + " " + user.LastName;
            specialistExaminations = new List<ExaminationDTO>();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //potvrdi
            if (specialistGrid.SelectedItem != null || vreme.Text!="" || naziv.Text!="")
            {
                ExaminationDTO examDTO = (ExaminationDTO)specialistGrid.SelectedItem;
                string messageBoxText = "Uspesno ste zakazali operaciju za dan" + examDTO.Period.StartDate;
                string caption = "Operacija";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                this.Close();

            }
            else
            {
                string messageBoxText = "Morate uneti sve potrebne podatke kako biste zakazali operaciju!";
                string caption = "Operacija";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { //otkazi
            this.Close();
        }

        private void scrol_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrol.Height = this.ActualHeight - 130;
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
            specialistExaminations = app.BusinessDayController.Search(businessDayDTO);
            specialistGrid.ItemsSource = specialistExaminations;
            specialistGrid.Visibility = Visibility.Visible;

        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            var selectedItem = specialistGrid.SelectedItem;       

            ExaminationDTO scheduleExam = (ExaminationDTO)selectedItem;
            Period period = scheduleExam.Period;
            Patient patient = app.PatientController.Get(id);
            Examination examination = new Examination(patient, user, period);
            app.ExaminationController.Save(examination);
            BusinessDay day = app.BusinessDayController.GetExactDay(user, period.StartDate);
            app.BusinessDayController.MarkAsOccupied(period, day);


            if (specialistGrid.SelectedItem != null)
            {
                
                ExaminationDTO examDTO = (ExaminationDTO)specialistGrid.SelectedItem;
                string messageBoxText = "Uspesno ste zakazali operaciju " + " dana" + " " + examDTO.Period.StartDate;
                string caption = "Potvrda operacije!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                this.Close();

            }
            else
            {
                string messageBoxText = "Morate izabrati odgovarajuce podatke iz tabele kako biste uspesno zakazali operaciju.";
                string caption = "Uput";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }


        }
    }
}
