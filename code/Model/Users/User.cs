using Repository;
using System;
using System.Drawing;

namespace Model.Users
{
   public abstract class User : Person
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public Bitmap Image { get; set; }
        public long Id;

    }
}