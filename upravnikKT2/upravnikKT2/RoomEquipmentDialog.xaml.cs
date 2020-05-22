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
    /// Interaction logic for RoomEquipmentDialog.xaml
    /// </summary>
    public partial class RoomEquipmentDialog : Window
    {
        public RoomEquipmentDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            List<Oprema> lista_opreme = new List<Oprema>();
            lista_opreme.Add(new Oprema { Naziv = "Sto", Kolicina = "1" });
            lista_opreme.Add(new Oprema { Naziv = "Krevet", Kolicina = "3" });
            lista_opreme.Add(new Oprema { Naziv = "Stolica", Kolicina = "5" });

            this.lista.ItemsSource = lista_opreme;

        }
    }
}
