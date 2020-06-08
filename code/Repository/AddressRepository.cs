using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository.CSV;
using Model.Users;

namespace bolnica.Repository
{
    public class AddressRepository : CSVGetterRepository<Address, long>, IAddressRepository
    {
        public AddressRepository(ICSVStream<Address> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {
        }

        public IEnumerable<Address> GetAllEager()
        {
            return GetAll();
        }

        public Address GetEager(long id)
        {
            return Get(id);
        }
    }
}
