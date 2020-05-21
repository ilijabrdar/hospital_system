/***********************************************************************
 * Module:  IRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IRepository
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Repository
{
   public interface IRepository<E, ID> where E : IIdentifiable<ID>
       where ID : IComparable
   {    //TODO: the rest of the methods?
      IEnumerable<E> GetAll();
      E Save(E entity);  //Danijelov create
      void Edit(E entity);
      void Delete(E entity);
        E get(ID id);
        
   }
}