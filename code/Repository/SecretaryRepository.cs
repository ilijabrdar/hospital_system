/***********************************************************************
 * Module:  SecretaryService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.SecretaryService
 ***********************************************************************/

using bolnica.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class SecretaryRepository : CSVRepository<Secretary, long>, ISecretaryRepository, IEagerRepository<Secretary, long>
   {
        private readonly IEagerRepository<Address, long> _addressRepository;

        public SecretaryRepository(ICSVStream<Secretary> stream, ISequencer<long> sequencer, IEagerRepository<Address, long> addressRepository) : base(stream, sequencer)
        {
            _addressRepository = addressRepository;
        }

        public SecretaryRepository(CSVStream<Secretary> cSVStream, LongSequencer longSequencer) : base(cSVStream, longSequencer)
        {
        }

        public IEnumerable<Secretary> GetAllEager()
        {
            List<Secretary> secretaries = GetAll().ToList();
            List<Address> addresses = _addressRepository.GetAllEager().ToList();
            Join(secretaries, addresses);
            return secretaries;
        }

        private void Join(List<Secretary> secretaries, List<Address> addresses)
        {
            for(int i = 0; i < secretaries.Count; i++)
            {
                secretaries[i].address = GetAddressByID(addresses, secretaries[i].GetId());
            }
        }

        private Address GetAddressByID(List<Address> addresses, long id)
        {
            foreach (Address address in addresses)
                if (address.GetId() == id)
                    return address;
            return null; 
        }

        public Secretary GetEager(long id)
        {
            Secretary secretary = Get(id);
            Address address = secretary.address;
            address = _addressRepository.GetEager(address.GetId());
            return secretary;
        }

        public Secretary GetSecretaryByUsername(string username)
        {
            List<Secretary> entities = this.GetAllEager().ToList();
            foreach(Secretary entity in entities)
            {
                if (entity.Username == username)
                    return entity;
            }
            return null;
        }
    }
}