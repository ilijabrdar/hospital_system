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
    /// Interaction logic for CreateArticle.xaml
    /// </summary>
    public partial class CreateArticle : Window
    {
        public CreateArticle()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SideBar sideBarWin = new SideBar();
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 1;
            sideBarWin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //otkazi
            SideBar sideBarWin = new SideBar();
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 1;
            sideBarWin.Show();
        }
    }
}
