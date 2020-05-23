/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.RenovationService
 ***********************************************************************/

using bolnica.Service;
using Model.Director;
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

        public void Edit(Renovation entity)
        {
            _repository.Edit(entity);
        }

        public Renovation Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Renovation> GetAll()
        {
            return _repository.GetAll();
        }

        public Renovation Save(Renovation entity)
        {
            return _repository.Save(entity);
        }
    }
}