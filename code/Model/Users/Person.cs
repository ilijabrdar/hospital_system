/***********************************************************************
 * Module:  Person.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Person
 ***********************************************************************/

using System;

namespace Model.Users
{
   public abstract class Person
   {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Jmbg { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Address address { get; set; }
    }
}