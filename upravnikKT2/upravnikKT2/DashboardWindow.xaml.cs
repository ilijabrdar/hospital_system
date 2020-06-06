using bolnica.Controller;
using Controller;
using Model.Director;
using Model.PatientSecretary;
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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

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

            FirstName = "Marko";
            LastName = "Markovic";
            EMAIL = "marko@bolnica.com";
            Phone = "12312333";
            JMBG = "1122334455645";

            var app = Application.Current as App;
            _roomController = app.RoomController;
            _equipmentController = app.EquipmentController;
            _renovationController = app.RenovationController;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoctorAddWindow window = new DoctorAddWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

        private void editDoctor(object sender, RoutedEventArgs e)
        {
            DoctorAddWindow window = new DoctorAddWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

        private void Button_Click_Add_Shift(object sender, RoutedEventArgs e)
        {
            ShiftWindow window = new ShiftWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

        private void Button_Click_Edit_Shift(object sender, RoutedEventArgs e)
        {
            ShiftWindow window = new ShiftWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
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
        }

        private void Button_Click_Edit_Drug(object sender, RoutedEventArgs e)
        {
            DrugDialog window = new DrugDialog();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
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
            string messageBoxText = "Vase misljenje je uspesno prosledjeno sistemu. Hvala Vam na izdvojenom vremenu!";
                        string caption = "Vas utisak";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Information;

                        MessageBox.Show(messageBoxText, caption, button, icon);


                        mojTextBox.Clear();
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<WorkingShift> Smene = new ObservableCollection<WorkingShift>();
            Smene.Add(new WorkingShift { Ime = "Pera", Prezime = "Peric", ID= "AS3212", Period="18:00-23:00" });
            Smene.Add(new WorkingShift { Ime = "Marko", Prezime = "Markovic", ID = "ASD12A", Period = "10:00-14:00" });
            Smene.Add(new WorkingShift { Ime = "Seka", Prezime = "Seka", ID = "ASFE32", Period = "20:00-04:00" });
            Smene.Add(new WorkingShift { Ime = "Nenad", Prezime = "Nedic", ID = "DAGD32", Period = "10:00-18:00" });
            Smene.Add(new WorkingShift { Ime = "Sima", Prezime = "Simic", ID = "AS424D", Period = "07:00-14:00" });
            dataGridSmene.ItemsSource = Smene;

            ObservableCollection<Lekar> Lekari = new ObservableCollection<Lekar>();
            Lekari.Add(new Lekar { Ime="Marko", Prezime="Markovic",ID="ASD12A", JMBG="124534534", Email="marko@gmail.com", Telefon="02131243", Datum_rodjenja="21.4.1983.", Odeljenje="kardiologija",  Ocena="5.00"});
            Lekari.Add(new Lekar { Ime = "Pera", Prezime = "Peric", ID = "AS3212", JMBG = "234321543", Email = "pera@gmail.com", Telefon = "4253212", Datum_rodjenja = "03.01.1944.", Odeljenje = "opsta praksa",  Ocena = "3.00" });
            Lekari.Add(new Lekar { Ime = "Seka", Prezime = "Sekic", ID = "ASFE32", JMBG = "315434232", Email = "seka@gmail.com", Telefon = "23421223", Datum_rodjenja = "12.01.1976.", Odeljenje = "opsta praksa", Ocena = "4.00" });
            Lekari.Add(new Lekar { Ime = "Nenad", Prezime = "Nedic", ID = "DAGD32", JMBG = "1254324", Email = "nenad@gmail.com", Telefon = "12343212", Datum_rodjenja = "01.01.1988.", Odeljenje = "orl", Ocena = "3.94" });
            Lekari.Add(new Lekar { Ime = "Sima", Prezime = "Simic", ID = "AS424D", JMBG = "133122123", Email = "sima@gmail.com", Telefon = "5438575", Datum_rodjenja = "01.01.1991.", Odeljenje = "ocno", Ocena = "4.85" });

            dataGridLekari.ItemsSource = Lekari;

            List<Equipment> consumable_equipment = _equipmentController.getConsumableEquipment().ToList();
            ObservableCollection<Equipment> data_consumable = new ObservableCollection<Equipment>(consumable_equipment);
            this.DataGridOpremaPotrosna.ItemsSource = data_consumable;

            List<Equipment> inconsumable_equipment = _equipmentController.getInconsumableEquipment().ToList();
            ObservableCollection<Equipment> data_inconsumable = new ObservableCollection<Equipment>(inconsumable_equipment);
            this.DataGridOpremaNepotrosna.ItemsSource = data_inconsumable;

            ObservableCollection<DrugMockup> DataGridDrugs = new ObservableCollection<DrugMockup>();
            DataGridDrugs.Add(new DrugMockup { Naziv = "Bromazepan", Kolicina = "20", Sifra = "131233", Status = "odobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            DataGridDrugs.Add(new DrugMockup { Naziv = "Brufen", Kolicina = "212", Sifra = "32424", Status = "neodobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            DataGridDrugs.Add(new DrugMockup { Naziv = "Xanax", Kolicina = "34", Sifra = "54352", Status = "odobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            DataGridDrugs.Add(new DrugMockup { Naziv = "Paracetamol", Kolicina = "10", Sifra = "6435754", Status = "neodobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            this.DataGridLekovi.ItemsSource = DataGridDrugs;


            List<Renovation> renovations = _renovationController.GetAll().ToList();
            ObservableCollection<Renovation> data_renovations = new ObservableCollection<Renovation>(renovations);
            this.DataGridRenovation.ItemsSource = data_renovations;


            List<Room> rooms = _roomController.GetAll().ToList();
            ObservableCollection<Room> DataRooms = new ObservableCollection<Room>(rooms);
            this.DataGridRooms.ItemsSource = DataRooms;
            

        }

        private void PrikaziRasporedNepotrosne(object sender, RoutedEventArgs e)
        {
            DialogRasporedNepotrosne dialog = new DialogRasporedNepotrosne((Equipment) DataGridOpremaNepotrosna.SelectedItem);
            dialog.ShowDialog();
        }

        private void PrikaziSastojkeLeka(object sender, RoutedEventArgs e)
        {
            IngredientsDialog dialog = new IngredientsDialog();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
        }

        private void PrikaziAlternativneLekove(object sender, RoutedEventArgs e)
        {
            AlternativeDrugDialog dialog = new AlternativeDrugDialog();
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
            if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                addShiftBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editShiftBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                deleteShiftBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
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
        }

        private void deleteRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridRooms.SelectedItem != null)
            {
                Room room = (Room)DataGridRooms.SelectedItem;

                string messageBoxText = "Da li ste sigurni da zelite da obrisete opremu pod sifrom " + room.RoomCode + "?";
                string caption = "Potvrda brisanja";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                if (result == MessageBoxResult.Yes)
                {
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

            this.DataGridRooms.ItemsSource = DataRooms.Where(input => input.RoomCode.Contains(txtsearchRooms.Text));
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

                this.DataGridOpremaPotrosna.ItemsSource = data.Where(input => input.Name.Contains(txtsearcConsumable.Text));
            }
            else
            {
                List<Equipment> equipment = _equipmentController.getInconsumableEquipment().ToList();
                ObservableCollection<Equipment> data = new ObservableCollection<Equipment>(equipment);

                this.DataGridOpremaNepotrosna.ItemsSource = data.Where(input => input.Name.Contains(txtsearchInconsumable.Text));
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Uspesno izmenjeni podaci!";
            string caption = "Informacija";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;

            MessageBox.Show(messageBoxText, caption, button, icon);
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
                tabControlLekari.SelectedIndex = tabControlLekari.SelectedIndex == 0 ? 1 : 0;
                e.Handled = true;
            }
        }

        private void searchTxtAppear_Button_Click_Drug(object sender, RoutedEventArgs e)
        {
            //if (searchDrugBtn.Background == Brushes.Gray)
            //{
            //    searchDrugBtn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
            //    txtsearchDrug.Visibility = Visibility.Hidden;
            //    //TODO: vrati nazad tabelu

            //    List<Drug> drugs;
            //    ObservableCollection<Drug> DataDrugs = new ObservableCollection<Drug>(drugs);
            //    this.DataGridLekovi.ItemsSource = DataDrugs;
            //    txtsearchDrug.Clear();
            //}
            //else
            //{
            //    searchDrugBtn.Background = Brushes.Gray;
            //    txtsearchDrug.Visibility = Visibility.Visible;
            //}
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
    }
}
