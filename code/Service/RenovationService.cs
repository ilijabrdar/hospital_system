

using bolnica.Service;
using Model.Director;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class RenovationService : IRenovationService
   {
        private readonly IRenovationRepository _repository;

        public RenovationService(IRenovationRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Renovation entity)
        {
            _repository.Delete(entity);
        }

        public void DeleteRenovationByRoom(Room room)
        {
            foreach (Renovation renovation in GetAll())
                if (renovation.Room.Id == room.Id)
                    Delete(renovation);
            
        }

        public void Edit(Renovation entity)
        {
            _repository.Edit(entity);
        }

        public Renovation Get(long id)
        {
            return _repository.GetEager(id);
        }

        public IEnumerable<Renovation> GetAll()
        {
            return _repository.GetAllEager();
        }

        public IEnumerable<Renovation> GetRenovationsByRoomAndPeriod(Room room, Period period)
        {
            List<Renovation> ret = new List<Renovation>();
            foreach (Renovation renovation in GetAll())
                if (renovation.Room.RoomCode.Equals(room.RoomCode) && DateTime.Compare(renovation.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(renovation.Period.EndDate.Date, period.EndDate.Date) <= 0)
                    ret.Add(renovation);
            return ret;
        }

        public Renovation Save(Renovation entity)
        {
            if (validateDates(entity))
                return _repository.Save(entity);
            else
                return null;
        }

        

        private bool validateDates(Renovation entity)
        {
            if (DateTime.Compare(entity.Period.StartDate, entity.Period.EndDate) >= 0)
                return false;
            return true;
        }
    }
}