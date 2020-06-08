using Model.PatientSecretary;
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
    /// Interaction logic for IngredientsDialog.xaml
    /// </summary>
    public partial class IngredientsDialog : Window
    {
        private Drug selectedDrug;
        public IngredientsDialog(Drug selectedDrug)
        {
            InitializeComponent();
            this.selectedDrug = selectedDrug;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Ingredient> ingredients = selectedDrug.Ingredients;
            ObservableCollection<Ingredient> collection = new ObservableCollection<Ingredient>(ingredients);
            lista.ItemsSource = collection;
            lista.DisplayMemberPath = "Name";
            lista.SelectedValuePath = "Id";
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
