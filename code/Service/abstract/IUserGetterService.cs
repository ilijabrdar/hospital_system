using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IUserGetterService
{
     User GetUserByUsername(String username);
}
}
