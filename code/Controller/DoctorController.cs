/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DoctorService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DoctorController : IDoctorController
    {

        private readonly IDoctorService _doctorservice;
        public DoctorController(IDoctorService service)
        {
            _doctorservice = service;
        }
        public bool ChangeSpeciality(Specialty speciality, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public Doctor Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorsBySpeciality(Specialty specialty)
        {
            return _doctorservice.GetDoctorsBySpeciality(specialty);
        }

        public DoctorGrade GiveGrade(DoctorGrade doctorGrade)
        {
            throw new NotImplementedException();
        }

        public Doctor Save(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}