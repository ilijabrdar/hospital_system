

using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class PatientController : IPatientController
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public Patient ClaimAccount(String jmbg)
        {
            return _patientService.ClaimAccount(jmbg);
        }

        public void Delete(Patient entity)
        {
            _patientService.Delete(entity);
        }

        public void Edit(Patient entity)
        {
            _patientService.Edit(entity);
        }

        public Patient Get(long id)
        {
            return _patientService.Get(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientService.GetAll();
        }

        public Patient GetPatientByJMBG(string jmbg)
        {
            return _patientService.GetPatientByJMBG(jmbg);
        }

        public DoctorGrade GiveGrade(Doctor doctor, Dictionary<string, double> gradesForDoctor)
        {
            return _patientService.GiveGrade(doctor, gradesForDoctor);
        }

        public Patient Save(Patient entity)
        {
            return _patientService.Save(entity);
        }
    }
}