using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IEditController<E>
        where E : class
    {
        void Edit(E entity);
    }
}
