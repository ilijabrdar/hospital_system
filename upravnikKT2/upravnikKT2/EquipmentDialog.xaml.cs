using bolnica.Controller;
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
    /// Interaction logic for EquipmentDialog.xaml
    /// </summary>
    public partial class EquipmentDialog : Window, INotifyPropertyChanged
    {
        private readonly IEquipmentController _equipmentController;
        private readonly bool isConsumable;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public EquipmentDialog(bool isConsumable)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _equipmentController = app.EquipmentController;

            this.isConsumable = isConsumable;
        }

        private void Button_Click_OK_Equipment(object sender, RoutedEventArgs e)
        {
            _equipmentController.Save(new Model.Director.Equipment(
                isConsumable ? Model.Director.EquipmentType.Consumable : Model.Director.EquipmentType.Inconsumable,
                txtName.Text,
                (int)Test3));

            this.Close();
        }

        private void Button_Click_Cancel_Equipment(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private double _test3;
        public double Test3
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

        private string _test2;
        public string Test2
        {
            get
            {
                return _test2;
            }
            set
            {
                if (value != _test2)
                {
                    _test2 = value;
                    OnPropertyChanged("Test2");
                }
            }
        }
    }
}
