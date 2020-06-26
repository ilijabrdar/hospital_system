using Model.PatientSecretary;
using Model.Users;
using System;

namespace Model.Dto
{
   public class DoctorReportDTO
   {
      public Prescription Prescription;
      public Anemnesis Anemnesis;
      public Patient Patient;

        public DoctorReportDTO(Prescription prescription, Anemnesis anemnesis, Patient patient)
        {
            Prescription = prescription;
            Anemnesis = anemnesis;
            Patient = patient;
        }
    }
}