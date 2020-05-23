/***********************************************************************
 * Module:  Director.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Director
 ***********************************************************************/

using System;

namespace Model.Users
{
   public class Director : User
   {
      private String Id;

        public override long GetId()
        {
            throw new NotImplementedException();
        }

        public override void SetId(long id)
        {
            throw new NotImplementedException();
        }
    }
}