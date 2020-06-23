using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
     public class PrescriptionRepository : CSVRepository<Prescription, long>, IPrescriptionRepository
    {
        private readonly IDrugRepository _drugRepository;
        public PrescriptionRepository(ICSVStream<Prescription> stream, ISequencer<long> sequencer, IDrugRepository drugRepository)
          : base(stream, sequencer)
        {
            _drugRepository = drugRepository;
        }

        public IEnumerable<Prescription> GetAllEager()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach(Prescription pres in GetAll().ToList())
            {
                prescriptions.Add(GetEager(pres.GetId()));
            }
            return prescriptions;
        }

        public Prescription GetEager(long id)
        {
            Prescription prescription = Get(id);
            foreach(Drug drug in prescription.Drug)
            {
                Drug temp = _drugRepository.GetEager(drug.Id);
                drug.Name = temp.Name;
                drug.Amount = temp.Amount;
                drug.Approved = temp.Approved;
            }
            return prescription;
        }

    }
}
