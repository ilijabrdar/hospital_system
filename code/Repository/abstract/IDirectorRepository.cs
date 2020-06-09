

using bolnica.Repository;
using Model.Users;
using System;

namespace Repository
{
   public interface IDirectorRepository : IRepository<Director, long>, IUserGetterRepository, IEagerRepository<Director, long>
   {

   }
}