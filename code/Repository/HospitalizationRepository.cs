using bolnica.Repository;
using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Repository
{
   public class HospitalizationRepository : CSVRepository<Hospitalization, long>, IHospitalizationRepository
    {
        private readonly IRoomRepository _roomRepository;
        public HospitalizationRepository(ICSVStream<Hospitalization> stream, ISequencer<long> sequencer, IRoomRepository roomRepository)
            : base(stream, sequencer)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Hospitalization> GetAllEager()
        {
            List<Hospitalization> hospitalizations = new List<Hospitalization>();
            foreach(Hospitalization hospitalization in GetAll().ToList())
            {
                hospitalizations.Add(GetEager(hospitalization.GetId()));
            }
            return hospitalizations;
        }

        public Hospitalization GetEager(long id)
        {
            Hospitalization hospitalization = Get(id);
            hospitalization.Room=_roomRepository.GetEager(hospitalization.Room.GetId());

            return hospitalization;
        }

    }
}