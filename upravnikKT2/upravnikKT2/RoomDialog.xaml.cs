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
        }

        private void Button_Click_OK_Room(object sender, RoutedEventArgs e)
        {
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
