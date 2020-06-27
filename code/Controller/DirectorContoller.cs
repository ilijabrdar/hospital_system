
using bolnica.Controller;
using bolnica.Service;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DirectorContoller : IDirectorController
    {
        private readonly IDirectorService directorService;

        public DirectorContoller(IDirectorService directorService)
        {
            this.directorService = directorService;
        }

        public void Delete(Director entity)  //TODO: sta cemo sa ovim
        {
            throw new NotImplementedException();
        }

        public void Edit(Director entity)
        {
            directorService.Edit(entity);
        }

        public Director Get(long id)
        {
            return directorService.Get(id);
        }

        public IEnumerable<Director> GetAll()  //sta cemo sa ovim
        {
            throw new NotImplementedException();
        }

        public Director Save(Director entity)  //TODO: sta cemo sa ovim
        {
            throw new NotImplementedException();
        }
    }
}