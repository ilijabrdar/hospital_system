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
        E getEager(ID id);
        IEnumerable<E> getAllEager();
    }
}
