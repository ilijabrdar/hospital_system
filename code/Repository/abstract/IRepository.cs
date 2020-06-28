

using System;
using System.Collections;
using System.Collections.Generic;
using bolnica.Repository;

namespace Repository
{
   public interface IRepository<E, ID> : IGetterRepository<E,ID>
       where E : IIdentifiable<ID>
       where ID : IComparable
   {    
      
      E Save(E entity);  
      void Edit(E entity);
      void Delete(E entity);
        
   }
}