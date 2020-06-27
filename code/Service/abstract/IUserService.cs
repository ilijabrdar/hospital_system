using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;

namespace bolnica.Service
{
    public interface IUserService : IService<User, long>
    {
        User IsUsernameValid(String username);
        bool IsPasswordValid(User user, String password);

        User Login(String username, String password);
    }
}
