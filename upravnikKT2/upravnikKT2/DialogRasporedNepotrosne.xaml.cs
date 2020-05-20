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
        public DialogRasporedNepotrosne()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            ObservableCollection<Oprema> DataGridOpremaNepotrosna = new ObservableCollection<Oprema>();
            DataGridOpremaNepotrosna.Add(new Oprema { Naziv = "4323", Kolicina = "10" });
            DataGridOpremaNepotrosna.Add(new Oprema { Naziv = "2142", Kolicina = "12" });
            DataGridOpremaNepotrosna.Add(new Oprema { Naziv = "4657", Kolicina = "5" });
            this.DataGridRasporedOpremePoProstorijama.ItemsSource = DataGridOpremaNepotrosna;
        }
    }
}
