using Model.PatientSecretary;
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
    /// Interaction logic for Examination.xaml
    /// </summary>
    
    public partial class ExaminationWin : Window
    {
        public Doctor user;
        public String Simptom {get; set;}
        public ExaminationWin(Doctor user)
        {
            this.user = user;
            InitializeComponent();
        }

        public ExaminationWin()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//otkazi

            SideBar sideBarWin = new SideBar((Doctor)user);
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 2;
            sideBarWin.Show();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //potvrdi
                var app = Application.Current as App;

           Console.WriteLine( simptomiTxt.Text);
                app.SymptomController.Save(new Symptom(simptomiTxt.Text));



                SideBar sideBarWin = new SideBar((Doctor)user);
                this.Visibility = Visibility.Hidden;
                sideBarWin.MyTabControl.SelectedIndex = 2;
                sideBarWin.Show();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        { //recept
            PrescriptionWin presWin = new PrescriptionWin((Doctor)user);
            //this.Visibility = Visibility.Hidden;
            presWin.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//uput
            RefferalWin refWin = new RefferalWin((Doctor)user);
           // this.Visibility = Visibility.Hidden;
            refWin.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        { //hospitalizacija
            HospitalizationWin hosWin = new HospitalizationWin((Doctor)user);
           // this.Visibility = Visibility.Hidden;
            hosWin.ShowDialog();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {//kontrola
            ScheduleExamination exaWin = new ScheduleExamination((Doctor)user);
          //  this.Visibility = Visibility.Hidden;
            exaWin.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            OperationWin opeWin = new OperationWin((Doctor)user);
           // this.Visibility = Visibility.Hidden;
            opeWin.ShowDialog();
        }

        private void examScrool_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            examScrool.Height = this.ActualHeight - 150;
        }
    }
}
