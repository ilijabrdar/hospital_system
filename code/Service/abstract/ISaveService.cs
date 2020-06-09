using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface ISaveService<E> where E : class
    {
        E Save(E entity);
    }
}
