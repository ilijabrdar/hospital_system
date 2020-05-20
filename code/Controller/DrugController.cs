/***********************************************************************
 * Module:  DrugService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DrugService
 ***********************************************************************/

using Model.PatientSecretary;
using System;

namespace Controller
{
   public class DrugController : IController
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
   
      public System.Collections.ArrayList iService;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetIService()
      {
         if (iService == null)
            iService = new System.Collections.ArrayList();
         return iService;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetIService(System.Collections.ArrayList newIService)
      {
         RemoveAllIService();
         foreach (Service.IService oIService in newIService)
            AddIService(oIService);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddIService(Service.IService newIService)
      {
         if (newIService == null)
            return;
         if (this.iService == null)
            this.iService = new System.Collections.ArrayList();
         if (!this.iService.Contains(newIService))
            this.iService.Add(newIService);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveIService(Service.IService oldIService)
      {
         if (oldIService == null)
            return;
         if (this.iService != null)
            if (this.iService.Contains(oldIService))
               this.iService.Remove(oldIService);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllIService()
      {
         if (iService != null)
            iService.Clear();
      }

        public object Save()
        {
            throw new NotImplementedException();
        }

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
    }
}