/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using System;

namespace Controller
{
   public class EquipmentController : IController
   {
      public Model.Director.Room[] GetRoomsContainingEquipment(String name)
      {
         // TODO: implement
         return null;
      }
   
      private Service.IService _service;
   
   }
}