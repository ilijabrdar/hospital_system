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

namespace PacijentBolnicaZdravo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
          public static int j = 0;
        private readonly String _patient_File = "../../../code/Resources/Data/patient.csv";
        private readonly String _patientFile_File = "../../../code/Resources/Data/patientFile.csv";

        private readonly String _article_File = "../../../code/Resources/Data/articles.csv";
        private readonly String _doctor_File = "../../../code/Resources/Data/doctors.csv";
        private readonly String _speciality_File = "../../../code/Resources/Data/speciality.csv";
        private readonly String _businessDay_File = "../../../code/Resources/Data/businessdays.csv";
        private readonly String _room_File = "../../../code/Resources/Data/rooms.csv";
        private readonly String _roomType_File = "../../../code/Resources/Data/roomtypes.csv";
        private readonly String _equipment_File = "../../../code/Resources/Data/equipment.csv";
        private readonly String _address_File = "../../../code/Resources/Data/AddressFile.txt";
        private readonly String _state_File = "../../../code/Resources/Data/StateFile.txt";
        private readonly String _town_File = "../../../code/Resources/Data/TownFile.txt";
        private readonly String _doctorGrade_File = "../../../code/Resources/Data/doctorGradeFile.csv";
        private readonly String _hospitalization_File = "../../../code/Resources/Data/hospitalizationFile.csv";
        private readonly String _examinationPrevius_File = "../../../code/Resources/Data/examinationPrevious.csv";
        private readonly String _examinationUpcoming_File = "../../../code/Resources/Data/examinationUpcoming.csv";
        private readonly String _operation_File = "../../../code/Resources/Data/operationFile.csv";
        private readonly String _prescription_File = "../../../code/Resources/Data/prescriptionFile.csv";
        private readonly String _referral_File = "../../../code/Resources/Data/referralFile.csv";
        private readonly String _symptom_File = "../../../code/Resources/Data/symptomFile.csv";
        private readonly String _therapy_File = "../../../code/Resources/Data/therapyFile.csv";
        private readonly String _drug_File = "../../../code/Resources/Data/drugs.csv";
        private readonly String _ingredients_File = "../../../code/Resources/Data/ingredients.csv";
        private readonly String _diagnosis_File = "../../../code/Resources/Data/diagnosisFile.csv";

        public IUserController UserController { get; set; }
        public IArticleController ArticleController
        { get; private set; }
        public IDoctorController DoctorController { get; set; }
        public IBusinessDayController BusinessDayController { get; set; }

        public IExaminationController ExaminationController { get; set; }
        public IPatientController PatientController { get; set; }


        App()
        {
            var doctorGradeRepo = new DoctorGradeRepository(new CSVStream<DoctorGrade>(_doctorGrade_File, new DoctorGradeCSVConverter("|", ";", ":")), new LongSequencer());
            var patientFileRepo = new PatientFileRepository(new CSVStream<PatientFile>(_patientFile_File, new PatientFileCSVConverter(",", "|")), new LongSequencer());
            var patientRepo = new PatientRepository(new CSVStream<Patient>(_patient_File, new PatientCSVConverter(",")), new LongSequencer(), patientFileRepo);
            var specialityRepo = new SpecialityRepository(new CSVStream<Speciality>(_speciality_File, new SpecialityCSVConverter(",")), new LongSequencer());
            var equipmentRepo = new EquipmentRepository(new CSVStream<Equipment>(_equipment_File, new EquipmentCSVConverter(",")), new LongSequencer());
            var roomTypeRepo = new RoomTypeRepository(new CSVStream<RoomType>(_roomType_File, new RoomTypeCSVConverter(",")), new LongSequencer());
            var roomRepo = new RoomRepository(new CSVStream<Room>(_room_File, new RoomCSVConverter(",")), new LongSequencer(), roomTypeRepo, equipmentRepo);
            var businessDayRepo = new BusinessDayRepository(new CSVStream<BusinessDay>(_businessDay_File, new BusinessDayCSVConverter()), new LongSequencer(), roomRepo);
            var doctorRepository = new DoctorRepository(new CSVStream<Doctor>(_doctor_File, new DoctorCSVConverter(",")), new LongSequencer(), businessDayRepo, specialityRepo, doctorGradeRepo);
            businessDayRepo.doctorRepo = doctorRepository;
            var articleRepo = new ArticleRepository(new CSVStream<Article>(_article_File, new ArticleCSVConverter("|")), new LongSequencer(), doctorRepository);
            var addressRepo = new AddressRepository(new CSVStream<Address>(_address_File, new AddressCSVConverter(",")), new LongSequencer());
            var townRepo = new TownRepository(new CSVStream<Town>(_town_File, new TownCSVConverter(",", "|")), new LongSequencer(), addressRepo);
            var stateRepo = new StateRepository(new CSVStream<State>(_state_File, new StateCSVConverter(",", "|")), new LongSequencer(), townRepo);
            var symptomRepository = new SymptomRepository(new CSVStream<Symptom>(_symptom_File, new SymptomCSVConverter(",")), new LongSequencer());
            var diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(_diagnosis_File, new DiagnosisCSVConverter(",", ":")), new LongSequencer(), symptomRepository);
            var ingredientRepository = new IngredientRepository(new CSVStream<Ingredient>(_ingredients_File, new IngredientsCSVConverter(",")), new LongSequencer());
            var drugRepository = new DrugRepository(new CSVStream<Drug>(_drug_File, new DrugCSVConverter(",")), new LongSequencer(), ingredientRepository);
            var prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(_prescription_File, new PrescriptionCSVConverter(",", ":")), new LongSequencer(), drugRepository);
            var therapyRepository = new TherapyRepository(new CSVStream<Therapy>(_therapy_File, new TherapyCSVConverter(",", ":")), new LongSequencer(), drugRepository);
            var referralRepository = new ReferralRepository(new CSVStream<Referral>(_referral_File, new ReferralCSVConverter(",")), new LongSequencer(), doctorRepository);
            var hospitalizationRepository = new HospitalizationRepository(new CSVStream<Hospitalization>(_hospitalization_File, new HospitalizationCSVConverter(",")), new LongSequencer(), roomRepo);
            var operationRepository = new OperationRepository(new CSVStream<Operation>(_operation_File, new OperationCSVConverter(",")), new LongSequencer(), roomRepo, doctorRepository);
            var examinationUpcomingRepository = new ExaminationUpcomingRepository(new CSVStream<Examination>(_examinationUpcoming_File, new UpcomingExaminationCSVConverter(",")), new LongSequencer(), doctorRepository, patientRepo);
            var examinationPreviousRepository = new ExaminationPreviousRepository(new CSVStream<Examination>(_examinationPrevius_File, new PreviousExaminationCSVConverter(",", "|")), new LongSequencer(), doctorRepository, patientRepo, diagnosisRepository, prescriptionRepository, therapyRepository, referralRepository);
            patientFileRepo._examinationPreviousRepository = examinationPreviousRepository;
            patientFileRepo._hospitalizationRepository = hospitalizationRepository;
            patientFileRepo._operationRepository = operationRepository;


            var specialityService = new SpecialityService(specialityRepo);
            var hospitalizationService = new HospitalizationService(hospitalizationRepository);
            var operationService = new OperationService(operationRepository);
            var diagnosisService = new DiagnosisService(diagnosisRepository);
            var prescriptionService = new PrescriptionService(prescriptionRepository);
            var referralService = new ReferralService(referralRepository);
            var symptomService = new SymptomService(symptomRepository);
            var therapyService = new TherapyService(therapyRepository);
            var examinationService = new ExaminationService(examinationUpcomingRepository, examinationPreviousRepository);
            var drugService = new DrugService(drugRepository);
            var ingredientService = new IngredientService(ingredientRepository);
            var roomService = new RoomService(roomRepo);
            var roomTypeService = new RoomTypeService(roomTypeRepo);
            var equipmentService = new EquipmentService(equipmentRepo);
            var doctorGradeService = new DoctorGradeService(doctorGradeRepo);
            var articleService = new ArticleService(articleRepo);
            var patientFileService = new PatientFileService(patientFileRepo);
            var patientService = new PatientService(patientRepo, patientFileService, doctorGradeService);
            var userService = new UserService(patientService);
            var doctorService = new DoctorService(doctorRepository);
            var businessDayService = new BusinessDayService(businessDayRepo);
            var addressService = new AddressService(addressRepo);
            var townService = new TownService(townRepo);
            var stateService = new StateService(stateRepo);
            doctorService._doctorGradeService = doctorGradeService;


            UserController = new UserController(userService);
            ArticleController = new ArticleController(articleService);
            DoctorController = new DoctorController(doctorService);
            BusinessDayController = new BusinessDayController(businessDayService);
            ExaminationController = new ExaminationController(examinationService);
            PatientController = new PatientController(patientService);
           
        }


    }
}
