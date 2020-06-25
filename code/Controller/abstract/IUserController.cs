using Controller;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IUserController : IController<User, long>
    {
        Feedback SendFeedback(String feedback);

        Boolean IsPasswordValid(String password);
        User IsUsernamedValid(String username);

        Boolean BlockUser(String username);
        User Login(String username, String password);
        Boolean Logout(User user);
    }
}
