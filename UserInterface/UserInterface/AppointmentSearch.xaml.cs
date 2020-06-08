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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for AppointmentSearch.xaml
    /// </summary>
    public partial class AppointmentSearch : Window
    {
        public int Day { get; set; }
        public static int Month { get; set; }
        public static int Year { get; set; }
        public int Hour  { get; set; }
        public int Minute { get; set; }

        public AppointmentSearch()
        {
            InitializeComponent();
            this.DataContext = this;
            Day = DateTime.Now.Day;
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
        }

        private void CencelDialog(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
