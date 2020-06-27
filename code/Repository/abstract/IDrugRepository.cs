

using bolnica.Repository;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IDrugRepository : IRepository<Drug,long>, IEagerRepository<Drug,long>
   {

      List<Drug> GetNotApprovedDrugs();
   }
}