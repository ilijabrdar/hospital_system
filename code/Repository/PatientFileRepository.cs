
using bolnica.Repository;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class PatientFileRepository : CSVRepository<PatientFile, long>, IPatientFileRepository
    {
        private String FilePath;


        public PatientFileRepository(ICSVStream<PatientFile> stream, ISequencer<long> sequencer)
               : base(stream, sequencer)
        {

        }

        public IEnumerable<PatientFile> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public PatientFile GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}