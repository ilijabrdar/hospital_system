/***********************************************************************
 * Module:  SecretaryService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.SecretaryService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using bolnica.Controller;
using bolnica.Service;
using Model.Users;

namespace Controller
{
    public class SecretaryController : ISecretaryController //TODO: sta cemo sa metodama
    {
        private ISecretaryService _service;

        public SecretaryController(ISecretaryService service)
        {
            _service = service;
        }

        public void Delete(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Secretary entity)
        {
            _service.Edit(entity);
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