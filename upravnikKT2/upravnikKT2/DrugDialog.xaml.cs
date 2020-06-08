using bolnica.Controller;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DrugDialog.xaml
    /// </summary>
    public partial class DrugDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IIngredientController _ingredientController;
        private List<Ingredient> listOfSelectedIngredients = new List<Ingredient>();

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public DrugDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            var app = Application.Current as App;
            _ingredientController = app.IngredientController;
        }

        private void TextBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void Button_Click_OK_Drug(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Cancel_Drug(object sender, RoutedEventArgs e)
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

        private string _test1;
        public string Test1
        {
            get
            {
                return _test1;
            }
            set
            {
                if (value != _test1)
                {
                    _test1 = value;
                    OnPropertyChanged("Test1");
                }
            }
        }
        private int _noOfErrorsOnScreen = 0;

        private void mojtext_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;

            Save.IsEnabled = _noOfErrorsOnScreen > 0 ? false : true;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
        }

        private void tutorialBtn_Click(object sender, RoutedEventArgs e)
        {
            TutorialVideoDialog dialog = new TutorialVideoDialog();
            dialog.Show();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients =  _ingredientController.GetAll().ToList();

            ObservableCollection<Ingredient> collection = new ObservableCollection<Ingredient>(ingredients);
            listAllIngredients.ItemsSource = collection;
            listAllIngredients.DisplayMemberPath = "Name";
            listAllIngredients.SelectedValuePath = "Id";


        }

        private void AddIngredient_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (listAllIngredients.SelectedItem != null)
            {
                if (!listOfSelectedIngredients.Contains((Ingredient)listAllIngredients.SelectedItem))
                {
                    listOfSelectedIngredients.Add((Ingredient)listAllIngredients.SelectedItem);

                    ObservableCollection<Ingredient> collection = new ObservableCollection<Ingredient>(listOfSelectedIngredients);
                    listSelectedIngredients.ItemsSource = collection;
                    listSelectedIngredients.DisplayMemberPath = "Name";
                    listSelectedIngredients.SelectedValuePath = "Id";
                    listSelectedIngredients.SelectedValue = "2";
                }
                else
                {
                    string messageBoxText = "Taj sastojak ste već dodali!";
                    string caption = "Greska";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;

                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
            else
            {
                string messageBoxText = "Morate selektovati sastojak da biste ga dodali!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }
    }
}
