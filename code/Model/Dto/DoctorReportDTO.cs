using Model.PatientSecretary;
using Model.Users;
using System;

namespace Model.Dto
{
   public class DoctorReportDTO
   {
        public Prescription Prescription { get; set; }
        public Anemnesis Anemnesis { get; set; }
        public Patient Patient { get; set; }

        public DoctorReportDTO(Prescription prescription, Anemnesis anemnesis, Patient patient)
        {
            Prescription = prescription;
            Anemnesis = anemnesis;
            Patient = patient;
        }
    }
}