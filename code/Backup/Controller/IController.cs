/***********************************************************************
 * Module:  IService.cs
 * Author:  david
 * Purpose: Definition of the Interface Service.IService
 ***********************************************************************/

using System;

namespace Controller
{
   public interface IController
   {
      Object Save();
      Object Delete();
      Object Edit();
      Object GetAll();
   }
}