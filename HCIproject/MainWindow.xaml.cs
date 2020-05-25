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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCIproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }
  

        private void search_text_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (searchTxt.Text == "Unesite parametar pretrage")
            {
                searchTxt.Text = "";
            }
        }
        

        private void open_LogIn(object sender, RoutedEventArgs e)
        {
            Log logWind = new Log();
            this.Visibility = Visibility.Hidden;
            logWind.Show();
        }

        private void search_text_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter)
            {
                if (searchTxt.Text == "")
                {
                    return;
                }
                else
                {
                    Article artWind = new Article();
                    this.Visibility = Visibility.Hidden;
                    artWind.Show();
                }
            }
        }

    }
}
