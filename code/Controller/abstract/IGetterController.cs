using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IGetterController<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        IEnumerable<E> GetAll();
        E Get(ID id);
    }
}
