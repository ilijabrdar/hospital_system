using bolnica.Controller;
using Controller;
using Model.Director;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for AddRoomType.xaml
    /// </summary>
    public partial class AddRoomType : Window, INotifyPropertyChanged
    {
        private readonly IRoomTypeController _roomTypeController;
        private ListView list;
        private RoomType roomTypeForEdit;

        public event PropertyChangedEventHandler PropertyChanged;
        

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public AddRoomType(ListView listView)
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _roomTypeController = app.RoomTypeController;

            list = listView;
        }

        public AddRoomType(ListView listView, RoomType roomTypeForEdit)
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _roomTypeController = app.RoomTypeController;

            list = listView;
            this.roomTypeForEdit = roomTypeForEdit;

            Ime = roomTypeForEdit.Name;
            txtName.Text = roomTypeForEdit.Name;
            
        }


        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            if (roomTypeForEdit == null)
            {
                if (_roomTypeController.CheckRoomTypeUnique(Ime))
                {
                    _roomTypeController.Save(new RoomType(Ime));

                    list.ItemsSource = null;

                    List<RoomType> roomTypes = new List<RoomType>();
                    roomTypes = _roomTypeController.GetAll().ToList();

                    ObservableCollection<RoomType> temp = new ObservableCollection<RoomType>(roomTypes);

                    list.ItemsSource = temp;
                    list.DisplayMemberPath = "Name";
                    list.SelectedValuePath = "Id";
                    list.SelectedValue = "2";
                }
                else
                {
                    string messageBoxText = "Tip prostorije sa nazivom " + Ime + " vec postoji";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }
            }
            else
            {
                if (!roomTypeForEdit.Name.Equals(Ime) && !_roomTypeController.CheckRoomTypeUnique(Ime))
                {
                    string messageBoxText = "Tip prostorije sa nazivom " + Ime + " vec postoji";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }
                else
                {
                    roomTypeForEdit.Name = Ime;
                    _roomTypeController.Edit(roomTypeForEdit);


                    list.ItemsSource = null;

                    List<RoomType> roomTypes = new List<RoomType>();
                    roomTypes = _roomTypeController.GetAll().ToList();

                    ObservableCollection<RoomType> temp = new ObservableCollection<RoomType>(roomTypes);

                    list.ItemsSource = temp;
                    list.DisplayMemberPath = "Name";
                    list.SelectedValuePath = "Id";
                    list.SelectedValue = "2";
                }
            }

            this.Close();
        }

        //private bool checkRoomTypeExists()
        //{
        //    foreach (RoomType type in _roomTypeController.GetAll().ToList())
        //    {
        //        if (type.Name.Equals(Ime))
        //            return false;
        //    }

        //    return true;
        //}

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
