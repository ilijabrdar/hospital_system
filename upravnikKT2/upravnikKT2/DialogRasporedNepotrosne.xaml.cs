using bolnica.Controller;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using upravnikKT2.ViewModel;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for DialogRasporedNepotrosne.xaml
    /// </summary>
    public partial class DialogRasporedNepotrosne : Window
    {
        private readonly IRoomController _roomController;
        private Equipment _selectedEquipment;
        public DialogRasporedNepotrosne(Equipment selectedEquipment)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;


            var app = Application.Current as App;
            _roomController = app.RoomController;

            _selectedEquipment = selectedEquipment;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            DodavanjeInventaraProstorijaDialog dialog = new DodavanjeInventaraProstorijaDialog(_selectedEquipment);
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();

            List<Room> rooms = _roomController.GetRoomsContainingEquipment(_selectedEquipment).ToList();
            List<RoomEquipment> result = new List<RoomEquipment>();

            foreach (Room room in rooms)
            {
                foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
                {
                    if (pair.Key.Id == _selectedEquipment.Id)
                    {
                        result.Add(new RoomEquipment(room.Id ,room.RoomCode, pair.Value, _selectedEquipment.Name));
                    }
                }
            }


            ObservableCollection<RoomEquipment> data_rooms = new ObservableCollection<RoomEquipment>(result);

            this.DataGridRasporedOpremePoProstorijama.ItemsSource = data_rooms;
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (DataGridRasporedOpremePoProstorijama.SelectedItem != null)
            {
                DodavanjeInventaraProstorijaDialog dialog = new DodavanjeInventaraProstorijaDialog(_selectedEquipment, (RoomEquipment) DataGridRasporedOpremePoProstorijama.SelectedItem);
                dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                dialog.ShowDialog();




                List<Room> rooms = _roomController.GetRoomsContainingEquipment(_selectedEquipment).ToList();
                List<RoomEquipment> result = new List<RoomEquipment>();

                foreach (Room room in rooms)
                {
                    foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
                    {
                        if (pair.Key.Id == _selectedEquipment.Id)
                        {
                            result.Add(new RoomEquipment(room.Id, room.RoomCode, pair.Value, _selectedEquipment.Name));
                        }
                    }
                }


                ObservableCollection<RoomEquipment> data_rooms = new ObservableCollection<RoomEquipment>(result);

                this.DataGridRasporedOpremePoProstorijama.ItemsSource = data_rooms;
            }
            else
            {
                string messageBoxText = "Morate selektovati prostoriju da biste izmenili opremu!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (DataGridRasporedOpremePoProstorijama.SelectedItem != null)
            {
                RoomEquipment roomEquipment = (RoomEquipment)DataGridRasporedOpremePoProstorijama.SelectedItem;
                string messageBoxText = "Da li ste sigurni da zelite da obrisete opremu pod nazivom " + roomEquipment.EquipmentName + "u prostoriji " + roomEquipment.RoomCode + "?";
                string caption = "Potvrda brisanja";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;

                MessageBoxResult resultMSG = MessageBox.Show(messageBoxText, caption, button, icon);
                if (resultMSG == MessageBoxResult.Yes)
                {

                    RoomEquipment roomEq = (RoomEquipment)DataGridRasporedOpremePoProstorijama.SelectedItem;
                    Room room_full = _roomController.Get(roomEq.Id);

                    //room_full.Equipment_inventory.Remove(_selectedEquipment); TODO: why doesn't it work
                    Equipment temp = null;
                    foreach (KeyValuePair<Equipment, int> pair in room_full.Equipment_inventory)
                    {
                        if (pair.Key.Id == _selectedEquipment.Id)
                        {
                            temp = pair.Key as Equipment;
                        }
                    }


                    room_full.Equipment_inventory.Remove(temp);
                    _roomController.Edit(room_full);

                    List<Room> rooms = _roomController.GetRoomsContainingEquipment(_selectedEquipment).ToList();
                    List<RoomEquipment> result = new List<RoomEquipment>();

                    foreach (Room room in rooms)
                    {
                        foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
                        {
                            if (pair.Key.Id == _selectedEquipment.Id)
                            {
                                result.Add(new RoomEquipment(room.Id, room.RoomCode, pair.Value, _selectedEquipment.Name));
                            }
                        }
                    }


                    ObservableCollection<RoomEquipment> data_rooms = new ObservableCollection<RoomEquipment>(result);

                    this.DataGridRasporedOpremePoProstorijama.ItemsSource = data_rooms;
                }
            }
            else
            {
                string messageBoxText = "Morate selektovati prostoriju da biste izbrisali opremu iz nje!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Room> rooms = _roomController.GetRoomsContainingEquipment(_selectedEquipment).ToList();
            List<RoomEquipment> result = new List<RoomEquipment>();

            foreach (Room room in rooms)
            {
                foreach(KeyValuePair<Equipment,int> pair in room.Equipment_inventory)
                {
                    if (pair.Key.Id == _selectedEquipment.Id)
                    {
                        result.Add(new RoomEquipment(room.Id, room.RoomCode, pair.Value, _selectedEquipment.Name));
                    }
                }
            }


            ObservableCollection<RoomEquipment> data_rooms = new ObservableCollection<RoomEquipment>(result);
            
            this.DataGridRasporedOpremePoProstorijama.ItemsSource = data_rooms;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
            else if (e.Key == System.Windows.Input.Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                addRoomEquipmentBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                editRoomEquipmentBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key == System.Windows.Input.Key.Delete)
            {
                deleteRoomEquipmentBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
    }
}
