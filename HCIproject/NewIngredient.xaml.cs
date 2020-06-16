using Model.PatientSecretary;
using Model.Users;
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

namespace HCIproject
{

    public partial class NewIngredient : Window
    {
        public Doctor user;
        public long drugId;
        private List<Ingredient> sastojci=new List<Ingredient>();
        private String imeSastojka = "";
        private Ingredient noviLek;
        public NewIngredient(Doctor _user, long id)
        {
            InitializeComponent();
            user = _user;
            drugId = id;
            var app = Application.Current as App;
            foreach (Ingredient ingredient in app.IngredientController.GetAll())
            {
                sastojci.Add(ingredient);
            }
            initializeComboBox();
        }
        private void initializeComboBox()
        {
            var app = Application.Current as App;
            Drug drug = app.DrugController.Get(drugId);
            List<Ingredient> drugIngredients = drug.Ingredients;
            bool flag = false;
            if (drugIngredients.Count == sastojci.Count)
            {
                popuni.Content = "Ne postoji sastojak u bazi kog vec ne sadrzi dati lek.";
                cBox1.Visibility = Visibility.Hidden;
            }
            else
            {
                foreach (Ingredient s in sastojci)
                {
                    flag = false;
                    foreach (Ingredient ing in drugIngredients)
                    {
                        if (s.Name == ing.Name)
                        {
                            flag = true;
                        }

                    }
                    if (!flag)
                        cBox1.Items.Add(s.Name);
                }
            }
        }
        private void cBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            imeSastojka = cBox1.SelectedItem.ToString();

            foreach (Ingredient s in sastojci)
            {
                if (s.Name == imeSastojka)
                {
                    noviLek = s;
                }

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {//[potvrdi
            if (cBox1.Visibility != Visibility.Hidden)
            {
                var app = Application.Current as App;
                Drug drug = app.DrugController.Get(drugId);
                drug.Ingredients.Add(noviLek);
                app.DrugController.Edit(drug);
            }
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


    }
}