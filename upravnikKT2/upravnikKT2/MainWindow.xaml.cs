using System.Windows;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxKorisnickoIme.Text.Equals("") || lozinka.Password.Equals(""))
            {
                string messageBoxText = "Unesite korisnicko ime i lozinku!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                DashboardWindow dashBoard = new DashboardWindow();
                dashBoard.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                dashBoard.Show();
                this.Close();
            }

            
        }
    }
}
