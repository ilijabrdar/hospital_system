using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class PatientService : IPatientService
    {

        private readonly IPatientRepository _patientRepository;
        private readonly IPatientFileService _patientFileService;
        private readonly IDoctorGradeService _doctorGradeService;

        public PatientService(IPatientRepository _patientRepo, IPatientFileService _servicePatientFile, IDoctorGradeService doctorGradeService)
        {
            _doctorGradeService = doctorGradeService;
            _patientRepository = _patientRepo;
            _patientFileService = _servicePatientFile;
        }

        public PatientService(IPatientRepository _patientRepo, IPatientFileService _servicePatientFile)
        {
            _patientRepository = _patientRepo;
            _patientFileService = _servicePatientFile;
        }

        public Patient Save(Patient entity)
        {
            if (_patientRepository.GetUserByUsername(entity.Username) != null)
            {
                return null;
            }
            //TODO: skloniti -1 iz patFile
            entity.patientFile = _patientFileService.Save(new PatientFile(-1));
            return _patientRepository.Save(entity);

        }

        public void Delete(Patient entity)
        {
            _patientRepository.Delete(entity);
        }

        public void Edit(Patient entity)
        {
            _patientRepository.Edit(entity);
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient Get(long id)
        {
            throw new NotImplementedException();
        }

        public Patient ClaimAccount(String id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(String username)
        {
            return _patientRepository.GetUserByUsername(username);
        }

        public Patient GetPatientByJMBG(string jmbg)
        {
            return _patientRepository.GetPatientByJMBG(jmbg);
        }

        public DoctorGrade GiveGradeToDoctor(Doctor doctor, Dictionary<string, double> gradesForDoctor)
        {
            DoctorGrade doctorGrade = doctor.DoctorGrade;
            doctorGrade.NumberOfGrades++;
            foreach(String question in doctorGrade.GradesForEachQuestions.Keys)
            {
                doctorGrade.GradesForEachQuestions[question] = (doctorGrade.GradesForEachQuestions[question] +
                                                                gradesForDoctor[question]) / doctorGrade.NumberOfGrades;
            }

             _doctorGradeService.Edit(doctorGrade);

            return doctorGrade;
        }

    }
}
