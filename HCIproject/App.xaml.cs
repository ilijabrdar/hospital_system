using bolnica.Controller;
using bolnica.Repository;
using bolnica.Repository.CSV.Converter;
using Controller;
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
        private const String CSV_DELIMITER = ",";
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

        public IUserController UserController { get; private set; }
    
        public App()
        {
            DoctorRepository doctorRepository=new DoctorRepository(new CSVStream<Doctor>(DOCTOR_FILE, new DoctorCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DoctorGradeRepository doctorGradeRepository=new DoctorGradeRepository(new CSVStream<DoctorGrade>(DOCTOR_GRADE_FILE, new DoctorGradeCSVConverter(CSV_DELIMITER, CSV_DICTIONARY_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            SpecialityRepository specialityRepository=new SpecialityRepository(new CSVStream<Speciality>(SPECIALITY_FILE, new SpecialityCSVConverter(CSV_DELIMITER)), new LongSequencer());
            HospitalizationRepository hospitalizationRepository = new HospitalizationRepository(new CSVStream<Hospitalization>(HOSPITALIZATION_FILE, new HospitalizationCSVConverter(CSV_DELIMITER)), new LongSequencer());
            OperationRepository operationRepository = new OperationRepository(new CSVStream<Operation>(OPERATION_FILE, new OperationCSVConverter(CSV_DELIMITER)), new LongSequencer());
            DiagnosisRepository diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(DIAGNOSIS_FILE, new DiagnosisCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(PRESCRIPTION_FILE, new PrescriptionCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer());
            ReferralRepository referralRepository = new ReferralRepository(new CSVStream<Referral>(REFERRAL_FILE, new ReferralCSVConverter(CSV_DELIMITER)), new LongSequencer());
            SymptomRepository symptomRepository = new SymptomRepository(new CSVStream<Symptom>(SYMPTOM_FILE, new SymptomCSVConverter(CSV_DELIMITER)), new LongSequencer());
            TherapyRepository therapyRepository = new TherapyRepository(new CSVStream<Therapy>(THERAPY_FILE, new TherapyCSVConverter(CSV_DELIMITER)), new LongSequencer());


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

            DoctorController = new DoctorController(doctorService);
            DoctorGradeController = new DoctorGradeController(doctorGradeService);
            SpecialityController = new SpecialityController(specialityService);
            HospitalizationController = new HospitalizationController(hospitalizationService);
            OperationController = new OperationController(operationService);
            DiagnosisController = new DiagnosisController(diagnosisService);
            PrescriptionController = new PrescriptionController(prescriptionService);
            ReferralController = new ReferralController(referralService);
            SymptomController = new SymptomController(symptomService);
            TherapyController = new TherapyController(therapyService);
        }
        public IController<Doctor, long> DoctorController { get; private set; }
        public IController<DoctorGrade, long> DoctorGradeController { get; private set; }
        public IController<Speciality, long> SpecialityController { get; private set; }
        public IController<Hospitalization, long> HospitalizationController { get; private set; }
        public IController<Operation, long> OperationController { get; private set; }
        public IController<Diagnosis, long> DiagnosisController { get; private set; }
        public IController<Prescription, long> PrescriptionController { get; private set; }
        public IController<Referral, long> ReferralController { get; private set; } 
        public IController<Symptom, long> SymptomController { get; private set; }
        public IController<Therapy, long> TherapyController { get; private set; }
    }
}
