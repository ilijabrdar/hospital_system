using bolnica.Controller;
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

            comboRoomTypes.SelectedItem = selectedRoom.RoomType.GetId();
            
        }



        private void Button_Click_OK_Room(object sender, RoutedEventArgs e)
        {
            if (_selectedRoom == null)
            {
                if (checkRoomExists())
                {
                    _roomController.Save(new Room(RoomCode, (RoomType)comboRoomTypes.SelectedItem, null));
                }
                else
                {
                    string messageBoxText = "Prostorija sa sifrom " + RoomCode + " vec postoji";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }
            }
            else
            {
                if (!_selectedRoom.RoomCode.Equals(RoomCode) && checkRoomExists() == false)
                {
                    string messageBoxText = "Prostorija sa sifrom " + RoomCode + " vec postoji";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }
                else
                {
                    _selectedRoom.RoomCode = RoomCode;
                    _selectedRoom.RoomType = (RoomType)comboRoomTypes.SelectedItem;
                    _roomController.Edit(_selectedRoom);
                }
            }

            this.Close();
        }

        private bool checkRoomExists()
        {
            List<Room> rooms = _roomController.GetAll().ToList();
            foreach (Room room in rooms)
            {
                if (room.RoomCode.Equals(RoomCode))
                    return false;
            }

            return true;
        }

        private void Button_Click_Cancel_Room(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string _roomCode;

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
            list_room_types.Sort((x,y) => x.Name.CompareTo(y.Name));

            comboRoomTypes.ItemsSource = list_room_types;
            comboRoomTypes.DisplayMemberPath = "Name";
            comboRoomTypes.SelectedValuePath = "Id";
            comboRoomTypes.SelectedValue = "2";

            if (_selectedRoom != null)
            {
                comboRoomTypes.SelectedValue = _selectedRoom.RoomType.GetId();
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
                    Button_Click_OK_Room(sender, e);
                    e.Handled = true;
                }
            }
        }
    }
}
