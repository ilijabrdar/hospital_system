/***********************************************************************
 * Module:  IService.cs
 * Author:  david
 * Purpose: Definition of the Interface Service.IService
 ***********************************************************************/

using bolnica.Controller;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Controller
{
   public interface IController<E, ID> : IGetterController<E, ID>
       where E : IIdentifiable<ID>
       where ID : IComparable
    {
      E Save(E entity);
      void Delete(E entity);
      void Edit(E entity);
   }
}