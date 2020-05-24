using bolnica.Controller;
using Controller;
using Model.Director;
using Model.PatientSecretary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for AddRoomType.xaml
    /// </summary>
    public partial class AddRoomType : Window, INotifyPropertyChanged
    {
        private readonly IRoomTypeController _roomTypeController;
        private readonly IIngredientController _ingredientController; //TODO: delete this test
        private ListView list;

        public event PropertyChangedEventHandler PropertyChanged;
        

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public AddRoomType(ListView listView)
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;
            _roomTypeController = app.RoomTypeController;
            _ingredientController = app.IngredientController; //TODO: delete this test

            list = listView;

        }

        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            //var type = new RoomType(Ime);
            //_roomTypeController.Save(type);

            ////TODO: delete this test
            //var ingredients = new Ingredient("sastav", 323);
            //_ingredientController.Save(ingredients);

            //2,test3
            //var edit = new RoomType(2,"test3 u yas");  //TODO: delete this test
            //_roomTypeController.Edit(edit);

            _roomTypeController.Save(new RoomType(Ime));
            

            this.Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
