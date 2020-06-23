
using bolnica.Repository;
using Model.Director;
using System;

namespace Repository
{
   public interface IRoomTypeRepository : IRepository<RoomType, long>,  IEagerRepository<RoomType, long>
    {
   }
}