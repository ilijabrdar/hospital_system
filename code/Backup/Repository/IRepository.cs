/***********************************************************************
 * Module:  IRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IRepository
 ***********************************************************************/

using System;

namespace Repository
{
   public interface IRepository
   {
      Object GetAll();
      Object Save();
      Object Edit();
      Object Delete();
   }
}