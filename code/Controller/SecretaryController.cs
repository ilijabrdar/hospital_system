using System;
using System.Collections.Generic;
using bolnica.Controller;
using bolnica.Service;
using Model.Users;

namespace Controller
{
    public class SecretaryController : ISecretaryController 
    {
        private ISecretaryService _secretaryService;

        public SecretaryController(ISecretaryService service)
        {
            _secretaryService = service;
        }

        public void Delete(Secretary entity)
        {
            _secretaryService.Delete(entity);
        }

        public void Edit(Secretary entity)
        {
            _secretaryService.Edit(entity);
        }

        public Secretary Get(long id)
        {
            return _secretaryService.Get(id);
        }

        public IEnumerable<Secretary> GetAll()
        {
            return _secretaryService.GetAll();
        }

        public Secretary Save(Secretary entity)
        {
            return _secretaryService.Save(entity);
        }
    }
}