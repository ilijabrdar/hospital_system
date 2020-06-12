using Controller;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Refferal.xaml
    /// </summary>

    public partial class RefferalWin : Window
    {
        private int colNum = 0;
        public Doctor user;
        public ObservableCollection<Doctor> Specijaliste { get; set; }

        public RefferalWin(Doctor user)
        {
            this.user = user;
            InitializeComponent();
            this.DataContext = this;
            Specijaliste = new ObservableCollection<Doctor>();
            Specijaliste.Add(new Doctor(1) { FirstName = "Jovana", LastName = "Petrovic" });
        }



        public RefferalWin()
        {
            InitializeComponent();
           
        }

        private void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
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
