using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model.Dto;
using Repository;

namespace bolnica.Repository
{
    public class PatientNotificationRepository : CSVRepository<PatientNotification, long>, IPatientNotificationRepository
    {
        private readonly IPatientRepository _patientRepository;

        public PatientNotificationRepository(ICSVStream<PatientNotification> stream, ISequencer<long> sequencer, IPatientRepository patientRepository)
             : base(stream, sequencer)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<PatientNotification> GetAllEager()
        {
            List<PatientNotification> patientNotifications = new List<PatientNotification>();
            foreach (PatientNotification notification in GetAll().ToList())
            {
                patientNotifications.Add(GetEager(notification.GetId()));
            }
            return patientNotifications;
        }

        public PatientNotification GetEager(long id)
        {
            PatientNotification patientNotification = Get(id);
            patientNotification.Patient = _patientRepository.GetEager(patientNotification.Patient.GetId());

            return patientNotification;
        }
    }
}
