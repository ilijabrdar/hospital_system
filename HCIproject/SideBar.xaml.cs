using Model.Doctor;
using Model.Users;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HCIproject
{
    public partial class SideBar : Window, INotifyPropertyChanged
    {
        public Doctor user;
        public string Naslov { get; set; }


        public SideBar()
        {
            InitializeComponent();
            this.DataContext = this;
            setArticle();

        }
        public SideBar(Doctor _user)
        {
            InitializeComponent();
            this.DataContext = this;
            user = _user;
            setArticle();
            setDoctorsData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        //pocetna stranica binduj imena


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
                    ArticleWin artWind = new ArticleWin();
                    this.Visibility = Visibility.Hidden;
                    artWind.Show();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//otvara karton
            PatientFileWin fileWin = new PatientFileWin((Doctor)user);
            this.Visibility = Visibility.Hidden;
            fileWin.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//otvara prozor za validaciju sastava leka
            DrugValidation drugValWind = new DrugValidation((Doctor)user);
            this.Visibility = Visibility.Hidden;
            drugValWind.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//dodaj alternativni
            DrugAlternative drugAltWind = new DrugAlternative((Doctor)user);
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

        private string _testImePrz;
        private string _testSpec;
        private string _testEmail;
        private string _testPhoneNum;
        private string _testJMBG;
        public string TestImePrezime
        {
            get
            {
                return _testImePrz;
            }
            set
            {
                if (value != _testImePrz)
                {
                    _testImePrz = value;
                    OnPropertyChanged("TestImePrezime");
                }
            }
        }

        public string TestSpec
        {
            get
            {
                return _testSpec;
            }
            set
            {
                if (value != _testSpec)
                {
                    _testSpec = value;
                    OnPropertyChanged("TestSpec");
                }
            }
        }

        public string TestEmail
        {
            get
            {
                return _testEmail;
            }
            set
            {
                if (value != _testEmail)
                {
                    _testEmail = value;
                    OnPropertyChanged("TestEmail");
                }
            }
        }

        public string TestPhoneNumber
        {
            get
            {
                return _testPhoneNum;
            }
            set
            {
                if (value != _testPhoneNum)
                {
                    _testPhoneNum = value;
                    OnPropertyChanged("TestPhoneNumber");
                }
            }
        }

        public string TestJMBG
        {
            get
            {
                return _testJMBG;
            }
            set
            {
                if (value != _testJMBG)
                {
                    _testJMBG = value;
                    OnPropertyChanged("TestJMBG");
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {//posalji izmene

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {//sacuvaj lozinku
         //TODO provera da li je dobra stara sifra
            if (NovaLozTxt.Password != PotvNovaLozTxt.Password)
            {
                obavesti.Foreground = new SolidColorBrush(Color.FromRgb(199, 24, 24));
                obavesti.Text = "Unos se ne poklapa.Pokusajte ponovo.";
            }
            else
            {
                obavesti.Foreground = new SolidColorBrush(Color.FromRgb(64, 85, 81));

                obavesti.Text = "Uspešno ste promenili lozinku.";
                NovaLozTxt.Password = "";
                PotvNovaLozTxt.Password = "";
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ExaminationWin examWin = new ExaminationWin((Doctor)user);
            this.Visibility = Visibility.Hidden;
            examWin.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {//novi clanak
            CreateArticle creWin = new CreateArticle((Doctor)user);
         //   this.Visibility = Visibility.Hidden;
            creWin.ShowDialog();
        }

        private void setDoctorsData()
        {

            var app = Application.Current as App;

            ImePrzSet.Text = user.FirstName + " " + user.LastName;
            Speciality spec= app.SpecialityController.Get(user.Specialty.Id);
            SpecSet.Text = spec.Name;
            DatSet.Text = user.DateOfBirth.ToString();
            JmbgSet.Text = user.Jmbg.ToString();
            EmailSet.Text = user.Email;
            TelSet.Text = user.Phone;
            AdrSet.Text = user.Address.GetFullAddress();

        }

        //clanci
        private void setArticle()
        {
            var app = Application.Current as App;


            foreach (var article in app.ArticleController.GetAll())
            {

                Border b = new Border();
                b.BorderThickness = new Thickness(5);
                b.CornerRadius = new CornerRadius(5);
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelArticle = new StackPanel();
                TextBlock newTopic = new TextBlock();
                TextBlock newText = new TextBlock();
                TextBlock writer = new TextBlock();

                newTopic.TextWrapping = TextWrapping.Wrap;
                newTopic.FontSize = 12;
                newTopic.FontWeight = FontWeights.Bold;
                newTopic.MaxWidth = 700;
                newTopic.HorizontalAlignment = HorizontalAlignment.Center;
                newText.TextWrapping = TextWrapping.Wrap;
                newText.FontSize = 10;
                newText.MaxWidth = 700;
                writer.FontSize = 8;
                writer.HorizontalAlignment = HorizontalAlignment.Right;


                newTopic.Text = article.Topic;
                
                writer.Text =user.FirstName + " " + user.LastName;
                newText.Text = article.Text;

                stackPanelArticle.Children.Add(newTopic);
                stackPanelArticle.Children.Add(writer);
                stackPanelArticle.Children.Add(newText);

                b.Child = stackPanelArticle;

                Articles.Children.Add(b);

            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {//posalji utisak
            misljenje.Text = "";
        }
    }
}
