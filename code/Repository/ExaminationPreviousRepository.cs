using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ExaminationPreviousRepository : CSVRepository<Examination, long>, IExaminationPreviousRepository
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IPatientRepository patientRepository;
        private readonly IDiagnosisRepository diagnosisRepository;
        private readonly IPrescriptionRepository prescriptionRepository;
        private readonly ITherapyRepository therapyRepository;
        private readonly IReferralRepository referralRepository;

        public ExaminationPreviousRepository(ICSVStream<Examination> stream, ISequencer<long> sequencer, IDoctorRepository doctorRepository, IPatientRepository patientRepository, IDiagnosisRepository diagnosisRepository, IPrescriptionRepository prescriptionRepository, ITherapyRepository therapyRepository, IReferralRepository referralRepository)
         : base(stream, sequencer)
        {
            this.doctorRepository = doctorRepository;
            this.patientRepository = patientRepository;
            this.diagnosisRepository = diagnosisRepository;
            this.prescriptionRepository = prescriptionRepository;
            this.therapyRepository = therapyRepository;
            this.referralRepository = referralRepository;
        }

        public IEnumerable<Examination> GetAllEager()
        {
            List<Examination> examinations = new List<Examination>();
            foreach (Examination exam in GetAll().ToList())
            {
                examinations.Add(GetEager(exam.GetId()));
            }
            return examinations;
        }

        public Examination GetEager(long id)
        {
            Examination exam = base.Get(id);
            exam.Doctor = doctorRepository.GetEager(exam.Doctor.GetId());
            exam.User = patientRepository.Get(exam.User.GetId());
            exam.Diagnosis = diagnosisRepository.Get(exam.Diagnosis.GetId());
            if (exam.Therapy != null)
                exam.Therapy = therapyRepository.GetEager(exam.Therapy.GetId());
            if(exam.Refferal!=null)
                exam.Refferal = referralRepository.GetEager(exam.Refferal.GetId());
            if(exam.Prescription!=null)
                exam.Prescription = prescriptionRepository.GetEager(exam.Prescription.GetId());     
            return exam;
        }

        public List<Examination> GetExaminationsByUser(User user)
        {
            try
            {
                Doctor doctor = (Doctor)user;
                List<Examination> examinations = GetAllEager().ToList();
                List<Examination> findExamination = new List<Examination>();
                foreach (Examination examination in examinations)
                {
                    if (examination.Doctor.Id == doctor.Id)
                    {
                        findExamination.Add(examination);
                    }
                }
                return findExamination;
            }
            catch 
            {
                Patient patient = (Patient)user;
                List<Examination> examinations = GetAllEager().ToList();
                List<Examination> findExamination = new List<Examination>();
                foreach (Examination examination in examinations)
                {
                    if (examination.Doctor.Id == patient.Id)
                    {
                        findExamination.Add(examination);
                    }
                }
                return findExamination;
            }
        }

    }
}