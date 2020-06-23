using bolnica.Repository;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IOperationRepository : IRepository<Operation,long>, IEagerRepository<Operation, long>
   {
        List<Operation> GetOperationsByDoctor(Doctor doctor);
   }
}