
using bolnica.Controller;
using bolnica.Service;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DirectorContoller : IDirectorController
    {
        private readonly IDirectorService _directorService;

        public DirectorContoller(IDirectorService directorService)
        {
            this._directorService = directorService;
        }

        public void Delete(Director entity) 

        {
            _directorService.Delete(entity);
        }

        public void Edit(Director entity)
        {
            _directorService.Edit(entity);
        }

        public Director Get(long id)
        {

            return _directorService.Get(id);
        }

        public IEnumerable<Director> GetAll()  

        {
            return _directorService.GetAll();
        }

        public Director Save(Director entity)  
        {
            return _directorService.Save(entity);

        }
    }
}