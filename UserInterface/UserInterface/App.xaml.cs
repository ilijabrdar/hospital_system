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
using Model.PatientSecretary;
using Model.Director;
using Model.Doctor;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const String CSV_DELIMITER = ",";
        private const String CSV_ARRAY_DELIMITER = "|";
        private const String CSV_DICTIONARY_DELIMITER = ";";
        private const String CSV_COLOMN_DELIMITER = ":";

        private const String SECRETARY_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/SecretaryFile.txt";
        private const String DOCTOR_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/DoctorFile.csv";

        private const String ADDRESS_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/AddressFile.txt";
        private const String TOWN_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/TownFile.txt";
        private const String STATE_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/StateFile.txt";

        private const string ROOM_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/roomFile.txt";
        private const string EQUIPMENT_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/equipment.csv";
        private const string ROOMTYPE_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/roomtypes.csv";
        private const String SPECIALITY_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/SpecialityFile.csv";
        private const String DOCTOR_GRADE_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/DoctorGradeFile.csv";

        private const String ARTICLE_FILE = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/articleFile.csv";

        private readonly String _patient_File = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/PatientFile.txt";
        private readonly String _patientFile_File = "C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/patientFileFile.txt";



        public IUserController UserController { get; private set; }
        public IPatientController PatientController { get; private set; }
        public IStateController StateController { get; private set; }
        public ISecretaryController SecretaryController { get;private set; }

        public IRoomController RoomController { get; private set; }

        public IArticleController ArticleController { get; private set; }

        public IDoctorController DoctorController { get; private set; }

        public App()
        {
            AddressRepository addressRepository = new AddressRepository(new CSVStream<Address>(ADDRESS_FILE, new AddressCSVConverter(CSV_DELIMITER)), new LongSequencer());
            TownRepository townRepository = new TownRepository(new CSVStream<Town>(TOWN_FILE, new TownCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), addressRepository);
            StateRepository stateRepository = new StateRepository(new CSVStream<State>(STATE_FILE, new StateCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), townRepository);

            ArticleRepository articleRepository = new ArticleRepository(new CSVStream<Article>(ARTICLE_FILE, new ArticleCSVConverter(CSV_ARRAY_DELIMITER)), new LongSequencer());
            SpecialityRepository specialityRepository = new SpecialityRepository(new CSVStream<Speciality>(SPECIALITY_FILE, new SpecialityCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DoctorGradeRepository doctorGradeRepository = new DoctorGradeRepository(new CSVStream<DoctorGrade>(DOCTOR_GRADE_FILE, new DoctorGradeCSVConverter(CSV_ARRAY_DELIMITER, CSV_DICTIONARY_DELIMITER, CSV_COLOMN_DELIMITER)), new LongSequencer());
            var roomTypeRepository = new RoomTypeRepository(
              new CSVStream<RoomType>(ROOMTYPE_FILE, new RoomTypeCSVConverter(CSV_DELIMITER)),
              new LongSequencer());

            var equipmentRepository = new EquipmentRepository(
              new CSVStream<Equipment>(EQUIPMENT_FILE, new EquipmentCSVConverter(CSV_DELIMITER)),
              new LongSequencer());

            var roomRepository = new RoomRepository(
               new CSVStream<Room>(ROOM_FILE, new RoomCSVConverter(CSV_DELIMITER)),
               new LongSequencer(), roomTypeRepository, equipmentRepository);
            BusinessDayRepository businessDayRepository = new BusinessDayRepository(new CSVStream<BusinessDay>(ROOM_FILE, new BusinessDayCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository);


            SecretaryRepository secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer(), addressRepository, townRepository, stateRepository);
            DoctorRepository doctorRepository = new DoctorRepository(new CSVStream<Doctor>(DOCTOR_FILE, new DoctorCSVConverter(CSV_DELIMITER)), new LongSequencer(), articleRepository, businessDayRepository, specialityRepository, doctorGradeRepository);//, addressRepository,townRepository,stateRepository);
            // DirectorRepository directorRepository = new DirectorRepository(new CSVStream<Director>(SECRETARY_FILE, null, new LongSequencer());
            // DoctorRepository doctorRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer());
            // PatientRepository patientRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer());

            SecretaryService secretaryService = new SecretaryService(secretaryRepository);
            SecretaryController = new SecretaryController(secretaryService);

            UserService userService = new UserService(null, null, secretaryService, null);
            UserController = new UserController(userService);

            StateService stateService = new StateService(stateRepository);
            StateController = new StateController(stateService);

            DoctorService doctorService = new DoctorService(doctorRepository);
            DoctorController = new DoctorController(doctorService);

            var patientFileRepo = new PatientFileRepository(new CSVStream<PatientFile>(_patientFile_File, new PatientFileCSVConverter()), new LongSequencer());
            var patientFileService = new PatientFileService(patientFileRepo);
            var patientRepo = new PatientRepository(new CSVStream<Patient>(_patient_File, new PatientCSVConverter()), new LongSequencer(), patientFileRepo);
            var patientService = new PatientService(patientRepo, patientFileService);
            PatientController = new PatientController(patientService);

            var roomService = new RoomService(roomRepository);

            RoomController = new RoomController(roomService);

            ArticleService articleService = new ArticleService(articleRepository);
            ArticleController = new ArticleController(articleService);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textField = sender as TextBox;
            textField.SelectAll();
        }
    }
}
