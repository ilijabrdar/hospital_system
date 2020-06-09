

using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class ExaminationPreviousRepository : CSVRepository<Examination, long>, IExaminationPreviousRepository
    {
        public ExaminationPreviousRepository(ICSVStream<Examination> stream, ISequencer<long> sequencer)
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

        List<Examination> IExaminationPreviousRepository.GetExaminationsByUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}