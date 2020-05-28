/***********************************************************************
 * Module:  Director.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Director
 ***********************************************************************/

using System;
using System.Drawing;

namespace Model.Users
{
    public class Director : User
    {
        public Director(long id,
            String username, String password, Bitmap image,
            String firstName, String lastName, String jmbg, String email, String phone, DateTime dateOfBirth, Address address)
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
            Address = address;
        }

        public override long GetId()
        {
            return Id;
        }

        public override void SetId(long id)
        {
            Id = id;
        }
    }
}