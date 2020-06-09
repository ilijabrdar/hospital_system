using bolnica.Repository;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class OperationRepository : CSVRepository<Operation,long>, IOperationRepository
   {
        public OperationRepository(ICSVStream<Operation> stream, ISequencer<long> sequencer)
          : base(stream, sequencer)
        {
  
        }

        public IEnumerable<Operation> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Operation GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}