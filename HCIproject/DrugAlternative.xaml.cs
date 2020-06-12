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
    /// Interaction logic for DrugAlternative.xaml
    /// </summary>
    public partial class DrugAlternative : Window
    {
        public Doctor user;

        public DrugAlternative(Doctor user)
        {
            this.user = user;
            InitializeComponent();
        }

        public DrugAlternative()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//potvrdi treba da izmeni u bazi i leku doda alternativni
            SideBar sideBarWin = new SideBar((Doctor)user);
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 4;
            sideBarWin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //otkazi
            SideBar sideBarWin = new SideBar((Doctor)user);
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 4;
            sideBarWin.Show();
        }
    }
}
