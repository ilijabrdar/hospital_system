

using bolnica.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class SecretaryRepository : CSVRepository<Secretary, long>, ISecretaryRepository, IEagerRepository<Secretary, long>
   {
        private readonly IAddressRepository _addressRepository;
        private readonly ITownRepository _townRepository;
        private readonly IStateRepository _stateRepository;

        public SecretaryRepository(ICSVStream<Secretary> stream, ISequencer<long> sequencer, IAddressRepository addressRepository,
            ITownRepository townRepository, IStateRepository stateRepository) : base(stream, sequencer)
        {
            _addressRepository = addressRepository;
            _townRepository = townRepository;
            _stateRepository = stateRepository;

        }

        public IEnumerable<Secretary> GetAllEager()
        {
            List<Secretary> secretaries = GetAll().ToList();
            for(int i = 0; i < secretaries.Count; i++)
            {
                secretaries[i] = GetEager(secretaries[i].GetId());
            }
            return secretaries;
        }

        public Secretary GetEager(long id)
        {
            Secretary secretary = Get(id);
            secretary.Address = _addressRepository.GetEager(secretary.Address.GetId());
            secretary.Address.Town = _townRepository.GetEager(secretary.Address.Town.GetId());
            secretary.Address.Town.State = _stateRepository.GetEager(secretary.Address.Town.State.GetId());
            return secretary;
        }

        public User GetUserByUsername(string username)
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