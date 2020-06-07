using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IReferralService : IService<Referral,long>
    {
    }
}
