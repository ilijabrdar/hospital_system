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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for IntroductionWizard.xaml
    /// </summary>
    public partial class IntroductionWizard : Window
    {
        int currentPage;
        public IntroductionWizard()
        {
            InitializeComponent();
            currentPage = 1;
            Previous.Visibility = Visibility.Hidden;
            FillCircles(currentPage);
            PicTime(currentPage);
        }

        private void PreviousPage(object sender, RoutedEventArgs e)
        {
            currentPage--;
            if(currentPage == 1) Previous.Visibility = Visibility.Hidden;
            FillCircles(currentPage);
            PicTime(currentPage);
        }

        private void NextPage(object sender, RoutedEventArgs e)
        {
            Previous.Visibility = Visibility.Visible;
            currentPage++;
            if (currentPage == 5) Close(sender, e);
            FillCircles(currentPage);
            PicTime(currentPage);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FillCircles(int page)
        {
            switch (page)
            {
                case 1:
                    One.Fill = Brushes.Blue;
                    Two.Fill = Brushes.White;
                    Three.Fill = Brushes.White;
                    Four.Fill = Brushes.White;
                    Five.Fill = Brushes.White;
                    break;
                case 2:
                    One.Fill = Brushes.Blue;
                    Two.Fill = Brushes.Blue;
                    Three.Fill = Brushes.White;
                    Four.Fill = Brushes.White;
                    Five.Fill = Brushes.White;
                    break;
                case 3:
                    One.Fill = Brushes.Blue;
                    Two.Fill = Brushes.Blue;
                    Three.Fill = Brushes.Blue;
                    Four.Fill = Brushes.White;
                    Five.Fill = Brushes.White;
                    break;
                case 4:
                    One.Fill = Brushes.Blue;
                    Two.Fill = Brushes.Blue;
                    Three.Fill = Brushes.Blue;
                    Four.Fill = Brushes.Blue;
                    Five.Fill = Brushes.White;
                    break;
                case 5:
                    One.Fill = Brushes.Blue;
                    Two.Fill = Brushes.Blue;
                    Three.Fill = Brushes.Blue;
                    Four.Fill = Brushes.Blue;
                    Five.Fill = Brushes.Blue;
                    break;
            }
        }

        private void PicTime(int page)
        {
            switch(page)
            {
                case 1:
                    Img.Source = new BitmapImage(new Uri("C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/Images/Slide1.PNG"));
                    break;
                case 2:
                    Img.Source = new BitmapImage(new Uri("C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/Images/Slide2.PNG"));
                    break;
                case 3:
                    Img.Source = new BitmapImage(new Uri("C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/Images/Slide3.PNG"));
                    break;
                case 4:
                    Img.Source = new BitmapImage(new Uri("C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/Images/Slide4.PNG"));
                    break;
                case 5:
                    Img.Source = new BitmapImage(new Uri("C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/Images/Slide5.PNG"));
                    break;
            }
        }

    }
}
