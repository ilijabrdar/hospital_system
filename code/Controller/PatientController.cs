/***********************************************************************
 * Module:  PatientService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using Model.Users;
using System;

namespace Controller
{
   public class PatientController : IController
   {
      public Patient ClaimAccount(String jmbg)
      {
         // TODO: implement
         return null;
      }
   
      private System.Collections.ArrayList _service;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList Get_service()
      {
         if (_service == null)
            _service = new System.Collections.ArrayList();
         return _service;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void Set_service(System.Collections.ArrayList new_service)
      {
         RemoveAll_service();
         foreach (Service.IService oIService in new_service)
            Add_service(oIService);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void Add_service(Service.IService newIService)
      {
         if (newIService == null)
            return;
         if (this._service == null)
            this._service = new System.Collections.ArrayList();
         if (!this._service.Contains(newIService))
            this._service.Add(newIService);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void Remove_service(Service.IService oldIService)
      {
         if (oldIService == null)
            return;
         if (this._service != null)
            if (this._service.Contains(oldIService))
               this._service.Remove(oldIService);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAll_service()
      {
         if (_service != null)
            _service.Clear();
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