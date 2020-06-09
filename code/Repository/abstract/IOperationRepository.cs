using bolnica.Repository;
using Model.Doctor;
using System;

namespace Repository
{
   public interface IOperationRepository : IRepository<Operation,long>, IEagerRepository<Operation, long>
   {
   }
}