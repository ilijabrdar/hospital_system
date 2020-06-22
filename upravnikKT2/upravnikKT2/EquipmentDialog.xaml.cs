using bolnica.Controller;
using Model.Director;
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
        private Equipment _selectedEquipment;

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

        public EquipmentDialog(bool isConsumable, Equipment selectedEquipment)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _equipmentController = app.EquipmentController;

            this._selectedEquipment = selectedEquipment;
            Amount = selectedEquipment.Amount;
            Eq_Name = selectedEquipment.Name;
            txtName.Text = Eq_Name;

            this.isConsumable = isConsumable;
        }

        private void Button_Click_OK_Equipment(object sender, RoutedEventArgs e)
        {
            if (_selectedEquipment == null)
            {
                if (_equipmentController.CheckEquipmentNameUnique(Eq_Name))
                {
                    _equipmentController.Save(new Model.Director.Equipment(
                        isConsumable ? Model.Director.EquipmentType.Consumable : Model.Director.EquipmentType.Inconsumable,
                        txtName.Text,
                        Amount));
                }
                else
                {
                    string messageBoxText = "Oprema sa nazivom " + Eq_Name + " vec postoji";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }
            }
            else
            {
                if (!_selectedEquipment.Name.Equals(Eq_Name) && !_equipmentController.CheckEquipmentNameUnique(Eq_Name))
                {
                    string messageBoxText = "Oprema sa nazivom " + Eq_Name + " vec postoji";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                    return;
                }

                _selectedEquipment.Amount = Amount;
                _selectedEquipment.Name = Eq_Name;
                _equipmentController.Edit(_selectedEquipment);
            }

            this.Close();
        }

        //private bool checkEquipmentExists()
        //{
        //    List<Equipment> equipments = _equipmentController.GetAll().ToList();
        //    foreach (Equipment equipment in equipments)
        //    {
        //        if (equipment.Name.Equals(Eq_Name))
        //            return false;
        //    }

        //    return true;
        //}

        private void Button_Click_Cancel_Equipment(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private int _amount;
        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value != _amount)
                {
                    _amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }

        private string _name;
        public string Eq_Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name1");
                }
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (OKBtn.IsEnabled)
                {
                    Button_Click_OK_Equipment(sender, e);
                    e.Handled = true;
                }
            }
        }
    }
}
