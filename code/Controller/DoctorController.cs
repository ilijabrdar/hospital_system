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

        public bool CheckJMBGUnique(string JMBG)
        {
            return _doctorservice.CheckJMBGUnique(JMBG);
        }

        public void Delete(Doctor entity)
        {
            _doctorservice.Delete(entity);
        }

        public void Edit(Doctor entity)
        {
            _doctorservice.Edit(entity);
        }

        public Doctor Get(long id)
        {
            return _doctorservice.Get(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorservice.GetAll();
        }

        public List<Doctor> GetDoctorsBySpeciality(Speciality specialty)
        {
            return _doctorservice.GetDoctorsBySpeciality(specialty);
        }


        public DoctorGrade GiveGrade(DoctorGrade doctorGrade)
        {
            throw new NotImplementedException();
        }

        public Doctor Save(Doctor entity)
        {
            return _doctorservice.Save(entity);
        }
    }
}