using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
        public List<Article> articles=new List<Article>();

        public ArticleWin(List<Article> articles)
        {
            this.articles = articles;
            InitializeComponent();
            setArticle();

        }
        public void setArticle()
        {
            var app = Application.Current as App;
            if (articles.Count == 0)
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(5);
                b.CornerRadius = new CornerRadius(5);
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelArticle = new StackPanel();
                TextBlock newTopic = new TextBlock();
                newTopic.TextWrapping = TextWrapping.Wrap;
                newTopic.FontSize = 12;
                newTopic.FontWeight = FontWeights.Bold;
                newTopic.MaxWidth = 700;
                newTopic.HorizontalAlignment = HorizontalAlignment.Center;
                newTopic.Text = "Ne postoji clanak koji zadovoljava dati parametar pretrage.";
                stackPanelArticle.Children.Add(newTopic);
                b.Child = stackPanelArticle;

                Articles.Children.Add(b);

            }
            else
            {

                foreach (Article article in articles)
                {
                    Border b = new Border();
                    b.BorderThickness = new Thickness(5);
                    b.CornerRadius = new CornerRadius(5);
                    b.BorderBrush = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                    b.Margin = new Thickness(10, 10, 10, 10);

                    StackPanel stackPanelArticle = new StackPanel();
                    TextBlock newTopic = new TextBlock();
                    TextBlock newText = new TextBlock();
                    TextBlock writer = new TextBlock();



                    newTopic.TextWrapping = TextWrapping.Wrap;
                    newTopic.FontSize = 12;
                    newTopic.FontWeight = FontWeights.Bold;
                    newTopic.MaxWidth = 700;
                    newTopic.HorizontalAlignment = HorizontalAlignment.Center;
                    newText.TextWrapping = TextWrapping.Wrap;
                    newText.FontSize = 10;
                    newText.MaxWidth = 700;
                    writer.FontSize = 8;
                    writer.HorizontalAlignment = HorizontalAlignment.Right;


                    newTopic.Text = article.Topic;
                    writer.Text = article.Doctor.FirstName + " " + article.Doctor.LastName;
                    newText.Text = article.Text;

                    stackPanelArticle.Children.Add(newTopic);
                    stackPanelArticle.Children.Add(newText);
                    stackPanelArticle.Children.Add(writer);

                    b.Child = stackPanelArticle;

                    Articles.Children.Add(b);
                }
            }

        }
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
            /// MainWindow mainWin = new MainWindow();
            //  this.Visibility = Visibility.Hidden;
            //   mainWin.Show();
            this.Close();
        }

        private void logBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
