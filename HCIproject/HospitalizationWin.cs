using Model.Users;
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

namespace HCIproject
{
    /// <summary>
    /// Interaction logic for Hospitalization.xaml
    /// </summary>

    public partial class HospitalizationWin : Window
    {
        private Doctor user;
        public String dijagnoza;
        private long patientId;
       
        public HospitalizationWin(Doctor _user, long _patientId, String _dijagnoza)
        {
            this.user = _user;
            this.dijagnoza = _dijagnoza;
            this.patientId = _patientId;


            InitializeComponent();
            dijagnozaTxt.Text = dijagnoza;
            setSpecialityCombo();
        }

        public HospitalizationWin()
        {
            InitializeComponent();
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;

        }

        private void setSpecialityCombo()
        {
            var app = Application.Current as App;
            foreach(var spec in app.SpecialityController.GetAll())
            {
                specialitiCMB.Items.Add(spec.Name);
            }


            Random rand = new Random();
            int randInt = rand.Next(0, 200);
            sobaTxt.Text = randInt.ToString();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //potvrdi
            if (specialitiCMB.SelectedItem != null)
            {
                string messageBoxText = "Uspesno ste izvrsili hospitalizaciju pacijenta!";
                string caption = "Hospitalizacija";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                this.Close();

            }
            else if (StartDate.SelectedDate > EndDate.SelectedDate || StartDate.SelectedDate < DateTime.Now)
            {
                string messageBoxText = "Nevalidan unos datuma. Datum početka operacije mora biti u budućnosti, pre završetka iste.";
                string caption = "Hospitalizacija";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                string messageBoxText = "Morate izabrati odeljenje kako biste izvrsili hospitalizaciju!";
                string caption = "Hospitalizacija";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        { //otkazi
            //ExaminationWin exam = new ExaminationWin((Doctor)user);
            //this.Visibility = Visibility.Hidden;
            //exam.Show();
            this.Close();
        }
    }
}
