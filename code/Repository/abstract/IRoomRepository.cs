

using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IRoomRepository : IRepository<Room, long>, IEagerRepository<Room, long>
    {




    }
}