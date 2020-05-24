using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IPatientService : IService<Patient, long>
{
        Patient ClaimAccount(long id);

    }
}
