using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls;
using MahApps.Metro;
using Model.Users;
using System.ComponentModel;

namespace PacijentBolnicaZdravo
{

    public partial class WindowLogIn : MetroWindow, INotifyPropertyChanged
    {
        public WindowLogIn()
        {

           InitializeComponent();

            setArticle();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
 
            if (MainWindow.Theme == 1)
            {
                ThemeManager.ChangeAppStyle(this,
                                   ThemeManager.GetAccent("Teal"),
                                   ThemeManager.GetAppTheme("BaseDark"));
                DarkMode.Value = DarkMode.Maximum;
            }
            else
            {
                ThemeManager.ChangeAppStyle(this,
                                   ThemeManager.GetAccent("Blue"),
                                   ThemeManager.GetAppTheme("BaseLight"));
                DarkMode.Value = DarkMode.Minimum;
            }

            this.DataContext = this;


        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private void setArticle()
        {
            var app = Application.Current as App;
          
            foreach (var article in app.ArticleController.GetAll())
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.LightBlue;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelArticle = new StackPanel();
                TextBlock newTopic = new TextBlock();
                TextBlock newText = new TextBlock();
                TextBlock writer = new TextBlock();

                newTopic.TextWrapping = TextWrapping.Wrap;
                newTopic.FontSize = 15;
                newTopic.FontWeight = FontWeights.Bold;
                newTopic.MaxWidth = 700;
                newTopic.HorizontalAlignment = HorizontalAlignment.Center;
                newText.TextWrapping = TextWrapping.Wrap;
                newText.FontSize = 13;
                newText.MaxWidth = 700;
                writer.FontSize = 12;
                writer.HorizontalAlignment = HorizontalAlignment.Right;


                newTopic.Text = article.Topic;
                writer.Text = article.Doctor.FirstName + " " + article.Doctor.LastName;
                newText.Text = article.Text;

                stackPanelArticle.Children.Add(newTopic);
                stackPanelArticle.Children.Add(newText);
                stackPanelArticle.Children.Add(writer);

                b.Child = stackPanelArticle;

                ArticlesPanel.Children.Add(b);
            }
        }

        private String _username;
        public String USERNAME
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("USERNAME");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String username = UsernameLogIn.Text.ToString();
            String password = PasswordLogIn.Password.ToString();
            
                var app = Application.Current as App;
                var temp = app.userController.Login(username,password);
            if (temp != null) {
                
                App.j = 0;
                MainWindow mw = new MainWindow((Patient)temp);
                mw.Show();
                //TODO : provera za ako ne nadje

                this.Close();
                return;
            }
            LogInValidation.badUserString = "badUserString";
            UsernameLogIn.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
            return;
 
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if ((int)DarkMode.Value == 1)
            {
                ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Teal"),
                                    ThemeManager.GetAppTheme("BaseDark"));
                MainWindow.Theme = 1;
            }
            else
            {
                ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Blue"),
                                    ThemeManager.GetAppTheme("BaseLight"));
                MainWindow.Theme = 0;
            }
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            App.j = 0;
            Registration lg = new Registration();
            lg.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      
  
        }
    }
}
