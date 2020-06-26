using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model.Dto;
using Model.Users;
using Service;

namespace bolnica.Service
{
    public interface IPatientNotificationService : IService<PatientNotification, long>
    {
        IEnumerable<PatientNotification> getNotificationByPatient(Patient patient);
    }
}
