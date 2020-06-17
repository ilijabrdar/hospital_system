using bolnica.Controller;
using Controller;
using Microsoft.Win32;
using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using upravnikKT2.ModelMock;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window, INotifyPropertyChanged
    {
        private readonly IRoomController _roomController;
        private readonly IEquipmentController _equipmentController;
        private readonly IRenovationController _renovationController;
        private readonly IDrugController _drugController;
        private readonly IDoctorController _doctorController;
        private readonly IBusinessDayController _businessDayController;
        private readonly IDirectorController _directorController;
        private readonly IArticleController _articleController;

        public Director director;


        public List<State> States { get; set; }
        public List<Town> Towns { get; set; }
        public List<Address> Addresses { get; set; }

        public List<Article> articles = new List<Article>();

        public string fileName { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        private string _feedback;
        public string Feedback
        {
            get
            {
                return _feedback;
            }
            set
            {
                if (value != _feedback)
                {
                    _feedback = value;
                    OnPropertyChanged("Feedback");
                }
            }
        }

        private string _jmbg;
        public string JMBG
        {
            get
            {
                return _jmbg;
            }
            set
            {
                if (value != _jmbg)
                {
                    _jmbg = value;
                    OnPropertyChanged("JMBG");
                }
            }
        }

        private string _email;
        public string EMAIL
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("EMAIL");
                }
            }
        }

        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        public DashboardWindow()
        {
            InitializeComponent();
            this.DataContext = this;



            var app = Application.Current as App;
            _roomController = app.RoomController;
            _equipmentController = app.EquipmentController;
            _renovationController = app.RenovationController;
            _drugController = app.DrugController;
            _doctorController = app.DoctorController;
            _businessDayController = app.BusinessDayController;
            _directorController = app.DirectorController;
            _articleController = app.ArticleController;

            director = _directorController.Get(1);

            FirstName = director.FirstName;
            LastName = director.LastName;
            EMAIL = director.Email;
            Phone = director.Phone;
            JMBG = director.Jmbg;

            setDirectorField();
        }

        private void setDirectorField()
        {
            //welcomeLabel.Content = "DOBRODOŠLI " + director.FirstName.ToUpper() + "!";
            FirstNameDirector.Content = director.FirstName;
            LastNameDirector.Content = director.LastName;
            JMBGDirector.Content = director.Jmbg;
            EmailDirector.Content = director.Email;
            PhoneDirector.Content = director.Phone;

            String directorAddress = director.Address.Street + " " + director.Address.Number + "," + " " + director.Address.Town.Name + " " + director.Address.Town.PostalNumber + "," + " " + director.Address.Town.State.Name;
            AddressDirector.Content = directorAddress;

            BirthDateDirector.Content = director.DateOfBirth.ToString("dd/MM/yyyy");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoctorAddWindow window = new DoctorAddWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();

            dataGridLekari.ItemsSource = null;
            List<Doctor> sada = _doctorController.GetAll().ToList();
            var app = Application.Current as App;
            AddressController addressController = app.AddressController;
            List<Address> adrese = addressController.GetAll().ToList();

            foreach (Doctor doctor in sada)
            {
                doctor.Address.FullAddress = adrese.Find(x => doctor.Address.Id == x.Id).FullAddress;
            }
            dataGridLekari.ItemsSource = new ObservableCollection<Doctor>(sada);
            //dataGridLekari.ItemsSource = new ObservableCollection<Doctor>(_doctorController.GetAll());
        }

        private void editDoctor(object sender, RoutedEventArgs e)
        {
            if (dataGridLekari.SelectedItem != null)
            {
                DoctorAddWindow window = new DoctorAddWindow((Doctor)dataGridLekari.SelectedItem);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();

                dataGridLekari.ItemsSource = null;
                List<Doctor> sada = _doctorController.GetAll().ToList();
                var app = Application.Current as App;
                AddressController addressController = app.AddressController;
                List<Address> adrese = addressController.GetAll().ToList();

                foreach (Doctor doctor in sada)
                {
                    doctor.Address.FullAddress = adrese.Find(x => doctor.Address.Id == x.Id).FullAddress;
                }
                dataGridLekari.ItemsSource = new ObservableCollection<Doctor>(sada);
                //dataGridLekari.ItemsSource = new ObservableCollection<Doctor>(_doctorController.GetAll());
            }
            else
            {
                string messageBoxText = "Morate selektovati lekara da biste izvrsili izmenu!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }

        }

        private void Button_Click_Add_Shift(object sender, RoutedEventArgs e)
        {
            //ShiftWindow window = new ShiftWindow();
            //window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //window.ShowDialog();
        }

        private void Button_Click_Edit_Shift(object sender, RoutedEventArgs e)
        {
            //ShiftWindow window = new ShiftWindow();
            //window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //window.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_Read_Article(object sender, RoutedEventArgs e)
        {
            ReadArticleWindow window = new ReadArticleWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

        private void Button_Click_Add_Equipment(object sender, RoutedEventArgs e)
        {
            if (tabControlOprema.SelectedIndex == 0)
            {
                EquipmentDialog window = new EquipmentDialog(true);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();

                DataGridOpremaPotrosna.ItemsSource = null;

                List<Equipment> consumable_equipment = _equipmentController.getConsumableEquipment().ToList();
                ObservableCollection<Equipment> data_consumable = new ObservableCollection<Equipment>(consumable_equipment);
                this.DataGridOpremaPotrosna.ItemsSource = data_consumable;
                txtsearcConsumable.Clear();
                
            }
            else
            {
                EquipmentDialog window = new EquipmentDialog(false);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();

                DataGridOpremaNepotrosna.ItemsSource = null;

                List<Equipment> inconsumable_equipment = _equipmentController.getInconsumableEquipment().ToList();
                ObservableCollection<Equipment> data_inconsumable = new ObservableCollection<Equipment>(inconsumable_equipment);
                this.DataGridOpremaNepotrosna.ItemsSource = data_inconsumable;
                txtsearchInconsumable.Clear();
            }
        }

        private void Button_Click_Edit_Equipment(object sender, RoutedEventArgs e)
        {
            if (tabControlOprema.SelectedIndex == 0)
            {
                if (DataGridOpremaPotrosna.SelectedItem != null)
                {
                    EquipmentDialog window = new EquipmentDialog(true,(Equipment) DataGridOpremaPotrosna.SelectedItem);
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.ShowDialog();

                    DataGridOpremaPotrosna.ItemsSource = null;

                    List<Equipment> consumable_equipment = _equipmentController.getConsumableEquipment().ToList();
                    ObservableCollection<Equipment> data_consumable = new ObservableCollection<Equipment>(consumable_equipment);
                    this.DataGridOpremaPotrosna.ItemsSource = data_consumable;
                    txtsearcConsumable.Clear();
                }
                else
                {
                    string messageBoxText = "Morate selektovati opremu da biste izvrsili izmenu!";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                }


            }
            else
            {
                if (DataGridOpremaNepotrosna.SelectedItem != null)
                {
                    EquipmentDialog window = new EquipmentDialog(false, (Equipment) DataGridOpremaNepotrosna.SelectedItem);
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.ShowDialog();

                    DataGridOpremaNepotrosna.ItemsSource = null;

                    List<Equipment> inconsumable_equipment = _equipmentController.getInconsumableEquipment().ToList();
                    ObservableCollection<Equipment> data_inconsumable = new ObservableCollection<Equipment>(inconsumable_equipment);
                    this.DataGridOpremaNepotrosna.ItemsSource = data_inconsumable;

                    txtsearchInconsumable.Clear();
                }
                else
                {
                    string messageBoxText = "Morate selektovati opremu da biste izvrsili izmenu!";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }


        }

        private void Button_Click_Logout(object sender, RoutedEventArgs e)
        {

            
            MainWindow window = new MainWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            this.Close();
        }

        private void Button_Click_Add_Drug(object sender, RoutedEventArgs e)
        {
            DrugDialog window = new DrugDialog();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();

            DataGridLekovi.ItemsSource = null;
            this.DataGridLekovi.ItemsSource = new ObservableCollection<Drug>(_drugController.GetAll().ToList());
        }

        private void Button_Click_Edit_Drug(object sender, RoutedEventArgs e)
        {
            if (DataGridLekovi.SelectedItem != null)
            {
                DrugDialog window = new DrugDialog((Drug)DataGridLekovi.SelectedItem);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();

                DataGridLekovi.ItemsSource = null;
                this.DataGridLekovi.ItemsSource = new ObservableCollection<Drug>(_drugController.GetAll().ToList());
            }
            else
            {
                string messageBoxText = "Morate selektovati lek da biste izvrsili izmenu!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }


        private void Button_Click_Add_Room(object sender, RoutedEventArgs e)
        {
            RoomDialog window = new RoomDialog();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();

            DataGridRooms.ItemsSource = null;

            List<Room> rooms = _roomController.GetAll().ToList();
            ObservableCollection<Room> DataRooms = new ObservableCollection<Room>(rooms);

            this.DataGridRooms.ItemsSource = DataRooms;
            txtsearchRooms.Clear();
        }

        private void OpenAllShiftsWindow(object sender, RoutedEventArgs e)
        {
            OpenAllShiftsWindow window = new OpenAllShiftsWindow((Doctor)dataGridLekari.SelectedItem);
            window.ShowDialog();
        }

        private void Button_Click_Edit_Room(object sender, RoutedEventArgs e)
        {
            if (DataGridRooms.SelectedItem != null)
            {
                Room selected = (Room)DataGridRooms.SelectedItem;
                RoomDialog window = new RoomDialog(selected);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();

                DataGridRooms.ItemsSource = null;

                List<Room> rooms = _roomController.GetAll().ToList();
                ObservableCollection<Room> DataRooms = new ObservableCollection<Room>(rooms);

                this.DataGridRooms.ItemsSource = DataRooms;
                txtsearchRooms.Clear();

                this.DataGridRenovation.ItemsSource = null;
                this.DataGridRenovation.ItemsSource = new ObservableCollection<Renovation>(_renovationController.GetAll());

                this.dataGridLekari.ItemsSource = null;
                this.dataGridLekari.ItemsSource = new ObservableCollection<Doctor>(_doctorController.GetAll());
            }
            else
            {
                string messageBoxText = "Morate selektovati prostoriju da biste izvrsili izmenu!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

       

        private void Button_Click_Add_Renovation(object sender, RoutedEventArgs e)
        {
            RenovationDialog window = new RenovationDialog();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();

            DataGridRenovation.ItemsSource = null;
            List<Renovation> renovations = _renovationController.GetAll().ToList();
            ObservableCollection<Renovation> data_renovations = new ObservableCollection<Renovation>(renovations);
            this.DataGridRenovation.ItemsSource = data_renovations;
            txtSearchRenovations.Clear();
        }

        private void Button_Click_Edit_Renovation(object sender, RoutedEventArgs e)
        {
            if (DataGridRenovation.SelectedItem != null)
            {
                var reno = (Renovation)DataGridRenovation.SelectedItem;
                RenovationDialog window = new RenovationDialog((Renovation)DataGridRenovation.SelectedItem);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();

                DataGridRenovation.ItemsSource = null;

                List<Renovation> renovations = _renovationController.GetAll().ToList();
                ObservableCollection<Renovation> data_renovations = new ObservableCollection<Renovation>(renovations);
                this.DataGridRenovation.ItemsSource = data_renovations;
                txtSearchRenovations.Clear();

            }
            else
            {
                string messageBoxText = "Morate selektovati renoviranje da biste izvrsili izmenu!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void send_feedback(object sender, RoutedEventArgs e)
        {
            if (mojTextBox.Text.Equals(""))
            {
                string messageBoxText = "Polje za unos ne moze biti prazno!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                //string messageBoxText = "Vase misljenje je uspesno prosledjeno sistemu. Hvala Vam na izdvojenom vremenu!";
                //            string caption = "Vas utisak";
                //            MessageBoxButton button = MessageBoxButton.OK;
                //            MessageBoxImage icon = MessageBoxImage.Information;

                //            MessageBox.Show(messageBoxText, caption, button, icon);

                feedbackInfo.Content = "Vase misljenje je uspesno prosledjeno sistemu. Hvala Vam na izdvojenom vremenu!";
                feedbackInfo.Foreground = Brushes.Green;
                feedbackInfo.Visibility = Visibility.Visible;
               
                mojTextBox.Clear();
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //ObservableCollection<WorkingShift> Smene = new ObservableCollection<WorkingShift>();
            //Smene.Add(new WorkingShift { Ime = "Pera", Prezime = "Peric", ID= "AS3212", Period="18:00-23:00" });
            //Smene.Add(new WorkingShift { Ime = "Marko", Prezime = "Markovic", ID = "ASD12A", Period = "10:00-14:00" });
            //Smene.Add(new WorkingShift { Ime = "Seka", Prezime = "Seka", ID = "ASFE32", Period = "20:00-04:00" });
            //Smene.Add(new WorkingShift { Ime = "Nenad", Prezime = "Nedic", ID = "DAGD32", Period = "10:00-18:00" });
            //Smene.Add(new WorkingShift { Ime = "Sima", Prezime = "Simic", ID = "AS424D", Period = "07:00-14:00" });
            //dataGridSmene.ItemsSource = Smene;

            //DataGridTextColumn txtClmn = new DataGridTextColumn();
            //txtClmn.Header = "Datum neki";
            //txtClmn.CanUserSort = true;
            //txtClmn.Binding = new Binding("Shift.StartDate");
            //dataGridSmene.Columns.Add(txtClmn);

            //List<BusinessDay> temp = _businessDayController.GetAll().ToList();
            //dataGridSmene.ItemsSource = new ObservableCollection<BusinessDay>(temp);

            //dataGridSmene.Columns.Add(new DataGridColumn());

            articles = _articleController.GetAll().ToList();
            setArticles();

            doctorCount.Text = "" + _doctorController.GetAll().ToList().Count.ToString();


            //ObservableCollection<Lekar> Lekari = new ObservableCollection<Lekar>();
            //Lekari.Add(new Lekar { Ime="Marko", Prezime="Markovic",ID="ASD12A", JMBG="124534534", Email="marko@gmail.com", Telefon="02131243", Datum_rodjenja="21.4.1983.", Odeljenje="kardiologija",  Ocena="5.00"});
            //Lekari.Add(new Lekar { Ime = "Pera", Prezime = "Peric", ID = "AS3212", JMBG = "234321543", Email = "pera@gmail.com", Telefon = "4253212", Datum_rodjenja = "03.01.1944.", Odeljenje = "opsta praksa",  Ocena = "3.00" });
            //Lekari.Add(new Lekar { Ime = "Seka", Prezime = "Sekic", ID = "ASFE32", JMBG = "315434232", Email = "seka@gmail.com", Telefon = "23421223", Datum_rodjenja = "12.01.1976.", Odeljenje = "opsta praksa", Ocena = "4.00" });
            //Lekari.Add(new Lekar { Ime = "Nenad", Prezime = "Nedic", ID = "DAGD32", JMBG = "1254324", Email = "nenad@gmail.com", Telefon = "12343212", Datum_rodjenja = "01.01.1988.", Odeljenje = "orl", Ocena = "3.94" });
            //Lekari.Add(new Lekar { Ime = "Sima", Prezime = "Simic", ID = "AS424D", JMBG = "133122123", Email = "sima@gmail.com", Telefon = "5438575", Datum_rodjenja = "01.01.1991.", Odeljenje = "ocno", Ocena = "4.85" });
            List<Doctor> sada = _doctorController.GetAll().ToList();
            var app = Application.Current as App;
            AddressController addressController = app.AddressController;
            List<Address> adrese = addressController.GetAll().ToList();
            
            foreach (Doctor doctor in sada)
            {
                doctor.Address.FullAddress = adrese.Find(x => doctor.Address.Id == x.Id).FullAddress;
            }
            dataGridLekari.ItemsSource = new ObservableCollection<Doctor>(sada);

            List<Equipment> consumable_equipment = _equipmentController.getConsumableEquipment().ToList();
            ObservableCollection<Equipment> data_consumable = new ObservableCollection<Equipment>(consumable_equipment);
            this.DataGridOpremaPotrosna.ItemsSource = data_consumable;

            List<Equipment> inconsumable_equipment = _equipmentController.getInconsumableEquipment().ToList();
            ObservableCollection<Equipment> data_inconsumable = new ObservableCollection<Equipment>(inconsumable_equipment);
            this.DataGridOpremaNepotrosna.ItemsSource = data_inconsumable;

            List<Drug> drugs = _drugController.GetAll().ToList();
            ObservableCollection<Drug> lekovi = new ObservableCollection<Drug>(drugs);
            //ObservableCollection<DrugMockup> drug_collection = new ObservableCollection<DrugMockup>();
            //drug_collection.Add(new DrugMockup { Naziv = "Bromazepan", Kolicina = "20", Sifra = "131233", Status = "odobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            //drug_collection.Add(new DrugMockup { Naziv = "Brufen", Kolicina = "212", Sifra = "32424", Status = "neodobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            //drug_collection.Add(new DrugMockup { Naziv = "Xanax", Kolicina = "34", Sifra = "54352", Status = "odobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            //drug_collection.Add(new DrugMockup { Naziv = "Paracetamol", Kolicina = "10", Sifra = "6435754", Status = "neodobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            this.DataGridLekovi.ItemsSource = lekovi;


            List<Renovation> renovations = _renovationController.GetAll().ToList();
            ObservableCollection<Renovation> data_renovations = new ObservableCollection<Renovation>(renovations);
            this.DataGridRenovation.ItemsSource = data_renovations;


            List<Room> rooms = _roomController.GetAll().ToList();
            ObservableCollection<Room> DataRooms = new ObservableCollection<Room>(rooms);
            this.DataGridRooms.ItemsSource = DataRooms;



            StateCombo.DisplayMemberPath = "Name";
            StateCombo.SelectedValuePath = "Id";
            //App app = Application.Current as App;
            States = app.StateController.GetAll().ToList();
            States.Sort((x, y) => x.Name.CompareTo(y.Name));
            StateCombo.ItemsSource = States;

            TownCombo.DisplayMemberPath = "Name";
            TownCombo.SelectedValuePath = "Id";

            AddressCombo.DisplayMemberPath = "FullAddress";
            AddressCombo.SelectedValuePath = "Id";

            StateCombo.SelectedValue = director.Address.Town.State.GetId();
            TownCombo.SelectedValue = director.Address.Town.GetId();
            AddressCombo.SelectedValue = director.Address.GetId();


            //<TextBlock>
            //                   <Bold>CTRL+TAB</Bold> tab unapred <LineBreak />
            //                   <Bold>CTRL+SHIFT+TAB</Bold> tab unazad <LineBreak />
            //                   <Bold>CTRL+`</Bold> tab unapred za Opremu i Lekare <LineBreak/>
            //                   <Bold>CTRL+SHIFT+`</Bold> tab unazad za Opremu i Lekare <LineBreak/>
            //                   <Bold>CTRL+N</Bold> unos entiteta u sistem <LineBreak />
            //                   <Bold>CTRL+E</Bold> izmena entiteta<LineBreak />
            //                   <Bold>DELETE</Bold> brisanje entiteta<LineBreak />
            //                   <Bold>CTRL+T</Bold> otvaranje prozora za pregled tipova prostorija <LineBreak/>
            //                   <Bold>CTRL+I</Bold> generisanje izvestaja prostorija <LineBreak />
            //                   <Bold>TAB</Bold> kretanje unapred kroz polja za unos<LineBreak />
            //                   <Bold>SHIFT+TAB</Bold> kretanje unazad kroz polja za unos<LineBreak/>
            //                   <Bold>ESCAPE</Bold> zatvaranje prozora <LineBreak />
            //                   <Bold>ENTER</Bold> umesto dugmeta za potvrdu <LineBreak />
            //                </TextBlock>

            List<ShortcutData> shortcuts = new List<ShortcutData>();
            shortcuts.Add(new ShortcutData("CTRL + TAB", "tab unapred"));
            shortcuts.Add(new ShortcutData("CTRL + SHIFT + TAB", "tab unazad"));
            shortcuts.Add(new ShortcutData("CTRL + ~", "tab unapred za opremu"));
            shortcuts.Add(new ShortcutData("CTRL + SHIFT + ~", "tab unazad za opremu"));
            shortcuts.Add(new ShortcutData("CTRL + N", "unos entiteta u sistem"));
            shortcuts.Add(new ShortcutData("CTRL + E", "izmena entiteta"));
            shortcuts.Add(new ShortcutData("DELETE", "brisanje entiteta"));
            shortcuts.Add(new ShortcutData("CTRL + T", "otvaranje prozora za pregled tipova prostorija"));
            shortcuts.Add(new ShortcutData("CTRL + I", "generisanje izveštaja prostorija"));
            shortcuts.Add(new ShortcutData("TAB", "kretanje unapred kroz polja za unos"));
            shortcuts.Add(new ShortcutData("SHIFT + TAB", "kretanje unazad kroz polja za unos"));
            shortcuts.Add(new ShortcutData("ESCAPE", "zatvaranje prozora"));
            shortcuts.Add(new ShortcutData("ENTER", "umesto dugmeta za potvrdu"));
            shortcuts.Add(new ShortcutData("CTRL + →", "prenos sastojaka iz leve tabele u desnu"));
            shortcuts.Add(new ShortcutData("CTRL + ←", "prenos sastojaka iz desne tabele u levu"));
            shortcuts.Add(new ShortcutData("CTRL + A", "aktiviranje pretrage desne tabele sastojaka"));
            shortcuts.Add(new ShortcutData("CTRL + S", "aktiviranje pretrage leve tabele sastojaka"));
            shortcuts.Add(new ShortcutData("ALT + F4", "zatvaranje aplikacije"));

            DataGridShortcuts.ItemsSource = shortcuts;

        }

        private void setArticles()
        {
            foreach (Article article in articles)
            {
                //TextBlock textBlockTitle = new TextBlock();
                //textBlockTitle.Text = article.Topic;
                //textBlockTitle.Opacity = 0.68;

                TextBlock textContent = new TextBlock();
                textContent.Text = article.Text;
                textContent.TextWrapping = TextWrapping.Wrap;
                textContent.Opacity = 0.68;

                StackPanel WrapArticle = new StackPanel();
                WrapArticle.Orientation = Orientation.Vertical;
                WrapArticle.Margin = new Thickness(24, 8, 24, 16);

                Expander expander = new Expander();
                expander.HorizontalAlignment = HorizontalAlignment.Stretch;
                expander.Header = article.Topic;

                //WrapArticle.Children.Add(textBlockTitle);
                WrapArticle.Children.Add(textContent);

                expander.Content = WrapArticle;
                StackArticles.Children.Add(expander);

                Border border = new Border();
                border.Height = 1;
                border.HorizontalAlignment = HorizontalAlignment.Stretch;
                border.SnapsToDevicePixels = true;
                border.Background = Brushes.Gray;

                StackArticles.Children.Add(border);

            }
        }

        private void UpdateTownAddress(object sender, RoutedEventArgs e)
        {
            State state = StateCombo.SelectedItem as State;
            Towns = state.GetTown();
            Towns.Sort((x, y) => x.Name.CompareTo(y.Name));
            TownCombo.ItemsSource = Towns;
            AddressCombo.ItemsSource = null;

            editAccountInfo.Visibility = Visibility.Hidden;

        }

        private void UpdateAddress(object sender, RoutedEventArgs e)
        {
            Town town = TownCombo.SelectedItem as Town;
            if (town == null)
                return;
            Addresses = town.GetAddress();
            Addresses.Sort((x, y) => x.FullAddress.CompareTo(y.FullAddress));
            AddressCombo.ItemsSource = Addresses;

            editAccountInfo.Visibility = Visibility.Hidden;

        }

        private void PrikaziRasporedNepotrosne(object sender, RoutedEventArgs e)
        {
            DialogRasporedNepotrosne dialog = new DialogRasporedNepotrosne((Equipment) DataGridOpremaNepotrosna.SelectedItem);
            dialog.ShowDialog();
        }

        private void PrikaziSastojkeLeka(object sender, RoutedEventArgs e)
        {
            IngredientsDialog dialog = new IngredientsDialog((Drug) DataGridLekovi.SelectedItem);
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
        }

        private void PrikaziAlternativneLekove(object sender, RoutedEventArgs e)
        {
            AlternativeDrugDialog dialog = new AlternativeDrugDialog((Drug)DataGridLekovi.SelectedItem);
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
        }

        private void PrikaziSpisakOpremeProstorije(object sender, RoutedEventArgs e)
        {
            RoomEquipmentDialog dialog = new RoomEquipmentDialog((Room) DataGridRooms.SelectedItem);
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
        }

        private void GenerisanjeIzvestaja(object sender, RoutedEventArgs e)
        {
            GenerateReportDialog dialog = new GenerateReportDialog();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
        }



        private void TabItem_PreviewKeyDown_Drugs(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                addDrugBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editDrugBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                deleteDrugBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                searchDrugBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                txtsearchDrug.Focus();
                e.Handled = true;
            }
        }

        private void TabItem_PreviewKeyDown_Rooms(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                addRoomBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editRoomBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.I && Keyboard.Modifiers == ModifierKeys.Control)
            {
                generateRoomReportBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                searchRoomBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                txtsearchRooms.Focus();
                e.Handled = true;
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                deleteRoomBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.T && Keyboard.Modifiers == ModifierKeys.Control)
                addRoomTypeBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void TabItem_PreviewKeyDown_Doctors(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                addDoctorBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editDoctorBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                deleteDoctorBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        private void TabItem_PreviewKeyDown_Shifts(object sender, KeyEventArgs e)
        {
            //if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            //{
            //    addShiftBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            //}
            //else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            //{
            //    editShiftBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            //}
            //else if (e.Key == System.Windows.Input.Key.Delete)
            //{
            //    deleteShiftBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            //}
        }

        private void TabItem_PreviewKeyDown_Equipment_Consumable(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                addEquipmentConsumableBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editEquipmentConsumableBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                deleteEquipmentConsumableBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        private void TabItem_PreviewKeyDown_Equipment_Incomsumable(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                addEquipmentInconsumableBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editEquipmentInconsumableBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                deleteEquipmentInconsumableBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        private void TabItem_PreviewKeyDown_Renovations(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                addRenovationBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editRenovationBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                deleteRenovationBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        private void TabItem_PreviewKeyDown_Feedback(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                sendFeedbackBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        private void TabItem_PreviewKeyDown_Home(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.X  && Keyboard.Modifiers == ModifierKeys.Alt)
            {
                logoutBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        private void addRoomTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            RoomTypeWindow window = new RoomTypeWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();

            DataGridRooms.ItemsSource = null;
            DataGridRooms.ItemsSource = new ObservableCollection<Room>(_roomController.GetAll());

        }

        public void deleteRoomsFromRoomType(RoomType type)
        {

        }

        

        private void deleteRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridRooms.SelectedItem != null)
            {
                Room room = (Room)DataGridRooms.SelectedItem;

                string messageBoxText = "Da li ste sigurni da zelite da obrisete prostoriju pod sifrom " + room.RoomCode + "?";
                string caption = "Potvrda brisanja";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                if (result == MessageBoxResult.Yes)
                {
                    List<Renovation> allrenovations = _renovationController.GetAll().ToList();
                    foreach (Renovation renovation in allrenovations)
                    {
                        if (renovation.Room.RoomCode.Equals(room.RoomCode))
                            _renovationController.Delete(renovation);
                        
                    }
                    DataGridRenovation.ItemsSource = new ObservableCollection<Renovation>(_renovationController.GetAll());
                    

                    List<BusinessDay> allDays = _businessDayController.GetAll().ToList();
                    foreach (BusinessDay day in allDays)
                    {
                        if (day.room.RoomCode.Equals(room.RoomCode))
                        {
                            _businessDayController.Delete(day);
                            List<BusinessDay> temp = day.doctor.BusinessDay;
                            foreach (BusinessDay bd in temp)
                            {
                                if (bd.Id == day.Id)
                                {
                                    temp.Remove(bd);
                                    break;
                                }
                            }
                            _doctorController.Edit(day.doctor);
                        }
                    }

                    _roomController.Delete((Room)DataGridRooms.SelectedItem);

                    this.DataGridRooms.ItemsSource = null;
                    List<Room> rooms = _roomController.GetAll().ToList();
                    ObservableCollection<Room> DataRooms = new ObservableCollection<Room>(rooms);
                    this.DataGridRooms.ItemsSource = DataRooms;
                    txtsearchRooms.Clear();
                }
            }
            else
            {
                string messageBoxText = "Morate selektovati prostoriju da biste je izbrisali!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void searchRooms_KeyUp(object sender, KeyEventArgs e)
        {
            List<Room> rooms = _roomController.GetAll().ToList();
            ObservableCollection<Room> DataRooms = new ObservableCollection<Room>(rooms);

            this.DataGridRooms.ItemsSource = DataRooms.Where(input => input.RoomCode.ToUpper().Contains(txtsearchRooms.Text.ToUpper()));
        }

        private void searchDrugsKeyUp(object sender, KeyEventArgs e)
        {
            ObservableCollection<Drug> data_drug = new ObservableCollection<Drug>(_drugController.GetAll());

            this.DataGridLekovi.ItemsSource = data_drug.Where(input => input.Name.ToUpper().Contains(txtsearchDrug.Text.ToUpper()));
        }


        private void searchRenovations_KeyUp(object sender, KeyEventArgs e)
        {
            ObservableCollection<Renovation> data_renovation = new ObservableCollection<Renovation>(_renovationController.GetAll());

            this.DataGridRenovation.ItemsSource = data_renovation.Where(input => input.Room.RoomCode.ToUpper().Contains(txtSearchRenovations.Text.ToUpper()));
        }

        private void searchDoctorsKeyUp(object sender, KeyEventArgs e)
        {
            ObservableCollection<Doctor> data_doctor = new ObservableCollection<Doctor>(_doctorController.GetAll());

            this.dataGridLekari.ItemsSource = data_doctor.Where(input => input.FirstName.ToUpper().Contains(txtSearchDoctors.Text.ToUpper()));
        }

        private void deleteEquipment_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (tabControlOprema.SelectedIndex == 0)
            {
                if (DataGridOpremaPotrosna.SelectedItem != null)
                {
                    Equipment eq = (Equipment)DataGridOpremaPotrosna.SelectedItem;
                    string messageBoxText = "Da li ste sigurni da zelite da obrisete opremu pod nazivom " + eq.Name + "?";
                    string caption = "Potvrda brisanja";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Question;

                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    if (result == MessageBoxResult.Yes)
                    {
                        _equipmentController.Delete((Equipment)DataGridOpremaPotrosna.SelectedItem);

                        DataGridOpremaPotrosna.ItemsSource = null;

                        List<Equipment> consumable_equipment = _equipmentController.getConsumableEquipment().ToList();
                        ObservableCollection<Equipment> data_consumable = new ObservableCollection<Equipment>(consumable_equipment);
                        this.DataGridOpremaPotrosna.ItemsSource = data_consumable;
                    }
                }
                else
                {
                    string messageBoxText = "Morate selektovati opremu da biste je obrisali!";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                }


            }
            else
            {
                if (DataGridOpremaNepotrosna != null)
                {
                    Equipment eq = (Equipment)DataGridOpremaNepotrosna.SelectedItem;
                    string messageBoxText = "Da li ste sigurni da zelite da obrisete opremu pod nazivom " + eq.Name + "?";
                    string caption = "Potvrda brisanja";
                    MessageBoxButton button = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Question;

                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    if (result == MessageBoxResult.Yes)
                    {
                        List<Room> rooms = _roomController.GetRoomsContainingEquipment(eq).ToList();
                        foreach (Room room in rooms)
                        {
                            foreach (Equipment equipment in room.Equipment_inventory.Keys)
                            {
                                if (equipment.Id==eq.Id)
                                {
                                    room.Equipment_inventory.Remove(equipment);
                                    _roomController.Edit(room);
                                    break;
                                }
                            }
                        }

                        _equipmentController.Delete((Equipment)DataGridOpremaNepotrosna.SelectedItem);

                        DataGridOpremaNepotrosna.ItemsSource = null;

                        List<Equipment> inconsumable_equipment = _equipmentController.getInconsumableEquipment().ToList();
                        ObservableCollection<Equipment> data_inconsumable = new ObservableCollection<Equipment>(inconsumable_equipment);
                        this.DataGridOpremaNepotrosna.ItemsSource = data_inconsumable;
                    }
                }
                else
                {
                    string messageBoxText = "Morate selektovati opremu da biste je obrisali!";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (tabControlOprema.SelectedIndex == 0)
            {
                List<Equipment> equipment = _equipmentController.getConsumableEquipment().ToList();
                ObservableCollection<Equipment> data = new ObservableCollection<Equipment>(equipment);

                this.DataGridOpremaPotrosna.ItemsSource = data.Where(input => input.Name.ToUpper().Contains(txtsearcConsumable.Text.ToUpper()));
            }
            else
            {
                List<Equipment> equipment = _equipmentController.getInconsumableEquipment().ToList();
                ObservableCollection<Equipment> data = new ObservableCollection<Equipment>(equipment);

                this.DataGridOpremaNepotrosna.ItemsSource = data.Where(input => input.Name.ToUpper().Contains(txtsearchInconsumable.Text.ToUpper()));
            }
        }

        private void deleteRenovationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridRenovation.SelectedItem != null)
            {
                Renovation renovation = (Renovation)DataGridRenovation.SelectedItem;

                string messageBoxText = "Da li ste sigurni da zelite da obrisete renoviranje prostorije pod sifrom " + renovation.Room.RoomCode + "?";
                string caption = "Potvrda brisanja";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;

                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                if (result == MessageBoxResult.Yes)
                {
                    _renovationController.Delete((Renovation)DataGridRenovation.SelectedItem);

                    DataGridRenovation.ItemsSource = null;
                    List<Renovation> renovations = _renovationController.GetAll().ToList();
                    ObservableCollection<Renovation> data_renovations = new ObservableCollection<Renovation>(renovations);
                    this.DataGridRenovation.ItemsSource = data_renovations;
                    txtSearchRenovations.Clear();
                }
            }
            else
            {
                string messageBoxText = "Morate selektovati renoviranje da biste ga obrisali!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void UpdateDataBtnClick(object sender, RoutedEventArgs e)
        {



            director.FirstName = txtFirstNameEdit.Text;
            director.LastName = txtLastNameEdit.Text;
            director.Phone = txtPhoneEdit.Text;
            director.Email = txtEmailEdit.Text;
            director.Jmbg = txtJMBGEdit.Text;
            director.DateOfBirth = (DateTime) birthDatePickerEdit.SelectedDate;

            var state = StateCombo.SelectedItem as State;
            var town = TownCombo.SelectedItem as Town;
            var selectedAddress = AddressCombo.SelectedItem as Address;
            var address = new Address(selectedAddress.GetId(), town.GetId(), state.GetId());
            director.Address = address;

            _directorController.Edit(director);
            director = _directorController.Get(1);
            setDirectorField();

            //string messageBoxText = "Uspesno izmenjeni podaci!";
            //string caption = "Informacija";
            //MessageBoxButton button = MessageBoxButton.OK;
            //MessageBoxImage icon = MessageBoxImage.Information;

            //MessageBox.Show(messageBoxText, caption, button, icon);


            editAccountInfo.Content = "Uspesno izmenjeni podaci!";
            editAccountInfo.Visibility = Visibility.Visible;
            editAccountInfo.Foreground = Brushes.Green;


        }

        private void searchTxtAppear_Button_Click(object sender, RoutedEventArgs e)
        {
            //searchRenovationsBtn.Background = Brushes.Gray;

            //if (searchRenovationsBtn.Background == Brushes.Purple)
            //{
            //    searchRenovationsBtn.Background = Brushes.Gray;
            //}
            //else
            //{
            //    searchRenovationsBtn.Background = Brushes.Purple;
            //}

            //searchRenovationsBtn.Background = searchRenovationsBtn.Background == Brushes.Gray ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF673AB7")) : Brushes.Gray;

            //if (searchRenovationsBtn.Background == (SolidColorBrush) new BrushConverter().ConvertFrom("#FF673AB7")) {
            //    searchRenovationsBtn.Background = Brushes.Gray;
            //    txtSearchRenovations.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    searchRenovationsBtn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
            //    txtSearchRenovations.Visibility = Visibility.Hidden;
            //}

            if (searchRenovationsBtn.Background == Brushes.Gray)
            {
                searchRenovationsBtn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
                txtSearchRenovations.Visibility = Visibility.Hidden;
            }
            else
            {
                searchRenovationsBtn.Background = Brushes.Gray;
                txtSearchRenovations.Visibility = Visibility.Visible;
            }
        }

        private void searchTxtAppear_Button_Click_Room(object sender, RoutedEventArgs e)
        {
            if (searchRoomBtn.Background == Brushes.Gray)
            {
                searchRoomBtn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
                txtsearchRooms.Visibility = Visibility.Hidden;
                //TODO: vrati nazad tabelu

                List<Room> rooms = _roomController.GetAll().ToList();
                ObservableCollection<Room> DataRooms = new ObservableCollection<Room>(rooms);
                this.DataGridRooms.ItemsSource = DataRooms;
                txtsearchRooms.Clear();
            }
            else
            {
                searchRoomBtn.Background = Brushes.Gray;
                txtsearchRooms.Visibility = Visibility.Visible;
            }
        }

        private void tabControlMini_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.LeftCtrl | e.Key == Key.Tab)
            //{
            //    tabControlMain.SelectedIndex++;
            //    e.Handled = true;
            //}

            if (e.Key == Key.Tab && (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                tabControlMain.SelectedIndex--;
                e.Handled = true;
            }

            else if (e.Key == Key.Tab && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                tabControlMain.SelectedIndex++;
                e.Handled = true;
            }

            else if (e.Key == Key.Oem3 && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                tabControlOprema.SelectedIndex = tabControlOprema.SelectedIndex == 0 ? 1 : 0;
                //tabControlLekari.SelectedIndex = tabControlLekari.SelectedIndex == 0 ? 1 : 0;
                e.Handled = true;
            }
        }

        private void searchTxtAppear_Button_Click_Drug(object sender, RoutedEventArgs e)
        {
            if (searchDrugBtn.Background == Brushes.Gray)
            {
                searchDrugBtn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
                txtsearchDrug.Visibility = Visibility.Hidden;
                //TODO: vrati nazad tabelu

                this.DataGridLekovi.ItemsSource = new ObservableCollection<Drug>(_drugController.GetAll());
                txtsearchDrug.Clear();
            }
            else
            {
                searchDrugBtn.Background = Brushes.Gray;
                txtsearchDrug.Visibility = Visibility.Visible;
            }
        }

        private void searchTxtAppear_Button_Click_ConsumableEq(object sender, RoutedEventArgs e)
        {
            if (searchConsumableEquipmentBtn.Background == Brushes.Gray)
            {
                searchConsumableEquipmentBtn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
                txtsearcConsumable.Visibility = Visibility.Hidden;
                //TODO: vrati nazad tabelu

                List<Equipment> equipments = _equipmentController.getConsumableEquipment().ToList();
                ObservableCollection<Equipment> data_equipments = new ObservableCollection<Equipment>(equipments);
                this.DataGridOpremaPotrosna.ItemsSource = data_equipments;
                txtsearcConsumable.Clear();
            }
            else
            {
                searchConsumableEquipmentBtn.Background = Brushes.Gray;
                txtsearcConsumable.Visibility = Visibility.Visible;
            }
        }

        private void searchTxtAppear_Button_Click_InconsumableEq(object sender, RoutedEventArgs e)
        {
            if (searchInconsumableEquipmentBtn.Background == Brushes.Gray)
            {
                searchInconsumableEquipmentBtn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
                txtsearchInconsumable.Visibility = Visibility.Hidden;
                //TODO: vrati nazad tabelu

                List<Equipment> equipments = _equipmentController.getInconsumableEquipment().ToList();
                ObservableCollection<Equipment> data_equipments = new ObservableCollection<Equipment>(equipments);
                this.DataGridOpremaNepotrosna.ItemsSource = data_equipments;
                txtsearchInconsumable.Clear();
            }
            else
            {
                searchInconsumableEquipmentBtn.Background = Brushes.Gray;
                txtsearchInconsumable.Visibility = Visibility.Visible;
            }
        }

        private void deleteDrugBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridLekovi.SelectedItem != null)
            {
                Drug drug = (Drug)DataGridLekovi.SelectedItem;

                string messageBoxText = "Da li ste sigurni da zelite da obrisete lek pod nazivom " + drug.Name + "?";
                string caption = "Potvrda brisanja";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;

                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                if (result == MessageBoxResult.Yes)
                {
                    _drugController.Delete((Drug)DataGridLekovi.SelectedItem);

                    DataGridRenovation.ItemsSource = null;
                    List<Drug> drugs = _drugController.GetAll().ToList();
                    ObservableCollection<Drug> data_drugs = new ObservableCollection<Drug>(drugs);
                    this.DataGridLekovi.ItemsSource = data_drugs;
                    txtsearchDrug.Clear();
                }
            }
            else
            {
                string messageBoxText = "Morate selektovati lek da biste ga obrisali!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void deleteDoctorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridLekari.SelectedItem != null)
            {
                Doctor doctor = (Doctor)dataGridLekari.SelectedItem;

                string messageBoxText = "Da li ste sigurni da zelite da obrisete lekara " + doctor.FirstName + " " + doctor.LastName + " ?";
                string caption = "Potvrda brisanja";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                if (result == MessageBoxResult.Yes)
                {
                    foreach (BusinessDay businessDay in doctor.BusinessDay)
                        _businessDayController.Delete(businessDay);
                    _doctorController.Delete((Doctor)dataGridLekari.SelectedItem);

                    this.DataGridRooms.ItemsSource = null;
                    List<Doctor> doctors = _doctorController.GetAll().ToList();
                    ObservableCollection<Doctor> data_doctors = new ObservableCollection<Doctor>(doctors);
                    this.dataGridLekari.ItemsSource = data_doctors;
                    txtSearchDoctors.Clear();
                }
            }
            else
            {
                string messageBoxText = "Morate selektovati lekara da biste ga izbrisali!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void searchTxtAppear_Button_Click_Doctor(object sender, RoutedEventArgs e)
        {
            if (searchDoctorBtn.Background == Brushes.Gray)
            {
                searchDoctorBtn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
                txtSearchDoctors.Visibility = Visibility.Hidden;
                //TODO: vrati nazad tabelu

                this.dataGridLekari.ItemsSource = new ObservableCollection<Doctor>(_doctorController.GetAll());
                txtSearchDoctors.Clear();
            }
            else
            {
                searchDoctorBtn.Background = Brushes.Gray;
                txtSearchDoctors.Visibility = Visibility.Visible;
            }
        }

        

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            doctorCount.Text = "" + _doctorController.GetAll().ToList().Count.ToString();
        }

        private void TabItem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
                        if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                addDoctorBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editDoctorBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                deleteDoctorBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        private void txtSearchArticles_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearchArticles.Text.Equals(""))
            {
                foreach (Article article in articles)
                {
                    //TextBlock textBlockTitle = new TextBlock();
                    //textBlockTitle.Text = article.Topic;
                    //textBlockTitle.Opacity = 0.68;
                    if (article.Topic.ToUpper().Contains(txtSearchArticles.Text.ToUpper()))
                    {

                        TextBlock textContent = new TextBlock();
                        textContent.Text = article.Text;
                        textContent.TextWrapping = TextWrapping.Wrap;
                        textContent.Opacity = 0.68;

                        StackPanel WrapArticle = new StackPanel();
                        WrapArticle.Orientation = Orientation.Vertical;
                        WrapArticle.Margin = new Thickness(24, 8, 24, 16);

                        Expander expander = new Expander();
                        expander.HorizontalAlignment = HorizontalAlignment.Stretch;
                        expander.Header = article.Topic;

                        //WrapArticle.Children.Add(textBlockTitle);
                        WrapArticle.Children.Add(textContent);

                        expander.Content = WrapArticle;
                        StackArticles.Children.Add(expander);

                        Border border = new Border();
                        border.Height = 1;
                        border.HorizontalAlignment = HorizontalAlignment.Stretch;
                        border.SnapsToDevicePixels = true;
                        border.Background = Brushes.Gray;

                        StackArticles.Children.Add(border);
                    }

                }
            }
        }

        private void txtSearchArticles_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            //StackArticles.Children.Clear();
        }

        private void articleSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            StackArticles.Children.Clear();
            foreach (Article article in articles)
            {
                //TextBlock textBlockTitle = new TextBlock();
                //textBlockTitle.Text = article.Topic;
                //textBlockTitle.Opacity = 0.68;
                if (article.Topic.ToUpper().Contains(txtSearchArticles.Text.ToUpper()))
                {

                    TextBlock textContent = new TextBlock();
                    textContent.Text = article.Text;
                    textContent.TextWrapping = TextWrapping.Wrap;
                    textContent.Opacity = 0.68;

                    StackPanel WrapArticle = new StackPanel();
                    WrapArticle.Orientation = Orientation.Vertical;
                    WrapArticle.Margin = new Thickness(24, 8, 24, 16);

                    Expander expander = new Expander();
                    expander.HorizontalAlignment = HorizontalAlignment.Stretch;
                    expander.Header = article.Topic;

                    //WrapArticle.Children.Add(textBlockTitle);
                    WrapArticle.Children.Add(textContent);

                    expander.Content = WrapArticle;
                    StackArticles.Children.Add(expander);

                    Border border = new Border();
                    border.Height = 1;
                    border.HorizontalAlignment = HorizontalAlignment.Stretch;
                    border.SnapsToDevicePixels = true;
                    border.Background = Brushes.Gray;

                    StackArticles.Children.Add(border);
                }

            }
        }

        private void articleSearchBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //StackArticles.Children.Clear();
        }

        private void txtSearchArticles_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                articleSearchBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

       private String _passwordOld;
        public String PasswordOld
        {
            get
            {
                return _passwordOld;
            }
            set
            {
                if (value != _passwordOld)
                {
                    _passwordOld = value;
                    OnPropertyChanged("PasswordOld");
                }
            }
        }
        private String _passwordNewCheck;
        public String PasswordNewCheck
        {
            get
            {
                return _passwordNewCheck;
            }
            set
            {
                if (value != _passwordNewCheck)
                {
                    _passwordNewCheck = value;
                    OnPropertyChanged("PasswordNewCheck");
                }
            }
        }

        private String _passwordNew;
        public String PasswordNew
        {
            get
            {
                return _passwordNew;
            }
            set
            {
                if (value != _passwordNew)
                {
                    _passwordNew = value;
                    OnPropertyChanged("PasswordNew");
                }
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (tabControlMain.SelectedIndex == 1)
                {
                    searchDoctorBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    txtSearchDoctors.Focus();
                    e.Handled = true;
                }
                else if (tabControlMain.SelectedIndex == 2)
                {
                    //searchRoomBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    //txtsearchRooms.Focus();
                    //e.Handled = true;
                }
                else if (tabControlMain.SelectedIndex == 3)
                {
                    if (tabControlOprema.SelectedIndex == 0)
                    {
                        searchConsumableEquipmentBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                        txtsearcConsumable.Focus();
                        e.Handled = true;
                    }
                    else if (tabControlOprema.SelectedIndex == 1)
                    {
                        searchInconsumableEquipmentBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                        txtsearchInconsumable.Focus();
                        e.Handled = true;
                    }
                }
                else if (tabControlMain.SelectedIndex == 4)
                {
                    searchDrugBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    txtsearchDrug.Focus();
                    e.Handled = true;
                }
                else if (tabControlMain.SelectedIndex == 5)
                {
                    searchRoomBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    txtsearchRooms.Focus();
                    e.Handled = true;
                }
                else if (tabControlMain.SelectedIndex == 6)
                {
                    searchRenovationsBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    txtSearchRenovations.Focus();
                    e.Handled = true;
                }

            }
        }

        private void changePicBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() ==true)
            {
                fileName = op.FileName;
                UserImage.Source = new BitmapImage(new Uri(fileName));
            }
        }

        private void editPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!txtOldPassword.Text.Equals(director.Password))
            {
                //string messageBoxText = "Pogresno ste uneli trenutnu lozinku!";
                //string caption = "Greska";
                //MessageBoxButton button = MessageBoxButton.OK;
                //MessageBoxImage icon = MessageBoxImage.Error;

                //MessageBox.Show(messageBoxText, caption, button, icon);
                //return;

                passwordInfo.Content = "Pogresno ste uneli trenutnu lozinku!";
                passwordInfo.Visibility = Visibility.Visible;
                passwordInfo.Foreground = Brushes.Red;
                return;
            }
            else if (txtOldPassword.Text.Equals(director.Password) && !txtNewPassword.Text.Equals(txtNewPasswordCheck.Text))
            {
                //string messageBoxText = "Potvrda nove lozinke se ne poklapa!";
                //string caption = "Greska";
                //MessageBoxButton button = MessageBoxButton.OK;
                //MessageBoxImage icon = MessageBoxImage.Error;

                //MessageBox.Show(messageBoxText, caption, button, icon);
                //return;

                passwordInfo.Content = "Potvrda nove lozinke se ne poklapa!";
                passwordInfo.Visibility = Visibility.Visible;
                passwordInfo.Foreground = Brushes.Red;
                return;
            }
            else if (txtOldPassword.Text.Equals(director.Password) && txtNewPassword.Text.Equals(txtNewPasswordCheck.Text))
            {
                //string messageBoxText = "Uspesno izmenjeni podaci!";
                //string caption = "Informacija";
                //MessageBoxButton button = MessageBoxButton.OK;
                //MessageBoxImage icon = MessageBoxImage.Information;

                //MessageBox.Show(messageBoxText, caption, button, icon);

                passwordInfo.Content = "Uspesno izmenjeni podaci!";
                passwordInfo.Visibility = Visibility.Visible;
                passwordInfo.Foreground = Brushes.Green;

                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtNewPasswordCheck.Clear();
                return;
            }
        }

        private void mojTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            feedbackInfo.Visibility = Visibility.Hidden;
            passwordInfo.Visibility = Visibility.Hidden;
            editAccountInfo.Visibility = Visibility.Hidden;
        }

        private void AddressCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editAccountInfo.Visibility = Visibility.Hidden;
        }

        private void birthDatePickerEdit_CalendarOpened(object sender, RoutedEventArgs e)
        {
            editAccountInfo.Visibility = Visibility.Hidden;
        }
    }
}
