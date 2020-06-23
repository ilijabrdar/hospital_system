using bolnica.Repository;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class OperationRepository : CSVRepository<Operation,long>, IOperationRepository
   {
        private readonly IRoomRepository _roomRepository;
        private readonly IDoctorRepository _doctorRepository;
        public OperationRepository(ICSVStream<Operation> stream, ISequencer<long> sequencer, IRoomRepository roomRepository, IDoctorRepository doctorRepository)
          : base(stream, sequencer)
        {
            _roomRepository = roomRepository;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Operation> GetAllEager()
        {
            List<Operation> operations = new List<Operation>();
            foreach (Operation operation in GetAll().ToList())
            {
                operations.Add(GetEager(operation.GetId()));
            }
            return operations;
        }

        public Operation GetEager(long id)
        {
            Operation operation = Get(id);
            operation.Room = _roomRepository.GetEager(operation.Room.GetId());
            operation.Doctor = _doctorRepository.GetEager(operation.Doctor.GetId());
            return operation;
        }
    }
}