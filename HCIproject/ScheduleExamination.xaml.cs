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
    /// Interaction logic for ScheduleExamination.xaml
    /// </summary>
    public partial class ScheduleExamination : Window
    {
        public ScheduleExamination()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Examination exam = new Examination();
            this.Visibility = Visibility.Hidden;
            exam.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Examination exam = new Examination();
            this.Visibility = Visibility.Hidden;
            exam.Show();
        }
    }
}
