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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for DialogRasporedNepotrosne.xaml
    /// </summary>
    public partial class DialogRasporedNepotrosne : Window
    {
        private readonly IRoomController _roomController;

        public DialogRasporedNepotrosne()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;


            var app = Application.Current as App;
            _roomController = app.RoomController;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            DodavanjeInventaraProstorijaDialog dialog = new DodavanjeInventaraProstorijaDialog();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            DodavanjeInventaraProstorijaDialog dialog = new DodavanjeInventaraProstorijaDialog();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Room> rooms = _roomController.GetAll().ToList();
            ObservableCollection<Room> data_rooms = new ObservableCollection<Room>(rooms);
            
            this.DataGridRasporedOpremePoProstorijama.ItemsSource = data_rooms;
        }
    }
}
