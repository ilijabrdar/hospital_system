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
using bolnica.Controller;
using Controller;
using Model.Doctor;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Window
    {
        public Index()
        {
            InitializeComponent();
            CreateArticles();
        }

        private void CreateArticles()
        {
            App app = Application.Current as App;
            IArticleController articleController = app.ArticleController;
            foreach (Article article in articleController.GetAll())
            {
                Border b = new Border();
                b.Focusable = true;
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(2);
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                b.Margin = new Thickness(5, 5, 5, 5);

                StackPanel stackPanelArticle = new StackPanel();
                TextBlock newTopic = new TextBlock();
                TextBlock newText = new TextBlock();
                TextBlock writer = new TextBlock();

                newTopic.TextWrapping = TextWrapping.Wrap;
                newTopic.FontSize = 20;
                newTopic.FontWeight = FontWeights.Bold;
                newTopic.HorizontalAlignment = HorizontalAlignment.Center;
                newTopic.Foreground = Brushes.LightSteelBlue;
                newText.TextWrapping = TextWrapping.Wrap;
                newText.HorizontalAlignment = HorizontalAlignment.Stretch;
                newText.Margin = new Thickness(10);
                newText.FontSize = 15;
                writer.FontSize = 10;
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

        private void OpenLoginDialog(object sender, RoutedEventArgs e)
        {
            Login loginDialog = new Login();
            loginDialog.Show();
            this.Close();
        }
    }
}
