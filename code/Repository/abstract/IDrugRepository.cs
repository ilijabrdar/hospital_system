/***********************************************************************
 * Module:  IDrugRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IDrugRepository
 ***********************************************************************/

using Model.PatientSecretary;
using System;

namespace Repository
{
   public interface IDrugRepository : IRepository<Drug,long>
   {
      Drug[] GetAlternative(Drug drug);
      Drug[] GetNotApproved();
   }
}