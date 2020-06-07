using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;
using Service;

namespace bolnica.Service
{
    public interface IDirectorService : IService<Director, long>
    {
        Director GetDirectorByUsername(String username);
        Doctor RegisterDoctor(Doctor doctor);
    }
}
