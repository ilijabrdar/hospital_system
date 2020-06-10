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
            setArticle();


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
                    ArticleWin artWind = new ArticleWin();
                    this.Visibility = Visibility.Hidden;
                    artWind.Show();
                }
            }
        }

        private void setArticle()
        {
            var app = Application.Current as App;


            foreach (var article in app.ArticleController.GetAll())
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
                newText.Text = article.Text;
                writer.Text = article.Doctor.FirstName + " " + article.Doctor.LastName;

                stackPanelArticle.Children.Add(newTopic);
                stackPanelArticle.Children.Add(newText);
                stackPanelArticle.Children.Add(writer);

                b.Child = stackPanelArticle;

                Articles.Children.Add(b);
            }

        }

    }
}
