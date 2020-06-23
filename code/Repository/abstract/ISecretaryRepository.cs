

using bolnica.Repository;
using Model.Users;
using System;

namespace Repository
{
   public interface ISecretaryRepository : IRepository<Secretary,long>, IUserGetterRepository, IEagerRepository<Secretary,long>
   {
   }
}