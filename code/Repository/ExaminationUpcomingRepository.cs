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
        private readonly IDoctorRepository doctorRepository;
        private readonly IPatientRepository patientRepository;
        private LongSequencer longSequencer;
        private DoctorRepository doctorRepository1;
        private PatientRepository patientRepository1;

        public ExaminationUpcomingRepository(ICSVStream<Examination> stream, ISequencer<long> sequencer, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
  : base(stream, sequencer)
        {
            this.doctorRepository = doctorRepository;
            this.patientRepository = patientRepository;

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
            exam.Doctor = doctorRepository.Get(exam.Doctor.GetId());
            exam.User =patientRepository.Get(exam.User.GetId());
            return exam;
        }

        public  List<Examination> GetUpcomingExaminationsByUser(User user)
        {
            List<Examination> examinations = GetAllEager().ToList();
            foreach(Examination examination in examinations)
            {
                if (examination.Doctor == user)
                {
                    examinations.Add(examination);
                }
            }
            return examinations;
        }

        public Examination StartUpcomingExamination(Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}