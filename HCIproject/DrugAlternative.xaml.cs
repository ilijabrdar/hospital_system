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
        private List<String> lekovi;
        public DrugAlternative(Doctor user)
        {
            this.user = user;
            lekovi = new List<string> { "Nimulid", "Bromazepam", "Brufen", "Diklofen", "Aspirin" };
            InitializeComponent();
            initializeComboBox();
        }

        public DrugAlternative()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//potvrdi
            if (cBox.SelectedItem.ToString() == cBox1.SelectedItem.ToString())
            {
                Console.WriteLine(cBox.SelectedItem.ToString());
                obavestenje.Content = "Lek ne moze biti sam sebi alternativni, molimo proverite unos";
            }
            else
            {
                this.Close();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void initializeComboBox()
        {// cBox drugPass
            foreach (String s in lekovi)
            {
                cBox.Items.Add(s);
                cBox1.Items.Add(s);
            }
        }



        private void cBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            obavestenje.Content = "";
            String lek = cBox.SelectedItem.ToString();
            if (lek == "Bromazepam")
            {
                drugKey.Content = "B23E";
            }
            else if (lek.Equals("Nimulid"))
            {
                drugKey.Content = "N34D";
            }
            else if (lek.Equals("Diklofen"))
            {
                drugKey.Content = "D12F";
            }
            else if (lek.Equals("Brufen"))
            {
                drugKey.Content = "B32N";
            }
            else if (lek.Equals("Aspirin"))
            {
                drugKey.Content = "A14S";
            }
        }

        private void cBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            obavestenje.Content = "";
            String lek = cBox1.SelectedItem.ToString();
            if (lek == "Bromazepam")
            {
                drugKey1.Content = "B23E";
            }
            else if (lek.Equals("Nimulid"))
            {
                drugKey1.Content = "N34D";
            }
            else if (lek.Equals("Diklofen"))
            {
                drugKey1.Content = "D12F";
            }
            else if (lek.Equals("Brufen"))
            {
                drugKey1.Content = "B32N";
            }
            else if (lek.Equals("Aspirin"))
            {
                drugKey1.Content = "A14S";
            }
        }
    }
}
