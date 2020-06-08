using bolnica.Controller;
using bolnica.Repository;
using bolnica.Repository.CSV.Converter;
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

        private const String CSV_DELIMITER = ",";
        private const String CSV_DELIMITER2 = "|";
        private const String CSV_DICTIONARY_DELIMITER = ";";
        private const String CSV_ARRAY_DELIMITER = ":";
        private const String DOCTOR_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/DoctorFile.txt";
        private const String DOCTOR_GRADE_FILE= "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/DoctorGradeFile.txt";
        private const String SPECIALITY_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/SpecialityFile.txt";
        private const String HOSPITALIZATION_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/HospitalizationFile.txt";
        private const String OPERATION_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/OperationFile.txt";
        private const String DIAGNOSIS_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/DiagnosisFile.txt";
        private const String PRESCRIPTION_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/PrescriptionFile.txt";
        private const String REFERRAL_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/ReferralFile.txt";
        private const String SYMPTOM_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/SymptomFile.txt";
        private const String THERAPY_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/TherapyFile.txt";
        private const String ARTICLE_FILE = "C:/Users/Tamara Kovacevic/Desktop/hospital_system/HCIproject/RESOURCES/ArticleFile.txt";


    
        public App()
        {
            DoctorRepository doctorRepository=new DoctorRepository(new CSVStream<Doctor>(DOCTOR_FILE, new DoctorCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DoctorGradeRepository doctorGradeRepository=new DoctorGradeRepository(new CSVStream<DoctorGrade>(DOCTOR_GRADE_FILE, new DoctorGradeCSVConverter(CSV_DELIMITER2, CSV_DICTIONARY_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            SpecialityRepository specialityRepository=new SpecialityRepository(new CSVStream<Speciality>(SPECIALITY_FILE, new SpecialityCSVConverter(CSV_DELIMITER)), new LongSequencer());
            HospitalizationRepository hospitalizationRepository = new HospitalizationRepository(new CSVStream<Hospitalization>(HOSPITALIZATION_FILE, new HospitalizationCSVConverter(CSV_DELIMITER)), new LongSequencer());
            OperationRepository operationRepository = new OperationRepository(new CSVStream<Operation>(OPERATION_FILE, new OperationCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DiagnosisRepository diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(DIAGNOSIS_FILE, new DiagnosisCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(PRESCRIPTION_FILE, new PrescriptionCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            ReferralRepository referralRepository = new ReferralRepository(new CSVStream<Referral>(REFERRAL_FILE, new ReferralCSVConverter(CSV_DELIMITER)), new LongSequencer());
            SymptomRepository symptomRepository = new SymptomRepository(new CSVStream<Symptom>(SYMPTOM_FILE, new SymptomCSVConverter(CSV_DELIMITER)), new LongSequencer());
            TherapyRepository therapyRepository = new TherapyRepository(new CSVStream<Therapy>(THERAPY_FILE, new TherapyCSVConverter(CSV_DELIMITER)), new LongSequencer());
            ArticleRepository articleRepository = new ArticleRepository(new CSVStream<Article>(ARTICLE_FILE, new ArticleCSVConverter(CSV_DELIMITER)), new LongSequencer());


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

            UserController = new UserController(userService);
            DoctorController = new DoctorController(doctorService);


            ArticleController articleController = new ArticleController(articleService);
            DiagnosisController diagnosisController = new DiagnosisController(diagnosisService);
            DoctorGradeController doctorGradeController = new DoctorGradeController(doctorGradeService);
            HospitalizationController hospitalizationController = new HospitalizationController(hospitalizationService);
            OperationController operationController = new OperationController(operationService);
            PrescriptionController prescriptionController = new PrescriptionController(prescriptionService);
            ReferralController referralController = new ReferralController(referralService);
            SpecialityController specialityController = new SpecialityController(specialityService);
            SymptomController symptomController = new SymptomController(symptomService);
            TherapyController therapyController = new TherapyController(therapyService);

            //List<Symptom> s = new List<Symptom>();
            //Symptom si = new Symptom(1, "ime");
            //Symptom si2 = new Symptom(2, "ime2");
            //s.Add(si);
            //s.Add(si2);
            //Diagnosis dijagnoza = new Diagnosis(111,"imedijagnoze", s);
            //Console.WriteLine(dijagnoza.Symptom);
            //articleController.Save(new Article(111, DateTime.Today, "bllllla", "blaaaa"));
            //  diagnosisController.Save(dijagnoza);
            //Dictionary<String, double> dic = new Dictionary<string, double>();
            //dic["pitanje1"] = 1;
            //dic["pitanje2"] = 2.22;
            //DoctorGrade dg = new DoctorGrade(11, 11, dic);
            //doctorGradeController.Save(dg);           
            //hospitalizationController.Save( new Hospitalization(11, new Period(new DateTime(2015,10,10), new DateTime(2006,10,15)), new PatientFile(2), new Room(3)));
            // operationController.Save(new Operation(111, new Doctor(5), "naziv", new Period(new DateTime(2015, 10, 10), new DateTime(2006, 10, 15)), new Room(3), new PatientFile(3)));
            //List<Drug> d = new List<Drug>();
            //Drug gr = new Drug(2);
            //Drug gr1 = new Drug(3);
            //d.Add(gr);
            //d.Add(gr1);
            //prescriptionController.Save(new Prescription(111, new DateTime(2016, 10, 10), new DateTime(2016, 10, 15), "note", d));
            //referralController.Save(new Referral(11, new DateTime(2016, 10, 10), new DateTime(2016, 10, 15), new Doctor(5)));
            //specialityController.Save(new Speciality("lslsl"));
            // symptomController.Save(new Symptom("ime"));
            //therapyController.Save(new Therapy("note", new Period(new DateTime(2015, 10, 10), new DateTime(2006, 10, 15)), 23));
        }
        public IController<Article, long> ArticleController { get; private set; }

        public IController<DoctorGrade, long> DoctorGradeController { get; private set; }
        public IController<Speciality, long> SpecialityController { get; private set; }
        public IController<Hospitalization, long> HospitalizationController { get; private set; }
        public IController<Operation, long> OperationController { get; private set; }
        public IController<Diagnosis, long> DiagnosisController { get; private set; }
        public IController<Prescription, long> PrescriptionController { get; private set; }
        //public IController<Referral, long> ReferralController { get; private set; } 
        //public IController<Symptom, long> SymptomController { get; private set; }
        //public IController<Therapy, long> TherapyController { get; private set; }
    }
}
