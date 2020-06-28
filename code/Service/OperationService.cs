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
   public class OperationService : IOperationService
   {
      private IOperationRepository _operationRepository;

        public OperationService(IOperationRepository repository)
        {
            _operationRepository = repository;
        }

        public void Delete(Operation entity)
        {
            _operationRepository.Delete(entity);
        }

        public void Edit(Operation entity)
        {
            _operationRepository.Edit(entity);
        }

        public Operation Get(long id)
        {
            return _operationRepository.GetEager(id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return _operationRepository.GetAllEager();
        }

        public Operation Save(Operation entity)
        {

           return _operationRepository.Save(entity);
        }

        public List<Operation> GetOperationsByDoctor(Doctor doctor)
        {
            return _operationRepository.GetOperationsByDoctor(doctor);
        }

        public List<Operation> GetOperationsByRoomAndPeriod(Room room, Period period)
        {
            List<Operation> operations = new List<Operation>();
            foreach (Operation operation in GetAll())
                if (DateTime.Compare(operation.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(operation.Period.EndDate.Date, period.EndDate.Date) <= 0 && operation.Room.Id == room.Id)
                    operations.Add(operation);

            return operations;
        }
    }
}