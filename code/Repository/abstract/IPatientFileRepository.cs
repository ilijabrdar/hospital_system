/***********************************************************************
 * Module:  IPatientFileRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IPatientFileRepository
 ***********************************************************************/

using Model.PatientSecretary;
using System;

namespace Repository
{
   public interface IPatientFileRepository : IRepository<PatientFile, long>
   {
   }
}