/***********************************************************************
 * Module:  OperationService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.OperationService
 ***********************************************************************/

using bolnica.Service;
using Model.Doctor;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class OperationService : IOperationService
   {
      private IOperationRepository _repository;

        public OperationService(IOperationRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Operation entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(Operation entity)
        {
            _repository.Edit(entity);
        }

        public Operation Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return _repository.GetAll();
        }

        public Operation Save(Operation entity)
        {

           return _repository.Save(entity);
        }
    }
}