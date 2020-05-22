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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public List<Examination> examinations { get; set; }
        public List<Examination> freeSlots { get; set; }

        private ToolTip _toolTip = new ToolTip();
        private Boolean _isToolTipAvailable = true;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.examinations = new List<Examination>();
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 12, 00, 00), "Pera Peric", "Petar Petrovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 15, 00, 00), "Pera Peric", "Milan Milanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 16, 30, 00), "Marko Markovic", "Ivan Ivanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 2, 17, 15, 00), "Pera Peric", "Luka Lukovic", "S13"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 8, 00, 00), "Nikola Nikolic", "Milan Milanovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 9, 30, 00), "Nikola Nikolic", "Marko Markovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 10, 00, 00), "Ivan Ivanovic", "Luka Lukovic", "S12"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 3, 10, 15, 00), "Pera Peric", "Milan Milanovic", "S14"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 00, 00), "Marko Markovic", "Marko Markovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 15, 00), "Marko Markovic", "Milan Milanovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 30, 00), "Nikola Nikolic", "Marko Markovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 12, 50, 00), "Marko Markovic", "Milan Milanovic", "S16"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 4, 15, 00, 00), "Nikola Nikolic", "Ivan Ivanovic", "S17"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 16, 00, 00), "Marko Markovic", "Milan Milanovic", "S16"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 17, 00, 00), "Nikola Nikolic", "Petar Petrovic", "S30"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 18, 00, 00), "Marko Markovic", "Milan Milanovic", "S55"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 18, 30, 00), "Nikola Nikolic", "Ivan Ivanovic", "S25"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 18, 55, 00), "Marko Markovic", "Petar Petrovic", "S15"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 19, 10, 00), "Nikola Nikolic", "Marko Markovic", "S55"));
            this.examinations.Add(new Examination(new DateTime(2020, 1, 5, 20, 00, 00), "Marko Markovic", "Milan Milanovic", "S15"));

            this.freeSlots = new List<Examination>();
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 2, 12, 00, 00), "Pera Peric", "S12"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 2, 15, 00, 00), "Pera Peric", "S12"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 2, 16, 30, 00), "Marko Markovic", "S12"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 2, 17, 15, 00), "Pera Peric", "S13"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 3, 8, 00, 00), "Nikola Nikolic", "S12"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 3, 9, 30, 00), "Nikola Nikolic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 3, 10, 00, 00), "Ivan Ivanovic", "S12"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 3, 10, 15, 00), "Pera Peric", "S14"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 12, 00, 00), "Marko Markovic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 12, 15, 00), "Marko Markovic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 12, 30, 00), "Nikola Nikolic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 12, 50, 00), "Marko Markovic", "S16"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 4, 15, 00, 00), "Nikola Nikolic", "S17"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 16, 00, 00), "Marko Markovic", "S16"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 17, 00, 00), "Nikola Nikolic", "S30"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 18, 00, 00), "Marko Markovic", "S55"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 18, 30, 00), "Nikola Nikolic", "S25"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 18, 55, 00), "Marko Markovic", "S15"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 19, 10, 00), "Nikola Nikolic", "S55"));
            this.freeSlots.Add(new Examination(new DateTime(2020, 1, 5, 20, 00, 00), "Marko Markovic", "S15"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GenerateReport(object sender, RoutedEventArgs e)
        {
            Report reportWindow = new Report();
            reportWindow.Show();
        }

        private void FindAppointment(object sender, RoutedEventArgs e)
        {
            AppointmentFilter filterWindow = new AppointmentFilter();
            filterWindow.Show();
        }

        private void FindFreeAppointment(object sender, RoutedEventArgs e)
        {
            AppointmentSearch searchDialog = new AppointmentSearch();
            searchDialog.Show();
        }

        private void OpenEditPanel(object sender, RoutedEventArgs e)
        {
            var changeProfilePanel = this.FindName("changeProfile") as Grid;
            var profilePanel = this.FindName("profile") as Grid;
            changeProfilePanel.Visibility = Visibility.Visible;
            profilePanel.Visibility = Visibility.Collapsed;
        }

       

        private void CancelProfileChangeDialog(object sender, RoutedEventArgs e)
        {
            var changeProfilePanel = this.FindName("changeProfile") as Grid;
            var profilePanel = this.FindName("profile") as Grid;
            changeProfilePanel.Visibility = Visibility.Collapsed;
            profilePanel.Visibility = Visibility.Visible;
        }

        private void EditSelectedAppointment(object sender, RoutedEventArgs e)
        {
            EditAppointment editDialog = new EditAppointment();
            editDialog.Show();
        }

        private void FreeSelectedAppointment(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayToolTip(object sender, RoutedEventArgs e)
        {
            if (_isToolTipAvailable)
            {
                Button button = sender as Button;
                String toolTipText = (String)button.ToolTip;
                _toolTip.Content = toolTipText;
                _toolTip.PlacementTarget = button;
                _toolTip.Placement = System.Windows.Controls.Primitives.PlacementMode.Top;
                _toolTip.IsOpen = true;
            }
        }

        private void RemoveToolTip(object sender, RoutedEventArgs e)
        {
            if(_isToolTipAvailable)
            _toolTip.IsOpen = false;
        }
    }
}
