/***********************************************************************
 * Module:  IService.cs
 * Author:  Asus
 * Purpose: Definition of the Interface Service.IService
 ***********************************************************************/

using System;

namespace Service
{
   public interface IService
   {
      Object Save();
      Object Delete();
      Object Edit();
      Object GetAll();
   }
}