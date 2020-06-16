using Model.Dto;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for FindFileWindow.xaml
    /// </summary>
    public partial class FindFileWindow : Window
    {
        private List<ExaminationDTO> findFile= new List<ExaminationDTO>();
        private int num1 = 0;

        private Doctor user;
        public FindFileWindow(Doctor user, List<ExaminationDTO> file)
        {
            this.findFile = file;
            this.user = user;
            InitializeComponent();

            setFiles();
        }

        private void setFiles()
        {
            foreach (var exam in findFile)
            {
                StackPanel stack = new StackPanel();
                DockPanel dock = new DockPanel();
                Label lbl = new Label();
                Button btn1 = new Button();

                stack.Children.Add(dock);
                dock.Children.Add(lbl);
                dock.Children.Add(btn1);


                #region DockPanel Content Properties
                lbl.Content = exam.Patient.FirstName + " " + exam.Patient.LastName;
                lbl.Height = 32;
                lbl.Width = 180;
                lbl.FontSize = 15;
                lbl.FontWeight = FontWeights.Bold;
                lbl.SetValue(DockPanel.DockProperty, Dock.Left);
                lbl.Margin = new Thickness(10, 30, 15, 0);
                lbl.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

                btn1.Content = "Otvori";
                btn1.Height = 32;
                btn1.Width = 100;
                btn1.FontSize = 12;
                btn1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                btn1.SetValue(DockPanel.DockProperty, Dock.Right);
                btn1.Tag = exam.Patient.Id;
                btn1.Click += new RoutedEventHandler(ClickOpenPatientFile);
                btn1.Margin = new Thickness(10, 10, 15, 0);
                btn1.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                #endregion

                Grid_Grid1.RowDefinitions.Add(new RowDefinition());
                Grid_Grid1.RowDefinitions[num1].Height = new GridLength(66, GridUnitType.Pixel);
                Grid_Grid1.Children.Add(stack);
                stack.SetValue(Grid.RowProperty, num1);
                num1++;

            }
        }
        private void ClickOpenPatientFile(object sender, RoutedEventArgs e)
        {//posalji utisak
            var PatientId = ((Button)sender).Tag;
            PatientFileWin patientWin = new PatientFileWin((Doctor)user, (long)PatientId);
            this.Visibility = Visibility.Hidden;
            patientWin.Show();
        }

        private void logBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
