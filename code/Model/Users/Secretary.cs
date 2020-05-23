/***********************************************************************
 * Module:  Secretary.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Secretary
 ***********************************************************************/

using System;
using System.Drawing;

namespace Model.Users
{
    public class Secretary : User, Repository.IIdentifiable<long>
    {
        private long _id;

        public Secretary(long id, 
            String username, String password, Image image, 
            String firstName, String lastName, String jmbg, String email, String phone, DateTime dateOfBirth)
        {
            _id = id;
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

        override
        public long GetId()
        {
            return _id;
        }

        override
        public void SetId(long id)
        {
            _id = id;
        }
    }
}