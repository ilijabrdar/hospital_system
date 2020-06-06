﻿using bolnica.Controller;
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
            if (_selectedRoomEquipmentEdit == null)
            {


                Room room = (Room)comboRoomCode.SelectedItem;


                foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
                {
                    if (pair.Key.id == _selectedEquipment.id)
                    {
                        string messageBoxText = "Prostorija vec sadrzi selektovanu opremu!";
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
            else
            {
                Room final_room = (Room)comboRoomCode.SelectedItem;

                if (final_room.Id != _selectedRoom.Id)  //erase inventory from selectedRoom and save it to final_room
                {

                    //room_full.Equipment_inventory.Remove(_selectedEquipment); TODO: why doesn't it work
                    Equipment temp = null;
                    foreach (KeyValuePair<Equipment, int> pair in _selectedRoom.Equipment_inventory)
                    {
                        if (pair.Key.id == _selectedEquipment.id)
                        {
                            temp = pair.Key as Equipment;
                        }
                    }

                    _selectedRoom.Equipment_inventory.Remove(temp);
                    _roomController.Edit(_selectedRoom);




                    foreach (KeyValuePair<Equipment, int> pair in final_room.Equipment_inventory)
                    {
                        if (pair.Key.id == _selectedEquipment.id)
                        {
                            string messageBoxText = "Prostorija vec sadrzi selektovanu opremu!";
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
                        if (pair.Key.id == _selectedEquipment.id)
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
