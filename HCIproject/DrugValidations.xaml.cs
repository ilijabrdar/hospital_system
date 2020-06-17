using bolnica.Controller;
using Controller;
using MindFusion.Charting.Wpf;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCIproject
{ 
    public partial class DrugValidations : Window
    {

        public Doctor user;
        public long drugId;
        private Ingredient obrisani;

        private List<string> customLabels = new List<string>();
        private DoubleCollection data = new DoubleCollection();

        public DrugValidations(Doctor user, long id)
        {
            InitializeComponent();

            this.user = user;
            this.drugId = id;
            dataInitialize();
            fillTable();
            fillGraph();
            this.DataContext = this;


        }

        private void fillGraph()
        {
            pieChart.Series.Clear();
            customLabels.Clear();
            data.Clear();
            var app = Application.Current as App;
            Drug drug = app.DrugController.Get(drugId);

            foreach (Ingredient ing in drug.Ingredients)
            {
                customLabels.Add(ing.Name);
                data.Add(ing.Quantity);
            }

            pieChart.TitleVisibility = Visibility.Collapsed;
            pieChart.Width = 290;
            pieChart.Height = 290;
            PieSeries series = new PieSeries();
            series.Effect = new DropShadowEffect() { Opacity = 0.5, ShadowDepth = 3, };
            series.Data = data;
            series.PieType = PieType.Pie2D;
            series.InnerLabel = customLabels;
            series.OuterLabel = customLabels;
            series.LabelForeground = Brushes.White;
            series.OuterLabelOffset = 30;

            series.Fills.Add(Brushes.LightGreen);
            series.Fills.Add(Brushes.DodgerBlue);
            series.Fills.Add(Brushes.Violet);
            series.Fills.Add(Brushes.Yellow);
            series.Fills.Add(Brushes.PowderBlue);
            series.Fills.Add(Brushes.BurlyWood);
            series.Fills.Add(Brushes.Tomato);
            series.Fills.Add(Brushes.Orange);

            series.Strokes.Add(Brushes.Green);
            series.Strokes.Add(Brushes.Blue);
            series.Strokes.Add(Brushes.BlueViolet);
            series.Strokes.Add(Brushes.Orange);
            series.Strokes.Add(Brushes.CadetBlue);
            series.Strokes.Add(Brushes.Brown);
            series.Strokes.Add(Brushes.Red);
            series.Strokes.Add(Brushes.OrangeRed);
            series.Fills.Add(Brushes.Violet);
            series.Strokes.Add(Brushes.BlueViolet);
            pieChart.Series.Clear();
            pieChart.Series.Add(series);
            pieChart.PlotAreaMargin = new Thickness(40, 20, 40, 20);
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
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NewIngredient newIngrWin = new NewIngredient((Doctor)user, drugId);
            newIngrWin.ShowDialog();

            var app = Application.Current as App;
            ingrediantsGrid.ItemsSource = null;
            ingrediantsGrid.ItemsSource = app.DrugController.Get(drugId).Ingredients;
            fillGraph();
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

                string messageBoxText = "Uspesno ste obrisali sastojak " + ingredient.Name+ "!";
                string caption = "Potvrda brisanja sastojka!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                ingrediantsGrid.ItemsSource = null;
                ingrediantsGrid.ItemsSource = app.DrugController.Get(drugId).Ingredients;
                fillGraph();
            }
        }

        private void ScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scroll.Height  = this.ActualHeight - 200;
        }


    }
}
