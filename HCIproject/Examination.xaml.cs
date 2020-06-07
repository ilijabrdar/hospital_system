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
    /// Interaction logic for Examination.xaml
    /// </summary>
    public partial class Examination : Window
    {
        public Examination()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SideBar sideBarWin = new SideBar();
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 2;
            sideBarWin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //otkazi
            SideBar sideBarWin = new SideBar();
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 2;
            sideBarWin.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        { //recept
            PrescriptionWin presWin = new PrescriptionWin();
            this.Visibility = Visibility.Hidden;
            presWin.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//uput
            RefferalWin refWin = new RefferalWin();
            this.Visibility = Visibility.Hidden;
            refWin.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        { //hospitalizacija
            HospitalizationWin hosWin = new HospitalizationWin();
            this.Visibility = Visibility.Hidden;
            hosWin.Show();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {//kontrola
            ScheduleExamination exaWin = new ScheduleExamination();
            this.Visibility = Visibility.Hidden;
            exaWin.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            OperationWin opeWin = new OperationWin();
            this.Visibility = Visibility.Hidden;
            opeWin.Show();
        }

        private void examScrool_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            examScrool.Height = this.ActualHeight - 150;
        }
    }
}
