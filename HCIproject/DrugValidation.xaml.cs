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
    /// Interaction logic for DrugValidation.xaml
    /// </summary>
    public partial class DrugValidation : Window
    {
        public Doctor user;

        public DrugValidation(Doctor user)
        {
            this.user = user;
            InitializeComponent();
        }

        public DrugValidation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { //otkazi treba samo da se vrati
            SideBar sideBarWin = new SideBar((Doctor)user);
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 4;
            sideBarWin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//Potvrdi treba da potvrdi sastav i ukloni lek sa spiska
            SideBar sideBarWin = new SideBar((Doctor)user);
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 4;
            sideBarWin.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//idi na izmenu 
            EditDrug editDrugWin = new EditDrug((Doctor)user);
          //  this.Visibility = Visibility.Hidden;
            editDrugWin.ShowDialog();
        }
    }
}
