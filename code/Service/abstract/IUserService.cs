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
        Boolean IsPasswordValid(User user, String password);
        User IsUsernameValid(String username);
        Feedback SendFeedback(String feedback);

        Boolean BlockUser(String username);
        User Login(String username, String password);
        Boolean Logout(User user);
    }
}
