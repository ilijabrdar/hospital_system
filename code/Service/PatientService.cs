using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return _patientRepository.GetAllEager();
        }

        public Patient Get(long id)
        {
            return _patientRepository.GetEager(id);
        }

        public Patient ClaimAccount(Patient patient)
        {
            if (GetUserByUsername(patient.Username) == null)
            {
                if (!patient.Phone.Equals("") && !patient.Email.Equals(""))
                {
                    patient.Guest = false;
                    Edit(patient);
                    return _patientRepository.GetEager(patient.GetId());
                }
            }
            return null;
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
            foreach(String question in doctorGrade.GradesForEachQuestions.Keys.ToList())
            {
                doctorGrade.GradesForEachQuestions[question] = (doctorGrade.GradesForEachQuestions[question]*(doctorGrade.NumberOfGrades-1) +
                                                                gradesForDoctor[question]) / doctorGrade.NumberOfGrades;
            }

             _doctorGradeService.Edit(doctorGrade);

            return doctorGrade;
        }

    }
}
