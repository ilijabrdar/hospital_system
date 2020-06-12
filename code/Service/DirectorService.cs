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
            throw new NotImplementedException();
        }

        public void Edit(Director entity)
        {
            _directorRepository.Edit(entity);
        }

        public Director Get(long id)
        {
            return _directorRepository.GetEager(id);
        }

        public IEnumerable<Director> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            return _directorRepository.GetUserByUsername(username);
        }

        public Doctor RegisterDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Director Save(Director entity)
        {
            throw new NotImplementedException();
        }
    }
}
