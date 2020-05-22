/***********************************************************************
 * Module:  ISpecialityRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.ISpecialityRepository
 ***********************************************************************/

using System;

namespace Repository
{
   public interface ISpecialityRepository
   {
      Speciality CreateSpeciality(Speciality speciality);
      Boolean DeleteSpeciality(Speciality speciality);
   }
}