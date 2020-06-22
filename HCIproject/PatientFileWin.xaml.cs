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
        }

        public PatientFileWin()
        {
            InitializeComponent();
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

                doctor.FontSize = 15;
                doctor.Inlines.Add(new Run("Doktor:  ") { FontWeight = FontWeights.Bold });
                doctor.Inlines.Add(examination.Doctor.FullName);
                doctor.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(doctor);
                //
                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.Bold });
                period.FontSize = 15;
                period.Inlines.Add(examination.Period.StartDate.ToString());
                period.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(period);

                //
                Anamnesis.FontSize = 15;
                Anamnesis.Inlines.Add(new Run("Anamnesis:  ") { FontWeight = FontWeights.Bold });
                Anamnesis.TextWrapping = TextWrapping.Wrap;
                Anamnesis.Margin = new Thickness(10, 10, 10, 10);
                Anamnesis.Inlines.Add(examination.Anemnesis.Text);
                stackPanelExamination.Children.Add(Anamnesis);

                //
                Diagnosis.FontSize = 15;
                Diagnosis.TextWrapping = TextWrapping.Wrap;
                Diagnosis.Inlines.Add(new Run("Diagnoza:  ") { FontWeight = FontWeights.Bold });
                Diagnosis.Margin = new Thickness(10, 10, 10, 10);
                Diagnosis.Inlines.Add(examination.Diagnosis.Name);
                stackPanelExamination.Children.Add(Diagnosis);

                //

                prescription.FontSize = 15;
                prescription.TextWrapping = TextWrapping.Wrap;
                prescription.Margin = new Thickness(10, 10, 10, 10);
                prescription.Inlines.Add(new Run("Recept: ") { FontWeight = FontWeights.Bold });
                foreach (Prescription pr in examination.Prescription)
                {
                    foreach (Drug dr in pr.Drug)
                        prescription.Inlines.Add(dr.Name);
                }
                stackPanelExamination.Children.Add(prescription);

                therapy.FontSize = 15;
                therapy.TextWrapping = TextWrapping.Wrap;
                therapy.Margin = new Thickness(10, 10, 10, 10);
                therapy.Inlines.Add(new Run("Terapija:  ") { FontWeight = FontWeights.Bold });
                therapy.Inlines.Add(examination.Therapy.Note);
                stackPanelExamination.Children.Add(therapy);
                if (examination.Refferal != null)
                {
                    refferal.FontSize = 15;
                    refferal.Margin = new Thickness(10, 10, 10, 10);
                    refferal.Inlines.Add(new Run("Uput:  ") { FontWeight = FontWeights.Bold });
                    refferal.Inlines.Add("pacijent se upućuje na dateljniji pregled kod lekara " + examination.Refferal.Doctor.FullName + " datuma " + examination.Refferal.Period.StartDate.ToString());
                    stackPanelExamination.Children.Add(refferal);
                }

                b.Child = stackPanelExamination;

                Exeminations.Children.Add(b);
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
            try
            { 
                Process process = new System.Diagnostics.Process();
                String file = "C:\\Users\\Tamara Kovacevic\\Desktop\\IZVESTAJ.pdf";
                process.StartInfo.FileName = file;
                process.Start();
                process.WaitForExit();
            }
            catch
            {
                System.Windows.MessageBox.Show("Could not open the file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
