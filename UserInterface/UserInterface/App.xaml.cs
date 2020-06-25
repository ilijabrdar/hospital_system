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
using bolnica.Model.Dto;

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

        private const String SECRETARY_FILE = "../../../../code/Resources/Data/SecretaryFile.txt";
        private const String DOCTOR_FILE = "../../../../code/Resources/Data/doctors.csv";

        private const String ADDRESS_FILE = "../../../../code/Resources/Data/AddressFile.txt";
        private const String TOWN_FILE = "../../../../code/Resources/Data/TownFile.txt";
        private const String STATE_FILE = "../../../../code/Resources/Data/StateFile.txt";

        private const string ROOM_FILE = "../../../../code/Resources/Data/rooms.csv";
        private const string EQUIPMENT_FILE = "../../../../code/Resources/Data/equipment.csv";
        private const string ROOMTYPE_FILE = "../../../../code/Resources/Data/roomtypes.csv";
        private const String SPECIALITY_FILE = "../../../../code/Resources/Data/speciality.csv";
        private const String DOCTOR_GRADE_FILE = "../../../../code/Resources/Data/DoctorGradeFile.csv";

        private const String DIAGNOSIS_FILE = "../../../../code/Resources/Data/diagnosisFile.csv";
        private const String PRESCRIPTION_FILE = "../../../../code/Resources/Data/prescriptionFile.csv";
        private const String REFERRAL_FILE = "../../../../code/Resources/Data/referralFile.csv";
        private const String SYMPTOM_FILE = "../../../../code/Resources/Data/symptomFile.csv";
        private const String THERAPY_FILE = "../../../../code/Resources/Data/therapyFile.csv";
        private const String DRUG_FILE = "../../../../code/Resources/Data/drugs.csv";
        private const String INGREDIENT_FILE = "../../../../code/Resources/Data/ingredients.csv";

        private const string BUSINESSDAY_FILE = "../../../../code/Resources/Data/businessdays.csv";
        private const String ARTICLE_FILE = "../../../../code/Resources/Data/articles.csv";

        private const String HOSPITALIZATION_FILE = "../../../../code/Resources/Data/hospitalizationFile.csv";
        private const String OPERATION_FILE = "../../../../code/Resources/Data/operationFile.csv";
        private readonly String _patient_File = "../../../../code/Resources/Data/patient.csv";
        private readonly String _patientFile_File = "../../../../code/Resources/Data/patientFile.csv";

        private const String EXAM_UPCOMING_FILE = "../../../../code/Resources/Data/upcomingExamination.csv";
        private const String EXAM_PREVIOUS_FILE = "../../../../code/Resources/Data/examinationPrevious.csv";

        private const String NOTIFICATION_FILE = "../../../../code/Resources/Data/patientNotification.csv";

        public IUserController UserController { get; private set; }
        public IPatientController PatientController { get; private set; }
        public IStateController StateController { get; private set; }
        public ISecretaryController SecretaryController { get; private set; }

        public IRoomController RoomController { get; private set; }

        public IArticleController ArticleController { get; private set; }

        public IDoctorController DoctorController { get; private set; }
        public IBusinessDayController BusinessDayController { get; private set; }
        public BusinessDayService businessDayService { get; set; }

        public IReportController ReportController { get; set; }

        public IExaminationController ExaminationController { get; private set; }

        public IPatientNotificationController NotificationController {get; private set; }
        public IOperationController OperationController { get; set; }
        public App()
        {
            AddressRepository addressRepository = new AddressRepository(new CSVStream<Address>(ADDRESS_FILE, new AddressCSVConverter(CSV_DELIMITER)), new LongSequencer());
            TownRepository townRepository = new TownRepository(new CSVStream<Town>(TOWN_FILE, new TownCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), addressRepository);
            StateRepository stateRepository = new StateRepository(new CSVStream<State>(STATE_FILE, new StateCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), townRepository);

            

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

            BusinessDayRepository businessDayRepository = new BusinessDayRepository(new CSVStream<BusinessDay>(BUSINESSDAY_FILE, new BusinessDayCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository);


            SecretaryRepository secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer(), addressRepository, townRepository, stateRepository);
            DoctorRepository doctorRepository = new DoctorRepository(new CSVStream<Doctor>(DOCTOR_FILE, new DoctorCSVConverter(CSV_DELIMITER)), new LongSequencer(), businessDayRepository, specialityRepository, doctorGradeRepository, addressRepository, townRepository, stateRepository);
            businessDayRepository.doctorRepo = doctorRepository;
            
            ArticleRepository articleRepository = new ArticleRepository(new CSVStream<Article>(ARTICLE_FILE, new ArticleCSVConverter(CSV_ARRAY_DELIMITER)), new LongSequencer(), doctorRepository);
            // DirectorRepository directorRepository = new DirectorRepository(new CSVStream<Director>(SECRETARY_FILE, null, new LongSequencer());
            // DoctorRepository doctorRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer());
            // PatientRepository patientRepository = new SecretaryRepository(new CSVStream<Secretary>(SECRETARY_FILE, new SecretaryCSVConverter(CSV_DELIMITER)), new LongSequencer());

            SecretaryService secretaryService = new SecretaryService(secretaryRepository);
            SecretaryController = new SecretaryController(secretaryService);

            

            StateService stateService = new StateService(stateRepository);
            StateController = new StateController(stateService);

            DoctorService doctorService = new DoctorService(doctorRepository);
            DoctorController = new DoctorController(doctorService);

            var patientFileRepository = new PatientFileRepository(new CSVStream<PatientFile>(_patientFile_File, new PatientFileCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            


            var patientFileService = new PatientFileService(patientFileRepository);
            var patientRepo = new PatientRepository(new CSVStream<Patient>(_patient_File, new PatientCSVConverter(CSV_DELIMITER)), new LongSequencer(), patientFileRepository, addressRepository, townRepository, stateRepository);
            var patientService = new PatientService(patientRepo, patientFileService);
            PatientController = new PatientController(patientService);

            HospitalizationRepository hospitalizationRepository = new HospitalizationRepository(new CSVStream<Hospitalization>(HOSPITALIZATION_FILE, new HospitalizationCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository, patientRepo);
            HospitalizationService hospitalizationService = new HospitalizationService(hospitalizationRepository);
            OperationRepository operationRepository = new OperationRepository(new CSVStream<Operation>(OPERATION_FILE, new OperationCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository, doctorRepository, patientRepo);
            OperationService operationService = new OperationService(operationRepository);
            OperationController = new OperationController(operationService);

            businessDayService = new BusinessDayService(businessDayRepository, doctorService);
            BusinessDayController = new BusinessDayController(businessDayService);

            var roomService = new RoomService(roomRepository, null, businessDayService, hospitalizationService);

            RoomController = new RoomController(roomService);

            ArticleService articleService = new ArticleService(articleRepository);
            ArticleController = new ArticleController(articleService);

            //pizdarije
            SymptomRepository symptomRepository = new SymptomRepository(new CSVStream<Symptom>(SYMPTOM_FILE, new SymptomCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DiagnosisRepository diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(DIAGNOSIS_FILE, new DiagnosisCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), symptomRepository);
            IngredientRepository ingredientRepository = new IngredientRepository(new CSVStream<Ingredient>(INGREDIENT_FILE, new IngredientsCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DrugRepository drugRepository = new DrugRepository(new CSVStream<Drug>(DRUG_FILE, new DrugCSVConverter(CSV_DELIMITER)), new LongSequencer(), ingredientRepository);
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(PRESCRIPTION_FILE, new PrescriptionCSVConverter(CSV_DELIMITER, CSV_COLOMN_DELIMITER)), new LongSequencer(), drugRepository);
            TherapyRepository therapyRepository = new TherapyRepository(new CSVStream<Therapy>(THERAPY_FILE, new TherapyCSVConverter(CSV_DELIMITER, CSV_COLOMN_DELIMITER)), new LongSequencer(), drugRepository);
            ReferralRepository referralRepository = new ReferralRepository(new CSVStream<Referral>(REFERRAL_FILE, new ReferralCSVConverter(CSV_DELIMITER)), new LongSequencer(), doctorRepository);

            ExaminationUpcomingRepository examinationUpcomingRepository = new ExaminationUpcomingRepository(new CSVStream<Model.PatientSecretary.Examination>(EXAM_UPCOMING_FILE, new UpcomingExaminationCSVConverter(CSV_DELIMITER)), new LongSequencer(), doctorRepository, patientRepo);
            ExaminationPreviousRepository examinationPreviousRepository = new ExaminationPreviousRepository(new CSVStream<Examination>(EXAM_PREVIOUS_FILE, new PreviousExaminationCSVConverter(CSV_ARRAY_DELIMITER)), new LongSequencer(), doctorRepository, patientRepo, diagnosisRepository, prescriptionRepository, therapyRepository, referralRepository);

            ExaminationService examinationService = new ExaminationService(examinationUpcomingRepository, examinationPreviousRepository);
            ExaminationController = new ExaminationController(examinationService);

            patientFileRepository._hospitalizationRepository = hospitalizationRepository;
            patientFileRepository._operationRepository = operationRepository;
            patientFileRepository._examinationPreviousRepository = examinationPreviousRepository;

            //report
            ReportService reportService = new ReportService(examinationService, operationService);
            ReportController = new ReportController(reportService);

            UserService userService = new UserService(patientService, doctorService, secretaryService, null);
            UserController = new UserController(userService);

            //notify
            PatientNotificationRepository notificationRepo = new PatientNotificationRepository(new CSVStream<PatientNotification>(NOTIFICATION_FILE, new PatientNotificationCSVConverter(CSV_DELIMITER)), new LongSequencer(), patientRepo);
            PatientNotificationService notificationService = new PatientNotificationService(notificationRepo);
            NotificationController = new PatientNotificationController(notificationService);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textField = sender as TextBox;
            textField.SelectAll();
        }
    }
}
