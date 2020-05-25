/***********************************************************************
 * Module:  IPatientRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IPatientRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.Users;
using System;

namespace Repository
{
   public interface IPatientRepository : IRepository<Patient, long>, IGetterRepository<Patient,long>
   {
      Patient GetPatientByJMBG(String jmbg);
      Patient GetPatientByUsername(String username);
   }
}