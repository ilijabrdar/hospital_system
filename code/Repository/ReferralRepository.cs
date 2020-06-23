using bolnica.Repository;
using bolnica.Service;
using Model.Doctor;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ReferralRepository : CSVRepository<Referral, long>, IReferralRepository
    {
        private readonly IDoctorRepository _doctorRepository;
        public ReferralRepository(ICSVStream<Model.Doctor.Referral> stream, ISequencer<long> sequencer, IDoctorRepository doctorRepository)
          : base(stream, sequencer)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Referral> GetAllEager()
        {
            List<Referral> referral = new List<Referral>();
            foreach(Referral r in GetAll().ToList()){
                referral.Add(GetEager(r.GetId()));
            }
            return referral;
        }

        public Referral GetEager(long id)
        {
            Referral referral = Get(id);
            referral.Doctor = _doctorRepository.GetEager(referral.Doctor.GetId());
            return referral;
        }
    }
}
