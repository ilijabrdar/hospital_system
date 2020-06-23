

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
            exam.Doctor = doctorRepository.Get(exam.Doctor.GetId());
            exam.User = patientRepository.Get(exam.User.GetId());
            exam.Diagnosis = diagnosisRepository.Get(exam.Diagnosis.GetId());
            exam.Therapy = therapyRepository.Get(exam.Therapy.GetId());
            exam.Refferal = referralRepository.Get(exam.Refferal.GetId());

            foreach (Prescription pres in exam.Prescription)
            {
                Prescription temp = prescriptionRepository.GetEager(pres.Id);
                pres.Period = temp.Period;
                List<Drug> drugs = new List<Drug>();
                foreach (Drug drug in temp.Drug)
                {
                    drugs.Add(drug);
                }
                pres.Drug = drugs;
            }

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
            catch (Exception e)
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