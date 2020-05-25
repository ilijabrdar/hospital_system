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

        public Secretary(long id, 
            String username, String password, Image image, 
            String firstName, String lastName, String jmbg, String email, String phone, DateTime dateOfBirth, Address address) //FIXME Prvo provera sa stringom
        {
            this.Id = id;
            Username = username;
            Password = password;
            Image = image;
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            this.address = address;
        }

        override
        public long GetId()
        {
            return this.Id;
        }

        override
        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}