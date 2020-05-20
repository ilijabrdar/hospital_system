/***********************************************************************
 * Module:  PatientFileService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.PatientFileService
 ***********************************************************************/

using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;

namespace Service
{
   public class PatientFileService : IService
   {
      public PatientFile GetPatientFile(Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public Examination AddExamination(Examination examination, PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public Hospitalization AddHospitalization(Hospitalization hospitalization, PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public Operation AddOperation(Operation operation, PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public Allergy AddAllergy(Allergy allergy, PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public Allergy EditAllergy(PatientFile patientFile, Allergy allergy)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAllergy(PatientFile patientFile, Allergy allergy)
      {
         // TODO: implement
         return false;
      }

        public object Save()
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        private IService Hospitalisation;
      private IService Operation;
      private Repository.IPatientFileRepository _patientFileRepository;
   
   }
}