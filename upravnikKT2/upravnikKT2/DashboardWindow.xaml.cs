using bolnica.Controller;
using Controller;
using Model.Director;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        private readonly IRoomController _roomController;
        private readonly IEquipmentController _equipmentController;
        public DashboardWindow()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _roomController = app.RoomController;
            _equipmentController = app.EquipmentController;
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
                if (DataGridOpremaNepotrosna != null)
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


            ObservableCollection<RenovationMockup> renovations = new ObservableCollection<RenovationMockup>();
            renovations.Add(new RenovationMockup { Sifra = "5432", Datum = "16.03.2012 - 14.06.2013.", Opis = "zamena instalacija", Status = "zavrseno", Tip="operaciona"});
            renovations.Add(new RenovationMockup { Sifra = "6547", Datum = "03.05.2020 - 14.06.2020.", Opis = "zamena sijalica", Status = "u toku", Tip = "kontrolna" });
            renovations.Add(new RenovationMockup { Sifra = "8764", Datum = "16.03.2020 - 14.06.2020.", Opis = "zamena kreveta", Status = "u toku", Tip = "operaciona" });
            renovations.Add(new RenovationMockup { Sifra = "9678", Datum = "16.03.2021 - 14.06.2021.", Opis = "zamena vrata", Status = "zakazano", Tip = "kontrolna" });
            renovations.Add(new RenovationMockup { Sifra = "0875", Datum = "16.03.2013 - 14.06.2014.", Opis = "zamena sijalica", Status = "otkazano", Tip = "rehabilitaciona" });
            this.DataGridRenovation.ItemsSource = renovations;


            
            List<Room> rooms = _roomController.GetAll().ToList();
            ObservableCollection<Room> DataRooms = new ObservableCollection<Room>(rooms);
            this.DataGridRooms.ItemsSource = DataRooms;
            

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

        private void deleteRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridRooms.SelectedItem != null)
            {
                _roomController.Delete((Room)DataGridRooms.SelectedItem);

                this.DataGridRooms.ItemsSource = null;
                List<Room> rooms = _roomController.GetAll().ToList();
                ObservableCollection<Room> DataRooms = new ObservableCollection<Room>(rooms);
                this.DataGridRooms.ItemsSource = DataRooms;
                txtsearchRooms.Clear();
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
                    _equipmentController.Delete((Equipment)DataGridOpremaPotrosna.SelectedItem);

                    DataGridOpremaPotrosna.ItemsSource = null;

                    List<Equipment> consumable_equipment = _equipmentController.getConsumableEquipment().ToList();
                    ObservableCollection<Equipment> data_consumable = new ObservableCollection<Equipment>(consumable_equipment);
                    this.DataGridOpremaPotrosna.ItemsSource = data_consumable;
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
                    _equipmentController.Delete((Equipment)DataGridOpremaNepotrosna.SelectedItem);

                    DataGridOpremaNepotrosna.ItemsSource = null;

                    List<Equipment> inconsumable_equipment = _equipmentController.getInconsumableEquipment().ToList();
                    ObservableCollection<Equipment> data_inconsumable = new ObservableCollection<Equipment>(inconsumable_equipment);
                    this.DataGridOpremaNepotrosna.ItemsSource = data_inconsumable;
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
    }
}
