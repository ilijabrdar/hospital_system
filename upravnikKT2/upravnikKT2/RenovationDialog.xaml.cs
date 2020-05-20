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
    /// Interaction logic for RenovationDialog.xaml
    /// </summary>
    public partial class RenovationDialog : Window
    {
        public RenovationDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_OK_Renovation(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Cancel_Renovation(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
