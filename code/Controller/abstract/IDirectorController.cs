using Controller;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
   public interface IDirectorController : IController<Director, long>
{
        Doctor RegisterDoctor(Doctor doctor);

    }
}
