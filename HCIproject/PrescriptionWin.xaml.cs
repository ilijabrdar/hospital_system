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
    public partial class PrescriptionWin : Window
    {
        public Doctor user;
        public long patientId;
        public String dijagnoza;

        public static Prescription prescription=new Prescription();
        public static Therapy terapija = new Therapy();

        public List<Drug> lekoviListBox = new List<Drug>();

        public Period period = new Period();

        public PrescriptionWin(Doctor user, long _patientId, String _dijagnoza)
        {
            this.user = user;
            this.patientId = _patientId;
            this.dijagnoza = _dijagnoza;
            InitializeComponent();
            prescription = null;
            terapija = null;


            setPatientInfo();
            dijagnozaTxt.Text = dijagnoza;
            setDrugCombo();
        }

        private void setPatientInfo()
        {
            var app = Application.Current as App;
            Patient patient = app.PatientDecorator.Get(patientId);
            String imePrez = patient.FirstName + " " + patient.LastName;
            imePacijenta.Content = imePrez;

            int godine=DateTime.Now.Year - patient.DateOfBirth.Year;
            godinePacijenta.Content = godine.ToString();

            foreach (Allergy allergy in patient.patientFile.Allergy)
            {
                alergijePacijenta.Content += allergy.Name;
            }
        }

        private void setDrugCombo()
        {
            var app = Application.Current as App;
            foreach(var lek in app.DrugDecorator.GetAll())
            {
                lekovi.Items.Add(lek.Name);
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;

            if (lekovi.SelectedItem != null)
            {
                if (StartDate.SelectedDate != null && EndDate.SelectedDate != null)
                {
                    period = new Period(StartDate.SelectedDate, EndDate.SelectedDate);
                }

                foreach(String drug in lekovi.SelectedItems)
                {
                    foreach (Drug lek in app.DrugDecorator.GetAll())
                    {
                        if (drug == lek.Name)
                        {
                            lekoviListBox.Add(lek);
                        }
                    }
                }

                terapija = new Therapy(terapija2.Text, period, lekoviListBox);
                prescription = new Prescription(period,lekoviListBox);


                app.PrescriptionDecorator.Save(prescription);
                app.TherapyDecorator.Save(terapija);
                string messageBoxText = "Uspesno!";
                string caption = "Recept";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                this.Close();

            }
            else if(StartDate.SelectedDate > EndDate.SelectedDate || StartDate.SelectedDate < DateTime.Now){
                string messageBoxText = "Datumi mogu biti iskljucivo u buducnosti, pocetni datum ne moze biti pre krajnjeg.";
                string caption = "Recept";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else{
                string messageBoxText = "Morate izabrati neki lek kako biste pacijentu izdali recept";
                string caption = "Recept";
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
            scrol.Height = this.ActualHeight - 150;
        }
    }
}
