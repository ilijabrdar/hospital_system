/***********************************************************************
 * Module:  IRoomTypeRepository.cs
 * Author:  Asus
 * Purpose: Definition of the Interface Repository.IRoomTypeRepository
 ***********************************************************************/

using Model.Director;
using System;

namespace Repository
{
   public interface IRoomTypeRepository : IRepository<RoomType, long>
   {
   }
}