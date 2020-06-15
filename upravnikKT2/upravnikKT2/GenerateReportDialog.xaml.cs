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

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for GenerateReportDialog.xaml
    /// </summary>
    public partial class GenerateReportDialog : Window
    {
        private readonly IRoomController roomController;
        private readonly IRenovationController renovationController;
        public GenerateReportDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            roomController = app.RoomController;
            renovationController = app.RenovationController;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Izvestaj"; // Default file name
            //dlg.DefaultExt = ".txt"; // Default file extension
            //dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            dlg.Title = "Select PDFFile";
            dlg.Filter = "PDF(*.pdf)|*.pdf";

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            Room room = (Room)comboRooms.SelectedItem;
            DateTime beginDate =(DateTime) startDatePicker.SelectedDate;
            DateTime endDate = (DateTime) endDatePicker.SelectedDate;

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

                foreach (KeyValuePair<Equipment,int> pair in room.Equipment_inventory)
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
                

                foreach (Renovation renovation in renovationController.GetAll())
                {
                    if (renovation.Room.RoomCode.Equals(room.RoomCode) && DateTime.Compare(renovation.Period.StartDate, beginDate)>=0 && DateTime.Compare(renovation.Period.EndDate,endDate)<=0)
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

            //Document doc = new Document(iTextSharp.text.PageSize.A4, 20f, 20f, 30f, 30f);
            //PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("TestFINAL.pdf", FileMode.Create));
            //doc.Open();

            //iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph("This is my first line using Paragraph");
            //doc.Add(paragraph);
            //doc.Close();

            this.Close();


            //iTextSharp.text.Document doc = null;

            //doc = new Document();
            //iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc,
            //    new System.IO.FileStream(System.IO.Directory.GetCurrentDirectory() + "\\ScienceReport.pdf",
            //        System.IO.FileMode.Create));

            //// Set margins and page size for the document
            //doc.SetMargins(50, 50, 50, 50);
            //// There are a huge number of possible page sizes, including such sizes as
            //// EXECUTIVE, LEGAL, LETTER_LANDSCAPE, and NOTE
            //doc.SetPageSize(new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.LETTER.Width,
            //    iTextSharp.text.PageSize.LETTER.Height));

            //// Add metadata to the document.  This information is visible when viewing the
            //// document properities within Adobe Reader.
            //doc.AddTitle("My Science Report");
            //doc.AddCreator("M. Lichtenberg");
            //doc.AddKeywords("paper airplanes");

            //// Add Xmp metadata to the document.


            //// Open the document for writing content
            //doc.Open();

            //// Add pages to the document


            //// Add page labels to the document
            //iTextSharp.text.pdf.PdfPageLabels pdfPageLabels = new iTextSharp.text.pdf.PdfPageLabels();
            //pdfPageLabels.AddPageLabel(1, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Basic Formatting");
            //pdfPageLabels.AddPageLabel(2, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Internal Links");
            //pdfPageLabels.AddPageLabel(3, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Bullet List");
            //pdfPageLabels.AddPageLabel(4, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "External Links");
            //pdfPageLabels.AddPageLabel(5, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Image");
            //writer.PageLabels = pdfPageLabels;

            //doc.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //ObservableCollection<RoomMockup> DataGridRooms = new ObservableCollection<RoomMockup>();
            //DataGridRooms.Add(new RoomMockup { Sifra = "1243"});
            //DataGridRooms.Add(new RoomMockup { Sifra = "6475"});
            //DataGridRooms.Add(new RoomMockup { Sifra = "9876"});
            //DataGridRooms.Add(new RoomMockup { Sifra = "8674"});
            //DataGridRooms.Add(new RoomMockup { Sifra = "5532"});
            //DataGridRooms.Add(new RoomMockup { Sifra = "7684" });
            //this.DataGridProstorije.ItemsSource = DataGridRooms;

            comboRooms.ItemsSource = roomController.GetAll().ToList();
            comboRooms.DisplayMemberPath = "RoomCode";
            comboRooms.SelectedValuePath = "Id";
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
