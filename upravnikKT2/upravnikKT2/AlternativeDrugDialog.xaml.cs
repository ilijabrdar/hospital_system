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
    /// Interaction logic for AlternativeDrugDialog.xaml
    /// </summary>
    public partial class AlternativeDrugDialog : Window
    {
        public AlternativeDrugDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<String> alternativni = new List<String>();
            alternativni.Add("Bromazepan");
            alternativni.Add("Linex");
            alternativni.Add("Brufen");
            alternativni.Add("Valijum");

            this.MyListView.ItemsSource = alternativni;
            
        }
    }
}
