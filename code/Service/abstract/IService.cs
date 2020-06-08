using bolnica.Service;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Service
{
   public interface IService<E, ID> : IGetterService<E, ID>
       where E : IIdentifiable<ID>
       where ID : IComparable
    {
      E Save(E entity); 
      void Delete(E entity);
      void Edit(E entity);

    }
}