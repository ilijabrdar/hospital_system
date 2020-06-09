using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;
using bolnica.Repository.CSV;

namespace bolnica.Repository
{
    public class TownRepository : CSVGetterRepository<Town, long>, ITownRepository
    {
        private readonly IEagerRepository<Address, long> _addressRepository;

        public TownRepository(ICSVStream<Town> stream, ISequencer<long> sequencer, IEagerRepository<Address, long> addressRepository) : base(stream, sequencer)
        {
            _addressRepository = addressRepository;
        }

        public IEnumerable<Town> GetAllEager()
        {
            List<Address> addresses = _addressRepository.GetAllEager().ToList();
            List<Town> towns = GetAll().ToList();
            Join(addresses, towns);
            return towns;
        }

        private void Join(List<Address> addresses, List<Town> towns)
        {
            for (int i = 0; i < towns.Count; i++)
            {
                List<Address> oldAddresses = towns[i].GetAddress();
                for (int j = 0; j < oldAddresses.Count; j++)
                    oldAddresses[j] = GetAddressByID(addresses, oldAddresses[i].GetId());
            }
        }

        private Address GetAddressByID(List<Address> addresses, long id)
        {
            foreach (Address address in addresses)
                if (address.GetId() == id)
                    return address;
            return null;
        }

        public Town GetEager(long id)
        {
            Town town = Get(id);
            List<Address> addresses = town.GetAddress();
            for (int i = 0; i < addresses.Count; i++)
            {
                addresses[i] = _addressRepository.GetEager(addresses[i].GetId());
            }
            return town;
        }
    }
}
