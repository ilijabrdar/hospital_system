using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model.Dto;
using Repository;

namespace bolnica.Repository
{
    public interface IPatientNotificationRepository : IRepository<PatientNotification, long>, IEagerRepository<PatientNotification, long>
    {

    }   
}
