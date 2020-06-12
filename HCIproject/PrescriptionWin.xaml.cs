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

        public PrescriptionWin(Doctor user)
        {
            this.user = user;
            InitializeComponent();
        }

        public PrescriptionWin()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //potvrdi
          //    Examination exam = new Examination();
          //this.Visibility = Visibility.Hidden;
          // exam.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { //otkazi
            ExaminationWin exam = new ExaminationWin((Doctor)user);
            this.Visibility = Visibility.Hidden;
            exam.Show();
        }
    }
}
