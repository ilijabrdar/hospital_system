

using bolnica.Repository;
using Model.Director;
using System;

namespace Repository
{
   public interface IRenovationRepository : IRepository<Renovation,long>, IEagerRepository<Renovation,long>
   {
   }
}