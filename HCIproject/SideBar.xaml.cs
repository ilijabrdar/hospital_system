using Microsoft.Win32;
using MindFusion.Charting.Wpf;
using Model.Director;
using Model.Doctor;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCIproject
{
    public partial class SideBar : Window, INotifyPropertyChanged
    {
        public Doctor user;
        public string Naslov { get; set; }
        public List<ExaminationDTO> upcomingExaminations { get; set; }
        private int num = 0;
        private int num1 = 0;
        public string fileName { get; set; }
        private Speciality spec=new Speciality();

        public List<State> States { get; set; }
        public List<Town> Towns { get; set; }
        public List<Address> Addresses { get; set; }


        public string TestAdresa { get; set; }

        public SideBar(Doctor _user)
        {
            InitializeComponent();
            this.DataContext = this;
            user = _user;
            setArticle();
            setDoctorsData();
            setDrug();
            upcomingExaminations = new List<ExaminationDTO>();

            StateCombo.DisplayMemberPath = "Name";
            StateCombo.SelectedValuePath = "Id";
            App app = Application.Current as App;
            States = app.StateController.GetAll().ToList();
            States.Sort((x, y) => x.Name.CompareTo(y.Name));
            StateCombo.ItemsSource = States;
            TownCombo.DisplayMemberPath = "Name";
            TownCombo.SelectedValuePath = "Id";
            AddressCombo.DisplayMemberPath = "FullAddress";
            AddressCombo.SelectedValuePath = "Id";
            StateCombo.SelectedValue = user.Address.Town.State.GetId();
            TownCombo.SelectedValue = user.Address.Town.GetId();
            AddressCombo.SelectedValue = user.Address.GetId();

            brojPregleda.Content = app.ExaminationController.GetUpcomingExaminationsByUser(user).Count;
            checkSpeciality();
            setViewUpcExam();
            setViewPatientFiles();
            setHospitalizations();
            setOperation();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public void checkSpeciality()
        {
            if(user.Specialty.Name=="Opsta praksa")
            {
                OperacijeTab.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { //odjavi se
            MainWindow mainWin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWin.Show();
        }
//Lekovi
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//dodaj alternativni
            DrugAlternative drugAltWind = new DrugAlternative((Doctor)user);
            drugAltWind.ShowDialog();
        }
//utisak
        private void myGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            misljenje.Height = this.ActualHeight - 300;
            misljenje.Width = this.ActualHeight - 80;
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {//posalji utisak
            string messageBoxText = "Hvala Vam što ste sa nama podelili vaše utiske o apliakciji!";
            string caption = "Hvala!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            misljenje.Text = "";
        }

//izmena naloga
        private void setDoctorsData()
        {

            var app = Application.Current as App;

            ImePrzSet.Text = user.FirstName + " " + user.LastName;
            SpecSet.Text = user.Specialty.Name;
            DatSet.Text = user.DateOfBirth.ToString();
            JmbgSet.Text = user.Jmbg.ToString();
            EmailSet.Text = user.Email;
            TelSet.Text = user.Phone;
            String doctorAddress = user.Address.Street + " " + user.Address.Number + "," + " " + user.Address.Town.Name + " " + user.Address.Town.PostalNumber + "," + " " + user.Address.Town.State.Name;
            AdresaSet.Text = doctorAddress;

            TestSpec = user.Specialty.Name;
            TestImePrezime= user.FirstName + " " + user.LastName;
            TestEmail= user.Email;
            TestJMBG = user.Jmbg.ToString();
            TestPhoneNumber= user.Phone;
            TestAdresa = doctorAddress;
        }

        private void UpdateTownAddress(object sender, RoutedEventArgs e)
        {
            State state = StateCombo.SelectedItem as State;
            Towns = state.GetTown();
            Towns.Sort((x, y) => x.Name.CompareTo(y.Name));
            TownCombo.ItemsSource = Towns;
            AddressCombo.ItemsSource = null;


        }

        private void UpdateAddress(object sender, RoutedEventArgs e)
        {
            Town town = TownCombo.SelectedItem as Town;
            if (town == null)
                return;
            Addresses = town.GetAddress();
            Addresses.Sort((x, y) => x.FullAddress.CompareTo(y.FullAddress));
            AddressCombo.ItemsSource = Addresses;


        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {//izmena naloga potvrda
            var app = Application.Current as App;
            bool flag = false;
            if (TestImePrezime == "" || TestSpec == "" || TestEmail == "" || TestEmail == "" || TestJMBG == "" || TestPhoneNumber == "")
            {
                string messageBoxText = "Polje ne sme biti prazno.Molim unesite podatke pre izmene!";
                string caption = "Izmena.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                flag = true;
            }
            else if (LocaleDatePicker.SelectedDate != null)
            {
                DateTime startDate = (DateTime)LocaleDatePicker.SelectedDate;
                DateTime dateNow = DateTime.Now;

                TimeSpan timeSpan = dateNow - startDate;

                if (timeSpan.TotalDays < 21 * 365)
                {
                    string messageBoxText1 = "Molimo proverite uneseni datum rođenja. Doktor mora da ima najmanje 21 godinu.";
                    string caption1 = "Datum rođenja.";
                    MessageBoxButton button1 = MessageBoxButton.OK;
                    MessageBoxImage icon1 = MessageBoxImage.Information;
                    MessageBoxResult result1 = MessageBox.Show(messageBoxText1, caption1, button1, icon1);
                    flag = true;
                }
                else
                {
                    user.DateOfBirth = startDate;
                }
            }
            if (!flag)
            {
                String[] imePrz2 = TestImePrezime.Split(" ".ToCharArray());
                String ime = imePrz2[0];
                String prezime = imePrz2[1];
                user.FirstName = ime;
                user.LastName = prezime;
                
                user.Jmbg = TestJMBG;
                user.Phone = TestPhoneNumber;
                user.Email = TestEmail;
                var state = StateCombo.SelectedItem as State;
                var town = TownCombo.SelectedItem as Town;
                var selectedAddress = AddressCombo.SelectedItem as Address;
                //var address = new Address(selectedAddress.GetId(), town.GetId(), state.GetId());
                user.Address = selectedAddress;
                user.Address.Town = town;
                user.Address.Town.State = state;
                user.DoctorGrade = user.DoctorGrade;
                app.UserController.Edit((Doctor)user);

                string messageBoxText1 = "Uspesno ste promenili podatke!";
                string caption1 = "Izmena naloga.";
                MessageBoxButton button1 = MessageBoxButton.OK;
                MessageBoxImage icon1 = MessageBoxImage.Information;
                MessageBoxResult result1 = MessageBox.Show(messageBoxText1, caption1, button1, icon1);
                setDoctorsData();

            }

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



        private void Button_Click_5(object sender, RoutedEventArgs e)
        {//sacuvaj lozinku
         // provera da li je dobra stara sifra
            if (NovaLozTxt.Password != PotvNovaLozTxt.Password)
            {
                obavesti.Foreground = new SolidColorBrush(Color.FromRgb(199, 24, 24));
                obavesti.Text = "Unos se ne poklapa.Pokusajte ponovo.";
            }
            if(LozinkaTxt.Password != user.Password)
            {
                obavesti.Foreground = new SolidColorBrush(Color.FromRgb(199, 24, 24));
                obavesti.Text = "Pogresan unos stare lozinke";
            }
            if(StateCombo.SelectedItem==null && TownCombo.SelectedItem == null && AddressCombo.SelectedItem == null)
            {
                string messageBoxText1 = "Morate da unesete podatke vezane za adresu!";
                string caption1 = "Izmena adrese.";
                MessageBoxButton button1 = MessageBoxButton.OK;
                MessageBoxImage icon1 = MessageBoxImage.Information;
                MessageBoxResult result1 = MessageBox.Show(messageBoxText1, caption1, button1, icon1);
            }
            else
            {
                user.Password = NovaLozTxt.Password;
                var app = Application.Current as App;
                app.UserController.Edit((Doctor)user);

                obavesti.Foreground = new SolidColorBrush(Color.FromRgb(64, 85, 81));
                string messageBoxText1 = "Uspesno ste promenili lozinku!";
                string caption1 = "Izmena lozinke.";
                MessageBoxButton button1 = MessageBoxButton.OK;
                MessageBoxImage icon1 = MessageBoxImage.Information;
                MessageBoxResult result1 = MessageBox.Show(messageBoxText1, caption1, button1, icon1);
                setDoctorsData();
                obavesti.Text = "";
                NovaLozTxt.Password = "";
                PotvNovaLozTxt.Password = "";
            }
        }

//clanci
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {//novi clanak
            CreateArticle creWin = new CreateArticle((Doctor)user);
            creWin.ShowDialog();
            setArticle();
        }
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
        private void search_article_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (search_article.Text == "Unesite parametar pretrage")
            {
                search_article.Text = "";
            }

        }

        private void search_article_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (search_article.Text == "")
                {
                    return;
                }
                else
                {
                    List<Article> findArticles = searchMyArticles(search_article.Text);
                    var artWind = new ArticleWin(findArticles);
                    artWind.ShowDialog();
                }
            }
        }

        private List<Article> searchMyArticles(String input)
        {
            var app = Application.Current as App;
            List<Article> articles = new List<Article>();
            foreach (var article in app.ArticleController.GetAll())
            {
                if (article.Topic.Contains(input))
                {
                    articles.Add(article);
                }
            }
            return articles;
        }
//KARTON PREGLED    
        private void search_patient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (search_patient.Text == "")
                {
                    return;
                }
                else
                {
                    List<ExaminationDTO> findFile = searchMyFiles(search_patient.Text);
                    if (findFile.Count == 0)
                    {
                        string messageBoxText = "Ne postoje pacijenti sa zadatim parametrima.";
                        string caption = "Pretraga";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Information;
                        MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    }
                    else
                    {
                        var winFind = new FindFileWindow((Doctor)user,findFile);
                        winFind.ShowDialog();
                    }
                }
            }
        }
        private List<ExaminationDTO> searchMyFiles(string search)
        {
            List<ExaminationDTO> lista = new List<ExaminationDTO>();
            foreach (var exam in upcomingExaminations)
            {
                if ((exam.Patient.FirstName).Equals(search) || (exam.Patient.LastName).Equals(search) || (exam.Patient.FirstName+" " +exam.Patient.LastName).Equals(search))
                {
                    lista.Add(exam);
                }
            }
            return lista;
        }

        private void search_patient_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (search_patient.Text == "Pretraga")
            {
                search_patient.Text = "";
            }

        }

        private void LozTxt_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            obavesti.Text = "";
        }


