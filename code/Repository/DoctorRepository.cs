/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DoctorService
 ***********************************************************************/

using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using bolnica.Repository;
using System.Linq;

namespace Repository
{
   public class DoctorRepository : CSVRepository<Doctor, long>, IDoctorRepository
   {
        public DoctorRepository(ICSVStream<Doctor> stream, ISequencer<long> sequencer) : base(stream, sequencer) { }

        public Doctor GetDoctorByUsername(string username)
        {
            IEnumerable<Doctor> entities = this.GetAll();
            foreach (Doctor entity in entities)
            {
                if (entity.Username.Equals(username))
                    return entity;
            }
            return null;
        }

        public List<Doctor> GetDoctorsBySpeciality(Model.Doctor.Speciality specialty)
        {
            List<Doctor> doctors = this.GetAll().ToList();
            List<Doctor> retVal = new List<Doctor>();
            foreach(Doctor doct in doctors)
            {
                if (doct.Specialty.Equals(specialty))
                    retVal.Add(doct);
            }
            return retVal;
        }
    }
}