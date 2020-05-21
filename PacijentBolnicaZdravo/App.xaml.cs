using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PacijentBolnicaZdravo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
          public static int j = 0;
      
        App()
        {
           
           
        }
    /*    public static void ChangeCulture(CultureInfo info)
        {
            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = info;

            var oldWindow = Application.Current.MainWindow;

            oldWindow.Close();
            var w = new MainWindow();
            w.Show();
            Application.Current.MainWindow = w;

            
        }*/
/*
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            App.j = 0;
        }*/


    }
}
