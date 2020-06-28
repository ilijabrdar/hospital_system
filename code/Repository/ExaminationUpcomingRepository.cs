using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bolnica.Repository
{
    public class ExaminationUpcomingRepository : CSVRepository<Examination, long>, IExaminationUpcomingRepository
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public ExaminationUpcomingRepository(ICSVStream<Examination> stream, ISequencer<long> sequencer, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
        : base(stream, sequencer)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        public IEnumerable<Examination> GetAllEager()
        {
            List<Examination> examinations = new List<Examination>();
            foreach(Examination exam in GetAll().ToList())
            {
                examinations.Add(GetEager(exam.GetId()));
            }
            return examinations;
        }

        public Examination GetEager(long id)
        {
            Examination exam = base.Get(id);
            exam.Doctor = _doctorRepository.GetEager(exam.Doctor.GetId());
            exam.User =_patientRepository.GetEager(exam.User.GetId());
            return exam;
        }

        public  List<Examination> GetUpcomingExaminationsByUser(User user)
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

            }catch(Exception e)
            {
                Patient patient = (Patient)user;
                List<Examination> examinations = GetAllEager().ToList();
                List<Examination> findExamination = new List<Examination>();
                foreach (Examination examination in examinations)
                {
                    if (examination.User.Id == patient.Id)
                    {
                        findExamination.Add(examination);
                    }
                }
                return findExamination;
            }
        }

    }
}