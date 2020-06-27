using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model.Dto;
using bolnica.Repository;
using Model.Users;
using Service;

namespace bolnica.Service
{
    public class PatientNotificationService : IPatientNotificationService
    {
        private readonly IPatientNotificationRepository _patientNotificationRepository;

        public PatientNotificationService(IPatientNotificationRepository patientNotificationRepository)
        {
            _patientNotificationRepository = patientNotificationRepository;
        }
        public void Delete(PatientNotification entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(PatientNotification entity)
        {
            _patientNotificationRepository.Edit(entity);
        }

        public PatientNotification Get(long id)
        {
            return _patientNotificationRepository.GetEager(id);
        }

        public IEnumerable<PatientNotification> GetAll()
        {
            return _patientNotificationRepository.GetAllEager();
        }

        public PatientNotification Save(PatientNotification entity)
        {
            return _patientNotificationRepository.Save(entity);
        }

        public IEnumerable<PatientNotification> getNotificationByPatient(Patient patient)
            => GetAll().ToList().FindAll(notification => notification.Patient.Id == patient.Id && !notification.Read);

    }
}
