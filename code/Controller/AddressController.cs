using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Service;
using Model.Users;

namespace bolnica.Controller
{
    public class AddressController : IAddressController
    {
        IAddressService _adressService;

        public AddressController(IAddressService service)
        {
            _adressService = service;
        }

        public Address Get(long id)
        {
            return _adressService.Get(id);
        }

        public IEnumerable<Address> GetAll()
        {
            return _adressService.GetAll();
        }
    }
}
