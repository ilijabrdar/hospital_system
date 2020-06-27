using System;
using System.Collections.Generic;
using bolnica.Service;
using Model.Users;
using Repository;

namespace Service
{
   public class SecretaryService : ISecretaryService
   {
      private readonly ISecretaryRepository _secretaryRepository;

        public SecretaryService(ISecretaryRepository secretaryRepository)
        {
            _secretaryRepository = secretaryRepository;
        }
        
        public void Delete(Secretary entity)
        {
            _secretaryRepository.Delete(entity);
        }


        public void Edit(Secretary entity)
        {
            _secretaryRepository.Edit(entity);
        }

        public Secretary Get(long id)
        {
            return _secretaryRepository.Get(id);
        }

        public IEnumerable<Secretary> GetAll()
        {
            return _secretaryRepository.GetAll();
        }

        public User GetUserByUsername(string username)
        {
            return _secretaryRepository.GetUserByUsername(username);
        }

        public Secretary Save(Secretary entity)
        {
            return _secretaryRepository.Save(entity);
        }
    }
}
