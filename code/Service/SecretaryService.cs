/***********************************************************************
 * Module:  SecretaryService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.SecretaryService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using bolnica.Service;
using Model.Users;

namespace Service
{
   public class SecretaryService : ISecretaryService
   {
      private Repository.ISecretaryRepository _secretaryRepository;

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

        public Secretary Save(Secretary entity)
        {
            throw new NotImplementedException();
        }
    }
}