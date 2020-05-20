/***********************************************************************
 * Module:  PatientFile.cs
 * Author:  david
 * Purpose: Definition of the Class PatientSecretary.PatientFile
 ***********************************************************************/

using Model.Doctor;
using System;

namespace Model.PatientSecretary
{
   public class PatientFile
   {
      private System.Collections.ArrayList hospitalization;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetHospitalization()
      {
         if (hospitalization == null)
            hospitalization = new System.Collections.ArrayList();
         return hospitalization;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetHospitalization(System.Collections.ArrayList newHospitalization)
      {
         RemoveAllHospitalization();
         foreach (Hospitalization oHospitalization in newHospitalization)
            AddHospitalization(oHospitalization);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddHospitalization(Hospitalization newHospitalization)
      {
         if (newHospitalization == null)
            return;
         if (this.hospitalization == null)
            this.hospitalization = new System.Collections.ArrayList();
         if (!this.hospitalization.Contains(newHospitalization))
            this.hospitalization.Add(newHospitalization);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveHospitalization(Hospitalization oldHospitalization)
      {
         if (oldHospitalization == null)
            return;
         if (this.hospitalization != null)
            if (this.hospitalization.Contains(oldHospitalization))
               this.hospitalization.Remove(oldHospitalization);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllHospitalization()
      {
         if (hospitalization != null)
            hospitalization.Clear();
      }
      private System.Collections.ArrayList operation;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetOperation()
      {
         if (operation == null)
            operation = new System.Collections.ArrayList();
         return operation;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetOperation(System.Collections.ArrayList newOperation)
      {
         RemoveAllOperation();
         foreach (Operation oOperation in newOperation)
            AddOperation(oOperation);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddOperation(Operation newOperation)
      {
         if (newOperation == null)
            return;
         if (this.operation == null)
            this.operation = new System.Collections.ArrayList();
         if (!this.operation.Contains(newOperation))
         {
            this.operation.Add(newOperation);
            newOperation.SetPatientFile(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveOperation(Operation oldOperation)
      {
         if (oldOperation == null)
            return;
         if (this.operation != null)
            if (this.operation.Contains(oldOperation))
            {
               this.operation.Remove(oldOperation);
               oldOperation.SetPatientFile((Model.PatientSecretary.PatientFile)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllOperation()
      {
         if (operation != null)
         {
            System.Collections.ArrayList tmpOperation = new System.Collections.ArrayList();
            foreach (Operation oldOperation in operation)
               tmpOperation.Add(oldOperation);
            operation.Clear();
            foreach (Operation oldOperation in tmpOperation)
               oldOperation.SetPatientFile((Model.PatientSecretary.PatientFile)null);
            tmpOperation.Clear();
         }
      }
      private Model.Users.Person person;
      private System.Collections.ArrayList examination;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetExamination()
      {
         if (examination == null)
            examination = new System.Collections.ArrayList();
         return examination;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetExamination(System.Collections.ArrayList newExamination)
      {
         RemoveAllExamination();
         foreach (Examination oExamination in newExamination)
            AddExamination(oExamination);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddExamination(Examination newExamination)
      {
         if (newExamination == null)
            return;
         if (this.examination == null)
            this.examination = new System.Collections.ArrayList();
         if (!this.examination.Contains(newExamination))
            this.examination.Add(newExamination);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveExamination(Examination oldExamination)
      {
         if (oldExamination == null)
            return;
         if (this.examination != null)
            if (this.examination.Contains(oldExamination))
               this.examination.Remove(oldExamination);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllExamination()
      {
         if (examination != null)
            examination.Clear();
      }
      private Allergy[] allergy;
   
   }
}