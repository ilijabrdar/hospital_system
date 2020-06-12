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
    /// Interaction logic for EditDrug.xaml
    /// </summary>
    public partial class EditDrug : Window
    {
        public Doctor user;

        public EditDrug(Doctor user)
        {
            this.user = user;
            InitializeComponent();
        }

        public EditDrug()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        { //otkazi treba samo da se vrati


            DrugValidation drugValWin = new DrugValidation((Doctor)user);
            this.Visibility = Visibility.Hidden;
            drugValWin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//Potvrdi treba da potvrdi i azurira sastav 
            DrugValidation drugValWin = new DrugValidation((Doctor)user);
            this.Visibility = Visibility.Hidden;
            drugValWin.Show();
        }
    }
}
