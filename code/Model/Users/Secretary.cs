/***********************************************************************
 * Module:  Secretary.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Secretary
 ***********************************************************************/

using System;

namespace Model.Users
{
    public class Secretary : User, Repository.IIdentifiable<long>
    {
        private long _id;

        public Secretary(long id, 
            String username, String password, Object image, 
            String firstName, String lastName, String jmbg, String email, String phone, DateTime dateOfBirth)
        {
            Id = id;
            Username = username;
            Password = password;
            Image = image;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
        }

        public long GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }
    }
}