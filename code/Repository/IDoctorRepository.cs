/***********************************************************************
 * Module:  IDoctorRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IDoctorRepository
 ***********************************************************************/

using Model.Doctor;
using System;

namespace Repository
{
   public interface IDoctorRepository// : IRepository
   {
      Model.Users.Doctor[] GetDoctorsBySpeciality(Specialty specialty);
      Model.Users.Doctor GetDoctorByUsername(String username);
   }
}