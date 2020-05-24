using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;

namespace bolnica.Repository
{
    public interface IStateRepository : IEagerRepository<State, long>
    {
        IEnumerable<State> GetAll();
        State get(long id);
    }
}
