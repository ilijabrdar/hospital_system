/***********************************************************************
 * Module:  IOperationRepository.cs
 * Author:  Asus
 * Purpose: Definition of the Interface Repository.IOperationRepository
 ***********************************************************************/

using Model.Doctor;
using System;

namespace Repository
{
   public interface IOperationRepository : IRepository<Operation,long>
   {
   }
}