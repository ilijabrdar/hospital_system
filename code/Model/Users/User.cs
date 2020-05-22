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
        public String Username { get; set; }
        public String Password { get; set; }
        public Object Image { get; set; }
    }
}