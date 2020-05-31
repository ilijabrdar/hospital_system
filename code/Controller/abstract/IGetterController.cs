using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;

namespace bolnica.Controller
{
    public interface IGetterController<E, ID> where E : class
    {
        IEnumerable<E> GetAll();
        E Get(ID id);
    }
}
