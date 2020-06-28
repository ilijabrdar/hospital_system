using bolnica.Model.Dto;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Controller
{
    public interface INotificationController
    {
        int NotifyDoctorOfDrugsForValidation();
        List<NotifyDoctorBusinessDay> NotifyDoctorOfUpcomingBusinessDays(Doctor doctor);

    }
}
