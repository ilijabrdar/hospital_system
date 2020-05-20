/***********************************************************************
 * Module:  Employees.cs
 * Author:  david
 * Purpose: Definition of the Class Users.Employees
 ***********************************************************************/

using System;

namespace Model.Users
{
   public abstract class User : Person
   {
      private String Username;
      private String Password;
      private Object Image;
   
   }
}