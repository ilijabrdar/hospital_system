
using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Controller
{
    public class PatientFileController : IPatientFileController
    {
        private readonly IPatientFileService _patientFileService;

        public PatientFileController(IPatientFileService patientFileService)
        {
            _patientFileService = patientFileService;
        }

        public Allergy AddAllergy(Allergy allergy, PatientFile patientFile)
        {
            return _patientFileService.AddAllergy(allergy, patientFile);
        }

        public Examination AddExamination(Examination examination, PatientFile patientFile)
        {
            return _patientFileService.AddExamination(examination, patientFile);
        }

        public Hospitalization AddHospitalization(Hospitalization hospitalization, PatientFile patientFile)
        {
            return _patientFileService.AddHospitalization(hospitalization, patientFile);
        }

        public Operation AddOperation(Operation operations, PatientFile patientFile)
        {
            return _patientFileService.AddOperation(operations, patientFile);
        }

        public void Delete(PatientFile entity)
        {
            _patientFileService.Delete(entity);
        }

        public bool DeleteAllergy(Allergy allergy, PatientFile patientFile)
        {
            return _patientFileService.DeleteAllergy(patientFile, allergy);
        }

        public void Edit(PatientFile entity)
        {
           _patientFileService.Edit(entity);
        }


        public PatientFile Get(long id)
        {
           return _patientFileService.Get(id);
        }

        public IEnumerable<PatientFile> GetAll()
        {
            return _patientFileService.GetAll();
        }

        public PatientFile GetPatientFile(Patient patient)
        {
            return _patientFileService.GetPatientFile(patient);
        }

        public PatientFile Save(PatientFile entity)
        {
            return _patientFileService.Save(entity);
        }
    }
}