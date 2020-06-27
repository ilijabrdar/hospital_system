using bolnica.Service;
using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class HospitalizationService : IHospitalizationService
   {
      private IHospitalizationRepository _hospitalizationRepository;

        public HospitalizationService(IHospitalizationRepository repository)
        {
            _hospitalizationRepository = repository;
        }

        public void Delete(Hospitalization entity)
        {
            _hospitalizationRepository.Delete(entity);
        }

        public void Edit(Hospitalization entity)
        {
            _hospitalizationRepository.Edit(entity);
        }

        public Hospitalization Get(long id)
        {
            return _hospitalizationRepository.GetEager(id);
        }

        public IEnumerable<Hospitalization> GetAll()
        {
            return _hospitalizationRepository.GetAllEager();
        }

        public Hospitalization Save(Hospitalization entity)
        {
            return _hospitalizationRepository.Save(entity);
        }

        public List<Hospitalization> GetHospitalizationByDoctor(Doctor doctor)
        {
            return _hospitalizationRepository.GetHospitalizationByDoctor(doctor);
        }

        public List<Hospitalization> GetHospitalizationsByRoomAndPeriod(Room room, Period period)
        {
            List<Hospitalization> hospitalizations = new List<Hospitalization>();
            foreach (Hospitalization hospitalization in GetAll())
                if (DateTime.Compare(hospitalization.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(hospitalization.Period.EndDate.Date, period.EndDate.Date) <= 0 && hospitalization.Room.Id == room.Id)
                    hospitalizations.Add(hospitalization);

            return hospitalizations;
        }
    }
}