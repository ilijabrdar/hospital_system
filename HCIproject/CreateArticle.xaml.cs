using Controller;
using Model.Doctor;
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
    /// Interaction logic for CreateArticle.xaml
    /// </summary>
    public partial class CreateArticle : Window
    {
        private readonly IController<Article, long> _articleController;

        public String Topic { get; set; }
        public String NewArticle { get; set; }
        public CreateArticle()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            Article article = new Article(111, DateTime.Today, Topic, NewArticle);
            //_articleController.Save(article);
            SideBar sideBarWin = new SideBar();
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 1;
            sideBarWin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //otkazi
            SideBar sideBarWin = new SideBar();
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 1;
            sideBarWin.Show();
        }
    }
}
