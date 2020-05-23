using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Repository;
using bolnica.Repository;
using Model.Users;
using Service;
using Controller;
using bolnica.Controller;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const String CSV_DELIMITER = ",";
        private const String SECRETARY_FILE = "";

        public IUserController UserController { get; private set; }
        public App()
        {
            // SecretaryRepository secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer());
            // DirectorRepository directorRepository = new DirectorRepository(new CSVStream<Director>(SECRETARY_FILE, null, new LongSequencer());
            // DoctorRepository doctorRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer());
            // PatientRepository patientRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer());

            //UserService userService = new UserService(null, null, secretaryRepository, null, null);
            //UserController = new UserController(userService);
        }
    }
}
