using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IGetterService<E, ID> where E : class
    {
        IEnumerable<E> GetAll();
        E Get(ID id);
    }
}
