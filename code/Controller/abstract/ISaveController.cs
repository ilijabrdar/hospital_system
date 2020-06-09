using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface ISaveController<E>
        where E : class
    {
        E Save(E entity);
    }
}
