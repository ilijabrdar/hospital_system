using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for DrugAlternative.xaml
    /// </summary>
    public partial class DrugAlternative : Window
    {
        public Doctor user;
       public DrugAlternative(Doctor user)
        {
            this.user = user;
            InitializeComponent();
            initializeComboBox();
        }

        public DrugAlternative()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//potvrdi
            if(cBox.SelectedItem.ToString()==null || cBox1.SelectedItem.ToString() == null)
            {
                string messageBoxText = "Morate odabrati oba leka ukoliko želite da odaberete alternativu.";
                string caption = "Greska prilikom odabira alternativnih lekova!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            }
            else if (cBox.SelectedItem.ToString() == cBox1.SelectedItem.ToString())
            {
                string messageBoxText = "Lek ne moze biti sam sebi alternativni, molimo proverite Vas unos.";
                string caption = "Greska prilikom odabira alternativnih lekova!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                string messageBoxText = "Uspesno ste dodali alternativni lek " + cBox1.SelectedItem.ToString() + " za lek " + cBox.SelectedItem.ToString()+"!";
                string caption = "Potvrda dodavanja alternativnog leka!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                this.Close();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void initializeComboBox()
        {// cBox drugPass
            var app = Application.Current as App;
            foreach (Drug drug in app.DrugController.GetAll())
            {
                cBox.Items.Add(drug.Name);
                cBox1.Items.Add(drug.Name);
                
            }
        }



        private void cBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var app = Application.Current as App;

            obavestenje.Content = "";
            String lek = cBox.SelectedItem.ToString();

            foreach (Drug drug in app.DrugController.GetAll())
            {
                if (lek.Equals(drug.Name))
                {
                    drugKey.Content = drug.Id;
                }
            }
        }

        private void cBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var app = Application.Current as App;

            obavestenje.Content = "";
            String lek = cBox1.SelectedItem.ToString();

            foreach (Drug drug in app.DrugController.GetAll())
            {
                if (lek.Equals(drug.Name))
                {
                    drugKey1.Content = drug.Id;
                }
            }

        }
    }
}
