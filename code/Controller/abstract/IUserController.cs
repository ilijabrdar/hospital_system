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
        void SendFeedback(String feedback);
        User IsUsernamedValid(String username);
        User Login(String username, String password);
    }
}
