using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;

namespace bolnica.Service
{
     public interface IUserInterface : IService<User, long>
    {
        Boolean IsPasswordValid(String password);


        Boolean IsUsernameValid(String username);
        Feedback SendFeedback(String feedback);

        Boolean BlockUser(String username);
        User Login(String username, String password);
        Boolean Logout(User user);
    }
}
