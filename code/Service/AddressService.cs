using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository;
using Model.Users;

namespace bolnica.Service
{
    public class AddressService : IAddressService
    {
        IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public Address Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
