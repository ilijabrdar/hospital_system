/***********************************************************************
 * Module:  UserService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

using Model.Users;
using System;

namespace Service
{
   public class UserService : IService
   {
      public User Login(String username, String password)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Logout(User user)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean IsPasswordValid(String password)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean IsUsernameValid(String username)
      {
         // TODO: implement
         return false;
      }
      
      public Feedback SendFeedback(String feedback)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean BlockUser(String username)
      {
         // TODO: implement
         return false;
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

        private IService _doctorService;
      private IService _patientService;
      private IService _secretaryService;
      private IService _directorService;
   
   }
}