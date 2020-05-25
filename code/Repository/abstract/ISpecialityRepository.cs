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
   public interface ISpecialityRepository : IRepository<Specialty,long>, IGetterRepository<Specialty,long>
   {
      Specialty CreateSpeciality(Specialty speciality);
      Boolean DeleteSpeciality(Specialty speciality);
   }
}