using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;

namespace bolnica.Repository
{
    public interface IGetterRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        IEnumerable<E> GetAll();
        E get(ID id);
    }
}
