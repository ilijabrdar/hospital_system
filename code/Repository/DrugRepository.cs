

using bolnica.Repository;
using Model.PatientSecretary;
using System;

namespace Repository
{
   public class DrugRepository : CSVRepository<Drug,long>, IDrugRepository
   {
      private String FilePath;
        public DrugRepository(ICSVStream<Drug> stream, ISequencer<long> sequencer)
            : base(stream, sequencer)
        {

        }
      

        public Drug[] GetAlternative(Drug drug)
        {
            throw new NotImplementedException();
        }

        public Drug[] GetNotApproved()
        {
            throw new NotImplementedException();
        }

    }
}