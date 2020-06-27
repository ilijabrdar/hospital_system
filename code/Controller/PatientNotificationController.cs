using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model.Dto;
using bolnica.Service;
using Model.Users;

namespace bolnica.Controller
{
    public class PatientNotificationController : IPatientNotificationController
    {
        private readonly IPatientNotificationService _patientNotificationService;

        public PatientNotificationController(IPatientNotificationService service)
        {
            _patientNotificationService = service;
        }

        public void Delete(PatientNotification entity)  
        {
            _patientNotificationService.Delete(entity);
        }

        public void Edit(PatientNotification entity)
        {
            _patientNotificationService.Edit(entity);
        }

        public PatientNotification Get(long id)
        {
            return _patientNotificationService.Get(id);
        }

        public IEnumerable<PatientNotification> GetAll()
        {
            return _patientNotificationService.GetAll();
        }

        public IEnumerable<PatientNotification> getNotificationByPatient(Patient patient)
        {
            return _patientNotificationService.getNotificationByPatient(patient);
        }

        public PatientNotification Save(PatientNotification entity)
        {
            return _patientNotificationService.Save(entity);
        }
    }
}
