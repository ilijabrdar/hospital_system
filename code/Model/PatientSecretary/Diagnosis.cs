/***********************************************************************
 * Module:  Dijagnoza.cs
 * Author:  Tamara Kovacevic
 * Purpose: Definition of the Class Pacijent.Dijagnoza
 ***********************************************************************/

using System;

namespace Model.PatientSecretary
{
   public class Diagnosis
   {
      private String Code;
      
      private System.Collections.ArrayList symptom;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetSymptom()
      {
         if (symptom == null)
            symptom = new System.Collections.ArrayList();
         return symptom;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetSymptom(System.Collections.ArrayList newSymptom)
      {
         RemoveAllSymptom();
         foreach (Symptom oSymptom in newSymptom)
            AddSymptom(oSymptom);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddSymptom(Symptom newSymptom)
      {
         if (newSymptom == null)
            return;
         if (this.symptom == null)
            this.symptom = new System.Collections.ArrayList();
         if (!this.symptom.Contains(newSymptom))
            this.symptom.Add(newSymptom);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveSymptom(Symptom oldSymptom)
      {
         if (oldSymptom == null)
            return;
         if (this.symptom != null)
            if (this.symptom.Contains(oldSymptom))
               this.symptom.Remove(oldSymptom);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllSymptom()
      {
         if (symptom != null)
            symptom.Clear();
      }
   
   }
}