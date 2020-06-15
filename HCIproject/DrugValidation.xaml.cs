using Controller;
using Model.PatientSecretary;
using Model.Users;
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

namespace HCIproject
{
    /// <summary>
    /// Interaction logic for DrugValidation.xaml
    /// </summary>
    public partial class DrugValidation : Window
    {
        public Doctor user;
        public long drugId;
        public ObservableCollection<Ingredient> ingredients { get; set; }
        public DrugValidation(Doctor user, long id)
        {
            InitializeComponent();

            this.user = user;
            this.drugId = id;
            dataInitialize();
            this.DataContext = this;
            ingredients = new ObservableCollection<Ingredient>();
            ingredients.Add(new Ingredient { Name = "sastojak1", Quantity = 23 });
            ingredients.Add(new Ingredient { Name = "sastojak2", Quantity = 11 });
            ingredients.Add(new Ingredient { Name = "sastojak3", Quantity = 66 });

        }

        public DrugValidation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { //otkazi treba samo da se vrati
          //   SideBar sideBarWin = new SideBar((Doctor)user);
          //  this.Visibility = Visibility.Hidden;
          //   sideBarWin.MyTabControl.SelectedIndex = 4;
          //   sideBarWin.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//Potvrdi treba da potvrdi sastav i ukloni lek sa spiska
         //  SideBar sideBarWin = new SideBar((Doctor)user);
         //  this.Visibility = Visibility.Hidden;
         //  sideBarWin.MyTabControl.SelectedIndex = 4;
         //   sideBarWin.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//idi na izmenu 
            EditDrug editDrugWin = new EditDrug((Doctor)user);
          //  this.Visibility = Visibility.Hidden;
            editDrugWin.ShowDialog();
        }

        private void dataInitialize()
        {
            var app = Application.Current as App;
           String name= app.DrugController.Get(drugId).Name;
           long sifra = app.DrugController.Get(drugId).Id;
            Console.WriteLine(name );
            imeLeka.Content = name.ToString();
            sifraLeka.Content = sifra.ToString();
            Random rand = new Random();
            int randInt = rand.Next(0,50);
            kolicina.Content = randInt;
        }
        private void fillTable(List<Ingredient> ingredients)
        {

        }
    }
}
