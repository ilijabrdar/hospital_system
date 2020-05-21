/***********************************************************************
 * Module:  IService.cs
 * Author:  david
 * Purpose: Definition of the Interface Service.IService
 ***********************************************************************/

using System;

namespace Controller
{
   public interface IController<E, ID> where E : class
    {
      E Save(E entity);
      Object Delete();
      Object Edit();
      Object GetAll();
   }
}