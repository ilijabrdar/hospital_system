using bolnica.Controller;
using Model.Director;
using Model.PatientSecretary;
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

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for RenovationDialog.xaml
    /// </summary>
    /// 
    public partial class RenovationDialog : Window
    {
        private readonly IRenovationController _renovationController;

        public RenovationDialog()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var app = Application.Current as App;
            _renovationController = app.RenovationController;
        }

        private void Button_Click_OK_Renovation(object sender, RoutedEventArgs e)
        {
            List<Room> temp = new List<Room>();
            temp.Add(new Room("3", new RoomType("jas"), null, null));
            var reno = new Renovation(Model.Director.RenovationStatus.Cancelled,
                new Period(startDatePicker.SelectedDate, endDatePicker.SelectedDate),
                txtDescription.Text,
                temp
                );
            _renovationController.Save(reno);

            this.Close();


        }

        private void Button_Click_Cancel_Renovation(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
