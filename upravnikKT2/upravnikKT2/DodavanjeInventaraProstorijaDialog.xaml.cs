using bolnica.Controller;
using Model.Director;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using upravnikKT2.ViewModel;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for DodavanjeInventaraProstorijaDialog.xaml
    /// </summary>
    public partial class DodavanjeInventaraProstorijaDialog : Window, INotifyPropertyChanged
    {
        private readonly IRoomController _roomController;
        private Equipment _selectedEquipment;
        private RoomEquipment _selectedRoomEquipmentEdit;
        private Room _selectedRoom;

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public DodavanjeInventaraProstorijaDialog(Equipment selectedEquipment)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _roomController = app.RoomController;

            _selectedEquipment = selectedEquipment;
        }

        public DodavanjeInventaraProstorijaDialog(Equipment selectedEquipment, RoomEquipment selectedRoomEquipmentEdit)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _roomController = app.RoomController;

            _selectedEquipment = selectedEquipment;
            _selectedRoomEquipmentEdit = selectedRoomEquipmentEdit;
            _selectedRoom = _roomController.Get(selectedRoomEquipmentEdit.Id);
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            bool ret = check_valid_amount();
            if (!ret) return;
            if (_selectedRoomEquipmentEdit == null )
            {


                Room room = (Room)comboRoomCode.SelectedItem;


                foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
                {
                    if (pair.Key.Id == _selectedEquipment.Id)
                    {
                        string messageBoxText = "Prostorija " + room.RoomCode + " vec sadrzi selektovanu opremu!";
                        string caption = "Greska";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;

                        MessageBox.Show(messageBoxText, caption, button, icon);
                        return;
                    }
                }


                room.Equipment_inventory.Add(_selectedEquipment, _amount);
                _roomController.Edit(room);
            }
            else  //edit case
            {
                Room final_room = (Room)comboRoomCode.SelectedItem;

                if (final_room.Id != _selectedRoom.Id)  //erase inventory from selectedRoom and save it to final_room
                {

                    //room_full.Equipment_inventory.Remove(_selectedEquipment); TODO: why doesn't it work
                    Equipment temp = null;
                    foreach (KeyValuePair<Equipment, int> pair in _selectedRoom.Equipment_inventory)
                    {
                        if (pair.Key.Id == _selectedEquipment.Id)
                        {
                            temp = pair.Key as Equipment;
                        }
                    }

                    _selectedRoom.Equipment_inventory.Remove(temp);
                    _roomController.Edit(_selectedRoom);




                    foreach (KeyValuePair<Equipment, int> pair in final_room.Equipment_inventory)
                    {
                        if (pair.Key.Id == _selectedEquipment.Id)
                        {
                            string messageBoxText = "Prostorija " + final_room.RoomCode + " vec sadrzi selektovanu opremu!";
                            string caption = "Greska";
                            MessageBoxButton button = MessageBoxButton.OK;
                            MessageBoxImage icon = MessageBoxImage.Error;

                            MessageBox.Show(messageBoxText, caption, button, icon);
                            return;
                        }
                    }

                    final_room.Equipment_inventory.Add(_selectedEquipment, _amount);
                    _roomController.Edit(final_room);
                }
                else
                {
                    Equipment temp = null;
                    foreach (KeyValuePair<Equipment, int> pair in final_room.Equipment_inventory)
                    {
                        if (pair.Key.Id == _selectedEquipment.Id)
                        {
                            temp = pair.Key;
                        }
                    }

                    final_room.Equipment_inventory[temp] = _amount;
                    _roomController.Edit(final_room);
                }
            }
            this.Close();
                
        }

        private bool check_valid_amount()
        {
            List<Room> rooms = _roomController.GetRoomsContainingEquipment(_selectedEquipment).ToList();
            int result = 0;
            Room final_room = (Room)comboRoomCode.SelectedItem;

            foreach (Room room in rooms)
            {
                foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
                {
                    if (pair.Key.Id == _selectedEquipment.Id)
                    {
                        result+= pair.Value;
                    }
                }
            }
            if (_selectedRoomEquipmentEdit != null && final_room.RoomCode.Equals(_selectedRoomEquipmentEdit.RoomCode))
                result -= _selectedRoomEquipmentEdit.Equipment_Amount;
            if (result+Amount > _selectedEquipment.Amount)
            {
                string messageBoxText = "Uneli ste vecu kolicinu opreme " + _selectedEquipment.Name + " od one na raspolaganju";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
                return false;
            }
            return true;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private int _amount;
        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value != _amount)
                {
                    _amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Room> rooms = _roomController.GetAll().ToList();
            rooms.Sort((x, y) => x.RoomCode.CompareTo(y.RoomCode));
            comboRoomCode.ItemsSource = rooms;
            comboRoomCode.DisplayMemberPath = "RoomCode";
            comboRoomCode.SelectedValuePath = "Id";
            comboRoomCode.SelectedValue = "2";

            if (_selectedRoomEquipmentEdit != null)
            {
                Amount = _selectedRoomEquipmentEdit.Equipment_Amount;
                comboRoomCode.SelectedValue = _selectedRoom.GetId();
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (OKBtn.IsEnabled)
                {
                    Button_Click_OK(sender, e);
                    e.Handled = true;
                }
            }
        }
    }
}
