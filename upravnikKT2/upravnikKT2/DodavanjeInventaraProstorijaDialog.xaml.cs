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

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for DodavanjeInventaraProstorijaDialog.xaml
    /// </summary>
    public partial class DodavanjeInventaraProstorijaDialog : Window, INotifyPropertyChanged
    {
        private readonly IRoomController _roomController;


        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public DodavanjeInventaraProstorijaDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _roomController = app.RoomController;
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private double _amount;
        public double Amount
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
            comboRoomCode.ItemsSource = rooms;
            comboRoomCode.DisplayMemberPath = "RoomCode";
            comboRoomCode.SelectedValuePath = "Id";
            comboRoomCode.SelectedValue = "2";
        }
    }
}
