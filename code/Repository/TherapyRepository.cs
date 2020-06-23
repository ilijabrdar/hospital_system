using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
   public class TherapyRepository : CSVRepository<Therapy, long>, ITherapyRepository
    {
        private readonly IDrugRepository _drugRepository;
        public TherapyRepository(ICSVStream<Therapy> stream, ISequencer<long> sequencer, IDrugRepository drugRepo)
          : base(stream, sequencer)
        {
            _drugRepository = drugRepo;
        }

        public IEnumerable<Therapy> GetAllEager()
        {
            List<Therapy> therapy = new List<Therapy>();

            foreach (Therapy t in GetAll().ToList())
            {
                therapy.Add(GetEager(t.GetId()));    
            }
            return therapy; 
        }

        public Therapy GetEager(long id)
        {
            Therapy therapy = Get(id);
            foreach(Drug drug in therapy.Drug)
            {
                Drug temp = _drugRepository.GetEager(drug.Id);
                drug.Name = temp.Name;
                drug.Amount = temp.Amount;
                drug.Approved = temp.Approved;
            }
            return therapy;
        }

    }
}
