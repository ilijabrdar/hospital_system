/***********************************************************************
 * Module:  DirectorService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.DirectorService
 ***********************************************************************/

using Model.Users;
using System;
using bolnica.Service;
using System.Collections.Generic;

namespace Service
{
    public class DirectorService : IDirectorService
    { 
      private Repository.IDirectorRepository _directorRepository;

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