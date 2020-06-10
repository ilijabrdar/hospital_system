using Controller;
using Model.Doctor;
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
    /// Interaction logic for CreateArticle.xaml
    /// </summary>
    public partial class CreateArticle : Window
    {
        Article article;

        public Doctor user;
        public String Topic { get; set; }
        public String NewArticle { get; set; }

        public CreateArticle(Doctor _user)
        {
            this.DataContext = this;
            InitializeComponent();
            user = _user;
        }
        public CreateArticle()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//potvrdi
            var app = Application.Current as App;
            if (Topic ==null || NewArticle == null)
            {
                Obavesti.Content = "Da bi ste sačuvali članak neophodno je da uneste njegov naslov i sadržaj.";
            }
            else {
                article = new Article(DateTime.Today, user, Topic, NewArticle);
                article.Doctor.FirstName = user.FirstName;
                article.Doctor.LastName = user.LastName;
                app.ArticleController.Save(article);


                SideBar sideBarWin = new SideBar((Doctor)user);
                this.Visibility = Visibility.Hidden;
                sideBarWin.MyTabControl.SelectedIndex = 1;
                sideBarWin.Show();
            }
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
