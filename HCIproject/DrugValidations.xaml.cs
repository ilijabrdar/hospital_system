using bolnica.Controller;
using Controller;
using Model.PatientSecretary;
using Model.Users;
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

namespace HCIproject
{
    /// <summary>
    /// Interaction logic for DrugValidation.xaml
    /// </summary>
    public partial class DrugValidations : Window
    {

        public Doctor user;
        public long drugId;

        private Ingredient obrisani;
        private static List<Ingredient> sastojci { get; set; }
        public double Quantity { get; set; }
        public DrugValidations(Doctor user, long id)
        {
            InitializeComponent();

            this.user = user;
            this.drugId = id;
            dataInitialize();
            fillTable();

            sastojci = new List<Ingredient>()
            {
                new Ingredient{Name="bla1", Quantity=15},
                new Ingredient{Name="bla2", Quantity=46}
            };
            this.DataContext = this;
        }

        public DrugValidations()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//otkazi
            var app = Application.Current as App;
            Drug drug = app.DrugController.Get(drugId);

            if (obrisani != null)
            {
                drug.Ingredients.Add(obrisani);
                app.DrugController.Edit(drug);
            }
            bool flag = false;

            //foreach (Ingredient ing in drug.Ingredients)
            //{
            //    flag = false;
            //    foreach(Ingredient i in ingredients)
            //    {
            //        if (ing.Id == i.Id)
            //        {
            //            flag = true;
            //        }
            //    }
            //    if (flag == true)
            //    {
            //        drug.Ingredients.Remove(ing);
            //        app.DrugController.Edit(drug);

            //    }
            //}



            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//potvrdjeni
            var app = Application.Current as App;
            Drug drug = app.DrugController.Get(drugId);
            drug.Approved = true;
            app.DrugController.Edit(drug);

            string messageBoxText = "Uspesno ste validirali lek " + drug.Name + "!";
            string caption = "Potvrda validacije leka!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            this.Close();

        }

        private void dataInitialize()
        {
            var app = Application.Current as App;
            String name = app.DrugController.Get(drugId).Name;
            long sifra = app.DrugController.Get(drugId).Id;
            imeLeka.Content = name.ToString();
            sifraLeka.Content = sifra.ToString();
            Random rand = new Random();
            int randInt = rand.Next(0, 50);
            kolicina.Content = randInt;
        }

        private void fillTable()
        {
            var app = Application.Current as App;
            List<Ingredient> drugIngr = app.DrugController.Get(drugId).Ingredients;

            ingrediantsGrid.ItemsSource = app.DrugController.Get(drugId).Ingredients;

            //   ingredients = app.DrugController.Get(drugId).Ingredients;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NewIngredient newIngrWin = new NewIngredient((Doctor)user, drugId);
            newIngrWin.ShowDialog();

            var app = Application.Current as App;
            ingrediantsGrid.ItemsSource = null;
            ingrediantsGrid.ItemsSource = app.DrugController.Get(drugId).Ingredients;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//obrisi sastojak
            if (ingrediantsGrid.SelectedItem != null)
            {
                Ingredient ingredient = (Ingredient)ingrediantsGrid.SelectedItem;
                obrisani = ingredient;
                var app = Application.Current as App;
                Drug drug = app.DrugController.Get(drugId);

                foreach (Ingredient ing in drug.Ingredients)
                {
                    if (ing.Id == ingredient.Id)
                    {
                        drug.Ingredients.Remove(ing);
                        break;
                    }
                }
                app.DrugController.Edit(drug);

                ingrediantsGrid.ItemsSource = null;
                ingrediantsGrid.ItemsSource = app.DrugController.Get(drugId).Ingredients;
            }
        }
    }
}
