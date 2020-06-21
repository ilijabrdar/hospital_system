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
        public IDoctorController DoctorController { get; private set; }
        public ISpecialityController SpecialityController{ get; private set; }
        public IExaminationController ExaminationController { get; private set; }
        public IPatientController PatientController { get; private set; }
        public IPatientFileController PatientFileController { get; private set; }
        public IDrugController DrugController { get; private set; }
        public IHospitalizationController HospitalizationController { get; private set; }
        public IOperationController OperationController { get; private set; }
        public IDiagnosisController DiagnosisController { get; private set; }
        public IPrescriptionController PrescriptionController { get; private set; }
        public IReferralController ReferralController { get; private set; }
        public ISymptomController SymptomController { get; private set; }
        public ITherapyController TherapyController { get; private set; }
        public IArticleController ArticleController  { get; private set; }
        public IIngredientController IngredientController  { get; private set; }
        public IAddressController AddressController  { get; private set; }
        public IStateController StateController  { get; private set; }
        public ITownController TownController  { get; private set; }
        public IRoomController RoomController  { get; private set; }
        public IRoomTypeController RoomTypeController  { get; private set; }
        public IEquipmentController EquipmentController  { get; private set; }

        private const String CSV_DELIMITER = ",";
        private const String CSV_DELIMITER2 = "|";
        private const String CSV_DICTIONARY_DELIMITER = ";";
        private const String CSV_ARRAY_DELIMITER = ":";
        private const String DOCTOR_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/DoctorFile.csv";
        private const String DOCTOR_GRADE_FILE= "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/DoctorGradeFile.csv";
        private const String SPECIALITY_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/SpecialityFile.csv";
        private const String HOSPITALIZATION_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/HospitalizationFile.csv";
        private const String OPERATION_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/OperationFile.csv";
        private const String DIAGNOSIS_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/DiagnosisFile.csv";
        private const String PRESCRIPTION_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/PrescriptionFile.csv";
        private const String REFERRAL_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/ReferralFile.csv";
        private const String SYMPTOM_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/SymptomFile.csv";
        private const String THERAPY_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/TherapyFile.csv";
        private const String ARTICLE_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/ArticleFile.csv";
        private const String ROOMTYPE_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/RoomTypeFile.csv";
        private const String ROOM_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/RoomFile.csv";
        private const String EQUIPMENT_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/EquipmentFile.csv";
        private const String EXAM_UPCOMING_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/ExaminationUpcoming.csv";
        private const String EXAM_PREVIOUS_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/ExaminationPrevious.csv";
        private const String PATIENTFILE_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/PatientFile.csv";
        private const String PATIENT_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/Patient.csv";
        private const String DRUG_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/DrugFile.csv";
        private const String INGREDIENT_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/IngredientsFile.csv";
        private const String BUSSINESDAY_FILE= "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/BussinesDayFile.csv";
        private const String ADDRESS_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/AddressFile.csv";
        private const String TOWN_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/TownFile.csv";
        private const String STATE_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/StateFile.csv";


    
        public App()
        {

            DoctorGradeRepository doctorGradeRepository=new DoctorGradeRepository(new CSVStream<DoctorGrade>(DOCTOR_GRADE_FILE, new DoctorGradeCSVConverter(CSV_DELIMITER2, CSV_DICTIONARY_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            SpecialityRepository specialityRepository=new SpecialityRepository(new CSVStream<Speciality>(SPECIALITY_FILE, new SpecialityCSVConverter(CSV_DELIMITER)), new LongSequencer());
            SymptomRepository symptomRepository = new SymptomRepository(new CSVStream<Symptom>(SYMPTOM_FILE, new SymptomCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DiagnosisRepository diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(DIAGNOSIS_FILE, new DiagnosisCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), symptomRepository);
            IngredientRepository ingredientRepository = new IngredientRepository(new CSVStream<Ingredient>(INGREDIENT_FILE, new IngredientsCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DrugRepository drugRepository = new DrugRepository(new CSVStream<Drug>(DRUG_FILE, new DrugCSVConverter(CSV_DELIMITER)), new LongSequencer(), ingredientRepository);
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(PRESCRIPTION_FILE, new PrescriptionCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), drugRepository);
            TherapyRepository therapyRepository = new TherapyRepository(new CSVStream<Therapy>(THERAPY_FILE, new TherapyCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), drugRepository);
            ArticleRepository articleRepository = new ArticleRepository(new CSVStream<Article>(ARTICLE_FILE, new ArticleCSVConverter(CSV_DELIMITER2)), new LongSequencer());
            RoomTypeRepository roomTypeRepository= new RoomTypeRepository(new CSVStream<RoomType>(ROOMTYPE_FILE, new RoomTypeCSVConverter(CSV_DELIMITER)), new LongSequencer());
            EquipmentRepository equipmentRepository=new EquipmentRepository(new CSVStream<Equipment>(EQUIPMENT_FILE, new EquipmentCSVConverter(CSV_DELIMITER)), new LongSequencer());
            RoomRepository roomRepository=new RoomRepository(new CSVStream<Room>(ROOM_FILE, new RoomCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomTypeRepository, equipmentRepository);
            BusinessDayRepository businessDayRepository = new BusinessDayRepository(new CSVStream<BusinessDay>(BUSSINESDAY_FILE, new BusinessDayCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository);

            //AddressRepository addressRepository = new AddressRepository(new CSVStream<Address>(ADDRESS_FILE, new AddressCSVConverter(CSV_DELIMITER)), new LongSequencer());
            // TownRepository townRepository = new TownRepository(new CSVStream<Town>(TOWN_FILE, new TownCSVConverter(CSV_DELIMITER, CSV_DELIMITER2)), new LongSequencer(), addressRepository);
            //  StateRepository stateRepository = new StateRepository(new CSVStream<State>(STATE_FILE, new StateCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), townRepository);


            DoctorRepository doctorRepository = new DoctorRepository(new CSVStream<Doctor>(DOCTOR_FILE, new DoctorCSVConverter(CSV_DELIMITER)), new LongSequencer(), articleRepository, businessDayRepository, specialityRepository, doctorGradeRepository);//, addressRepository,townRepository,stateRepository);

            businessDayRepository.doctorRepo = doctorRepository;
            articleRepository._doctorRepository = doctorRepository;

            ReferralRepository referralRepository = new ReferralRepository(new CSVStream<Referral>(REFERRAL_FILE, new ReferralCSVConverter(CSV_DELIMITER)), new LongSequencer(), doctorRepository);
            PatientFileRepository patientFileRepository = new PatientFileRepository(new CSVStream<PatientFile>(PATIENTFILE_FILE, new PatientFileCSVConverter(CSV_DELIMITER, CSV_DELIMITER2)), new LongSequencer());

            HospitalizationRepository hospitalizationRepository = new HospitalizationRepository(new CSVStream<Hospitalization>(HOSPITALIZATION_FILE, new HospitalizationCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository, patientFileRepository);
            OperationRepository operationRepository = new OperationRepository(new CSVStream<Operation>(OPERATION_FILE, new OperationCSVConverter(CSV_DELIMITER)), new LongSequencer(), roomRepository,patientFileRepository,doctorRepository);
            PatientRepository patientRepository = new PatientRepository(new CSVStream<Patient>(PATIENT_FILE, new PatientCSVConverter(CSV_DELIMITER)), new LongSequencer(), patientFileRepository);
            ExaminationUpcomingRepository examinationUpcomingRepository = new ExaminationUpcomingRepository(new CSVStream<Examination>(EXAM_UPCOMING_FILE, new UpcomingExaminationCSVConverter(CSV_DELIMITER)), new LongSequencer(), doctorRepository, patientRepository);
            ExaminationPreviousRepository examinationPreviousRepository = new ExaminationPreviousRepository(new CSVStream<Examination>(EXAM_PREVIOUS_FILE, new PreviousExaminationCSVConverter(CSV_DELIMITER, CSV_DELIMITER2)), new LongSequencer(), doctorRepository, patientRepository, diagnosisRepository, prescriptionRepository, therapyRepository, referralRepository);
            patientFileRepository._hospitalizationRepository = hospitalizationRepository;
            patientFileRepository._operationRepository = operationRepository;
            patientFileRepository._examinationPreviousRepository = examinationPreviousRepository;
            //  AddressService addressService = new AddressService(addressRepository);
            //   StateService stateService = new StateService(stateRepository);
            //   TownService townService = new TownService(townRepository);



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
            UserService userService = new UserService(null, doctorService,null,null);
            ExaminationService examinationService = new ExaminationService(examinationUpcomingRepository, examinationPreviousRepository);
            DrugService drugService = new DrugService(drugRepository);
            IngredientService ingredientService = new IngredientService(ingredientRepository);
            PatientFileService patientFileService = new PatientFileService(patientFileRepository);
            PatientService patientService = new PatientService(patientRepository,patientFileService,doctorGradeService);
            RoomService roomService = new RoomService(roomRepository);
            RoomTypeService roomTypeService = new RoomTypeService(roomTypeRepository);
            EquipmentService equipmentService = new EquipmentService(equipmentRepository);

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
            //PatientFileController.Save(new PatientFile(0));
            //StateController = new StateController(stateService);
            //AddressController = new AddressController(addressService);
            //TownController = new TownController(townService);
            //  ArticleController articleController = new ArticleController(articleService);
            // DiagnosisController diagnosisController = new DiagnosisController(diagnosisService);
            // DoctorGradeController doctorGradeController = new DoctorGradeController(doctorGradeService);
            // HospitalizationController hospitalizationController = new HospitalizationController(hospitalizationService);
            // OperationController operationController = new OperationController(operationService);
            // PrescriptionController prescriptionController = new PrescriptionController(prescriptionService);
            // ReferralController referralController = new ReferralController(referralService);
            //// SpecialityController specialityController = new SpecialityController(specialityService);
            // SymptomController symptomController = new SymptomController(symptomService);
            // TherapyController therapyController = new TherapyController(therapyService);
            //DrugController drugController = new DrugController(drugService);
            // List<Symptom> s = new List<Symptom>();
            //Symptom si = new Symptom(1, "ime");
            //Symptom si2 = new Symptom(2, "ime2");
            // s.Add(si);
            // s.Add(si2);
            //   Diagnosis dijagnoza = new Diagnosis(111,"imedijagnoze", s);
            ////Console.WriteLine(dijagnoza.Symptom);
            ////articleController.Save(new Article(111, DateTime.Today, "bllllla", "blaaaa"));
            //  diagnosisController.Save(dijagnoza);
            //Dictionary<String, double> dic = new Dictionary<string, double>();
            //dic["pitanje1"] = 1;
            //dic["pitanje2"] = 2.22;
            //DoctorGrade dg = new DoctorGrade(11, 11, dic);
            //doctorGradeController.Save(dg);           
            //hospitalizationController.Save( new Hospitalization(11, new Period(new DateTime(2015,10,10), new DateTime(2006,10,15)), new PatientFile(2), new Room(3)));
            //// operationController.Save(new Operation(111, new Doctor(5), "naziv", new Period(new DateTime(2015, 10, 10), new DateTime(2006, 10, 15)), new Room(3), new PatientFile(3)));
         //   List<Drug> d = new List<Drug>();
        //    Drug gr = new Drug(2);
       ///     Drug gr1 = new Drug(3);
        //d.Add(gr);
        //    d.Add(gr1);
            //prescriptionController.Save(new Prescription(111,new Period( new DateTime(2016, 10, 10), new DateTime(2016, 10, 15)), "note", d));
            //referralController.Save(new Referral(11, new Period(new DateTime(2016, 10, 10), new DateTime(2016, 10, 15)), new Doctor(5)));
            //specialityController.Save(new Speciality("lslsl"));
            // symptomController.Save(new Symptom("ime"));
            //       therapyController.Save(new Therapy("note", new Period(new DateTime(2015, 10, 10), new DateTime(2006, 10, 15)), 23,d));
            //       Article article = new Article(new DateTime(2015, 10, 10), new Doctor(1), "Naslov", "dfcjd");
            //       articleController.Save(article);
            // diagnosisController.GetAll\
            //Article ar= articleRepository.GetEager(1);
            // Console.WriteLine(ar.Doctor.FirstName);

            //        public Examination(User user, Users.Doctor doctor, Period period, Diagnosis diagnosis, List<Prescription> prescription, Anemnesis anemnesis, Therapy therapy, Referral refferal)
         //   Prescription pre = new Prescription(111, new Period(new DateTime(2016, 10, 10), new DateTime(2016, 10, 15)), "note", d);
         //   List<Prescription> p = new List<Prescription>();
         //    p.Add(pre);
        //     Patient patient = new Patient(1);
            // ExaminationController.Save( new Examination((User)patient, new Doctor(2), new Period(new DateTime(2019, 10, 10), new DateTime(2016, 10, 15)), new Diagnosis(2),p ,new Anemnesis("ssssss"), new Therapy(1), new Referral(1)));
           // ExaminationController.SaveFinishedExamination(new Examination((User)patient, new Doctor(2), new Period(new DateTime(2019, 10, 10), new DateTime(2016, 10, 15)), new Diagnosis(2), p, new Anemnesis("ssssss"), new Therapy(1), new Referral(1)));
            // List<Drug> non = drugController.GetNotApprovedDrugs();
            // foreach(Drug d in non)
            //{
            //     Console.WriteLine(d.Name);
            // }
        }

    }
}
