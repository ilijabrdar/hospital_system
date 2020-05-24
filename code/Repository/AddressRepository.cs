using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository.CSV;
using Model.Users;

namespace bolnica.Repository
{
    public class AddressRepository : CSVGetterRepository<Address, long>, IAddressRepository, IEagerRepository<Address, long>
    {
        private readonly IEagerRepository<Town, long> _townRepository;
        public AddressRepository(ICSVStream<Address> stream, ISequencer<long> sequencer, IEagerRepository<Town, long> townRepository) : base(stream, sequencer)
        {
            _townRepository = townRepository;
        }

        public IEnumerable<Address> GetAllEager()
        {
            List<Address> addresses = GetAll().ToList();
            List<Town> towns = _townRepository.GetAllEager().ToList();
            Join(addresses, towns);
            return addresses;
        }

        private void Join(List<Address> addresses, List<Town> towns)
        {
            for(int i = 0; i < addresses.Count; i++)
            {
                Town town = addresses[i].GetTown();
                town = GetTownByID(towns, town.GetId());
            }
        }

        private Town GetTownByID(List<Town> towns, long id)
        {
            foreach (Town town in towns)
                if (town.GetId() == id)
                    return town;
            return null;
        }

        public Address GetEager(long id)
        {
            Address address = Get(id);
            Town town = address.GetTown();
            town = _townRepository.GetEager(town.GetId());
            return address;
        }
    }
}
