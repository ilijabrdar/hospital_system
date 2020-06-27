using Model.Users;
using System;
using bolnica.Service;
using System.Collections.Generic;
using bolnica.Repository;
using Repository;

namespace Service
{
    public class DirectorService : IDirectorService 
    { 
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public void Delete(Director entity)
        {
            _directorRepository.Delete(entity);
        }

        public void Edit(Director entity)
        {
            _directorRepository.Edit(entity);
        }

        public Director Get(long id)
        {
            return _directorRepository.Get(id);
        }

        public IEnumerable<Director> GetAll()
        {
            return _directorRepository.GetAll();
        }

        public User GetUserByUsername(string username)
        {
            return _directorRepository.GetUserByUsername(username);
        }

        public Director Save(Director entity)
        {
            return _directorRepository.Save(entity);
        }
    }
}
