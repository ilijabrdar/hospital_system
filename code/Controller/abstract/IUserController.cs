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
        Boolean IsPasswordValid(String password);
        Boolean IsUsernameValid(String username);
        Feedback SendFeedback(String feedback);

        Boolean BlockUser(String username);
        User Login(String username, String password);
        Boolean Logout(User user);
    }
}
