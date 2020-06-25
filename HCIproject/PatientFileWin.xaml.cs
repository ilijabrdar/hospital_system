using Model.Doctor;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for PatientFile.xaml
    /// </summary>
   
    public partial class PatientFileWin : Window
    {
        public Doctor user;
        public long id;


        public PatientFileWin(Doctor _user, long _patientId)
        {
            this.user = _user;
            this.id = _patientId;
            InitializeComponent();
            setExaminations();
            setHospitalizations();
            setOperation();
            setPatientInfo();
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
        private void setExaminations()
        {
            var app = Application.Current as App;
            List<Examination> examinations = new List<Examination>();

            Patient _patient = app.PatientController.Get(id);
            examinations = _patient.patientFile.Examination;
            if (examinations == null)
            {
                return;
            }
            foreach (var examination in examinations)
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.LightBlue;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelExamination = new StackPanel();
                TextBlock doctor = new TextBlock();
                TextBlock period = new TextBlock();
                TextBlock prescription = new TextBlock();
                TextBlock refferal = new TextBlock();
                TextBlock Anamnesis = new TextBlock();
                TextBlock Diagnosis = new TextBlock();
                TextBlock therapy = new TextBlock();
                TextBlock Simptomi = new TextBlock();
                Button myButton = new Button();

                myButton.Content = "Izvestaj";
                myButton.Width = 100;
                myButton.Height = 30;
                myButton.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                myButton.Click += new RoutedEventHandler(izvestajPdf);
                stackPanelExamination.Children.Add(myButton);

                doctor.FontSize = 15;
                doctor.Inlines.Add(new Run("Doktor:  ") { FontWeight = FontWeights.SemiBold });
                doctor.Inlines.Add(examination.Doctor.FullName);
                doctor.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(doctor);
                //
                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.SemiBold });
                period.FontSize = 15;
                period.Inlines.Add(examination.Period.StartDate.ToString());
                period.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(period);

                Simptomi.FontSize = 15;
                Simptomi.Inlines.Add(new Run("Simptomi:  ") { FontWeight = FontWeights.SemiBold });
                Simptomi.TextWrapping = TextWrapping.Wrap;
                Simptomi.Margin = new Thickness(10, 10, 10, 10);
                foreach (var s in examination.Diagnosis.Symptom)
                {
                    Simptomi.Inlines.Add(s.Name);
                }
                stackPanelExamination.Children.Add(Simptomi);

                Anamnesis.FontSize = 15;
                Anamnesis.Inlines.Add(new Run("Anamneza:  ") { FontWeight = FontWeights.SemiBold });
                Anamnesis.TextWrapping = TextWrapping.Wrap;
                Anamnesis.Margin = new Thickness(10, 10, 10, 10);
                Anamnesis.Inlines.Add(examination.Anemnesis.Text);
                stackPanelExamination.Children.Add(Anamnesis);

                //
                Diagnosis.FontSize = 15;
                Diagnosis.TextWrapping = TextWrapping.Wrap;
                Diagnosis.Inlines.Add(new Run("Diagnoza:  ") { FontWeight = FontWeights.SemiBold });
                Diagnosis.Margin = new Thickness(10, 10, 10, 10);
                Diagnosis.Inlines.Add(examination.Diagnosis.Name);
                stackPanelExamination.Children.Add(Diagnosis);

                //

                prescription.FontSize = 15;
                prescription.TextWrapping = TextWrapping.Wrap;
                prescription.Margin = new Thickness(10, 10, 10, 10);
                prescription.Inlines.Add(new Run("Recept: ") { FontWeight = FontWeights.SemiBold });
                foreach (Drug dr in examination.Prescription.Drug)
                {
                        prescription.Inlines.Add(dr.Name);
                }
                stackPanelExamination.Children.Add(prescription);

                therapy.FontSize = 15;
                therapy.TextWrapping = TextWrapping.Wrap;
                therapy.Margin = new Thickness(10, 10, 10, 10);
                therapy.Inlines.Add(new Run("Terapija:  ") { FontWeight = FontWeights.SemiBold });
                therapy.Inlines.Add(examination.Therapy.Note);
                stackPanelExamination.Children.Add(therapy);
                if (examination.Refferal != null)
                {
                    refferal.FontSize = 15;
                    refferal.Margin = new Thickness(10, 10, 10, 10);
                    refferal.Inlines.Add(new Run("Uput:  ") { FontWeight = FontWeights.SemiBold });
                    refferal.Inlines.Add("pacijent se upućuje na dateljniji pregled kod lekara " + examination.Refferal.Doctor.FullName + " datuma " + examination.Refferal.Period.StartDate.ToString());
                    stackPanelExamination.Children.Add(refferal);
                }

                b.Child = stackPanelExamination;

                Examinations.Children.Add(b);
            }
        }
        private void setHospitalizations()
        {
            var app = Application.Current as App;
            List<Hospitalization> hospitalizations = new List<Hospitalization>();
            Patient _patient = app.PatientController.Get(id);
            hospitalizations = _patient.patientFile.Hospitalization;
            if (hospitalizations == null)
            {
                return;
            }
            foreach (var hospitalization in hospitalizations)
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.GreenYellow;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelExamination = new StackPanel();
                TextBlock period = new TextBlock();
                TextBlock room = new TextBlock();
                TextBlock hospitalizacija = new TextBlock();

                hospitalizacija.FontSize = 15;
                hospitalizacija.Inlines.Add(new Run("HOSPITALIZACIJA") { FontWeight = FontWeights.Bold });
                hospitalizacija.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(hospitalizacija);

                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.SemiBold });
                period.FontSize = 15;
                period.Inlines.Add(hospitalization.Period.StartDate.ToString());
                period.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(period);

                //
                room.Inlines.Add(new Run("Prostorija: ") { FontWeight = FontWeights.SemiBold });
                room.FontSize = 15;
                room.Inlines.Add(hospitalization.Room.RoomCode);
                room.Margin = new Thickness(10);
                stackPanelExamination.Children.Add(room);

                b.Child = stackPanelExamination;

                Examinations.Children.Add(b);
            }
        }


        private void setOperation()
        {
            var app = Application.Current as App;
            List<Operation> operations = new List<Operation>();
            Patient _patient = app.PatientController.Get(id);
            operations = _patient.patientFile.Operation;
            if (operations == null)
            {
                return;
            }
            foreach (var operation in operations)
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.Pink;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelExamination = new StackPanel();
                TextBlock operacija = new TextBlock();
                TextBlock doctor = new TextBlock();
                TextBlock period = new TextBlock();
                TextBlock room = new TextBlock();
                TextBlock description = new TextBlock();

                operacija.FontSize = 15;
                operacija.Inlines.Add(new Run("OPERACIJA") { FontWeight = FontWeights.Bold });
                operacija.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(operacija);

                doctor.FontSize = 15;
                doctor.Inlines.Add(new Run("Doktor:  ") { FontWeight = FontWeights.SemiBold });
                doctor.Inlines.Add(operation.Doctor.FullName);
                doctor.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(doctor);
                //
                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.SemiBold });
                period.FontSize = 15;
                period.Inlines.Add(operation.Period.StartDate.ToString());
                period.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(period);

                //
                room.Inlines.Add(new Run("Prostorija: ") { FontWeight = FontWeights.SemiBold });
                room.FontSize = 15;
                room.Inlines.Add(operation.Room.RoomCode);
                room.Margin = new Thickness(10);
                stackPanelExamination.Children.Add(room);

                //
                description.Inlines.Add(new Run("Opis: ") { FontWeight = FontWeights.SemiBold });
                description.FontSize = 15;
                description.Inlines.Add(operation.Description);
                description.Margin = new Thickness(10);
                stackPanelExamination.Children.Add(description);



                b.Child = stackPanelExamination;

                Examinations.Children.Add(b);
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // SideBar sideBarWin = new SideBar((Doctor)user);
            this.Close();
          //  sideBarWin.MyTabControl.SelectedIndex = 3;
          // sideBarWin.Show();
        }
        private void patientFileScrool_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            patientFileScrool.Height = this.ActualHeight - 200;
        }


        private void search_files_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (search_files.Text == "Unesite parametar pretrage")
            {
                search_files.Text = "";
            }
        }

        private void search_files_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (search_files.Text == "")
                {
                    return;
                }
                else
                {
                    searchMyExam(search_files.Text);
                    //   ArticleWin artWind = new ArticleWin(findAexarticles);
                    //    artWind.ShowDialog();
                    search_files.Text = "";
                }
            }
        }

        private void searchMyExam(String input)
        {
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            searchMyExam(" ");
        }

        private void izvestajPdf(object sender, RoutedEventArgs e)
        {
                //Process process = new System.Diagnostics.Process();
                //String file = "C:\\Users\\Tamara Kovacevic\\Desktop\\IZVESTAJ.pdf";
                //process.StartInfo.FileName = file;
                //process.Start();
                //process.WaitForExit();
            }

        }
}
