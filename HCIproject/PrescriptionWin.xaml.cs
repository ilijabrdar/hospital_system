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

        public string TerapijaBinding { get; set; }
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
            Patient patient = app.PatientController.Get(patientId);
            String imePrez = patient.FirstName + " " + patient.LastName;
            imePacijenta.Content = imePrez;

            int godine=DateTime.Now.Year - patient.DateOfBirth.Year;
            godinePacijenta.Content = godine.ToString();

            //alergijePacijenta.Content = patient.patientFile.Allergy.ToString();

        }

        private void setDrugCombo()
        {
            var app = Application.Current as App;
            foreach(var lek in app.DrugController.GetAll())
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
                    foreach (Drug lek in app.DrugController.GetAll())
                    {
                        if (drug == lek.Name)
                        {
                            lekoviListBox.Add(lek);
                        }
                    }
                }
                if (TerapijaBinding != null)
                {
                    terapija.Note = TerapijaBinding;
                }
                terapija = new Therapy(TerapijaBinding, period, lekoviListBox);
                prescription = new Prescription(period,lekoviListBox);

                string messageBoxText = "Uspesno!";
                string caption = "Recept";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                this.Close();

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
