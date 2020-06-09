/***********************************************************************
 * Module:  PatientService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class PatientRepository : CSVRepository<Patient,long> ,IPatientRepository, IEagerRepository<Patient,long>
   {
      private String FilePath;
        private readonly IEagerRepository<PatientFile, long> patientFleRepository;
        public PatientRepository(ICSVStream<Patient> stream, ISequencer<long> sequencer, IEagerRepository<PatientFile,long> patientFile)
            : base(stream, sequencer)
        {
            patientFleRepository = patientFile;
        }

        public IEnumerable<Patient> GetAllEager()
        {
            List<Patient> patients = new List<Patient>();
            foreach(Patient patient in GetAll().ToList())
            {
                patient.patientFile = patientFleRepository.GetEager(patient.patientFile.GetId());
                patients.Add(patient);
            }

            return patients;
        }

        public Patient GetEager(long id)
        {
            Patient patient = Get(id);
            PatientFile patientfile = patientFleRepository.GetEager(patient.patientFile.GetId());
            patient.patientFile = patientfile;
            return patient;

        }

        public Patient GetPatientByJMBG(string jmbg)
        {
            List<Patient> patients = GetAllEager().ToList();
            foreach(Patient patient in patients){
                if (patient.Jmbg.Equals(jmbg))
                {
                    return patient;
                }
            }
            return null;
        }

        public User GetUserByUsername(string username)
        {
            List<Patient> patients = GetAllEager().ToList();
            foreach (Patient patient in patients)
            {
                if (patient.Username.Equals(username))
                {
                    return patient;
                }
            }
            return null;
        }

    }
}