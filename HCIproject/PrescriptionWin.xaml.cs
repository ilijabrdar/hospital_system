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
    /// Interaction logic for Prescription.xaml
    /// </summary>
    public partial class PrescriptionWin : Window
    {
        public Doctor user;
        public long patientId;
        public String dijagnoza;
        public PrescriptionWin(Doctor user, long _patientId, String _dijagnoza)
        {
            this.user = user;
            this.patientId = _patientId;
            this.dijagnoza = _dijagnoza;

            InitializeComponent();
            dijagnozaTxt.Text = dijagnoza;
            setDrugCombo();
        }

        private void setDrugCombo()
        {
            var app = Application.Current as App;
            foreach(var lek in app.DrugController.GetAll())
            {
                lekovi.Items.Add(lek.Name);
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //potvrdi
          //    Examination exam = new Examination();
          //this.Visibility = Visibility.Hidden;
          // exam.Show();
            if (lekovi.SelectedItem != null)
            {
                string messageBoxText = "Uspesno ste prepisali lek:" + lekovi.SelectedItem.ToString();
                string caption = "Recept";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                this.Close();

            }
            else{
                string messageBoxText = "Morate izabrati neki lek kako biste pacijentu izdali recept";
                string caption = "Recept";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { //otkazi
            this.Close();
        }
    }
}
