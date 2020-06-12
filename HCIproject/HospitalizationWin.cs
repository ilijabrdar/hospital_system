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
        public Doctor user;

        public HospitalizationWin(Doctor user)
        {
            this.user = user;
            InitializeComponent();
        }

        public HospitalizationWin()
        {
            InitializeComponent();
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //potvrdi
            //ExaminationWin exam = new ExaminationWin((Doctor)user);
            //this.Visibility = Visibility.Hidden;
            //exam.Show();
            this.Close();
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
