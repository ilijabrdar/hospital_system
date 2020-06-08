

using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class ExaminationUpcomingRepository : CSVRepository<Examination, long>, IExaminationUpcomingRepository
    {
        public ExaminationUpcomingRepository(ICSVStream<Examination> stream, ISequencer<long> sequencer)
  : base(stream, sequencer)
        {

        }

        public IEnumerable<Examination> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Examination GetEager(long id)
        {
            throw new NotImplementedException();
        }

        List<Examination> IExaminationUpcomingRepository.GetScheduledUserExaminations(User user)
        {
            throw new NotImplementedException();
        }

        Examination IRepository<Examination, long>.Save(Examination entity)
        {
            throw new NotImplementedException();
        }

        Examination IExaminationUpcomingRepository.StartUpcomingExamination(Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}