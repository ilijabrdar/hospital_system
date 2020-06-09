

using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class PatientFileService : IPatientFileService
    { 

         private readonly  IHospitalizationService _hospitalisationService;
        private readonly  IOperationService _operationService;
        private readonly IPatientFileRepository _fileRepo;
     
        public PatientFileService(IPatientFileRepository repo) { _fileRepo = repo; }

        public Allergy AddAllergy(Allergy allergy, PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public Examination AddExamination(Examination examination, PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public Hospitalization AddHospitalization(Hospitalization hospitalization, PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public Operation AddOperation(Operation operation, PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public void Delete(PatientFile entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAllergy(PatientFile patientFile, Allergy allergy)
        {
            throw new NotImplementedException();
        }

        public void Edit(PatientFile entity)
        {
            throw new NotImplementedException();
        }

        public Allergy EditAllergy(PatientFile patientFile, Allergy allergy)
        {
            throw new NotImplementedException();
        }

        public PatientFile Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public PatientFile GetPatientFile(Patient patient)
        {
            throw new NotImplementedException();
        }

        public PatientFile Save(PatientFile entity)
        {
            return _fileRepo.Save(entity);
        }
    }
}