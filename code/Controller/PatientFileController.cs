/***********************************************************************
 * Module:  PatientFileService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.PatientFileService
 ***********************************************************************/

using bolnica.Controller;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class PatientFileController : IPatientFileController
    {
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

        public Operation AddOperation(Operation operations, PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public void Delete(PatientFile entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAllergy(Allergy allergy, PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public void Edit(PatientFile entity)
        {
            throw new NotImplementedException();
        }

        public Allergy EditAllergy(Allergy allergy, PatientFile patientFile)
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
            throw new NotImplementedException();
        }
    }
}