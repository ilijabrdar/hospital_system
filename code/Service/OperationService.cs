using bolnica.Service;
using Model.Doctor;
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
    }
}