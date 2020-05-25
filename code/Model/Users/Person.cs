/***********************************************************************
 * Module:  Person.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Person
 ***********************************************************************/

using Repository;
using System;

namespace Model.Users
{
    public abstract class Person : IIdentifiable<long>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Jmbg { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Address address { get; set; } //TODO: Promeni na Address

        public abstract long GetId();


        public abstract void SetId(long id);
       
    }
}