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
using bolnica.Controller;
using Model.Director;
using Model.Users;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for AppointmentFilter.xaml
    /// </summary>
    public partial class AppointmentFilter : Window
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

        public List<Patient> Patients { get; set; }
        public List<Room> Rooms { get; set; }

        public AppointmentFilter(List<Patient> patients)
        {
            InitializeComponent();
            this.DataContext = this;
            FromDay = ToDay = DateTime.Now.Day;
            FromMonth = ToMonth = DateTime.Now.Month;
            FromYear = ToYear = DateTime.Now.Year;
            FromHour = ToHour = DateTime.Now.Hour;
            FromMinute = ToMinute = DateTime.Now.Minute;
            Patients = patients;
            PopulateRoomCombo();
        }

        private void PopulateRoomCombo()
        {
            App app = Application.Current as App;
            IRoomController roomController = app.RoomController;
            Rooms = roomController.GetAll().ToList();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
