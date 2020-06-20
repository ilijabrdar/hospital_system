

using System;
using System.Drawing;

namespace Model.Users
{
    public class Secretary : User, Repository.IIdentifiable<long>
    {
        public bool Loged { get; set; }

        public Secretary(long id,
            String username, String password, Bitmap image,
            String firstName, String lastName, String jmbg, String email, String phone, DateTime dateOfBirth, Address address, bool loged)
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
            Loged = loged;
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