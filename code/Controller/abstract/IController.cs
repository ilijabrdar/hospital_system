/***********************************************************************
 * Module:  IService.cs
 * Author:  david
 * Purpose: Definition of the Interface Service.IService
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Controller
{
   public interface IController<E, ID> where E : class
    {
      E Save(E entity);
      void Delete(E entity);
      void Edit(E entity);
      IEnumerable<E> GetAll();

        E Get(ID id);
   }
}