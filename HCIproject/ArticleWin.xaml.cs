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
    /// <summary>
    /// Interaction logic for Article.xaml
    /// </summary>
    public partial class ArticleWin : Window
    {
        public Doctor user;

        public ArticleWin(Doctor user)
        {
            this.user = user;
            InitializeComponent();
        }

        public ArticleWin()
        {
            
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWin.Show();
        }
    }
}
