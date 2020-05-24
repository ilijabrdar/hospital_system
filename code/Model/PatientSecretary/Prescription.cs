/***********************************************************************
 * Module:  Recept.cs
 * Author:  Tamara Kovacevic
 * Purpose: Definition of the Class Pacijent.Recept
 ***********************************************************************/

using Repository;
using System;

namespace Model.PatientSecretary
{
   public class Prescription: IIdentifiable<long>
   {
      private DateTime DateOfIssue;
      private DateTime ExpirationDate;
      private String Note;
      public long Id;
      private System.Collections.ArrayList drug;

        public Prescription(DateTime dateOfIssue, DateTime expirationDate, string note, long id, System.Collections.ArrayList alternative)
        {
            DateOfIssue = dateOfIssue;
            ExpirationDate = expirationDate;
            Note = note;
            Id = id;
            this.drug = alternative;
        }

        public Prescription(long id)
        {
            Id = id;
        }



        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetDrug()
      {
         if (drug == null)
            drug = new System.Collections.ArrayList();
         return drug;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetDrug(System.Collections.ArrayList newDrug)
      {
         RemoveAllDrug();
         foreach (Drug oDrug in newDrug)
            AddDrug(oDrug);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddDrug(Drug newDrug)
      {
         if (newDrug == null)
            return;
         if (this.drug == null)
            this.drug = new System.Collections.ArrayList();
         if (!this.drug.Contains(newDrug))
            this.drug.Add(newDrug);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveDrug(Drug oldDrug)
      {
         if (oldDrug == null)
            return;
         if (this.drug != null)
            if (this.drug.Contains(oldDrug))
               this.drug.Remove(oldDrug);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllDrug()
      {
         if (drug != null)
            drug.Clear();
      }

        public long GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(long id)
        {
            throw new NotImplementedException();
        }
    }
}