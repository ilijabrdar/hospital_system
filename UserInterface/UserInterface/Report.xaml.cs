using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Model.Director;
using Model.Doctor;
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
            SecretaryReportDTO data = app.ReportController.GenerateDoctorOccupationReport(SelectedDoctor, new Period(FromFullDate, ToFullDate));

            String html = "<html><head><style>table {border-collapse: collapse; width: 100%;} table, th, td {border: 1px solid black;}</style></head><body><h1 style=\"text - align:center\">IZVEŠTAJ O ZAUZETOSTI LEKARA</h1>" +
                "<p><br><br>Lekar:\t" + SelectedDoctor.FullName + "<br>Od:\t" + FromFullDate + "<br>Do:\t" + ToFullDate + "<br><br></p><h2>Pregledi:</h2>" +
                "<table><tr style=\"text-align: center;\"><th>Datum</th><th>Vreme</th><th>Pacijent</th></tr>";
            foreach (Examination examination in data.Examinations)
            {
                Room room = null;
                foreach (BusinessDay businessDay in examination.Doctor.BusinessDay)
                    if (businessDay.Shift.StartDate.Date == examination.Period.StartDate.Date)
                    {
                        room = businessDay.room;
                        break;
                    }
                html += "<tr><td>" + examination.Period.StartDate.Date.ToString("dd/MM/yyyy") + "</td><td>" + examination.Period.StartDate.TimeOfDay + "</td><td>" + examination.User.FullName + "</td></tr>";
            }
            html += "</table><h2>Operacije:</h2>";
            html += "<table><tr style=\"text-align: center;\"><th>Datum</th><th>Vreme</th><th>Pacijent</th></tr>";
            foreach(Operation operation in data.Operations)
            {
                html += "<tr><td>" + operation.Period.StartDate.Date.ToString("dd/MM/yyyy") + "</td><td>" + operation.Period.StartDate.TimeOfDay + "</td><td>" + operation.Patient.FullName + "</td></tr>";
            }
            html += "</table></body></html>";
            try
            {
                Byte[] res = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    var PDF = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                    PDF.Save(ms);
                    res = ms.ToArray();
                }
                File.WriteAllBytes("C:\\Users\\Asus\\Desktop\\SIMS\\hospital_system\\code\\Resources\\Reports\\Report.pdf", res);
                this.Close();

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                Uri pdf = new Uri("C:\\Users\\Asus\\Desktop\\SIMS\\hospital_system\\code\\Resources\\Reports\\Report.pdf");
                process.StartInfo.FileName = new Uri("C:\\Users\\Asus\\Desktop\\SIMS\\hospital_system\\code\\Resources\\Reports\\Report.pdf").ToString();
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
