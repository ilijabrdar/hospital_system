/***********************************************************************
 * Module:  IService.cs
 * Author:  Asus
 * Purpose: Definition of the Interface Service.IService
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Service
{
   public interface IService<E, ID> where E : class
    {
      E Save(E entity); 
      void Delete(E entity);
      void Edit(E entity);
      IEnumerable<E> GetAll();
   }
}