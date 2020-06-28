using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public partial class ExaminationWin : Window
    {
        public Doctor user;
        public long patientId;
        public Examination examination;

        private String dijagnoza;

        public string Simptom{get; set;}
        public string Anamneza { get; set; }

        
        public ExaminationWin(Doctor user, long _patientId, Examination _examination)
        {
            this.user = user;
            this.patientId = _patientId;
            this.examination = _examination;
            

            InitializeComponent();
            //setDiagnosisCombo();
            setSimptomiCombo();
            checkSpeciality();
        }

        private void checkSpeciality()
        {
            if(user.Specialty.Name=="Opsta praksa")
            {
                labelOperacija.Visibility = Visibility.Hidden;
                buttonOperacija.Visibility = Visibility.Hidden;
            }
        }

        private void setDiagnosisCombo()
        {
            var app = Application.Current as App;
            if (simptomiCombo.SelectedItems == null)
            {
                return;
            }

            double[] niz = new double[20];
            List<double> vektor = new List<double>();
            
            foreach(Symptom s in simptomiCombo.SelectedItems)
            {
                niz[s.Id] = 1;
            }
            List<double> verovatnoce = app.Program.PredictDiagnosis(niz.ToList());

            double max1 =-1;
            double max2 =-1;
            foreach(double d in verovatnoce)
            {
                if (d > max1)
                {
                    max2 = max1;
                    max1 = d;
                }else if (d > max2)
                {
                    max2 = d;
                }
            }
            diagnosisCombo.Items.Clear();
            diagnosisCombo.Items.Add(app.DiagnosisDecorator.Get(verovatnoce.IndexOf(max1)));
            diagnosisCombo.Items.Add(app.DiagnosisDecorator.Get(verovatnoce.IndexOf(max2)));
        } 

        private void setSimptomiCombo()
        {
            var app = Application.Current as App;
            foreach(Symptom symptom in app.SympthomDecorator.GetAll())
            {
                simptomiCombo.Items.Add(symptom);
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //potvrdi
            if (diagnosisCombo.SelectedItem == null)
            {           
                string messageBoxText = "Kako biste zavrsili pregled morate popuniti polje za dijagnozu.";
                string caption = "Molimo popunite podatke.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                var app = Application.Current as App;
                //String diagnosisString = diagnosisCombo.SelectedItem.ToString();
                //Diagnosis diagnosis = new Diagnosis();
                //foreach (Diagnosis d in app.DiagnosisDecorator.GetAll())
                //{
                //    if (diagnosisString == d.Name)
                //    {
                //        diagnosis = d;
                //    }
                //}
                Diagnosis diagnosis =(Diagnosis)diagnosisCombo.SelectedItem;
                Patient patient = new Patient();
                patient = app.PatientDecorator.Get(patientId);
                User userPatient = patient as User;

                Anemnesis ane;
                if (anamnezaTxt.Text != " ") {
                    ane = new Anemnesis(anamnezaTxt.Text);
                }
                else
                {
                    ane = null; 
                }

                Therapy terapija;
                if (PrescriptionWin.terapija != null)
                {
                    terapija = PrescriptionWin.terapija;
                }
                else
                {
                    terapija = null; 
                }

                Referral referral;
                if (RefferalWin.referral != null)
                {
                    referral = RefferalWin.referral;
                }
                else
                {
                    referral = null;
                }
                Prescription prescription;
                if (PrescriptionWin.prescription != null)
                {
                    prescription = PrescriptionWin.prescription;
                }
                else
                {
                    prescription = null;
                }
                Examination saveExamination = new Examination(userPatient, user, examination.Period, diagnosis, ane,terapija,referral, prescription);
            //    app.ExaminationDecorator.SaveFinishedExamination(saveExamination);

                app.ExaminationDecorator.Delete(examination);
                BusinessDay selectedDay = app.BusinessDayDecorator.GetExactDay(saveExamination.Doctor, saveExamination.Period.StartDate);
                List<DateTime> pom = new List<DateTime>();
                pom.Add(examination.Period.StartDate);
                app.BusinessDayDecorator.FreePeriod(selectedDay, pom);

                app.PatientFileDecorator.AddExamination(saveExamination, patient.patientFile);
                
                

                string messageBoxText = "Pregled uspesno zavrsen";
                string caption = "Pregled gotov";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                SideBar sideBarWin = new SideBar((Doctor)user);
                this.Visibility = Visibility.Hidden;
                sideBarWin.MyTabControl.SelectedIndex = 2;
                sideBarWin.Show();
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        { //recept

            if (diagnosisCombo.SelectedItem == null)
            {
                string messageBoxText = "Kako biste nastavili izvrsavanje pregleda morate popuniti polje za dijagnozu.";
                string caption = "Molimo popunite podatke.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                Diagnosis diagnosis = (Diagnosis)diagnosisCombo.SelectedItem;
                dijagnoza = diagnosis.Name;
                PrescriptionWin presWin = new PrescriptionWin((Doctor)user, patientId,dijagnoza);
                //this.Visibility = Visibility.Hidden;
                presWin.ShowDialog();
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//uput
            if (diagnosisCombo.SelectedItem == null)
            {
                string messageBoxText = "Kako biste nastavili izvrsavanje pregleda morate popuniti polje za dijagnozu.";
                string caption = "Molimo popunite podatke.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                Diagnosis diagnosis = (Diagnosis)diagnosisCombo.SelectedItem;
                dijagnoza = diagnosis.Name;
                RefferalWin refWin = new RefferalWin((Doctor)user, patientId, dijagnoza);

                refWin.ShowDialog();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        { //hospitalizacija

            if (diagnosisCombo.SelectedItem == null)
            {
                string messageBoxText = "Kako biste nastavili izvrsavanje pregleda morate popuniti polje za dijagnozu.";
                string caption = "Molimo popunite podatke.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                Diagnosis diagnosis = (Diagnosis)diagnosisCombo.SelectedItem;
                dijagnoza = diagnosis.Name;
                HospitalizationWin hosWin = new HospitalizationWin((Doctor)user, patientId, dijagnoza);
                // this.Visibility = Visibility.Hidden;
                hosWin.ShowDialog();

            }

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {//kontrola
            ScheduleExamination exaWin = new ScheduleExamination((Doctor)user, patientId);
          //  this.Visibility = Visibility.Hidden;
            exaWin.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (diagnosisCombo.SelectedItem == null)
            {
                string messageBoxText = "Kako biste nastavili izvrsavanje pregleda morate popuniti polje za dijagnozu.";
                string caption = "Molimo popunite podatke.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                Diagnosis diagnosis = (Diagnosis)diagnosisCombo.SelectedItem;
                dijagnoza = diagnosis.Name;
                OperationWin opeWin = new OperationWin((Doctor)user, patientId, dijagnoza);
                opeWin.ShowDialog();

            }

        }

        private void examScrool_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            examScrool.Height = this.ActualHeight - 150;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            PatientFileWin patientWin = new PatientFileWin((Doctor)user, patientId);
            // this.Visibility = Visibility.Hidden;
            patientWin.ShowDialog();
        }

        private void diagnosisCombo_GotFocus(object sender, RoutedEventArgs e)
        {
            setDiagnosisCombo();
        }
    }
}
