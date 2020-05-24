/***********************************************************************
 * Module:  IHospitalizationRepository.cs
 * Author:  Asus
 * Purpose: Definition of the Interface Repository.IHospitalizationRepository
 ***********************************************************************/

using Model.Doctor;
using System;

namespace Repository
{
   public interface IHospitalizationRepository : IRepository<Hospitalization, long>
   {
   }
}