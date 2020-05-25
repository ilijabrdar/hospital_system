/***********************************************************************
 * Module:  SecretaryService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.SecretaryService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using bolnica.Service;
using Model.Users;
using Repository;

namespace Service
{
   public class SecretaryService : ISecretaryService
   {
      private ISecretaryRepository _secretaryRepository;
        public SecretaryService(ISecretaryRepository secretaryRepository)
        {
            _secretaryRepository = secretaryRepository;
        }
        public void Delete(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public Secretary Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Secretary> GetAll()
        {
            throw new NotImplementedException();
        }

        public Secretary GetSecretaryByUsername(string username)
        {
            return _secretaryRepository.GetSecretaryByUsername(username);
        }

        public Secretary Save(Secretary entity)
        {
            throw new NotImplementedException();
        }
    }
}