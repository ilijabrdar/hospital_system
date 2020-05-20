using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
            

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
            EquipmentDialog window = new EquipmentDialog();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

        private void Button_Click_Edit_Equipment(object sender, RoutedEventArgs e)
        {
            EquipmentDialog window = new EquipmentDialog();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
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
        }
        private void Button_Click_Edit_Room(object sender, RoutedEventArgs e)
        {
            RoomDialog window = new RoomDialog();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

       

        private void Button_Click_Add_Renovation(object sender, RoutedEventArgs e)
        {
            RenovationDialog window = new RenovationDialog();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }

        private void Button_Click_Edit_Renovation(object sender, RoutedEventArgs e)
        {
            RenovationDialog window = new RenovationDialog();
            window.ShowDialog();
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

            ObservableCollection<Oprema> DataGridOpremaPotrosna = new ObservableCollection<Oprema>();
            DataGridOpremaPotrosna.Add(new Oprema { Naziv = "Makaze", Kolicina = "30" });
            DataGridOpremaPotrosna.Add(new Oprema { Naziv = "Flasteri", Kolicina = "10" });
            DataGridOpremaPotrosna.Add(new Oprema { Naziv = "Gaza 5m", Kolicina = "21" });
            DataGridOpremaPotrosna.Add(new Oprema { Naziv = "Gaza 10m", Kolicina = "123" });
            DataGridOpremaPotrosna.Add(new Oprema { Naziv = "Hanzaplast", Kolicina = "203" });
            this.DataGridOpremaPotrosna.ItemsSource = DataGridOpremaPotrosna;

            ObservableCollection<Oprema> DataGridOpremaNepotrosna = new ObservableCollection<Oprema>();
            DataGridOpremaNepotrosna.Add(new Oprema { Naziv = "Sto", Kolicina = "40" });
            DataGridOpremaNepotrosna.Add(new Oprema { Naziv = "Stolica", Kolicina = "10" });
            DataGridOpremaNepotrosna.Add(new Oprema { Naziv = "Ormar", Kolicina = "45" });
            DataGridOpremaNepotrosna.Add(new Oprema { Naziv = "Ogledalo", Kolicina = "122" });
            this.DataGridOpremaNepotrosna.ItemsSource = DataGridOpremaNepotrosna;

            ObservableCollection<Drug> DataGridDrugs = new ObservableCollection<Drug>();
            DataGridDrugs.Add(new Drug { Naziv = "Bromazepan", Kolicina = "20", Sifra = "131233", Status = "odobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            DataGridDrugs.Add(new Drug { Naziv = "Brufen", Kolicina = "212", Sifra = "32424", Status = "neodobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            DataGridDrugs.Add(new Drug { Naziv = "Xanax", Kolicina = "34", Sifra = "54352", Status = "odobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            DataGridDrugs.Add(new Drug { Naziv = "Paracetamol", Kolicina = "10", Sifra = "6435754", Status = "neodobren", Sastojci = "asdasd asdasd, fdsfds,a sfadsf, asadf", Alternativa = "asdas asd, asd fdsf2q3e 123" });
            this.DataGridLekovi.ItemsSource = DataGridDrugs;

            ObservableCollection<Room> DataGridRooms = new ObservableCollection<Room>();
            DataGridRooms.Add(new Room { Sifra = "1243", Tip = "operaciona" });
            DataGridRooms.Add(new Room { Sifra = "6475", Tip = "kontrolna" });
            DataGridRooms.Add(new Room { Sifra = "9876", Tip = "rehabilitaciona" });
            DataGridRooms.Add(new Room { Sifra = "8674", Tip = "rehabilitaciona" });
            DataGridRooms.Add(new Room { Sifra = "5532", Tip = "operaciona" });
            DataGridRooms.Add(new Room { Sifra = "7684", Tip = "operaciona" });
            this.DataGridRooms.ItemsSource = DataGridRooms;

            ObservableCollection<Renovation> renovations = new ObservableCollection<Renovation>();
            renovations.Add(new Renovation { Sifra = "5432", Datum = "16.03.2012 - 14.06.2013.", Opis = "zamena instalacija", Status = "zavrseno", Tip="operaciona"});
            renovations.Add(new Renovation { Sifra = "6547", Datum = "03.05.2020 - 14.06.2020.", Opis = "zamena sijalica", Status = "u toku", Tip = "kontrolna" });
            renovations.Add(new Renovation { Sifra = "8764", Datum = "16.03.2020 - 14.06.2020.", Opis = "zamena kreveta", Status = "u toku", Tip = "operaciona" });
            renovations.Add(new Renovation { Sifra = "9678", Datum = "16.03.2021 - 14.06.2021.", Opis = "zamena vrata", Status = "zakazano", Tip = "kontrolna" });
            renovations.Add(new Renovation { Sifra = "0875", Datum = "16.03.2013 - 14.06.2014.", Opis = "zamena sijalica", Status = "otkazano", Tip = "rehabilitaciona" });
            this.DataGridRenovation.ItemsSource = renovations;

            
        }

        private void PrikaziRasporedNepotrosne(object sender, RoutedEventArgs e)
        {
            DialogRasporedNepotrosne dialog = new DialogRasporedNepotrosne();
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
            RoomEquipmentDialog dialog = new RoomEquipmentDialog();
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
            else if (e.Key == System.Windows.Input.Key.R && Keyboard.Modifiers == ModifierKeys.Control)
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
    }
}
