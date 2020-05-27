/***********************************************************************
 * Module:  IPatientFileRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IPatientFileRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.PatientSecretary;
using System;

namespace Repository
{
   public interface IPatientFileRepository : IRepository<PatientFile, long>
   {
   }
}