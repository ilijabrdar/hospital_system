using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using bolnica.Model.Dto;
using bolnica.Controller;

namespace Controller
{
   public class NotificationController : INotificationController
   {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService service)
        {
            this._notificationService = service;
        }

        public int NotifyDoctorOfDrugsForValidation()
        {
            return _notificationService.NotifyDoctorOfDrugsForValidation();
        }

        public List<NotifyDoctorBusinessDay> NotifyDoctorOfUpcomingBusinessDays(Doctor doctor)
        {
            return _notificationService.NotifyDoctorOfUpcomingBusinessDays(doctor);
        }

    }
}