

using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System.Collections.Generic;

namespace Service
{
    public class PatientFileService : IPatientFileService
    { 

        private readonly  IHospitalizationService _hospitalizationService;
        private readonly  IOperationService _operationService;
        private readonly IPatientFileRepository _patientFileRepo;
     
        public PatientFileService(IPatientFileRepository repo, IHospitalizationService hospitalizationService, IOperationService operationService) 
        {
            _hospitalizationService = hospitalizationService;
            _operationService = operationService;
            _patientFileRepo = repo; 
        }

        public PatientFileService(IPatientFileRepository repo)
        {
            _patientFileRepo = repo;
        }

        public Allergy AddAllergy(Allergy allergy, PatientFile patientFile)
        {
            patientFile.Allergy.Add(allergy);
            Edit(patientFile);
            return allergy;

        }

        public Examination AddExamination(Examination examination, PatientFile patientFile)
        { 
            //@Tamara :D Obrati paznju ovde moras prvo da napravis examination pa tek onda ga saljes ovde dok za hosp i za
            //oper samo prosledis, ali ako hoces moze i ovde sa servisom da ne moras da se njakas msm isto je 
            // mozda da ostanemo konzistentni
            patientFile.Examination.Add(examination);
            Edit(patientFile);
            return examination;
        }

        public Hospitalization AddHospitalization(Hospitalization hospitalization, PatientFile patientFile)
        {
            hospitalization = _hospitalizationService.Save(hospitalization);
            patientFile.Hospitalization.Add(hospitalization);
            Edit(patientFile);
            return hospitalization;
        }

        public Operation AddOperation(Operation operation, PatientFile patientFile)
        {
            operation = _operationService.Save(operation);
            patientFile.Operation.Add(operation);
            Edit(patientFile);
            return operation;
        }

        public void Delete(PatientFile entity)
        {
            _patientFileRepo.Delete(entity);
        }

        public bool DeleteAllergy(PatientFile patientFile, Allergy allergy)
        {
            foreach(var help in patientFile.Allergy)
            {
                if (help.Name.Equals(allergy.Name))
                {
                    patientFile.Allergy.Remove(help);
                    return true;
                }
            }
            return false;
        }

        public void Edit(PatientFile entity)
        {
            _patientFileRepo.Edit(entity);
        }


        public PatientFile Get(long id)
        {
           return _patientFileRepo.GetEager(id);
        }

        public IEnumerable<PatientFile> GetAll()
        {
            return _patientFileRepo.GetAllEager();
        }

        public PatientFile GetPatientFile(Patient patient)
        {
            //TODO : mozda treba?
           return null;
        }

        public PatientFile Save(PatientFile entity)
        {
            return _patientFileRepo.Save(entity);
        }
    }
}