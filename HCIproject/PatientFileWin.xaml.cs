using Model.Dto;
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
    /// Interaction logic for PatientFile.xaml
    /// </summary>
    public partial class PatientFileWin : Window
    {
        public Doctor user;
        public long id;


        public PatientFileWin(Doctor _user, long _patientId)
        {
            this.user = _user;
            this.id = _patientId;
            InitializeComponent();
        }

        public PatientFileWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // SideBar sideBarWin = new SideBar((Doctor)user);
            //  this.Visibility = Visibility.Hidden;
            //  sideBarWin.MyTabControl.SelectedIndex = 3;
            //  sideBarWin.Show();
            this.Close();
        }

        private void patientFileScrool_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            patientFileScrool.Height = this.ActualHeight - 200;
        }


        private void search_files_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (search_files.Text == "Unesite parametar pretrage")
            {
                search_files.Text = "";
            }
        }

        private void search_files_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (search_files.Text == "")
                {
                    return;
                }
                else
                {
                    searchMyExam(search_files.Text);
                    //   ArticleWin artWind = new ArticleWin(findAexarticles);
                    //    artWind.ShowDialog();
                    search_files.Text = "";
                }
            }
        }

        private void searchMyExam(String input)
        {
            if (input.Equals(lekar1.Text) || input.Equals(datum1Txt.Text))
            {
                Examination2.Visibility = Visibility.Hidden;
                Examination3.Visibility = Visibility.Hidden;
            }
            else if (input.Equals(lekar2.Text) || input.Equals(datum2Txt.Text))
            {
                Examination1.Visibility = Visibility.Hidden;
                Examination3.Visibility = Visibility.Hidden;
            } else if (input.Equals(lekar3.Text) || input.Equals(datum3Txt.Text))
            {
                Examination1.Visibility = Visibility.Hidden;
                Examination2.Visibility = Visibility.Hidden;
            }else if (input.Equals(" "))
            {
                Examination1.Visibility = Visibility.Visible;
                Examination2.Visibility = Visibility.Visible;
                Examination3.Visibility = Visibility.Visible;
            }
            else
            {
                Examination1.Visibility = Visibility.Hidden;
                Examination2.Visibility = Visibility.Hidden;
                Examination3.Visibility = Visibility.Hidden;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            searchMyExam(" ");
        }
    }
}
