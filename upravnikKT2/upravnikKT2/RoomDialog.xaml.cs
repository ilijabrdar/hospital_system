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
        private readonly IController<Room, long> _roomController;


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
        }

        private void Button_Click_OK_Room(object sender, RoutedEventArgs e)
        {
            //var RoomCode = new Room("test1", new RoomType("212"), null, null);
            //_roomController.Save(RoomCode);

            Equipment e1 = new Equipment(3);
            Equipment e2 = new Equipment(234);
            Dictionary<Equipment, int> dict = new Dictionary<Equipment, int>();
            dict[e1] = 3;
            dict[e2] = 56;

            var RoomCode = new Room(Test3, new RoomType("212"), dict, null);
            _roomController.Save(RoomCode);


            this.Close();
        }

        private void Button_Click_Cancel_Room(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string _test3;
        public string Test3
        {
            get
            {
                return _test3;
            }
            set
            {
                if (value != _test3)
                {
                    _test3 = value;
                    OnPropertyChanged("Test3");
                }
            }
        }
    }
}
