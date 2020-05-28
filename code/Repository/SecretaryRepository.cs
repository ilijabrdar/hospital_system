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
        private readonly IEagerRepository<Town, long> _townRepository;
        private readonly IEagerRepository<State, long> _stateRepository;

        public SecretaryRepository(ICSVStream<Secretary> stream, ISequencer<long> sequencer, IEagerRepository<Address, long> addressRepository,
            IEagerRepository<Town, long> townRepository, IEagerRepository<State, long> stateRepository) : base(stream, sequencer)
        {
            _addressRepository = addressRepository;
            _townRepository = townRepository;
            _stateRepository = stateRepository;

        }

        public SecretaryRepository(CSVStream<Secretary> cSVStream, LongSequencer longSequencer) : base(cSVStream, longSequencer)
        {
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