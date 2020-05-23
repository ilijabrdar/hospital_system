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
                if (entity.Username == username)
                    return entity;
            }
            return null;
        }

        public Doctor[] GetDoctorsBySpeciality(Specialty specialty)
        {
            throw new NotImplementedException();
        }
    }
}