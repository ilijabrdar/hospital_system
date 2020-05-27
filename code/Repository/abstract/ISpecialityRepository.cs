/***********************************************************************
 * Module:  ISpecialityRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.ISpecialityRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.Doctor;
using System;

namespace Repository
{
   public interface ISpecialityRepository : IRepository<Speciality,long>
   {
      Speciality CreateSpeciality(Speciality speciality);
      Boolean DeleteSpeciality(Speciality speciality);
   }
}