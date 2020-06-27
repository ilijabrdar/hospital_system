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
        IAddressRepository _addressRepository;

        public AddressService(IAddressRepository repository)
        {
            _addressRepository = repository;
        }

        public Address Get(long id)
        {
            return _addressRepository.Get(id);
        }

        public IEnumerable<Address> GetAll()
        {
            return _addressRepository.GetAll();
        }
    }
}
