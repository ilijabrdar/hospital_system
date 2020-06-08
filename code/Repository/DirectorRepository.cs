

using Model.Users;
using System;
using bolnica.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class DirectorRepository : CSVRepository<Director, long> ,IDirectorRepository, IEagerRepository<Director, long>
   {
        private readonly IEagerRepository<Address, long> _addressRepository;
        private readonly IEagerRepository<Town, long> _townRepository;
        private readonly IEagerRepository<State, long> _stateRepository;

        public DirectorRepository(ICSVStream<Director> stream, ISequencer<long> sequencer, IEagerRepository<Address, long> addressRepository,
            IEagerRepository<Town, long> townRepository, IEagerRepository<State, long> stateRepository) : base(stream, sequencer)
        {
            _addressRepository = addressRepository;
            _townRepository = townRepository;
            _stateRepository = stateRepository;

        }
        public User GetUserByUsername(string username) 
        {
            IEnumerable<Director> entities = this.GetAll();
            foreach (Director entity in entities)
            {
                if (entity.Username == username)
                    return entity;
            }
            return null;
        }

        public IEnumerable<Director> GetAllEager()
        {
            List<Director> directors = GetAll().ToList();
            for (int i = 0; i < directors.Count; i++)
            {
                directors[i] = GetEager(directors[i].GetId());
            }
            return directors;
        }

        public Director GetEager(long id)
        {
            Director director = Get(id);
            director.Address = _addressRepository.GetEager(director.Address.GetId());
            director.Address.Town = _townRepository.GetEager(director.Address.Town.GetId());
            director.Address.Town.State = _stateRepository.GetEager(director.Address.Town.State.GetId());
            return director;
        }
    }
}