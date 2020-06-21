

using System;
using System.Drawing;

namespace Model.Users
{
    public class Secretary : User, Repository.IIdentifiable<long>
    {

        public Secretary(long id,
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