//lekovi
        private void setDrug()
        {
            var app = Application.Current as App;
            DrugValidationPanel.Children.Clear();
            if (app.DrugController.GetNotApprovedDrugs().Count == 0)
            {
                Grid myGrid = new Grid();
                myGrid.Width = 250;
                //myGrid.Height = 300;
                myGrid.HorizontalAlignment = HorizontalAlignment.Left;
                myGrid.VerticalAlignment = VerticalAlignment.Center;

                ColumnDefinition colDef1 = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(colDef1);

                RowDefinition rowDef1 = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef1);
                Label lab = new Label();
                lab.Content = "Trenutno ne postoje lekovi za validiranje!";
                lab.FontSize = 12;
                Grid.SetRow(lab, 0);
                Grid.SetColumn(lab, 0);

                myGrid.Children.Add(lab);
                DrugValidationPanel.Children.Add(myGrid);
            }
            else
            {
                foreach (var drug in app.DrugController.GetNotApprovedDrugs())
                {
                    Grid myGrid = new Grid();
                    myGrid.Width = 250;
                    //   myGrid.Height = 100;
                    myGrid.HorizontalAlignment = HorizontalAlignment.Center;
                    myGrid.VerticalAlignment = VerticalAlignment.Center;

                    ColumnDefinition colDef1 = new ColumnDefinition();
                    ColumnDefinition colDef2 = new ColumnDefinition();
                    myGrid.ColumnDefinitions.Add(colDef1);
                    myGrid.ColumnDefinitions.Add(colDef2);

                    RowDefinition rowDef1 = new RowDefinition();
                    myGrid.RowDefinitions.Add(rowDef1);

                    TextBlock newDrug = new TextBlock();
                    newDrug.TextWrapping = TextWrapping.Wrap;
                    newDrug.FontSize = 16;
                    newDrug.FontWeight = FontWeights.Bold;
                    newDrug.HorizontalAlignment = HorizontalAlignment.Left;
                    newDrug.VerticalAlignment = VerticalAlignment.Center;
                    newDrug.Margin = new Thickness(20, 10, 10, 10);
                    newDrug.Foreground = new SolidColorBrush(Color.FromRgb(84, 96, 89));
                    newDrug.Text = drug.Name;
                    Grid.SetRow(newDrug, 0);
                    Grid.SetColumn(newDrug, 0);

                    var myButton = new Button();
                    myButton.Content = "Validiraj";
                    myButton.Width = 100;
                    myButton.Height = 30;
                    myButton.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                    Grid.SetColumn(myButton, 1);
                    Grid.SetRow(myButton, 0);
                    myButton.Tag = drug.Id;
                    myButton.Click += new RoutedEventHandler(ClickValidation);

                    myGrid.Children.Add(myButton);
                    myGrid.Children.Add(newDrug);


                    DrugValidationPanel.Children.Add(myGrid);


                }
            }
        }
        private void ClickValidation(object sender, RoutedEventArgs e)
        {//posalji utisak
            var DrugId = ((Button)sender).Tag;
            DrugValidations drugValWind = new DrugValidations((Doctor)user, (long)DrugId);
            // this.Visibility = Visibility.Hidden;
            drugValWind.ShowDialog();
            setDrug();
        }

        public void setViewUpcExam() {
            var app = Application.Current as App;

            foreach (var exam in app.ExaminationController.GetUpcomingExaminationsByUser(user)) 
            {
                StackPanel stack = new StackPanel();
                DockPanel dock = new DockPanel();
                Label lbl = new Label();
                Label lbl1 = new Label();
                Button btn1 = new Button();
                Button btn2 = new Button();

                stack.Children.Add(dock);
                dock.Children.Add(lbl);
                dock.Children.Add(lbl1);
                dock.Children.Add(btn2);
                dock.Children.Add(btn1);


                #region DockPanel Content Properties
                lbl.Content = exam.User.FirstName + " " + exam.User.LastName;
                lbl.Height = 32;
                lbl.Width = 180;
                lbl.FontSize = 15;
                lbl.FontWeight = FontWeights.Bold;
                lbl.SetValue(DockPanel.DockProperty, Dock.Left);
                lbl.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

                lbl1.Content = exam.Period.StartDate;
                lbl1.Height = 32;
                lbl1.Width = 180;
                lbl1.FontSize = 12;
                lbl1.FontWeight = FontWeights.SemiBold;
                lbl1.SetValue(DockPanel.DockProperty, Dock.Left);
                lbl1.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

                btn1.Content = "Započni";
                btn1.Height = 32;
                btn1.Width = 100;
                btn1.FontSize = 12;
                btn1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                btn1.SetValue(DockPanel.DockProperty, Dock.Right);
                btn1.Tag = exam.User.Id;
                btn1.Click += new RoutedEventHandler(ClickStartExamination);
                btn1.Margin = new Thickness(10, 10, 15, 0);
                btn1.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));


                btn2.Content = "Otkaži";
                btn2.Height = 32;
                btn2.Width = 100;
                btn2.FontSize = 12;
                btn2.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                btn2.SetValue(DockPanel.DockProperty, Dock.Right);
                btn2.Margin = new Thickness(10, 10, 15, 0);
                btn2.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                //    btn2.Click += new RoutedEventHandler(btn2_Click);
                #endregion

                Grid_Grid.RowDefinitions.Add(new RowDefinition());
                Grid_Grid.RowDefinitions[num].Height = new GridLength(66, GridUnitType.Pixel);
                Grid_Grid.Children.Add(stack);
                stack.SetValue(Grid.RowProperty, num);
                num++;

            }

        }
        private void setViewPatientFiles()
        {
            var app = Application.Current as App;

            List<long> helpExam = new List<long>();
            foreach (var exam in app.ExaminationController.GetUpcomingExaminationsByUser(user))
            {
                if (!helpExam.Contains(exam.User.Id))
                {
                    helpExam.Add(exam.User.Id);

                    StackPanel stack = new StackPanel();
                    DockPanel dock = new DockPanel();
                    Label lbl = new Label();
                    Button btn1 = new Button();

                    stack.Children.Add(dock);
                    dock.Children.Add(lbl);
                    dock.Children.Add(btn1);


                    #region DockPanel Content Properties
                    lbl.Content = exam.User.FirstName + " " + exam.User.LastName;
                    lbl.Height = 32;
                    lbl.Width = 180;
                    lbl.FontSize = 15;
                    lbl.FontWeight = FontWeights.Bold;
                    lbl.SetValue(DockPanel.DockProperty, Dock.Left);
                    lbl.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

                    btn1.Content = "Otvori";
                    btn1.Height = 32;
                    btn1.Width = 100;
                    btn1.FontSize = 12;
                    btn1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    btn1.SetValue(DockPanel.DockProperty, Dock.Right);
                    btn1.Tag = exam.User.Id;
                    btn1.Click += new RoutedEventHandler(ClickOpenPatientFile);
                    btn1.Margin = new Thickness(10, 10, 15, 0);
                    btn1.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                    #endregion

                    Grid_Grid1.RowDefinitions.Add(new RowDefinition());
                    Grid_Grid1.RowDefinitions[num1].Height = new GridLength(66, GridUnitType.Pixel);
                    Grid_Grid1.Children.Add(stack);
                    stack.SetValue(Grid.RowProperty, num1);
                    num1++;

                }
            }
            foreach (var exam in app.ExaminationController.GetFinishedxaminationsByUser(user))
            {
                if (!helpExam.Contains(exam.User.Id))
                {
                    helpExam.Add(exam.User.Id);
                    StackPanel stack = new StackPanel();
                    DockPanel dock = new DockPanel();
                    Label lbl = new Label();
                    Button btn1 = new Button();

                    stack.Children.Add(dock);
                    dock.Children.Add(lbl);
                    dock.Children.Add(btn1);


                    lbl.Content = exam.User.FirstName + " " + exam.User.LastName;
                    lbl.Height = 32;
                    lbl.Width = 180;
                    lbl.FontSize = 15;
                    lbl.FontWeight = FontWeights.Bold;
                    lbl.SetValue(DockPanel.DockProperty, Dock.Left);
                    lbl.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

                    btn1.Content = "Otvori";
                    btn1.Height = 32;
                    btn1.Width = 100;
                    btn1.FontSize = 12;
                    btn1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    btn1.SetValue(DockPanel.DockProperty, Dock.Right);
                    btn1.Tag = exam.User.Id;
                    btn1.Click += new RoutedEventHandler(ClickOpenPatientFile);
                    btn1.Margin = new Thickness(10, 10, 15, 0);
                    btn1.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));

                    Grid_Grid1.RowDefinitions.Add(new RowDefinition());
                    Grid_Grid1.RowDefinitions[num1].Height = new GridLength(66, GridUnitType.Pixel);
                    Grid_Grid1.Children.Add(stack);
                    stack.SetValue(Grid.RowProperty, num1);
                    num1++;
                }
            }

        }


        private void ClickStartExamination(object sender, RoutedEventArgs e)
        {//posalji utisak

            string messageBoxText = "Da li ste sigurni da želite da pokrenete pregled? Jednom pokrenut pregled se ne moze otkazati!";
            string caption = "Pregled";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            if (result == MessageBoxResult.Yes)
            {

                var PatientId = ((Button)sender).Tag;
                ExaminationWin examWinn = new ExaminationWin((Doctor)user, (long)PatientId);
                this.Visibility = Visibility.Hidden;
                examWinn.ShowDialog();
            }
        }  
        
        private void ClickOpenPatientFile(object sender, RoutedEventArgs e)
        {//posalji utisak
            var PatientId = ((Button)sender).Tag;
            PatientFileWin patientWin = new PatientFileWin((Doctor)user, (long)PatientId);
            // this.Visibility = Visibility.Hidden;
            patientWin.ShowDialog ();
        }

        private void ScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrool.Height = this.ActualHeight - 120;
        }

        private void scroolHospitalization_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scroolHospitalization.Height = this.ActualHeight - 120;
        }
        private void scroolOperation_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scroolOperation.Height = this.ActualHeight - 120;
        }



        private void changePhoto(object sender, RoutedEventArgs e)
        {//promeni sliku
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                fileName = op.FileName;
                pic.Source = new BitmapImage(new Uri(fileName));
            }
        }


        private void setHospitalizations()
        {
            var app = Application.Current as App;

            if (app.HospitalizationController.GetAll() == null)
            {
                return;
            }
            foreach (var hospitalization in app.HospitalizationController.GetHospitalizationByDoctor(user))
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.GreenYellow;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelExamination = new StackPanel();
                TextBlock period = new TextBlock();
                TextBlock room = new TextBlock();
                TextBlock patient = new TextBlock();
                TextBlock hospitalizacija = new TextBlock();

                hospitalizacija.FontSize = 15;
                hospitalizacija.Inlines.Add(new Run("HOSPITALIZACIJA") { FontWeight = FontWeights.Bold });
                hospitalizacija.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(hospitalizacija);

                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.SemiBold });
                period.FontSize = 15;
                period.Inlines.Add(hospitalization.Period.StartDate.ToString());
                period.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(period);

                patient.Inlines.Add(new Run("Pacijent:  ") { FontWeight = FontWeights.SemiBold });
                patient.FontSize = 15;
                patient.Inlines.Add(hospitalization.Patient.FullName);
                patient.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(patient);

                //
                room.Inlines.Add(new Run("Prostorija: ") { FontWeight = FontWeights.SemiBold });
                room.FontSize = 15;
                room.Inlines.Add(hospitalization.Room.RoomCode);
                room.Margin = new Thickness(10);
                stackPanelExamination.Children.Add(room);

                b.Child = stackPanelExamination;

                Hospitalizations.Children.Add(b);
            }
        }
        private void setOperation()
        {
            var app = Application.Current as App;

            if (app.OperationController.GetOperationsByDoctor(user) == null)
            {
                return;
            }
            foreach (var operation in app.OperationController.GetOperationsByDoctor(user))
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.Pink;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelExamination = new StackPanel();
                TextBlock operacija = new TextBlock();
                TextBlock patient = new TextBlock();
                TextBlock period = new TextBlock();
                TextBlock room = new TextBlock();
                TextBlock description = new TextBlock();

                operacija.FontSize = 15;
                operacija.Inlines.Add(new Run("OPERACIJA") { FontWeight = FontWeights.Bold });
                operacija.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(operacija);

                patient.FontSize = 15;
                patient.Inlines.Add(new Run("Pacijent:  ") { FontWeight = FontWeights.SemiBold });
                patient.Inlines.Add(operation.Patient.FullName);
                patient.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(patient);
                //
                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.SemiBold });
                period.FontSize = 15;
                period.Inlines.Add(operation.Period.StartDate.ToString());
                period.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(period);

                //
                room.Inlines.Add(new Run("Prostorija: ") { FontWeight = FontWeights.SemiBold });
                room.FontSize = 15;
                room.Inlines.Add(operation.Room.RoomCode);
                room.Margin = new Thickness(10);
                stackPanelExamination.Children.Add(room);

                //
                description.Inlines.Add(new Run("Opis: ") { FontWeight = FontWeights.SemiBold });
                description.FontSize = 15;
                description.Inlines.Add(operation.Description);
                description.Margin = new Thickness(10);
                stackPanelExamination.Children.Add(description);



                b.Child = stackPanelExamination;

                Operations.Children.Add(b);
            }
        }

    }
}
