/***********************************************************************
 * Module:  Employees.cs
 * Author:  david
 * Purpose: Definition of the Class Users.Employees
 ***********************************************************************/

using Repository;
using System;
using System.Drawing;

namespace Model.Users
{
   public abstract class User : Person
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public Image Image { get; set; }

     

     
    }
}