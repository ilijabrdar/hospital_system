/***********************************************************************
 * Module:  DrugService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DrugService
 ***********************************************************************/

using Model.PatientSecretary;
using System;

namespace Repository
{
   public class DrugRepository : IDrugRepository
   {
      private String FilePath;

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public Drug[] GetAlternative(Drug drug)
        {
            throw new NotImplementedException();
        }

        public Drug[] GetNotApproved()
        {
            throw new NotImplementedException();
        }

        public object Save()
        {
            throw new NotImplementedException();
        }
    }
}