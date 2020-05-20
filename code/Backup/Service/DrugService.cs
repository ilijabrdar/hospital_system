/***********************************************************************
 * Module:  DrugService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DrugService
 ***********************************************************************/

using System;

namespace Service
{
   public class DrugService : IService
   {
      public Drug CreateDrugBasedOnDiagnosis(Diagnosis diagnosis, Examination examination)
      {
         // TODO: implement
         return null;
      }
      
      public Drug AddAlternativeDrug(Drug originalDrug, Drug alternativeDrug)
      {
         // TODO: implement
         return null;
      }
      
      public Drug ApproveDrug(Drug drug)
      {
         // TODO: implement
         return null;
      }
      
      public Drug[] GetAlternativeDrug(Drug drug)
      {
         // TODO: implement
         return null;
      }
      
      public Drug[] GetNotApproved()
      {
         // TODO: implement
         return null;
      }
   
      private IngredientService ingredientService;
      private Repository.IDrugRepository _drugRepository;
   
   }
}