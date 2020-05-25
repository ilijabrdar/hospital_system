using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;
using Service;

namespace bolnica.Service
{
    public interface ISecretaryService : IService<Secretary, long>
    {
        Secretary GetSecretaryByUsername(String username);
    }
}
