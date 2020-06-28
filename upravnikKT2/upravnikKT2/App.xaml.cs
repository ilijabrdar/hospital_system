using bolnica.Controller;
using bolnica.Controller.decorators;
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
        private const String SECRETARY_FILE = "../../../../code/Resources/Data/SecretaryFile.txt";


        public AuthorityRoomTypeDecorator authorityRoomType { get; private set; }
        public AuthorityIngredientDecorator authorityIngredient { get; private set; }
        public AuthorityRoomDecorator authorityRoom { get; private set; }

        public AuthorityEquipmentDecorator authorityEquipment { get; private set; }

        public AuthorityRenovationDecoratorcs authorityRenovation { get; private set; }

        public AuthorityDrugDecorator authorityDrug { get; private set; }

        public AuthorityDoctorDecorator authorityDoctor { get; private set; }

        public AuthoritySpecialityDecorator authoritySpeciality { get; private set; }

        public IStateController StateController { get; private set; }

        public AuthorityBusinessDayDecorator authorityBusinessDay { get; private set; }

        public AuthorityDirectorDecorator authorityDirector { get; private set; }

        public AuthorityArticleDecorator authorityArticle { get; private set; }

        public AddressController AddressController { get; private set; }
        public NotificationController NotificationController { get; private set; }



        public IUserController UserController { get; private set; }
        public AuthorityExaminationDecorator authorityExamination { get; private set; }
        public AuthorityPatientDecorator authorityPatient { get; private set; }
        public AuthorityPatientFileDecorator authorityPatientFile { get; private set; }
        public AuthorityHospitalizationDecorator authorityHospitalization { get; private set; }
        public AuthorityOperationDecorator authorityOperation { get; private set; }
        public AuthorityDiagnosisDecorator authorityDiagnosis { get; private set; }
        public AuthorityPrescriptionDecorator authorityPrescription { get; private set; }
        public AuthorityRefferalDecorator authorityRefferal { get; private set; }
        public AuthoritySympthomDecorator authoritySymptom { get; private set; }
        public AuthorityTherapyDecorator authorityTherapy { get; private set; }
        public ITownController TownController { get; private set; }
        public AuthorityReportDecorator authorityReport { get; private set; }


        public App()
        {
            IRoomTypeController RoomTypeController;
            IIngredientController IngredientController;
            IRoomController RoomController;

            IEquipmentController EquipmentController;

            IRenovationController RenovationController;

            IDrugController DrugController;

            IDoctorController DoctorController;

            ISpecialityController SpecialityController;


            IBusinessDayController BusinessDayController;

            IDirectorController DirectorController;

            IArticleController ArticleController;

            //NotificationController NotificationController;

            //IUserController UserController;
            IExaminationController ExaminationController;
            IPatientController PatientController;
            IPatientFileController PatientFileController;
            IHospitalizationController HospitalizationController;
            IOperationController OperationController;
            IDiagnosisController DiagnosisController;
            IPrescriptionController PrescriptionController;
            IReferralController ReferralController;
            ISymptomController SymptomController;
            ITherapyController TherapyController;
            IReportController ReportController;


        DoctorGradeRepository doctorGradeRepository = new DoctorGradeRepository(new CSVStream<DoctorGrade>(DOCTOR_GRADE_FILE, new DoctorGradeCSVConverter(CSV_DELIMITER2, CSV_DICTIONARY_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            SpecialityRepository specialityRepository = new SpecialityRepository(new CSVStream<Speciality>(SPECIALITY_FILE, new SpecialityCSVConverter(CSV_DELIMITER)), new LongSequencer());
            SymptomRepository symptomRepository = new SymptomRepository(new CSVStream<Symptom>(SYMPTOM_FILE, new SymptomCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DiagnosisRepository diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(DIAGNOSIS_FILE, new DiagnosisCSVConverter(CSV_DELIMITER)), new LongSequencer(), symptomRepository);
            IngredientRepository ingredientRepository = new IngredientRepository(new CSVStream<Ingredient>(INGREDIENT_FILE, new IngredientsCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DrugRepository drugRepository = new DrugRepository(new CSVStream<Drug>(DRUG_FILE, new DrugCSVConverter(CSV_DELIMITER)), new LongSequencer(), ingredientRepository);
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(PRESCRIPTION_FILE, new PrescriptionCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), drugRepository);
            TherapyRepository therapyRepository = new TherapyRepository(new CSVStream<Therapy>(THERAPY_FILE, new TherapyCSVConverter("|", ":")), new LongSequencer(), drugRepository);
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

            businessDayRepository._doctorRepository = doctorRepository;

            ReferralRepository referralRepository = new ReferralRepository(new CSVStream<Referral>(REFERRAL_FILE, new ReferralCSVConverter(CSV_DELIMITER)), new LongSequencer(), doctorRepository);
            PatientFileRepository patientFileRepository = new PatientFileRepository(new CSVStream<PatientFile>(PATIENTFILE_FILE, new PatientFileCSVConverter(CSV_DELIMITER, CSV_DELIMITER2)), new LongSequencer());
            PatientRepository patientRepository = new PatientRepository(new CSVStream<Patient>(PATIENT_FILE, new PatientCSVConverter(CSV_DELIMITER)), new LongSequencer(), patientFileRepository, addressRepository, townRepository,stateRepository);
            HospitalizationRepository hospitalizationRepository = new HospitalizationRepository(new CSVStream<Hospitalization>(HOSPITALIZATION_FILE, new HospitalizationCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository, patientRepository, doctorRepository);
            OperationRepository operationRepository = new OperationRepository(new CSVStream<Operation>(OPERATION_FILE, new OperationCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository, doctorRepository, patientRepository);
            ExaminationUpcomingRepository examinationUpcomingRepository = new ExaminationUpcomingRepository(new CSVStream<Examination>(EXAM_UPCOMING_FILE, new UpcomingExaminationCSVConverter(CSV_DELIMITER)), new LongSequencer(), doctorRepository, patientRepository);
            ExaminationPreviousRepository examinationPreviousRepository = new ExaminationPreviousRepository(new CSVStream<Examination>(EXAM_PREVIOUS_FILE, new PreviousExaminationCSVConverter("|")), new LongSequencer(), doctorRepository, patientRepository, diagnosisRepository, prescriptionRepository, therapyRepository, referralRepository);
            patientFileRepository._hospitalizationRepository = hospitalizationRepository;
            patientFileRepository._operationRepository = operationRepository;
            patientFileRepository._examinationPreviousRepository = examinationPreviousRepository;
            AddressService addressService = new AddressService(addressRepository);
            StateService stateService = new StateService(stateRepository);
            TownService townService = new TownService(townRepository);

            var directorRepository = new DirectorRepository(new CSVStream<Director>(DIRECTOR_FILE, new DirectorCSVConverter(CSV_DELIMITER)), new LongSequencer(), addressRepository, townRepository, stateRepository);
            var directorService = new DirectorService(directorRepository);


            var secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer(), addressRepository, townRepository, stateRepository);
            var secretaryService = new SecretaryService(secretaryRepository);
            

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
           
            ExaminationService examinationService = new ExaminationService(examinationUpcomingRepository, examinationPreviousRepository, diagnosisService,prescriptionService,referralService,symptomService,therapyService);
            //examinationService._diagnosisService = diagnosisService;
            //examinationService._prescriptionService = prescriptionService;
            //examinationService._referralService = referralService;
            //examinationService._symptomService = symptomService;
            //examinationService._therapyService = therapyService;
            DrugService drugService = new DrugService(drugRepository);
            IngredientService ingredientService = new IngredientService(ingredientRepository);
            PatientFileService patientFileService = new PatientFileService(patientFileRepository);
            PatientService patientService = new PatientService(patientRepository, patientFileService, doctorGradeService);
            doctorService._articleService = articleService;
            doctorService._doctorGradeService = doctorGradeService;
            BusinessDayService businessDayService = new BusinessDayService(businessDayRepository, doctorService);
            businessDayService.examinationService = examinationService;
            doctorService._businessDayService = businessDayService;
            RenovationService renovationService = new RenovationService(renovationRepository);
            RoomService roomService = new RoomService(roomRepository, renovationService, businessDayService, hospitalizationService);
            RoomTypeService roomTypeService = new RoomTypeService(roomTypeRepository, roomService);
            EquipmentService equipmentService = new EquipmentService(equipmentRepository, roomService);
            UserService userService = new UserService(patientService, doctorService, secretaryService, directorService);


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
            DirectorController = new DirectorContoller(directorService);
            TherapyController = new TherapyController(therapyService);
            

            ReportService reportService = new ReportService(examinationService, renovationService, hospitalizationService, operationService);
            ReportController = new ReportController(reportService);


            authorityReport = new AuthorityReportDecorator(ReportController, "Director");
            authorityArticle = new AuthorityArticleDecorator(ArticleController, "Director");
            authorityBusinessDay = new AuthorityBusinessDayDecorator(BusinessDayController, "Director");
            authorityDiagnosis = new AuthorityDiagnosisDecorator(DiagnosisController, "Director");
            authorityDirector = new AuthorityDirectorDecorator(DirectorController, "Director");
            authorityDoctor = new AuthorityDoctorDecorator(DoctorController, "Director");
            authorityDrug = new AuthorityDrugDecorator(DrugController, "Director");
            authorityEquipment = new AuthorityEquipmentDecorator(EquipmentController, "Director");
            authorityHospitalization = new AuthorityHospitalizationDecorator(HospitalizationController, "Director");
            authorityIngredient = new AuthorityIngredientDecorator(IngredientController, "Director");
            authorityOperation = new AuthorityOperationDecorator(OperationController, "Director");
            authorityPatient = new AuthorityPatientDecorator(PatientController, "Director");
            authorityPatientFile = new AuthorityPatientFileDecorator(PatientFileController, "Director");
            authorityPrescription = new AuthorityPrescriptionDecorator(PrescriptionController, "Director");
            authorityRefferal = new AuthorityRefferalDecorator(ReferralController, "Director");
            authorityRenovation = new AuthorityRenovationDecoratorcs(RenovationController, "Director");
            authorityRoom = new AuthorityRoomDecorator(RoomController, "Director");
            authoritySymptom = new AuthoritySympthomDecorator(SymptomController, "Director");
            authorityRoomType = new AuthorityRoomTypeDecorator(RoomTypeController, "Director");
            authorityDiagnosis = new AuthorityDiagnosisDecorator(DiagnosisController, "Director");
            authoritySpeciality = new AuthoritySpecialityDecorator(SpecialityController, "Director");
            authorityExamination = new AuthorityExaminationDecorator(ExaminationController, "Director");
            authorityTherapy = new AuthorityTherapyDecorator(TherapyController, "Director");






            UserController = new UserController(userService);

            NotificationService notificationService = new NotificationService(drugService, businessDayService);
            NotificationController = new NotificationController(notificationService);





            authorityArticle = new AuthorityArticleDecorator(ArticleController, "Director");
            

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"../../../../code/Resources/LoggedIn/config.txt");

            if (text.Equals("false"))
                StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
            else
                StartupUri = new Uri("DashboardWindow.xaml", UriKind.Relative);

        }
    }
}
