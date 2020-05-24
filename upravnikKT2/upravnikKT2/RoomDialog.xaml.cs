﻿using bolnica.Controller;
using Controller;
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

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for RoomDialog.xaml
    /// </summary>
    public partial class RoomDialog : Window, INotifyPropertyChanged
    {
        private readonly IRoomController _roomController;
        private readonly IRoomTypeController _roomTypeController;
        private Room _selectedRoom;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public RoomDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _roomController = app.RoomController;
            _roomTypeController = app.RoomTypeController;
        }

        public RoomDialog(Room selectedRoom)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _roomController = app.RoomController;
            _roomTypeController = app.RoomTypeController;

            _selectedRoom = selectedRoom;
            RoomCode = _selectedRoom.RoomCode;
            
        }



        private void Button_Click_OK_Room(object sender, RoutedEventArgs e)
        {
            //var RoomCode = new Room("test1", new RoomType("212"), null, null);
            //_roomController.Save(RoomCode);

            //Equipment e1 = new Equipment(3);
            //Equipment e2 = new Equipment(234);
            //Dictionary<Equipment, int> dict = new Dictionary<Equipment, int>();
            //dict[e1] = 3;
            //dict[e2] = 56;

            //var RoomCode = new Room(Test3, new RoomType("21223"), dict, null);
            //_roomController.Save(new Room(Test3, new RoomType("t1"), dict, null));


            //_roomController.Delete(new Room(2));
            //_roomController.Edit(new Room(0,"roomCode",new RoomType("jasaa"),dict,null));

            if (_selectedRoom == null)
            {
                _roomController.Save(new Room(RoomCode, (RoomType)comboRoomTypes.SelectedItem, null, null));
            }
            else
            {
                _selectedRoom.RoomCode = RoomCode;
                _selectedRoom.RoomType = (RoomType) comboRoomTypes.SelectedItem;
                _roomController.Edit(_selectedRoom);
            }

            this.Close();
        }

        private void Button_Click_Cancel_Room(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string _roomCode;
        private Room selectedRoom;

        public string RoomCode
        {
            get
            {
                return _roomCode;
            }
            set
            {
                if (value != _roomCode)
                {
                    _roomCode = value;
                    OnPropertyChanged("RoomCode");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<RoomType> list_room_types = new List<RoomType>();
            list_room_types = _roomTypeController.GetAll().ToList();

            comboRoomTypes.ItemsSource = list_room_types;
            comboRoomTypes.DisplayMemberPath = "Name";
            comboRoomTypes.SelectedValuePath = "Id";
            comboRoomTypes.SelectedValue = "2";

            if (selectedRoom != null)
            {
                comboRoomTypes.SelectedItem = selectedRoom.RoomType;
            }
        }
    }
}