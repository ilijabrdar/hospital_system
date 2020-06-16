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
        IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        public Address Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAll()
        {
            return _service.GetAll();
        }
    }
}
