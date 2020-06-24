using bolnica.Controller;
using bolnica.Repository;
using bolnica.Repository.CSV.Converter;
using bolnica.Service;
using Controller;
using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using Service;
using System;
using System.Windows;
using System.Windows.Controls;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private const string ROOMTYPE_FILE = "../../../../code/Resources/Data/roomtypes.csv";
        //private const string INGREDIENTS_FILE = "../../../../code/Resources/Data/ingredients.csv";
        //private const string ROOMS_FILE = "../../../../code/Resources/Data/rooms.csv";
        //private const string EQUIPMENT_FILE = "../../../../code/Resources/Data/equipment.csv";
        //private const string RENOVATIONS_FILE = "../../../../code/Resources/Data/renovations.csv";
        //private const string DRUGS_FILE = "../../../../code/Resources/Data/drugs.csv";
        //private const string DOCTORS_FILE = "../../../../code/Resources/Data/doctors.csv";
        //private const string SPECIALITY_FILE = "../../../../code/Resources/Data/speciality.csv";
        //private const string ADDRESS_FILE = "../../../../code/Resources/Data/AddressFile.txt";
        //private const string TOWN_FILE = "../../../../code/Resources/Data/TownFile.txt";
        //private const string STATE_FILE = "../../../../code/Resources/Data/StateFile.txt";
        //private const string BUSINESSDAY_FILE = "../../../../code/Resources/Data/businessdays.csv";
        //private const string DIRECTOR_FILE = "../../../../code/Resources/Data/director.csv";
        //private const string ARTICLES_FILE = "../../../../code/Resources/Data/articles.csv";


        //private const string CSV_DELIMITER = ",";
        //private const String CSV_ARRAY_DELIMITER = "|";

        private const String CSV_DELIMITER = ",";
        private const String CSV_DELIMITER2 = "|";
        private const String CSV_DICTIONARY_DELIMITER = ";";
        private const String CSV_ARRAY_DELIMITER = ":";

        private const string DIRECTOR_FILE = "../../../../code/Resources/Data/director.csv";
        private const String DOCTOR_FILE = "../../../../code/Resources/Data/doctors.csv";
        private const String DOCTOR_GRADE_FILE = "../../../../code/Resources/Data/doctorGradeFile.csv";
        private const String SPECIALITY_FILE = "../../../../code/Resources/Data/speciality.csv";
        private const String HOSPITALIZATION_FILE = "../../../../code/Resources/Data/hospitalizationFile.csv";
        private const String OPERATION_FILE = "../../../../code/Resources/Data/operationFile.csv";
        private const String DIAGNOSIS_FILE = "../../../../code/Resources/Data/diagnosisFile.csv";
        private const String PRESCRIPTION_FILE = "../../../../code/Resources/Data/prescriptionFile.csv";
        private const String REFERRAL_FILE = "../../../../code/Resources/Data/referralFile.csv";
        private const String SYMPTOM_FILE = "../../../../code/Resources/Data/symptomFile.csv";
        private const String THERAPY_FILE = "../../../../code/Resources/Data/therapyFile.csv";
        private const String ARTICLE_FILE = "../../../../code/Resources/Data/articles.csv";
        private const String ROOMTYPE_FILE = "../../../../code/Resources/Data/roomtypes.csv";
        private const String ROOM_FILE = "../../../../code/Resources/Data/rooms.csv";
        private const String EQUIPMENT_FILE = "../../../../code/Resources/Data/equipment.csv";
        private const String RENOVATION_FILE = "../../../../code/Resources/Data/renovations.csv";
        private const String EXAM_UPCOMING_FILE = "../../../../code/Resources/Data/upcomingExamination.csv";
        private const String EXAM_PREVIOUS_FILE = "../../../../code/Resources/Data/examinationPrevious.csv";
        private const String PATIENTFILE_FILE = "../../../../code/Resources/Data/patientFile.csv";
        private const String PATIENT_FILE = "../../../../code/Resources/Data/patient.csv";
        private const String DRUG_FILE = "../../../../code/Resources/Data/drugs.csv";
        private const String INGREDIENT_FILE = "../../../../code/Resources/Data/ingredients.csv";
        private const String BUSSINESDAY_FILE = "../../../../code/Resources/Data/businessdays.csv";
        private const String ADDRESS_FILE = "../../../../code/Resources/Data/AddressFile.txt";
        private const String TOWN_FILE = "../../../../code/Resources/Data/townFile.txt";
        private const String STATE_FILE = "../../../../code/Resources/Data/StateFile.txt";


        public IRoomTypeController RoomTypeController { get; private set; }
        public IIngredientController IngredientController { get; private set; }
        public IRoomController RoomController { get; private set; }

        public IEquipmentController EquipmentController { get; private set; }

        public IRenovationController RenovationController { get; private set; }

        public IDrugController DrugController { get; private set; }

        public IDoctorController DoctorController { get; private set; }

        public ISpecialityController SpecialityController { get; private set; }

        public IStateController StateController { get; private set; }

        public IBusinessDayController BusinessDayController { get; private set; }

        public IDirectorController DirectorController { get; private set; }

        public IArticleController ArticleController { get; private set; }

        public AddressController AddressController { get; private set; }
        public NotificationController NotificationController { get; private set; }



        public IUserController UserController { get; private set; }
        public IExaminationController ExaminationController { get; private set; }
        public IPatientController PatientController { get; private set; }
        public IPatientFileController PatientFileController { get; private set; }
        public IHospitalizationController HospitalizationController { get; private set; }
        public IOperationController OperationController { get; private set; }
        public IDiagnosisController DiagnosisController { get; private set; }
        public IPrescriptionController PrescriptionController { get; private set; }
        public IReferralController ReferralController { get; private set; }
        public ISymptomController SymptomController { get; private set; }
        public ITherapyController TherapyController { get; private set; }
        public ITownController TownController { get; private set; }

        public App()
        {
            //var roomTypeRepository = new RoomTypeRepository(
            //    new CSVStream<RoomType>(ROOMTYPE_FILE, new RoomTypeCSVConverter(CSV_DELIMITER)),
            //    new LongSequencer());
            //var roomTypeService = new RoomTypeService(roomTypeRepository,null);
            //RoomTypeController = new RoomTypeController(roomTypeService);


            //var ingredientRepository = new IngredientRepository(
            //    new CSVStream<Ingredient>(INGREDIENTS_FILE, new IngredientsCSVConverter(CSV_DELIMITER)),
            //    new LongSequencer());
            //var ingredientService = new IngredientService(ingredientRepository);
            //IngredientController = new IngredientController(ingredientService);


            //var equipmentRepository = new EquipmentRepository(
            //   new CSVStream<Equipment>(EQUIPMENT_FILE, new EquipmentCSVConverter(CSV_DELIMITER)),
            //   new LongSequencer());
            //var equipmentService = new EquipmentService(equipmentRepository,null);
            //EquipmentController = new EquipmentController(equipmentService);




            //var renovationRepository = new RenovationRepository(new CSVStream<Renovation>(RENOVATIONS_FILE, new RenovationCSVConverter("|")), new LongSequencer(),null);
            //var renovationService = new RenovationService(renovationRepository);
            //RenovationController = new RenovationController(renovationService);

            //var roomRepository = new RoomRepository(
            //   new CSVStream<Room>(ROOMS_FILE, new RoomCSVConverter(CSV_DELIMITER)),
            //   new LongSequencer(), roomTypeRepository, equipmentRepository);
            //var roomService = new RoomService(roomRepository, renovationService,null);
            //RoomController = new RoomController(roomService);

            //equipmentService.roomService = roomService;

            //renovationRepository._roomRepository = roomRepository;
            //roomTypeService.roomService = roomService;

            //var drugRepository = new DrugRepository(new CSVStream<Drug>(DRUGS_FILE, new DrugCSVConverter(CSV_DELIMITER)), new LongSequencer(), ingredientRepository);
            //var drugService = new DrugService(drugRepository);
            //DrugController = new DrugController(drugService);

            //var specialityRepository = new SpecialityRepository(new CSVStream<Speciality>(SPECIALITY_FILE, new SpecialityCSVConverter(CSV_DELIMITER)), new LongSequencer());
            //var specialityService = new SpecialityService(specialityRepository);
            //SpecialityController = new SpecialityController(specialityService);



            //AddressRepository addressRepository = new AddressRepository(new CSVStream<Address>(ADDRESS_FILE, new AddressCSVConverter(CSV_DELIMITER)), new LongSequencer());
            //TownRepository townRepository = new TownRepository(new CSVStream<Town>(TOWN_FILE, new TownCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), addressRepository);
            //StateRepository stateRepository = new StateRepository(new CSVStream<State>(STATE_FILE, new StateCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), townRepository);

            //AddressService addressService = new AddressService(addressRepository);
            //AddressController = new AddressController(addressService);

            //StateService stateService = new StateService(stateRepository);
            //StateController = new StateController(stateService);

            //var businessDayRepository = new BusinessDayRepository(new CSVStream<BusinessDay>(BUSINESSDAY_FILE, new BusinessDayCSVConverter()), new LongSequencer(), roomRepository);
            //businessDayRepository.doctorRepo = doctorRepository;
            //var businessDayService = new BusinessDayService(businessDayRepository, doctorService);

            //var doctorRepository = new DoctorRepository(new CSVStream<Doctor>(DOCTORS_FILE, new DoctorCSVConverter(CSV_DELIMITER)), new LongSequencer(), null, specialityRepository, null);
            //var doctorService = new DoctorService(doctorRepository, null, null, null);
            //DoctorController = new DoctorController(doctorService);


            //BusinessDayController = new BusinessDayController(businessDayService);

            //roomService.businessDayService = businessDayService;

            //doctorService._businessDayService = businessDayService;


            //doctorRepository._businessDayRepo = businessDayRepository;



            //ArticleRepository articleRepository = new ArticleRepository(new CSVStream<Article>(ARTICLES_FILE, new ArticleCSVConverter(CSV_DELIMITER)), new LongSequencer(),doctorRepository);
            //articleRepository._doctorRepository = doctorRepository;
            //ArticleService articleService = new ArticleService(articleRepository);
            //ArticleController = new ArticleController(articleService);

            //doctorService._articleService = articleService;

            DoctorGradeRepository doctorGradeRepository = new DoctorGradeRepository(new CSVStream<DoctorGrade>(DOCTOR_GRADE_FILE, new DoctorGradeCSVConverter(CSV_DELIMITER2, CSV_DICTIONARY_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            SpecialityRepository specialityRepository = new SpecialityRepository(new CSVStream<Speciality>(SPECIALITY_FILE, new SpecialityCSVConverter(CSV_DELIMITER)), new LongSequencer());
            SymptomRepository symptomRepository = new SymptomRepository(new CSVStream<Symptom>(SYMPTOM_FILE, new SymptomCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DiagnosisRepository diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(DIAGNOSIS_FILE, new DiagnosisCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), symptomRepository);
            IngredientRepository ingredientRepository = new IngredientRepository(new CSVStream<Ingredient>(INGREDIENT_FILE, new IngredientsCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DrugRepository drugRepository = new DrugRepository(new CSVStream<Drug>(DRUG_FILE, new DrugCSVConverter(CSV_DELIMITER)), new LongSequencer(), ingredientRepository);
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(PRESCRIPTION_FILE, new PrescriptionCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), drugRepository);
            TherapyRepository therapyRepository = new TherapyRepository(new CSVStream<Therapy>(THERAPY_FILE, new TherapyCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), drugRepository);
            RoomTypeRepository roomTypeRepository = new RoomTypeRepository(new CSVStream<RoomType>(ROOMTYPE_FILE, new RoomTypeCSVConverter(CSV_DELIMITER)), new LongSequencer());
            EquipmentRepository equipmentRepository = new EquipmentRepository(new CSVStream<Equipment>(EQUIPMENT_FILE, new EquipmentCSVConverter(CSV_DELIMITER)), new LongSequencer());
            RoomRepository roomRepository = new RoomRepository(new CSVStream<Room>(ROOM_FILE, new RoomCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomTypeRepository, equipmentRepository);
            BusinessDayRepository businessDayRepository = new BusinessDayRepository(new CSVStream<BusinessDay>(BUSSINESDAY_FILE, new BusinessDayCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository);
            RenovationRepository renovationRepository = new RenovationRepository(new CSVStream<Renovation>(RENOVATION_FILE, new RenovationCSVConverter(CSV_DELIMITER2)), new LongSequencer(), roomRepository);
            AddressRepository addressRepository = new AddressRepository(new CSVStream<Address>(ADDRESS_FILE, new AddressCSVConverter(CSV_DELIMITER)), new LongSequencer());
            TownRepository townRepository = new TownRepository(new CSVStream<Town>(TOWN_FILE, new TownCSVConverter(CSV_DELIMITER, CSV_DELIMITER2)), new LongSequencer(), addressRepository);
            StateRepository stateRepository = new StateRepository(new CSVStream<State>(STATE_FILE, new StateCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), townRepository);
            DoctorRepository doctorRepository = new DoctorRepository(new CSVStream<Doctor>(DOCTOR_FILE, new DoctorCSVConverter(CSV_DELIMITER)), new LongSequencer(), businessDayRepository, specialityRepository, doctorGradeRepository, addressRepository, townRepository, stateRepository);
            ArticleRepository articleRepository = new ArticleRepository(new CSVStream<Article>(ARTICLE_FILE, new ArticleCSVConverter(CSV_DELIMITER2)), new LongSequencer(), doctorRepository);

            businessDayRepository.doctorRepo = doctorRepository;

            ReferralRepository referralRepository = new ReferralRepository(new CSVStream<Referral>(REFERRAL_FILE, new ReferralCSVConverter(CSV_DELIMITER)), new LongSequencer(), doctorRepository);
            PatientFileRepository patientFileRepository = new PatientFileRepository(new CSVStream<PatientFile>(PATIENTFILE_FILE, new PatientFileCSVConverter(CSV_DELIMITER, CSV_DELIMITER2)), new LongSequencer());
            PatientRepository patientRepository = new PatientRepository(new CSVStream<Patient>(PATIENT_FILE, new PatientCSVConverter(CSV_DELIMITER)), new LongSequencer(), patientFileRepository, addressRepository, townRepository,stateRepository);
            HospitalizationRepository hospitalizationRepository = new HospitalizationRepository(new CSVStream<Hospitalization>(HOSPITALIZATION_FILE, new HospitalizationCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository, patientRepository);
            OperationRepository operationRepository = new OperationRepository(new CSVStream<Operation>(OPERATION_FILE, new OperationCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository, doctorRepository, patientRepository);
            ExaminationUpcomingRepository examinationUpcomingRepository = new ExaminationUpcomingRepository(new CSVStream<Examination>(EXAM_UPCOMING_FILE, new UpcomingExaminationCSVConverter(CSV_DELIMITER)), new LongSequencer(), doctorRepository, patientRepository);
            ExaminationPreviousRepository examinationPreviousRepository = new ExaminationPreviousRepository(new CSVStream<Examination>(EXAM_PREVIOUS_FILE, new PreviousExaminationCSVConverter(CSV_DELIMITER, CSV_DELIMITER2)), new LongSequencer(), doctorRepository, patientRepository, diagnosisRepository, prescriptionRepository, therapyRepository, referralRepository);
            patientFileRepository._hospitalizationRepository = hospitalizationRepository;
            patientFileRepository._operationRepository = operationRepository;
            patientFileRepository._examinationPreviousRepository = examinationPreviousRepository;
            AddressService addressService = new AddressService(addressRepository);
            StateService stateService = new StateService(stateRepository);
            TownService townService = new TownService(townRepository);



            DoctorService doctorService = new DoctorService(doctorRepository);
            DoctorGradeService doctorGradeService = new DoctorGradeService(doctorGradeRepository);
            SpecialityService specialityService = new SpecialityService(specialityRepository);
            HospitalizationService hospitalizationService = new HospitalizationService(hospitalizationRepository);
            OperationService operationService = new OperationService(operationRepository);
            DiagnosisService diagnosisService = new DiagnosisService(diagnosisRepository);
            PrescriptionService prescriptionService = new PrescriptionService(prescriptionRepository);
            ReferralService referralService = new ReferralService(referralRepository);
            SymptomService symptomService = new SymptomService(symptomRepository);
            TherapyService therapyService = new TherapyService(therapyRepository);
            ArticleService articleService = new ArticleService(articleRepository);
            UserService userService = new UserService(null, doctorService, null, null);
            ExaminationService examinationService = new ExaminationService(examinationUpcomingRepository, examinationPreviousRepository);
            DrugService drugService = new DrugService(drugRepository);
            IngredientService ingredientService = new IngredientService(ingredientRepository);
            PatientFileService patientFileService = new PatientFileService(patientFileRepository);
            PatientService patientService = new PatientService(patientRepository, patientFileService, doctorGradeService);
            BusinessDayService businessDayService = new BusinessDayService(businessDayRepository, doctorService);
            RenovationService renovationService = new RenovationService(renovationRepository);
            RoomService roomService = new RoomService(roomRepository, renovationService, businessDayService);
            RoomTypeService roomTypeService = new RoomTypeService(roomTypeRepository, roomService);
            EquipmentService equipmentService = new EquipmentService(equipmentRepository, roomService);

            UserController = new UserController(userService);
            ArticleController = new ArticleController(articleService);
            SpecialityController = new SpecialityController(specialityService);
            ExaminationController = new ExaminationController(examinationService);
            HospitalizationController = new HospitalizationController(hospitalizationService);
            OperationController = new OperationController(operationService);
            DiagnosisController = new DiagnosisController(diagnosisService);
            PrescriptionController = new PrescriptionController(prescriptionService);
            ReferralController = new ReferralController(referralService);
            SymptomController = new SymptomController(symptomService);
            DrugController = new DrugController(drugService);
            IngredientController = new IngredientController(ingredientService);
            DiagnosisController = new DiagnosisController(diagnosisService);
            PatientController = new PatientController(patientService);
            PatientFileController = new PatientFileController(patientFileService);
            RoomController = new RoomController(roomService);
            RoomTypeController = new RoomTypeController(roomTypeService);
            EquipmentController = new EquipmentController(equipmentService);
            AddressController = new AddressController(addressService);
            TownController = new TownController(townService);
            StateController = new StateController(stateService);
            BusinessDayController = new BusinessDayController(businessDayService);
            RenovationController = new RenovationController(renovationService);
            DoctorController = new DoctorController(doctorService);
                

            var directorRepository = new DirectorRepository(new CSVStream<Director>(DIRECTOR_FILE, new DirectorCSVConverter(CSV_DELIMITER)), new LongSequencer(), addressRepository, townRepository, stateRepository);
            var directorService = new DirectorService(directorRepository);
            DirectorController = new DirectorContoller(directorService);

            NotificationService notificationService = new NotificationService(drugService, businessDayService);
            NotificationController = new NotificationController(notificationService);

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\david\Desktop\cc\hospital_system\upravnikKT2\upravnikKT2\Resources\Data\config.txt");

            if (text.Equals("false"))
                StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
            else
                StartupUri = new Uri("DashboardWindow.xaml", UriKind.Relative);

        }
    }
}
