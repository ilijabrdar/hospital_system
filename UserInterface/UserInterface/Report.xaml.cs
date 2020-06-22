using System;
using System.Collections.Generic;
using System.IO;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public static int FromDay { get; set; }
        public static int ToDay { get; set; }
        public static int FromMonth { get; set; }
        public static int ToMonth { get; set; }
        public static int FromYear { get; set; }
        public static int ToYear { get; set; }
        public static int FromHour { get; set; }
        public static int ToHour { get; set; }
        public static int FromMinute { get; set; }
        public static int ToMinute { get; set; }

        private DateTime FromFullDate { get; set; }
        private DateTime ToFullDate { get; set; }

        public List<Doctor> Doctors { get; set; }
        public Doctor SelectedDoctor { get; set; }

        private List<Examination> reportList;

        public Report()
        {
            InitializeComponent();
            this.DataContext = this;
            FromDay = ToDay = DateTime.Now.Day;
            FromMonth = ToMonth = DateTime.Now.Month;
            FromYear = ToYear = DateTime.Now.Year;
            FromHour = ToHour = DateTime.Now.Hour;
            FromMinute = ToMinute = DateTime.Now.Minute;

            App app = Application.Current as App;
            Doctors = app.DoctorController.GetAll().ToList();
            SelectedDoctor = Doctors[0];
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectAllOnFocus(object sender, RoutedEventArgs e)
        {
            TextBox textField = sender as TextBox;
            textField.SelectAll();
        }

        private void ReportToPDF(object sender, RoutedEventArgs e)
        {
            FromFullDate = new DateTime(FromYear, FromMonth, FromDay, FromHour, FromMinute, 0);
            ToFullDate = new DateTime(ToYear, ToMonth, ToDay, ToHour, ToMinute, 0);

            App app = Application.Current as App;
            ExaminationDTO examinationFilter = new ExaminationDTO(SelectedDoctor, null, new Period(new DateTime(FromYear, FromMonth, FromDay, FromHour, FromMinute, 0), new DateTime(ToYear, ToMonth, ToDay, ToHour, ToMinute, 0)), null);
            List<Examination> examinations = app.ExaminationController.GetExaminationsByFilter(examinationFilter, false);

            String html = "<html><head><style>table {border-collapse: collapse; width: 100%;} table, th, td {border: 1px solid black;}</style></head><body><h1 style=\"text - align:center\">IZVEŠTAJ O ZAUZETOSTI LEKARA</h1>" +
                "<p><br><br>Lekar:  Pera Perić<br>Od:  18/6/2020 00:00:00<br>Do:  19/6/2020 17:00:00<br><br></p>" +
                "<table><tr style=\"text-align: center;\"><th>Datum</th><th>Vreme</th><th>Pacijent</th><th>Sala</th></tr>" +
                "<tr><td>18/6/2020</td><td>1:45:00</td><td>Petar Petrovic</td><td>S12</td></tr>" +
                "<tr><td>18/6/2020</td><td>17:40:00</td><td>Marko Petrovic</td><td>S12</td></tr>" +
                "<tr><td>19/6/2020</td><td>2:45:00</td><td>Dusan Markovic</td><td>S12</td></tr>" +
                "</table>" +
                "<p>Ukupna zauzetost: 30% radnog vremena</p>" +
                "</body></html>";
            try
            {
                Byte[] res = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    var PDF = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                    PDF.Save(ms);
                    res = ms.ToArray();
                }
                File.WriteAllBytes("C:/Users/Asus/Desktop/hospital_system/UserInterface/UserInterface/Resources/Report1.pdf", res);
                this.Close();

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                Uri pdf = new Uri("C:/Users/Asus/Desktop/hospital_system/UserInterface/UserInterface/Resources/Report.pdf");
                process.StartInfo.FileName = new Uri("C:/Users/Asus/Desktop/hospital_system/UserInterface/UserInterface/Resources/Report1.pdf").ToString();
                process.Start();
                process.WaitForExit();

            }
            catch
            {
                MessageBox.Show("Greška pri generisanju izveštaja.", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
