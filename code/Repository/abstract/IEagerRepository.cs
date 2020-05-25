using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;

namespace bolnica.Repository
{
    public interface IEagerRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        E GetEager(ID id);
        IEnumerable<E> GetAllEager();
    }
}
