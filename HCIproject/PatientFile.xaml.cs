﻿using System;
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
    /// Interaction logic for PatientFile.xaml
    /// </summary>
    public partial class PatientFile : Window
    {
        public PatientFile()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SideBar sideBarWin = new SideBar();
            this.Visibility = Visibility.Hidden;
            sideBarWin.MyTabControl.SelectedIndex = 3;
            sideBarWin.Show();
        }
    }
}
