using bolnica.Controller;
using Model.Users;
using System.Collections;
using System.IO;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDirectorController directorController;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;


            var app = Application.Current as App;
            directorController = app.DirectorController;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxKorisnickoIme.Text.Equals("") || lozinka.Password.Equals(""))
            {
                labelError.Content = "Unesite korisnicko ime i lozinku!";
                labelError.Visibility = Visibility.Visible;
                //stackPanel.Children.Add(box);

                //string messageBoxText = "Unesite korisnicko ime i lozinku!";
                //string caption = "Greska";
                //MessageBoxButton button = MessageBoxButton.OK;
                //MessageBoxImage icon = MessageBoxImage.Error;

                //MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else if (TxtBoxKorisnickoIme.Text.Equals("marko") || lozinka.Password.Equals("marko"))
            {
                bool selected = (bool)stayLoggedIn.IsChecked;
                if (selected)
                {
                    
                    //delete false and write true
                    string path = @"C:\Users\david\Desktop\cc\hospital_system\upravnikKT2\upravnikKT2\Resources\Data\config.txt";
                    //File.Delete(path);

                    File.WriteAllText(path, "true");
                }
                else
                {
                    //delete true and write false
                    string path = @"C:\Users\david\Desktop\cc\hospital_system\upravnikKT2\upravnikKT2\Resources\Data\config.txt";

                    File.WriteAllText(path, "false");
                }
                Director temp = directorController.Get(1);
                DashboardWindow dashBoard = new DashboardWindow();
                dashBoard.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                dashBoard.Show();
                this.Close();
            }
            else
            {
                labelError.Content = "Neispravno korisnicko ime/lozinka!";
                labelError.Visibility = Visibility.Visible;
            }

            
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                button_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
