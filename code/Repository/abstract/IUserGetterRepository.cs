using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
   public interface IUserGetterRepository
{
        User GetUserByUsername(String username);
}
}
