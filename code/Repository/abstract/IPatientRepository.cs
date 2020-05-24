/***********************************************************************
 * Module:  IPatientRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IPatientRepository
 ***********************************************************************/

using Model.Users;
using System;

namespace Repository
{
   public interface IPatientRepository : IRepository<Patient, long>
   {
      Patient GetPatientByJMBG(String jmbg);
      Patient GetPatientByUsername(String username);
   }
}