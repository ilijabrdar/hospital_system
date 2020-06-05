/***********************************************************************
 * Module:  ISpecialityRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.ISpecialityRepository
 ***********************************************************************/

using Model.Doctor;
using System;

namespace Repository
{
   public interface ISpecialityRepository : IRepository<Speciality,long>
   {
    }
}