using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using bolnica.Model.Dto;

namespace Controller
{
   public class NotificationController
   {
        private readonly NotificationService service;

        public NotificationController(NotificationService service)
        {
            this.service = service;
        }

        public int NotifyDoctorOfDrugsForValidation()
        {
            return service.NotifyDoctorOfDrugsForValidation();
        }

        public List<NotifyDoctorBusinessDay> NotifyDoctorOfUpcomingBusinessDays(Doctor doctor)
        {
            return service.NotifyDoctorOfUpcomingBusinessDays(doctor);
        }

        //public PatientNotification NotifyPatientOfExaminationRescheduling()
        //{

        //}

    }
}