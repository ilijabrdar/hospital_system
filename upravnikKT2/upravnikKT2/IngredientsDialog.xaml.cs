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
    /// Interaction logic for IngredientsDialog.xaml
    /// </summary>
    public partial class IngredientsDialog : Window
    {
        public IngredientsDialog()
        {
            InitializeComponent();
            
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> sastojci = new List<String>();
            sastojci.Add("glicerol-dibehenat");
            sastojci.Add("natrijum-laurilsulfat");
            sastojci.Add("magnezijum-stearat");

            this.lista.ItemsSource = sastojci;
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
