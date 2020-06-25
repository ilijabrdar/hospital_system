using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model.Dto;
using Controller;
using Model.Users;

namespace bolnica.Controller
{
    public interface IPatientNotificationController : IController<PatientNotification, long>
    {
        IEnumerable<PatientNotification> getNotificationByPatient(Patient patient);

    }
}
