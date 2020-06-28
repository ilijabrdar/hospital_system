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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model.Director;
using Paragraph = iTextSharp.text.Paragraph;
using bolnica.Model.Dto;

namespace HCIproject
{   
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
            setAllergy();
        }


        private void setPatientInfo()
        {
            var app = Application.Current as App;
            Patient patient = app.PatientDecorator.Get(id);
            String imePrez = patient.FirstName + " " + patient.LastName;
            imePacijenta.Content = imePrez;

            int godine = DateTime.Now.Year - patient.DateOfBirth.Year;
            godinePacijenta.Content = godine.ToString();

          
        }

        private void setAllergy()
        {
            var app = Application.Current as App;
            alergijePacijenta.Content = "";
            Patient patient = app.PatientDecorator.Get(id);

            foreach (Allergy allergy in patient.patientFile.Allergy)
            {
                alergijePacijenta.Content += allergy.Name;
            }
        }
        private void setExaminations()
        {
            var app = Application.Current as App;
            List<Examination> examinations = new List<Examination>();

            Patient _patient = app.PatientDecorator.Get(id);
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
                b.Margin = new Thickness(5,5,5,5);

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
                myButton.Width = 80;
                myButton.Height = 20;
                myButton.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                myButton.Tag = examination;
                myButton.FontSize = 9;
                myButton.HorizontalAlignment = HorizontalAlignment.Right;
                myButton.Click += new RoutedEventHandler(izvestajPdf);
                stackPanelExamination.Children.Add(myButton);

                doctor.FontSize = 12;
                doctor.Inlines.Add(new Run("Doktor:  ") { FontWeight = FontWeights.SemiBold });
                doctor.Inlines.Add(examination.Doctor.FullName);
                doctor.Margin = new Thickness(5, 5, 5, 5);
                stackPanelExamination.Children.Add(doctor);
                //
                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.SemiBold });
                period.FontSize = 12;
                period.Inlines.Add(examination.Period.StartDate.ToString());
                period.Margin = new Thickness(5, 5, 5, 5);
                stackPanelExamination.Children.Add(period);

                Anamnesis.FontSize = 12;
                Anamnesis.Inlines.Add(new Run("Anamneza:  ") { FontWeight = FontWeights.SemiBold });
                Anamnesis.TextWrapping = TextWrapping.Wrap;
                Anamnesis.Margin = new Thickness(5, 5, 5, 5);
                if (examination.Anemnesis !=null)        
                Anamnesis.Inlines.Add(examination.Anemnesis.Text);

                stackPanelExamination.Children.Add(Anamnesis);

                //
                Diagnosis.FontSize = 12;
                Diagnosis.TextWrapping = TextWrapping.Wrap;
                Diagnosis.Inlines.Add(new Run("Diagnoza:  ") { FontWeight = FontWeights.SemiBold });
                Diagnosis.Margin = new Thickness(5, 5, 5, 5);
                Diagnosis.Inlines.Add(examination.Diagnosis.Name);
                stackPanelExamination.Children.Add(Diagnosis);

                //

                prescription.FontSize = 12;
                prescription.TextWrapping = TextWrapping.Wrap;
                prescription.Margin = new Thickness(5, 5, 5, 5);
                prescription.Inlines.Add(new Run("Recept: ") { FontWeight = FontWeights.SemiBold });
                if (examination.Prescription != null) { 
                    foreach (Drug dr in examination.Prescription.Drug)
                    {
                            prescription.Inlines.Add(dr.Name);

                    }
                    stackPanelExamination.Children.Add(prescription);

                }
                therapy.FontSize = 12;
                therapy.TextWrapping = TextWrapping.Wrap;
                therapy.Margin = new Thickness(5, 5, 5, 5);
                therapy.Inlines.Add(new Run("Terapija:  ") { FontWeight = FontWeights.SemiBold });
                if (examination.Therapy != null)
                {
                    therapy.Inlines.Add(examination.Therapy.Note);
                    stackPanelExamination.Children.Add(therapy);

                }


                if (examination.Refferal != null)
                {
                    refferal.FontSize = 12;
                    refferal.Margin = new Thickness(5, 5, 5, 5);
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
            Patient _patient = app.PatientDecorator.Get(id);
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
                b.Margin = new Thickness(5, 5, 5, 5);

                StackPanel stackPanelExamination = new StackPanel();
                TextBlock period = new TextBlock();
                TextBlock room = new TextBlock();
                TextBlock hospitalizacija = new TextBlock();

                hospitalizacija.FontSize = 12;
                hospitalizacija.Inlines.Add(new Run("HOSPITALIZACIJA") { FontWeight = FontWeights.Bold });
                hospitalizacija.Margin = new Thickness(5, 5, 5, 5);
                stackPanelExamination.Children.Add(hospitalizacija);

                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.SemiBold });
                period.FontSize = 12;
                period.Inlines.Add(hospitalization.Period.StartDate.ToString());
                period.Margin = new Thickness(5, 5, 5, 5);
                stackPanelExamination.Children.Add(period);

                room.Inlines.Add(new Run("Prostorija: ") { FontWeight = FontWeights.SemiBold });
                room.FontSize = 12;
                room.Inlines.Add(hospitalization.Room.RoomCode);
                room.Margin = new Thickness(5);
                stackPanelExamination.Children.Add(room);

                b.Child = stackPanelExamination;

                Examinations.Children.Add(b);
            }
        }


        private void setOperation()
        {
            var app = Application.Current as App;
            List<Operation> operations = new List<Operation>();
            Patient _patient = app.PatientDecorator.Get(id);
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
                b.Margin = new Thickness(5, 5, 5, 5);

                StackPanel stackPanelExamination = new StackPanel();
                TextBlock operacija = new TextBlock();
                TextBlock doctor = new TextBlock();
                TextBlock period = new TextBlock();
                TextBlock room = new TextBlock();
                TextBlock description = new TextBlock();

                operacija.FontSize = 12;
                operacija.Inlines.Add(new Run("OPERACIJA") { FontWeight = FontWeights.Bold });
                operacija.Margin = new Thickness(5, 5, 5, 5);
                stackPanelExamination.Children.Add(operacija);

                doctor.FontSize = 12;
                doctor.Inlines.Add(new Run("Doktor:  ") { FontWeight = FontWeights.SemiBold });
                doctor.Inlines.Add(operation.Doctor.FullName);
                doctor.Margin = new Thickness(5, 5, 5, 5);
                stackPanelExamination.Children.Add(doctor);
                //
                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.SemiBold });
                period.FontSize = 12;
                period.Inlines.Add(operation.Period.StartDate.ToString());
                period.Margin = new Thickness(5, 5, 5, 5);
                stackPanelExamination.Children.Add(period);


                room.Inlines.Add(new Run("Prostorija: ") { FontWeight = FontWeights.SemiBold });
                room.FontSize = 12;
                room.Inlines.Add(operation.Room.RoomCode);
                room.Margin = new Thickness(5);
                stackPanelExamination.Children.Add(room);

                description.Inlines.Add(new Run("Opis: ") { FontWeight = FontWeights.SemiBold });
                description.FontSize = 12;
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
            patientFileScrool.Height = this.ActualHeight - 150;
        }




        private void izvestajPdf(object sender, RoutedEventArgs e)
        {
            
            Examination examination =(Examination) ((Button)sender).Tag;
            var app = Application.Current as App;
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Izvestaj"; // Default file name

            dlg.Title = "Select PDFFile";
            dlg.Filter = "PDF(*.pdf)|*.pdf";
            String path = "";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                path = System.IO.Path.GetFullPath(dlg.FileName);
                string filename = dlg.FileName;

                Document doc = new Document(iTextSharp.text.PageSize.A4, 20f, 20f, 30f, 30f);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
                doc.Open();
                doc.SetMargins(50, 50, 50, 50);

                Paragraph header = new Paragraph("Izveštaj anamneza recept");

                header.Alignment = 1;
                header.Font.Size = 18;
                header.Font.SetStyle(1);
                doc.Add(header);
                doc.Add(new Chunk("\n"));
                doc.Add(new Chunk("\n"));
                doc.Add(new Chunk("\n"));

                Paragraph basicInfo = new Paragraph();
                Chunk basicInfoheader = new Chunk("OSNOVNE INFORMACIJE O PACIJENTU");
                basicInfoheader.Font.Size = 14;
                basicInfoheader.Font.SetStyle(1);
                basicInfo.Add(basicInfoheader);
                basicInfo.Add(new Chunk("\n"));
                basicInfo.Add("Ime i prezime pacijenta: " + app.PatientDecorator.Get(id).FullName);
                basicInfo.Add(new Chunk("\n"));
                basicInfo.Add("Datum rodjenja: " + app.PatientDecorator.Get(id).DateOfBirth);
                basicInfo.Add(new Chunk("\n"));
           
                DoctorReportDTO doctorDTO = app.ReportDecorator.GenerateAnamnesisPrescriptionReport(examination);

                Paragraph anamnesis = new Paragraph();
                anamnesis.Add(new Chunk("\n"));
                anamnesis.Add(new Chunk("\n"));
                Chunk anamnesisHeader = new Chunk("Anamneza:");
                anamnesisHeader.Font.Size = 14;
                anamnesisHeader.Font.SetStyle(1);
                anamnesis.Add(anamnesisHeader);
                anamnesis.Add(new Chunk("\n"));
                StringBuilder sb = new StringBuilder();
                if (doctorDTO.Anemnesis.Text != "")
                {
                    anamnesis.Add(doctorDTO.Anemnesis.Text);
                    anamnesis.Add(new Chunk("\n"));
                }
                else
                {
                    anamnesis.Add("Nije uneta ni jedna anamneza!");
                    anamnesis.Add(new Chunk("\n"));
                }


                Paragraph prescription = new Paragraph();
                prescription.Add(new Chunk("\n"));
                prescription.Add(new Chunk("\n"));
                Chunk prescriptionHeader = new Chunk("Recept:");
                prescriptionHeader.Font.Size = 14;
                prescriptionHeader.Font.SetStyle(1);
                prescription.Add(prescriptionHeader);
                prescription.Add(new Chunk("\n"));

                if (doctorDTO.Prescription!=null)
                {
                    prescription.Add("Vreme koriscenja terapije"+" od "+ doctorDTO.Prescription.Period.StartDate+" do "+doctorDTO.Prescription.Period.EndDate);
                    prescription.Add(new Chunk("\n"));
                    prescription.Add("Prepisani lekovi: ");
                    foreach (Drug drug in doctorDTO.Prescription.Drug)
                    {
                            sb.Append(drug.Name);
                            sb.Append(", ");                   
                    }
                    prescription.Add(sb.ToString());
                    prescription.Add(new Chunk("\n"));
                }
                else
                {
                    prescription.Add("Nije uneta ni jedan recept!");
                    prescription.Add(new Chunk("\n"));
                }

                doc.Add(basicInfo);
                doc.Add(anamnesis);
                doc.Add(prescription);
                doc.Close();

                string messageBoxText = "Uspesno kreiran izvestaj!";
                string caption = "Informacija";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;

                System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);

            }
            else
            {
                return;
            }


            try
            {
                Process process = new System.Diagnostics.Process();
                String file;

                file = path;

                process.StartInfo.FileName = file;
                process.Start();
                process.WaitForExit();
            }
            catch
            {
                System.Windows.MessageBox.Show("Could not open the file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//dodaj alergiju

            var app = Application.Current as App;
            Patient patient = app.PatientDecorator.Get(id);

            AllergyWin allergyWin = new AllergyWin((Doctor)user, patient);

            allergyWin.ShowDialog();
            setAllergy();
        }
    }
}
