using bolnica.Service;
using Controller;
using Model.Doctor;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IReferralController : IController<Referral, long>
    {
    }
}
