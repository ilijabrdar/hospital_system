/***********************************************************************
 * Module:  DirectorService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.DirectorService
 ***********************************************************************/

using System;

namespace Service
{
   public class DirectorService : IService
   {
      public Doctor RegisterDoctor(Doctor doctor)
      {
         // TODO: implement
         return null;
      }
   
      private Repository.IDirectorRepository _directorRepository;
   
   }
}