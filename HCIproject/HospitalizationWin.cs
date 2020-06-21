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
    /// Interaction logic for Hospitalization.xaml
    /// </summary>

    public partial class HospitalizationWin : Window
    {
        private Doctor user;
        public String dijagnoza;
        private long patientId;
       
        public HospitalizationWin(Doctor _user, long _patientId, String _dijagnoza)
        {
            this.user = _user;
            this.dijagnoza = _dijagnoza;
            this.patientId = _patientId;


            InitializeComponent();
            setPatientInfo();
            dijagnozaTxt.Text = dijagnoza;
            setSpecialityCombo();
        }

        public HospitalizationWin()
        {
            InitializeComponent();
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;

        }
        private void setPatientInfo()
        {
            var app = Application.Current as App;
            Patient patient = app.PatientController.Get(patientId);
            String imePrez = patient.FirstName + " " + patient.LastName;
            imePacijenta.Content = imePrez;

            int godine = DateTime.Now.Year - patient.DateOfBirth.Year;
            godinePacijenta.Content = godine.ToString();

            //alergijePacijenta.Content = patient.patientFile.Allergy.ToString();

        }

        private void setSpecialityCombo()
        {
            var app = Application.Current as App;
            foreach(var spec in app.SpecialityController.GetAll())
            {
                specialitiCMB.Items.Add(spec.Name);
            }


            Random rand = new Random();
            int randInt = rand.Next(0, 200);
            sobaTxt.Text = randInt.ToString();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //potvrdi

            if (StartDate.SelectedDate > EndDate.SelectedDate || StartDate.SelectedDate < DateTime.Now || specialitiCMB.SelectedItem == null)
            {
                if (specialitiCMB.SelectedItem == null)
                {
                    string messageBoxText1 = "Morate izabrati odeljenje kako biste izvrsili hospitalizaciju!";
                    string caption1 = "Hospitalizacija";
                    MessageBoxButton button1 = MessageBoxButton.OK;
                    MessageBoxImage icon1 = MessageBoxImage.Information;
                    MessageBoxResult result1 = MessageBox.Show(messageBoxText1, caption1, button1, icon1);
                }
                else
                {
                    string messageBoxText = "Nevalidan unos datuma. Datum početka operacije mora biti u budućnosti, pre završetka iste.";
                    string caption = "Hospitalizacija";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                }
            }else
            {
                string messageBoxText = "Uspesno ste izvrsili hospitalizaciju pacijenta!";
                string caption = "Hospitalizacija";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                this.Close();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        { //otkazi
            //ExaminationWin exam = new ExaminationWin((Doctor)user);
            //this.Visibility = Visibility.Hidden;
            //exam.Show();
            this.Close();
        }

        private void StackPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrol.Height = this.ActualHeight - 150;
        }


    }
}
