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
using bolnica.Repository.CSV.Converter;
using System.Windows.Controls;
using bolnica.Service;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const String CSV_DELIMITER = ",";
        private const String CSV_ARRAY_DELIMITER = "|";
        private const String SECRETARY_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/SecretaryFile.txt";
        private const String ADDRESS_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/AddressFile.txt";
        private const String TOWN_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/TownFile.txt";
        private const String STATE_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/StateFile.txt";

        public IUserController UserController { get; private set; }
        public IStateController StateController { get; private set; }
        public App()
        {
            AddressRepository addressRepository = new AddressRepository(new CSVStream<Address>(ADDRESS_FILE, new AddressCSVConverter(CSV_DELIMITER)), new LongSequencer());
            TownRepository townRepository = new TownRepository(new CSVStream<Town>(TOWN_FILE, new TownCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), addressRepository);
            StateRepository stateRepository = new StateRepository(new CSVStream<State>(STATE_FILE, new StateCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), townRepository);
            
            SecretaryRepository secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer(), addressRepository, townRepository, stateRepository);
            // DirectorRepository directorRepository = new DirectorRepository(new CSVStream<Director>(SECRETARY_FILE, null, new LongSequencer());
            // DoctorRepository doctorRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer());
            // PatientRepository patientRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer());

            SecretaryService secretaryService = new SecretaryService(secretaryRepository);

            UserService userService = new UserService(null, null, secretaryService, null);
            UserController = new UserController(userService);

            StateService stateService = new StateService(stateRepository);
            StateController = new StateController(stateService);

            //User user = userController.Login("pera", "pera");
            //Secretary secretary = (Secretary)user;
            //Console.WriteLine(secretary.FirstName);
            //Console.WriteLine(secretary.LastName);
            //Console.WriteLine(secretary.Jmbg);
            //Console.WriteLine(secretary.Username);
            //Console.WriteLine(secretary.Password);
            //Console.WriteLine(secretary.Email);
            //Console.WriteLine(secretary.address.Street);
            //Console.WriteLine(secretary.address.GetTown().Name);
            //Console.WriteLine(secretary.address.GetTown().GetState().Name);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textField = sender as TextBox;
            textField.SelectAll();
        }
    }
}
