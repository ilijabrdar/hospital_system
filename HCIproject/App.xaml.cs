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
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HCIproject
{
    public partial class App : Application
    {
        public IUserController UserController { get; private set; }
        public IAddressController AddressController { get; private set; }
        public IStateController StateController { get; private set; }
        public ITownController TownController { get; private set; }

        public AuthorityDoctorDecorator DoctorDecorator { get; private set; }
        public AuthorityPatientDecorator PatientDecorator { get; private set; }
        public AuthoritySecretaryDecorator SecretaryDecorator { get; private set; }
        public AuthorityDirectorDecorator DirectorDecorator { get; private set; }


        public AuthoritySpecialityDecorator SpecialityDecorator { get; private set; }
        public AuthorityExaminationDecorator ExaminationDecorator { get; private set; }
        public AuthorityPatientFileDecorator PatientFileDecorator { get; private set; }
        public AuthorityDrugDecorator DrugDecorator { get; private set; }
        public AuthorityHospitalizationDecorator HospitalizationDecorator { get; private set; }
        public AuthorityOperationDecorator OperationDecorator { get; private set; }
        public AuthorityDiagnosisDecorator DiagnosisDecorator { get; private set; }
        public AuthorityPrescriptionDecorator PrescriptionDecorator { get; private set; }
        public AuthorityRefferalDecorator RefferalDecorator { get; private set; }
        public AuthoritySympthomDecorator SympthomDecorator { get; private set; }
        public AuthorityTherapyDecorator TherapyDecorator { get; private set; }
        public AuthorityIngredientDecorator IngredientDecorator { get; private set; }
        public AuthorityArticleDecorator ArticleDecorator { get; private set; }

        public AuthorityBusinessDayDecorator BusinessDayDecorator { get; private set; }
        public AuthorityRoomDecorator RoomDecorator { get; private set; }
        public AuthorityRoomTypeDecorator RoomTypeDecorator { get; private set; }
        public AuthorityEquipmentDecorator EquipmentDecorator { get; private set; }
        public AuthorityRenovationDecoratorcs RenovationDecoratorcs { get; private set; }

        public AuthorityDoctorGradeDecorator DoctorGradeDecorator { get; private set; }
        public AuthorityReportDecorator ReportDecorator { get; private set; }

    //public IDoctorController DoctorController { get; private set; }
    //public ISpecialityController SpecialityController { get; private set; }
    //public IExaminationController ExaminationController { get; private set; }
    //public IPatientController PatientController { get; private set; }
    //public IPatientFileController PatientFileController { get; private set; }
    //public IDrugController DrugController { get; private set; }
    //public IHospitalizationController HospitalizationController { get; private set; }
    //public IOperationController OperationController { get; private set; }
    //public IDiagnosisController DiagnosisController { get; private set; }
    //public IPrescriptionController PrescriptionController { get; private set; }
    //public IReferralController ReferralController { get; private set; }
    //public ISymptomController SymptomController { get; private set; }
    //public ITherapyController TherapyController { get; private set; }
    //public IArticleController ArticleController { get; private set; }
    //public IIngredientController IngredientController { get; private set; }

    //public IRoomController RoomController { get; private set; }
    //public IRoomTypeController RoomTypeController { get; private set; }
    //public IEquipmentController EquipmentController { get; private set; }
    //public IBusinessDayController BusinessDayController { get; private set; }
    public BusinessDayService BusinessDayService { get; set; }
    //public IRenovationController RenovationController { get; private set; }
    //public IDoctorGradeController DoctorGradeController { get; private set; }
    //public DoctorController Doctor { get; private set; }

    public NotificationController NotificationController { get; private set; }
    //public ISecretaryController SecretaryController { get; private set; }
    //public IDirectorController Director { get; private set; }
    //public ReportController ReportController { get; private set; }

    //public DirectorContoller DirectorContoller { get; private set; }



    private const String CSV_DELIMITER = ",";
        private const String CSV_DELIMITER2 = "|";
        private const String CSV_DICTIONARY_DELIMITER = ";";
        private const String CSV_ARRAY_DELIMITER = ":";
        private const String DOCTOR_FILE = "../../../code/Resources/Data/doctors.csv";
        private const String DOCTOR_GRADE_FILE= "../../../code/Resources/Data/doctorGradeFile.csv";
        private const String SPECIALITY_FILE = "../../../code/Resources/Data/speciality.csv";
        private const String HOSPITALIZATION_FILE = "../../../code/Resources/Data/hospitalizationFile.csv";
        private const String OPERATION_FILE = "../../../code/Resources/Data/operationFile.csv";
        private const String DIAGNOSIS_FILE = "../../../code/Resources/Data/diagnosisFile.csv";
        private const String PRESCRIPTION_FILE = "../../../code/Resources/Data/prescriptionFile.csv";
        private const String REFERRAL_FILE = "../../../code/Resources/Data/referralFile.csv";
        private const String SYMPTOM_FILE = "../../../code/Resources/Data/symptomFile.csv";
        private const String THERAPY_FILE = "../../../code/Resources/Data/therapyFile.csv";
        private const String ARTICLE_FILE = "../../../code/Resources/Data/articles.csv";
        private const String ROOMTYPE_FILE = "../../../code/Resources/Data/roomtypes.csv";
        private const String ROOM_FILE = "../../../code/Resources/Data/rooms.csv";
        private const String EQUIPMENT_FILE = "../../../code/Resources/Data/equipment.csv";
        private const String RENOVATION_FILE = "../../../code/Resources/Data/renovations.csv";
        private const String EXAM_UPCOMING_FILE = "../../../code/Resources/Data/upcomingExamination.csv";
        private const String EXAM_PREVIOUS_FILE = "../../../code/Resources/Data/examinationPrevious.csv";
        private const String PATIENTFILE_FILE = "../../../code/Resources/Data/patientFile.csv";
        private const String PATIENT_FILE = "../../../code/Resources/Data/patient.csv";
        private const String DRUG_FILE = "../../../code/Resources/Data/drugs.csv";
        private const String INGREDIENT_FILE = "../../../code/Resources/Data/ingredients.csv";
        private const String BUSSINESDAY_FILE= "../../../code/Resources/Data/businessdays.csv";
        private const String ADDRESS_FILE = "../../../code/Resources/Data/AddressFile.txt";
        private const String TOWN_FILE = "../../../code/Resources/Data/townFile.txt";
        private const String STATE_FILE = "../../../code/Resources/Data/StateFile.txt";
        private const String SECRETARY_FILE = "../../../code/Resources/Data/SecretaryFile.txt";
        private const String DIRECTOR_FILE = "../../../code/Resources/Data/director.csv";




        public App()
        {

            DoctorGradeRepository doctorGradeRepository = new DoctorGradeRepository(new CSVStream<DoctorGrade>(DOCTOR_GRADE_FILE, new DoctorGradeCSVConverter(CSV_DELIMITER2, CSV_DICTIONARY_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            SpecialityRepository specialityRepository = new SpecialityRepository(new CSVStream<Speciality>(SPECIALITY_FILE, new SpecialityCSVConverter(CSV_DELIMITER)), new LongSequencer());
            SymptomRepository symptomRepository = new SymptomRepository(new CSVStream<Symptom>(SYMPTOM_FILE, new SymptomCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DiagnosisRepository diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(DIAGNOSIS_FILE, new DiagnosisCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), symptomRepository);
            IngredientRepository ingredientRepository = new IngredientRepository(new CSVStream<Ingredient>(INGREDIENT_FILE, new IngredientsCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DrugRepository drugRepository = new DrugRepository(new CSVStream<Drug>(DRUG_FILE, new DrugCSVConverter(CSV_DELIMITER)), new LongSequencer(), ingredientRepository);
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(PRESCRIPTION_FILE, new PrescriptionCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), drugRepository);
            TherapyRepository therapyRepository = new TherapyRepository(new CSVStream<Therapy>(THERAPY_FILE, new TherapyCSVConverter(CSV_DELIMITER2, CSV_ARRAY_DELIMITER)), new LongSequencer(), drugRepository);
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
            SecretaryRepository secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(",")), new LongSequencer(), addressRepository, townRepository, stateRepository);
            DirectorRepository directorRepository = new DirectorRepository(new CSVStream<Director>(DIRECTOR_FILE, new DirectorCSVConverter(",")), new LongSequencer(), addressRepository, townRepository, stateRepository);



            businessDayRepository.doctorRepo = doctorRepository;

            ReferralRepository referralRepository = new ReferralRepository(new CSVStream<Referral>(REFERRAL_FILE, new ReferralCSVConverter(CSV_DELIMITER)), new LongSequencer(), doctorRepository);
            PatientFileRepository patientFileRepository = new PatientFileRepository(new CSVStream<PatientFile>(PATIENTFILE_FILE, new PatientFileCSVConverter(CSV_DELIMITER, CSV_DELIMITER2)), new LongSequencer());
            PatientRepository patientRepository = new PatientRepository(new CSVStream<Patient>(PATIENT_FILE, new PatientCSVConverter(CSV_DELIMITER)), new LongSequencer(), patientFileRepository, addressRepository, townRepository, stateRepository);
            HospitalizationRepository hospitalizationRepository = new HospitalizationRepository(new CSVStream<Hospitalization>(HOSPITALIZATION_FILE, new HospitalizationCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository, patientRepository, doctorRepository);
            OperationRepository operationRepository = new OperationRepository(new CSVStream<Operation>(OPERATION_FILE, new OperationCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository, doctorRepository, patientRepository);
            ExaminationUpcomingRepository examinationUpcomingRepository = new ExaminationUpcomingRepository(new CSVStream<Examination>(EXAM_UPCOMING_FILE, new UpcomingExaminationCSVConverter(CSV_DELIMITER)), new LongSequencer(), doctorRepository, patientRepository);
            ExaminationPreviousRepository examinationPreviousRepository = new ExaminationPreviousRepository(new CSVStream<Examination>(EXAM_PREVIOUS_FILE, new PreviousExaminationCSVConverter(CSV_DELIMITER2)), new LongSequencer(), doctorRepository, patientRepository, diagnosisRepository, prescriptionRepository, therapyRepository, referralRepository);
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
            ExaminationService examinationService = new ExaminationService(examinationUpcomingRepository, examinationPreviousRepository);
            DrugService drugService = new DrugService(drugRepository);
            IngredientService ingredientService = new IngredientService(ingredientRepository);
            PatientFileService patientFileService = new PatientFileService(patientFileRepository);
            PatientService patientService = new PatientService(patientRepository, patientFileService, doctorGradeService);
            BusinessDayService = new BusinessDayService(businessDayRepository, doctorService);
            RenovationService renovationService = new RenovationService(renovationRepository);
            RoomService roomService = new RoomService(roomRepository, renovationService, BusinessDayService, hospitalizationService);
            RoomTypeService roomTypeService = new RoomTypeService(roomTypeRepository, roomService);
            EquipmentService equipmentService = new EquipmentService(equipmentRepository, roomService);
            NotificationService notificationService = new NotificationService(drugService, BusinessDayService);
            NotificationController = new NotificationController(notificationService);
            ReportService reportService = new ReportService(examinationService, renovationService, hospitalizationService, operationService);
            SecretaryService secretaryService = new SecretaryService(secretaryRepository);
            DirectorService directorService = new DirectorService(directorRepository);
            UserService userService = new UserService(patientService, doctorService, secretaryService, directorService);



            UserController = new UserController(userService);
            var ArticleController = new ArticleController(articleService);
            var SpecialityController = new SpecialityController(specialityService);
            var ExaminationController = new ExaminationController(examinationService);
            var HospitalizationController = new HospitalizationController(hospitalizationService);
            var OperationController = new OperationController(operationService);
            var DiagnosisController = new DiagnosisController(diagnosisService);
            var PrescriptionController = new PrescriptionController(prescriptionService);
            var ReferralController = new ReferralController(referralService);
            var SymptomController = new SymptomController(symptomService);
            var DrugController = new DrugController(drugService);
            var IngredientController = new IngredientController(ingredientService);
            var PatientController = new PatientController(patientService);
            var PatientFileController = new PatientFileController(patientFileService);
            var RoomController = new RoomController(roomService);
            var RoomTypeController = new RoomTypeController(roomTypeService);
            var EquipmentController = new EquipmentController(equipmentService);
            AddressController = new AddressController(addressService);
            TownController = new TownController(townService);
            StateController = new StateController(stateService);
            var BusinessDayController = new BusinessDayController(BusinessDayService);
            var RenovationController = new RenovationController(renovationService);
            var DoctorGradeController = new DoctorGradeController(doctorGradeService);
            var DoctorController = new DoctorController(doctorService);
            var TherapyController = new TherapyController(therapyService);
            var ReportController = new ReportController(reportService);
            var SecretaryController = new SecretaryController(secretaryService);
            var DirectorContoller = new DirectorContoller(directorService);

            DoctorDecorator = new AuthorityDoctorDecorator(DoctorController, "Doctor");
            PatientDecorator = new AuthorityPatientDecorator(PatientController, "Doctor");
            SecretaryDecorator = new AuthoritySecretaryDecorator(SecretaryController, "Doctor");
            DirectorDecorator = new AuthorityDirectorDecorator(DirectorContoller, "Doctor");

            SpecialityDecorator = new AuthoritySpecialityDecorator(SpecialityController, "Doctor");
            ExaminationDecorator = new AuthorityExaminationDecorator(ExaminationController, "Doctor");
            PatientFileDecorator = new AuthorityPatientFileDecorator(PatientFileController, "Doctor");
            DrugDecorator = new AuthorityDrugDecorator(DrugController, "Doctor");
            HospitalizationDecorator = new AuthorityHospitalizationDecorator(HospitalizationController, "Doctor");
            OperationDecorator = new AuthorityOperationDecorator(OperationController, "Doctor");
            DiagnosisDecorator = new AuthorityDiagnosisDecorator(DiagnosisController, "Doctor");
            PrescriptionDecorator = new AuthorityPrescriptionDecorator(PrescriptionController, "Doctor");
            RefferalDecorator = new AuthorityRefferalDecorator(ReferralController, "Doctor");
            SympthomDecorator = new AuthoritySympthomDecorator(SymptomController, "Doctor");
            TherapyDecorator = new AuthorityTherapyDecorator(TherapyController, "Doctor");
            IngredientDecorator = new AuthorityIngredientDecorator(IngredientController, "Doctor");
            ArticleDecorator = new AuthorityArticleDecorator(ArticleController, "Doctor");

            BusinessDayDecorator = new AuthorityBusinessDayDecorator(BusinessDayController, "Doctor");
            RoomDecorator = new AuthorityRoomDecorator(RoomController, "Doctor");
            RoomTypeDecorator = new AuthorityRoomTypeDecorator(RoomTypeController, "Doctor");
            EquipmentDecorator = new AuthorityEquipmentDecorator(EquipmentController, "Doctor");
            RenovationDecoratorcs = new AuthorityRenovationDecoratorcs(RenovationController, "Doctor");

            DoctorGradeDecorator = new AuthorityDoctorGradeDecorator(DoctorGradeController, "Doctor");
            ReportDecorator = new AuthorityReportDecorator(ReportController, "Doctor");

        }

    }
}
