/***********************************************************************
 * Module:  PatientService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using bolnica.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class PatientRepository : CSVRepository<Patient,long> ,IPatientRepository
   {
      private String FilePath;
        public PatientRepository(ICSVStream<Patient> stream, ISequencer<long> sequencer)
            : base(stream, sequencer)
        {

        }


        public Patient GetPatientByJMBG(string jmbg)
        {
            List<Patient> patients = GetAll().ToList();
            foreach(Patient patient in patients){
                if (patient.Jmbg.Equals(jmbg))
                {
                    return patient;
                }
            }
            return null;
        }

        public Patient GetPatientByUsername(string username)
        {
            List<Patient> patients = GetAll().ToList();
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