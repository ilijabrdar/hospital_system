using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;

namespace bolnica.Repository
{
    public interface ITownRepository : IEagerRepository<Town, long>
    {
        IEnumerable<Town> GetAll();
        Town get(long id);
    }
}
