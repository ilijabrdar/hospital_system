/***********************************************************************
 * Module:  UserService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

using System;

namespace Controller
{
   public class UserController : IController
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
   
      private Service.IService _service;
   
   }
}