using bolnica.Controller;
using Model.Director;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RoomTypeWindow.xaml
    /// </summary>
    public partial class RoomTypeWindow : Window
    {
        private readonly IRoomTypeController _roomTypeController;

        public RoomTypeWindow()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _roomTypeController = app.RoomTypeController;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //List<String> tipovi = new List<String>();
            //tipovi.Add("magazin");
            //tipovi.Add("operaciona");
            //tipovi.Add("rehabilitaciona");

            //this.lista.ItemsSource = tipovi;

            List<RoomType> roomTypes = new List<RoomType>();
            roomTypes = _roomTypeController.GetAll().ToList();

            listViewRoomTypes.ItemsSource = roomTypes;
            listViewRoomTypes.DisplayMemberPath = "Name";
            listViewRoomTypes.SelectedValuePath = "Id";
            listViewRoomTypes.SelectedValue = "2";


        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            AddRoomType dialog = new AddRoomType();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
