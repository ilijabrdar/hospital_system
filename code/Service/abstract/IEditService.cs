using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IEditService<E> where E : class
    {
        void Edit(E entity);
    }
}
