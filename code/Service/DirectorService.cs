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
        private IDirectorRepository _directorRepository;

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
            throw new NotImplementedException();
        }

        public Director Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> GetAll()
        {
            throw new NotImplementedException();
        }

        public Director GetDirectorByUsername(string username)
        {
            return _directorRepository.GetDirectorByUsername(username);
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
