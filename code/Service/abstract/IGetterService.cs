using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IGetterService<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        IEnumerable<E> GetAll();
        E Get(ID id);
    }
}
