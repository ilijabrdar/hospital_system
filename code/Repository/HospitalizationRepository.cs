using bolnica.Repository;
using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Repository
{
   public class HospitalizationRepository : CSVRepository<Hospitalization, long>, IHospitalizationRepository
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        public HospitalizationRepository(ICSVStream<Hospitalization> stream, ISequencer<long> sequencer, IRoomRepository roomRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
            : base(stream, sequencer)
        {
            _patientRepository = patientRepository;
            _roomRepository = roomRepository;
            _doctorRepository = doctorRepository;
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
            hospitalization.Patient = _patientRepository.Get(hospitalization.Patient.GetId());
            hospitalization.Doctor = _doctorRepository.GetEager(hospitalization.Doctor.GetId());
            return hospitalization;
        }

        public List<Hospitalization> GetHospitalizationByDoctor(Doctor doctor)
        {
            List<Hospitalization> hospitalizations = this.GetAllEager().ToList();
            List<Hospitalization> retVal = new List<Hospitalization>();
            foreach (Hospitalization hospitalization in hospitalizations)
            {
                if (hospitalization.Doctor.Id == doctor.Id)
                {
                    retVal.Add(hospitalization);
                }
            }
            return retVal;
        }

    }
}