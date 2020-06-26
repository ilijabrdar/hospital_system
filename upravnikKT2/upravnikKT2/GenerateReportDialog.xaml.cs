using bolnica.Controller;
using Controller;
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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model.Director;
using Paragraph = iTextSharp.text.Paragraph;
using Model.PatientSecretary;
using bolnica.Model.Dto;
using Model.Doctor;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for GenerateReportDialog.xaml
    /// </summary>
    public partial class GenerateReportDialog : Window
    {
        private readonly IRoomController roomController;
        private readonly IRenovationController renovationController;
        private readonly IReportController reportController;
        public GenerateReportDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            roomController = app.authorityRoom;
            renovationController = app.authorityRenovation;
            reportController = app.authorityReport;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createBasicRoomReport(RoomOccupationReportDTO report, Document doc)
        {
            Room room = report.room;

            bool found = false;

            Paragraph basicInfo = new Paragraph();
            Chunk basicInfoheader = new Chunk("OSNOVNE INFORMACIJE");
            basicInfoheader.Font.Size = 14;
            basicInfoheader.Font.SetStyle(1);
            basicInfo.Add(basicInfoheader);
            basicInfo.Add(new Chunk("\n"));
            basicInfo.Add("Sifra prostorije: " + room.RoomCode);
            basicInfo.Add(new Chunk("\n"));
            basicInfo.Add("Tip prostorije: " + room.RoomType.Name);
            basicInfo.Add(new Chunk("\n"));


            Paragraph equipment_inventory = new Paragraph();
            equipment_inventory.Add(new Chunk("\n"));
            equipment_inventory.Add(new Chunk("\n"));
            Chunk equipmentHeader = new Chunk("SPISAK OPREME");
            equipmentHeader.Font.Size = 14;
            equipmentHeader.Font.SetStyle(1);
            equipment_inventory.Add(equipmentHeader);
            equipment_inventory.Add(new Chunk("\n"));

            foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
            {
                equipment_inventory.Add(pair.Key.Name + ": " + pair.Value);
                equipment_inventory.Add(new Chunk("\n"));
                found = true;
            }

            if (!found)
            {
                equipment_inventory.Add("Inventar opreme prostorije je prazan!");
                equipment_inventory.Add(new Chunk("\n"));
            }

            found = false;

            equipment_inventory.Add(new Chunk("\n"));

            Paragraph renovation_paragraph = new Paragraph();
            renovation_paragraph.Add(new Chunk("\n"));
            Chunk renovationHeader = new Chunk("SPISAK RENOVIRANJA");
            renovationHeader.Font.Size = 14;
            renovationHeader.Font.SetStyle(1);
            renovation_paragraph.Add(renovationHeader);
            renovation_paragraph.Add(new Chunk("\n"));


            foreach (Renovation renovation in report.renovations)
            {
                renovation_paragraph.Add("Status : " + renovation.Status.ToString());
                renovation_paragraph.Add(new Chunk("\n"));
                renovation_paragraph.Add("Datum pocetka : " + renovation.Period.StartDate.ToString("dd/MM/yyyy"));
                renovation_paragraph.Add(new Chunk("\n"));
                renovation_paragraph.Add("Datum kraja : " + renovation.Period.EndDate.ToString("dd/MM/yyyy"));
                renovation_paragraph.Add(new Chunk("\n"));
                renovation_paragraph.Add("Opis : " + renovation.Description);
                renovation_paragraph.Add(new Chunk("\n"));
                renovation_paragraph.Add(new Chunk("\n"));
                found = true;

            }

            if (!found)
            {
                renovation_paragraph.Add("Nema renoviranja u navedenom periodu!");
                renovation_paragraph.Add(new Chunk("\n"));
            }


            doc.Add(basicInfo);
            doc.Add(equipment_inventory);
            doc.Add(renovation_paragraph);
            doc.Close();
        }

        private void createHospitalizationRoomReport(RoomOccupationReportDTO report, Document doc)
        {
            Room room = report.room;

            bool found = false;

            Paragraph basicInfo = new Paragraph();
            Chunk basicInfoheader = new Chunk("OSNOVNE INFORMACIJE");
            basicInfoheader.Font.Size = 14;
            basicInfoheader.Font.SetStyle(1);
            basicInfo.Add(basicInfoheader);
            basicInfo.Add(new Chunk("\n"));
            basicInfo.Add("Sifra prostorije: " + room.RoomCode);
            basicInfo.Add(new Chunk("\n"));
            basicInfo.Add("Tip prostorije: " + room.RoomType.Name);
            basicInfo.Add(new Chunk("\n"));
            basicInfo.Add("Max kapacitet: " + room.MaxNumberOfPatientsForHospitalization);
            basicInfo.Add(new Chunk("\n"));
            basicInfo.Add("Trenutni kapacitet: " + room.CurrentNumberOfPatients);
            basicInfo.Add(new Chunk("\n"));


            Paragraph equipment_inventory = new Paragraph();
            equipment_inventory.Add(new Chunk("\n"));
            equipment_inventory.Add(new Chunk("\n"));
            Chunk equipmentHeader = new Chunk("SPISAK OPREME");
            equipmentHeader.Font.Size = 14;
            equipmentHeader.Font.SetStyle(1);
            equipment_inventory.Add(equipmentHeader);
            equipment_inventory.Add(new Chunk("\n"));

            foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
            {
                equipment_inventory.Add(pair.Key.Name + ": " + pair.Value);
                equipment_inventory.Add(new Chunk("\n"));
                found = true;
            }

            if (!found)
            {
                equipment_inventory.Add("Inventar opreme prostorije je prazan!");
                equipment_inventory.Add(new Chunk("\n"));
            }

            found = false;

            equipment_inventory.Add(new Chunk("\n"));

            Paragraph renovation_paragraph = new Paragraph();
            renovation_paragraph.Add(new Chunk("\n"));
            Chunk renovationHeader = new Chunk("SPISAK RENOVIRANJA");
            renovationHeader.Font.Size = 14;
            renovationHeader.Font.SetStyle(1);
            renovation_paragraph.Add(renovationHeader);
            renovation_paragraph.Add(new Chunk("\n"));


            foreach (Renovation renovation in report.renovations)
            {
                renovation_paragraph.Add("Status : " + renovation.Status.ToString());
                renovation_paragraph.Add(new Chunk("\n"));
                renovation_paragraph.Add("Datum pocetka : " + renovation.Period.StartDate.ToString("dd/MM/yyyy"));
                renovation_paragraph.Add(new Chunk("\n"));
                renovation_paragraph.Add("Datum kraja : " + renovation.Period.EndDate.ToString("dd/MM/yyyy"));
                renovation_paragraph.Add(new Chunk("\n"));
                renovation_paragraph.Add("Opis : " + renovation.Description);
                renovation_paragraph.Add(new Chunk("\n"));
                renovation_paragraph.Add(new Chunk("\n"));
                found = true;

            }

            if (!found)
            {
                renovation_paragraph.Add("Nema renoviranja u navedenom periodu!");
                renovation_paragraph.Add(new Chunk("\n"));
            }


            found = false;
            Paragraph examination_paragraph = new Paragraph();
            examination_paragraph.Add(new Chunk("\n"));
            Chunk examinationHeader = new Chunk("ZAKAZANI PREGLEDI");
            examinationHeader.Font.Size = 14;
            examinationHeader.Font.SetStyle(1);
            examination_paragraph.Add(examinationHeader);
            examination_paragraph.Add(new Chunk("\n"));


            foreach (Examination examination in report.examinations)
            {
                examination_paragraph.Add("Datum pregleda: " + examination.Period.StartDate.ToString("dd/MM/yyyy"));
                examination_paragraph.Add(new Chunk("\n"));
                examination_paragraph.Add("Doktor : " + examination.Doctor.FullName);
                examination_paragraph.Add(new Chunk("\n"));
                examination_paragraph.Add("Pacijent : " + examination.User.FullName);
                examination_paragraph.Add(new Chunk("\n"));
                examination_paragraph.Add("Dijagnoza : " + examination.Diagnosis.Name);
                examination_paragraph.Add(new Chunk("\n"));
                examination_paragraph.Add("Anamneza : " + examination.Anemnesis.Text);
                examination_paragraph.Add(new Chunk("\n"));
                examination_paragraph.Add("Terapija : " + examination.Therapy.Note);
                examination_paragraph.Add(new Chunk("\n"));
                examination_paragraph.Add(new Chunk("\n"));


                found = true;

            }

            if (!found)
            {
                examination_paragraph.Add("Nema zakazanih pregleda u navedenom periodu!");
                examination_paragraph.Add(new Chunk("\n"));
            }


            found = false;
            Paragraph hospitalization_paragraph = new Paragraph();
            hospitalization_paragraph.Add(new Chunk("\n"));
            Chunk hospitalizationHeader = new Chunk("HOSPITALIZACIJE");
            hospitalizationHeader.Font.Size = 14;
            hospitalizationHeader.Font.SetStyle(1);
            hospitalization_paragraph.Add(hospitalizationHeader);
            hospitalization_paragraph.Add(new Chunk("\n"));


            foreach (Hospitalization hospitalization in report.hospitalizations)
            {
                hospitalization_paragraph.Add("Datum hospitalizacije: " + hospitalization.Period.StartDate.ToString("dd/MM/yyyy"));
                hospitalization_paragraph.Add(new Chunk("\n"));
                hospitalization_paragraph.Add("Doktor : " + hospitalization.Doctor.FullName);
                hospitalization_paragraph.Add(new Chunk("\n"));
                hospitalization_paragraph.Add("Pacijent : " + hospitalization.Patient.FullName);
                hospitalization_paragraph.Add(new Chunk("\n"));
                hospitalization_paragraph.Add(new Chunk("\n"));


                found = true;
            }

            if (!found)
            {
                hospitalization_paragraph.Add("Nema zakazanih hospitalizacija u navedenom periodu!");
                hospitalization_paragraph.Add(new Chunk("\n"));
            }


            found = false;
            Paragraph operation_paragraph = new Paragraph();
            operation_paragraph.Add(new Chunk("\n"));
            Chunk operationHeader = new Chunk("OPERACIJE");
            operationHeader.Font.Size = 14;
            operationHeader.Font.SetStyle(1);
            operation_paragraph.Add(operationHeader);
            operation_paragraph.Add(new Chunk("\n"));


            foreach (Operation operation in report.operations)
            {
                operation_paragraph.Add("Datum operacije: " + operation.Period.StartDate.ToString("dd/MM/yyyy"));
                operation_paragraph.Add(new Chunk("\n"));
                operation_paragraph.Add("Doktor : " + operation.Doctor.FullName);
                operation_paragraph.Add(new Chunk("\n"));
                operation_paragraph.Add("Pacijent : " + operation.Patient.FullName);
                operation_paragraph.Add(new Chunk("\n"));
                operation_paragraph.Add("Opis : " + operation.Description);
                operation_paragraph.Add(new Chunk("\n"));
                operation_paragraph.Add(new Chunk("\n"));


                found = true;
            }

            if (!found)
            {
                operation_paragraph.Add("Nema zakazanih operacija u navedenom periodu!");
                operation_paragraph.Add(new Chunk("\n"));
            }


            doc.Add(basicInfo);
            doc.Add(equipment_inventory);
            doc.Add(renovation_paragraph);
            doc.Add(examination_paragraph);
            doc.Add(hospitalization_paragraph);
            doc.Add(operation_paragraph);
            doc.Close();
        }



        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            if (DateTime.Compare((DateTime)startDatePicker.SelectedDate, (DateTime)endDatePicker.SelectedDate) > 0)
            {
                string messageBoxText = "Ne moze datum pocetka izvestaja biti posle datuma kraja izvestaja!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Izvestaj"; // Default file name
            //dlg.DefaultExt = ".txt"; // Default file extension
            //dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            dlg.Title = "Select PDFFile";
            dlg.Filter = "PDF(*.pdf)|*.pdf";

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            Room room = (Room)comboRooms.SelectedItem;
            DateTime beginDate = (DateTime)startDatePicker.SelectedDate;
            DateTime endDate = (DateTime)endDatePicker.SelectedDate;

            RoomOccupationReportDTO report = reportController.GenerateRoomOccupationReport(room, new Period(beginDate, endDate));

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;

                //u sastav ulaze prostorija, renoviranja, spisak opreme, pregledi, broj pacijenata
                Document doc = new Document(iTextSharp.text.PageSize.A4, 20f, 20f, 30f, 30f);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
                doc.Open();
                doc.SetMargins(50, 50, 50, 50);

                //iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph("This is my first line using Paragraph");
                //doc.Add(paragraph);

                Paragraph header = new Paragraph("Izveštaj o zauzetosti prostorije " + room.RoomCode);
                Paragraph periodInfo = new Paragraph(beginDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy"));
                periodInfo.Font.Size = 18;
                periodInfo.Font.SetStyle(1);
                periodInfo.Alignment = 1;

                header.Alignment = 1;
                header.Font.Size = 18;
                header.Font.SetStyle(1);
                doc.Add(header);
                doc.Add(periodInfo);
                doc.Add(new Chunk("\n"));
                doc.Add(new Chunk("\n"));
                doc.Add(new Chunk("\n"));

                if (report.room.MaxNumberOfPatientsForHospitalization != 0)
                    createHospitalizationRoomReport(report, doc);
                else
                    createBasicRoomReport(report, doc);


                string messageBoxText = "Uspesno kreiran izvestaj!";
                string caption = "Informacija";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }



            


            this.Close();


            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            comboRooms.ItemsSource = roomController.GetAll().ToList();
            comboRooms.DisplayMemberPath = "RoomCode";
            comboRooms.SelectedValuePath = "Id";

            startDatePicker.DisplayDateStart = new DateTime(DateTime.Now.Year, 1, 1);
            startDatePicker.DisplayDateEnd = DateTime.Now;

            endDatePicker.DisplayDateStart = new DateTime(DateTime.Now.Year, 1, 1);
            endDatePicker.DisplayDateEnd = DateTime.Now;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }

            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (OKBtn.IsEnabled)
                {
                    Button_Click_OK(sender, e);
                    e.Handled = true;
                }
            }
        }
    }
}
