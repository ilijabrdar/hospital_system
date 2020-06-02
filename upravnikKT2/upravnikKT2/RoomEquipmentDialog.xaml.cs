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
using upravnikKT2.ViewModel;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for RoomEquipmentDialog.xaml
    /// </summary>
    public partial class RoomEquipmentDialog : Window
    {
        private Room _selectedRoom;
        public RoomEquipmentDialog(Room selectedRoom)
        {
            InitializeComponent();
            _selectedRoom = selectedRoom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            List<RoomEquipment> lista_opreme = new List<RoomEquipment>();
            foreach (KeyValuePair<Equipment,int> pair in _selectedRoom.Equipment_inventory)
            {
                lista_opreme.Add(new RoomEquipment(pair.Key.Name, pair.Value));
            }

            this.lista.ItemsSource = lista_opreme;

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
        }
    }
}
