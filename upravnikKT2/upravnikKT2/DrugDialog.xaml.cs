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
using System.Windows.Controls.Primitives;
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
        private readonly IDrugController _drugController;
        private Drug _selectedDrug;

        private ObservableCollection<Ingredient> currentOriginal = new ObservableCollection<Ingredient>();
        private ObservableCollection<Ingredient> currentSelected = new ObservableCollection<Ingredient>();

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
            _drugController = app.DrugController;
        }

        public DrugDialog(Drug selectedDrug)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this;


            var app = Application.Current as App;
            _ingredientController = app.IngredientController;
            _drugController = app.DrugController;


            _selectedDrug = selectedDrug;

            DrugName = _selectedDrug.Name;
            Amount = _selectedDrug.Amount;

            tutorialBtn.Visibility = Visibility.Hidden;
        }

        private void TextBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void Button_Click_OK_Drug(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Ingredient> selectedIngredients = (ObservableCollection < Ingredient >) listSelectedIngredients.ItemsSource;
            var count = selectedIngredients == null ? 0 : selectedIngredients.Count;
            if (count!=0)
            {
                if (_selectedDrug == null)
                {
                    if (_drugController.CheckDrugNameUnique(DrugName))
                    _drugController.Save(new Drug(txtName.Text, Amount, false, selectedIngredients.ToList(), null));
                    else
                    {
                        string messageBoxText = "Lek sa nazivom " + DrugName + " vec postoji";
                        string caption = "Greska";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;

                        MessageBox.Show(messageBoxText, caption, button, icon);
                        return;
                    }

                }
                else
                {
                    if (!_selectedDrug.Name.Equals(DrugName) && !_drugController.CheckDrugNameUnique(DrugName))
                    {
                        string messageBoxText = "Lek sa nazivom " + DrugName + " vec postoji";
                        string caption = "Greska";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;

                        MessageBox.Show(messageBoxText, caption, button, icon);
                        return;
                    }
                    else
                    {
                        _selectedDrug.Name = DrugName;
                        _selectedDrug.Amount = Amount;
                        _selectedDrug.Ingredients = selectedIngredients.ToList();
                        _drugController.Edit(_selectedDrug);
                    }

                }
                this.Close();
            }
            else
            {
                string messageBoxText = "Morate uneti sastojke leka!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        //private bool checkDrugExists()
        //{
        //    List<Drug> drugs = _drugController.GetAll().ToList();
        //    foreach (Drug drug in drugs)
        //        if (drug.Name.Equals(DrugName))
        //            return false;

        //    return true;
        //}

        private void Button_Click_Cancel_Drug(object sender, RoutedEventArgs e)
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
        public string DrugName
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
                    OnPropertyChanged("DrugName");
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

            OKBtn.IsEnabled = _noOfErrorsOnScreen > 0 ? false : true;
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
                    Button_Click_OK_Drug(sender, e);
                    e.Handled = true;
                }
            }
            else if (e.Key == Key.Right && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                AddIngredient_Btn_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Key == Key.Left && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                RemoveIngredient_Btn_Click(sender, e);
                e.Handled = true;
            }

            else if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                searchOriginalBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                txtsearchOriginalIngredients.Focus();
                e.Handled = true;
            }
            else if (e.Key == Key.A && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                searchCustomBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                txtsearchSelectedIngredients.Focus();
                e.Handled = true;
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

            listAllIngredients.DisplayMemberPath = "Name";
            listAllIngredients.SelectedValuePath = "Id";

            
            listSelectedIngredients.DisplayMemberPath = "Name";
            listSelectedIngredients.SelectedValuePath = "Id";

            if (_selectedDrug != null)
            {
                ObservableCollection<Ingredient> original = new ObservableCollection<Ingredient>(ingredients);
                ObservableCollection<Ingredient> selected = new ObservableCollection<Ingredient>(_selectedDrug.Ingredients);

                List<Ingredient> forRemoval = new List<Ingredient>();

                foreach (Ingredient temp in original)
                {
                    if (selected.Any(ing => ing.Id == temp.Id) == true)
                        //original.Remove(temp);
                        forRemoval.Add(temp);
                }

                //foreach (int i in forRemoval)
                //    original.RemoveAt(i);

                //original.ToList().RemoveAll(drug => forRemoval.Contains(original.IndexOf(drug)));
                //original.ToList().RemoveAll(drug => forRemoval.Contains(drug));
                foreach (Ingredient temp in forRemoval)
                    original.Remove(temp);

                listAllIngredients.ItemsSource = original;
                listSelectedIngredients.ItemsSource = selected;

            }
            else
            {
                listAllIngredients.ItemsSource = new ObservableCollection<Ingredient>(ingredients);
                listSelectedIngredients.ItemsSource = new ObservableCollection<Ingredient>();
            }

            currentOriginal = (ObservableCollection<Ingredient>)listAllIngredients.ItemsSource;
            currentSelected = (ObservableCollection<Ingredient>)listSelectedIngredients.ItemsSource;


        }

        private void undoSearch()
        {

            listAllIngredients.ItemsSource = currentOriginal;
            txtsearchOriginalIngredients.Clear();

            listSelectedIngredients.ItemsSource = currentSelected;
            txtsearchSelectedIngredients.Clear();

        }

        private void AddIngredient_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (listAllIngredients.SelectedItem != null)
            {
                undoSearch();

                    ObservableCollection<Ingredient> selected = (ObservableCollection<Ingredient>)listSelectedIngredients.ItemsSource;
                    selected.Add((Ingredient)listAllIngredients.SelectedItem);

                    ObservableCollection<Ingredient> original = (ObservableCollection<Ingredient>) listAllIngredients.ItemsSource;
                    original.Remove((Ingredient)listAllIngredients.SelectedItem);

                    currentOriginal = (ObservableCollection<Ingredient>)listAllIngredients.ItemsSource;
                    currentSelected = (ObservableCollection<Ingredient>)listSelectedIngredients.ItemsSource;
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

        private void RemoveIngredient_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (listSelectedIngredients.SelectedItem != null)
            {
                undoSearch();

                ObservableCollection<Ingredient> original = (ObservableCollection<Ingredient>)listAllIngredients.ItemsSource;
                original.Add((Ingredient)listSelectedIngredients.SelectedItem);

                ObservableCollection<Ingredient> selected = (ObservableCollection<Ingredient>)listSelectedIngredients.ItemsSource;
                selected.Remove((Ingredient)listSelectedIngredients.SelectedItem);

                currentOriginal = (ObservableCollection<Ingredient>)listAllIngredients.ItemsSource;
                currentSelected = (ObservableCollection<Ingredient>)listSelectedIngredients.ItemsSource;


            }
            else
            {
                string messageBoxText = "Morate selektovati sastojak da biste ga izbrisali!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void searchOriginalIngredientsKeyUp(object sender, KeyEventArgs e)
        {
            listAllIngredients.ItemsSource = currentOriginal.Where(input => input.Name.ToUpper().Contains(txtsearchOriginalIngredients.Text.ToUpper()));
        }

        private void searchSelectedIngredientsKeyUp(object sender, KeyEventArgs e)
        {
            listSelectedIngredients.ItemsSource = currentSelected.Where(input => input.Name.ToUpper().Contains(txtsearchSelectedIngredients.Text.ToUpper()));
        }

        private void searchOriginalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (searchOriginalBtn.Background == Brushes.Gray)
            {
                searchOriginalBtn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
                txtsearchOriginalIngredients.Visibility = Visibility.Hidden;
                //TODO: vrati nazad tabelu


                this.listAllIngredients.ItemsSource = currentOriginal;
                txtsearchOriginalIngredients.Clear();
            }
            else
            {
                searchOriginalBtn.Background = Brushes.Gray;
                txtsearchOriginalIngredients.Visibility = Visibility.Visible;
            }
        }

        private void searchCustomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (searchCustomBtn.Background == Brushes.Gray)
            {
                searchCustomBtn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
                txtsearchSelectedIngredients.Visibility = Visibility.Hidden;
                //TODO: vrati nazad tabelu


                this.listSelectedIngredients.ItemsSource = currentSelected;
                txtsearchSelectedIngredients.Clear();
            }
            else
            {
                searchCustomBtn.Background = Brushes.Gray;
                txtsearchSelectedIngredients.Visibility = Visibility.Visible;
            }
        }
    }
}
