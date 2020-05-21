/***********************************************************************
 * Module:  IService.cs
 * Author:  Asus
 * Purpose: Definition of the Interface Service.IService
 ***********************************************************************/

using System;

namespace Service
{
   public interface IService<E, ID> where E : class
    {
      E Save(E entity);  //Danijelov create
      Object Delete();
      Object Edit();
      Object GetAll();
   }
}