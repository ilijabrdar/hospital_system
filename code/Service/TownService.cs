using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository;
using Model.Users;

namespace bolnica.Service
{
    public class TownService : ITownService
    {
        ITownRepository _repository;

        public TownService(ITownRepository repository)
        {
            _repository = repository;
        } 

        public Town Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Town> GetAll()
        {
            return _repository.GetAllEager();
        }
    }
}
