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
using System.Xml.Schema;

namespace HCIproject
{
    /// <summary>
    /// Interaction logic for DockPanel.xaml
    /// </summary>
    public partial class SideBar : Window
    {
        public SideBar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWin.Show();
        }

        private void search_text_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (search_patient.Text == "Unesite parametar pretrage")
            {
                search_patient.Text = "";
            }
        }

        private void search_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (search_patient.Text == "")
                {
                    return;
                }
                else
                {
                    Article artWind = new Article();
                    this.Visibility = Visibility.Hidden;
                    artWind.Show();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//otvara karton
            PatientFile fileWin = new PatientFile();
            this.Visibility = Visibility.Hidden;
            fileWin.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//otvara prozor za validaciju sastava leka
            DrugValidation drugValWind = new DrugValidation();
            this.Visibility = Visibility.Hidden;
            drugValWind.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//dodaj alternativni
            DrugAlternative drugAltWind = new DrugAlternative();
            this.Visibility = Visibility.Hidden;
            drugAltWind.Show();
        }

        private void myGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //MyTabControl.Height = this.ActualHeight - 100;
            misljenje.Height = this.ActualHeight - 300;
            misljenje.Width = this.ActualHeight - 80;

            //utisakGrid.Height = this.ActualHeight - 40;
            //izmenaGrid.Height = this.ActualHeight - 40;
            //evidencijaGrid.Height = this.ActualHeight - 40;
            //kartoniGrid.Height = this.ActualHeight - 40;
            //pregledGrid.Height = this.ActualHeight - 40;
            //clanciGrid.Height = this.ActualHeight - 40;
            //pocetnaGrid.Height = this.ActualHeight - 40;
        }

        private void izImePrzTxt_Initialized(object sender, EventArgs e)
        {
            izImePrzTxt.Text = ImePrzTxt.Text;
            
        }

        private void izSpecTxt_Initialized(object sender, EventArgs e)
        {
            izSpecTxt.Text = SpecTxt.Text;
        }

        private void izDatTxt_Initialized(object sender, EventArgs e)
        {
            izDatTxt.Text = DatTxt.Text;
        }

        private void izJmbgTxt_Initialized(object sender, EventArgs e)
        {          
            izJmbgTxt.Text = JmbgTxt.Text;
        }

        private void izEmailTxt_Initialized(object sender, EventArgs e)
        {
            izEmailTxt.Text = EmailTxt.Text;
        }

        private void izTelTxt_Initialized(object sender, EventArgs e)
        {
            izTelTxt.Text = TelTxt.Text;
        }



        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ImePrzTxt.Text = izImePrzTxt.Text;
            SpecTxt.Text = izSpecTxt.Text;
            DatTxt.Text = izDatTxt.Text;
            JmbgTxt.Text = izJmbgTxt.Text;
            EmailTxt.Text = izEmailTxt.Text;
            TelTxt.Text = izTelTxt.Text; 
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if(NovaLozTxt.Password != PotvNovaLozTxt.Password)
            {
                NovaLozTxt.Background = new SolidColorBrush(Color.FromRgb(255, 160, 122));
                obavesti.Content = "Lozinke se ne poklapaju.";
                obavesti1.Content = "Molimo pokušajte ponovo.";
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Examination examWin = new Examination();
            this.Visibility = Visibility.Hidden;
            examWin.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            CreateArticle creWin = new CreateArticle();
            this.Visibility = Visibility.Hidden;
            creWin.Show();
        }
    }
}
