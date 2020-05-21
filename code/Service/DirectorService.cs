/***********************************************************************
 * Module:  DirectorService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.DirectorService
 ***********************************************************************/

using Model.Users;
using System;

namespace Service
{
   public class DirectorService// : IService
   {
      public Doctor RegisterDoctor(Doctor doctor)
      {
         // TODO: implement
         return null;
      }

        public object Save()
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        private Repository.IDirectorRepository _directorRepository;
   
   }
}