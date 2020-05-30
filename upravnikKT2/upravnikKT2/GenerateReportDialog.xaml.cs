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
    /// Interaction logic for GenerateReportDialog.xaml
    /// </summary>
    public partial class GenerateReportDialog : Window
    {
        public GenerateReportDialog()
        {
            InitializeComponent();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_SacuvajPDF(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Izvestaj"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<RoomMockup> DataGridRooms = new ObservableCollection<RoomMockup>();
            DataGridRooms.Add(new RoomMockup { Sifra = "1243"});
            DataGridRooms.Add(new RoomMockup { Sifra = "6475"});
            DataGridRooms.Add(new RoomMockup { Sifra = "9876"});
            DataGridRooms.Add(new RoomMockup { Sifra = "8674"});
            DataGridRooms.Add(new RoomMockup { Sifra = "5532"});
            DataGridRooms.Add(new RoomMockup { Sifra = "7684" });
            this.DataGridProstorije.ItemsSource = DataGridRooms;
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
