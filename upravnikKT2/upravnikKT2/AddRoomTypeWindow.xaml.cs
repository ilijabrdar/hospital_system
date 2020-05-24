using bolnica.Controller;
using Controller;
using Model.Director;
using Model.PatientSecretary;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

            this.Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
