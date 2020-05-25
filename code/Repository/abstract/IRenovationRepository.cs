/***********************************************************************
 * Module:  IRenovationRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IRenovationRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using System;

namespace Repository
{
   public interface IRenovationRepository : IRepository<Renovation,long>, IGetterRepository<Renovation, long>, IEagerRepository<Renovation,long>
   {
   }
}