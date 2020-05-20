/***********************************************************************
 * Module:  BusinessDay.cs
 * Author:  Zorana
 * Purpose: Definition of the Class Users.BusinessDay
 ***********************************************************************/

using System;

namespace Model.Users
{
   public class BusinessDay
   {
      private Model.PatientSecretary.Period Shift;
      
      private System.Collections.ArrayList period;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetPeriod()
      {
         if (period == null)
            period = new System.Collections.ArrayList();
         return period;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetPeriod(System.Collections.ArrayList newPeriod)
      {
         RemoveAllPeriod();
         foreach (Model.PatientSecretary.Period oPeriod in newPeriod)
            AddPeriod(oPeriod);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddPeriod(Model.PatientSecretary.Period newPeriod)
      {
         if (newPeriod == null)
            return;
         if (this.period == null)
            this.period = new System.Collections.ArrayList();
         if (!this.period.Contains(newPeriod))
            this.period.Add(newPeriod);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemovePeriod(Model.PatientSecretary.Period oldPeriod)
      {
         if (oldPeriod == null)
            return;
         if (this.period != null)
            if (this.period.Contains(oldPeriod))
               this.period.Remove(oldPeriod);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllPeriod()
      {
         if (period != null)
            period.Clear();
      }
      private Doctor doctor;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Doctor GetDoctor()
      {
         return doctor;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newDoctor</param>
      public void SetDoctor(Doctor newDoctor)
      {
         if (this.doctor != newDoctor)
         {
            if (this.doctor != null)
            {
               Doctor oldDoctor = this.doctor;
               this.doctor = null;
               oldDoctor.RemoveBusinessDay(this);
            }
            if (newDoctor != null)
            {
               this.doctor = newDoctor;
               this.doctor.AddBusinessDay(this);
            }
         }
      }
      private Model.Director.Room room;
   
   }
}