using bolnica.Controller;
using bolnica.Repository;
using bolnica.Repository.CSV.Converter;
using Controller;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using Service;
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
        private readonly String _patient_File = "../../ResourcesFiles/patient.csv";
        private readonly String _patientFile_File = "../../ResourcesFiles/patientFile.csv";

        public IUserController userController;
      
        App()
        {
            var patientFileRepo = new PatientFileRepository(new CSVStream<PatientFile>(_patientFile_File, new PatientFileCSVConverter()), new LongSequencer());
            var patientFileService = new PatientFileService(patientFileRepo);
            var patientRepo = new PatientRepository(new CSVStream<Patient>(_patient_File, new PatientCSVConverter()), new LongSequencer());
            var patientService = new PatientService(patientRepo, patientFileService);
            var userService = new UserService(patientService);
            userController = new UserController(userService);
           
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
