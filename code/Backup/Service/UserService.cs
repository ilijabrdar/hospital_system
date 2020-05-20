/***********************************************************************
 * Module:  UserService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

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
         return null;
      }
      
      public Boolean IsPasswordValid(String password)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean IsUsernameValid(String username)
      {
         // TODO: implement
         return null;
      }
      
      public Feedback SendFeedback(String feedback)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean BlockUser(String username)
      {
         // TODO: implement
         return null;
      }
   
      private IService _doctorService;
      private IService _patientService;
      private IService _secretaryService;
      private IService _directorService;
   
   }
}