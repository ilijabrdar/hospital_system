using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;

namespace bolnica.Repository
{
    public interface IEditRepository<E, ID> 
       where E : IIdentifiable<ID>
       where ID : IComparable
    {
        void Edit(E entity);
    }
}
