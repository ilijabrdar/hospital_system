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
      private String FirstName;
      private String LastName;
      private String Jmbg;
      private String Email;
      private String Phone;
      private DateTime DateOfBirth;
      
      private Address address;
   
   }
}