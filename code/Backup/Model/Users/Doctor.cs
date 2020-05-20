/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Zorana
 * Purpose: Definition of the Class Users.Doctor
 ***********************************************************************/

using System;

namespace Model.Users
{
   public class Doctor : User
   {
      public System.Collections.ArrayList article;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetArticle()
      {
         if (article == null)
            article = new System.Collections.ArrayList();
         return article;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetArticle(System.Collections.ArrayList newArticle)
      {
         RemoveAllArticle();
         foreach (Article oArticle in newArticle)
            AddArticle(oArticle);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddArticle(Article newArticle)
      {
         if (newArticle == null)
            return;
         if (this.article == null)
            this.article = new System.Collections.ArrayList();
         if (!this.article.Contains(newArticle))
            this.article.Add(newArticle);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveArticle(Article oldArticle)
      {
         if (oldArticle == null)
            return;
         if (this.article != null)
            if (this.article.Contains(oldArticle))
               this.article.Remove(oldArticle);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllArticle()
      {
         if (article != null)
            article.Clear();
      }
   
      private String Id;
      
      private System.Collections.ArrayList businessDay;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetBusinessDay()
      {
         if (businessDay == null)
            businessDay = new System.Collections.ArrayList();
         return businessDay;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetBusinessDay(System.Collections.ArrayList newBusinessDay)
      {
         RemoveAllBusinessDay();
         foreach (BusinessDay oBusinessDay in newBusinessDay)
            AddBusinessDay(oBusinessDay);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddBusinessDay(BusinessDay newBusinessDay)
      {
         if (newBusinessDay == null)
            return;
         if (this.businessDay == null)
            this.businessDay = new System.Collections.ArrayList();
         if (!this.businessDay.Contains(newBusinessDay))
         {
            this.businessDay.Add(newBusinessDay);
            newBusinessDay.SetDoctor(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveBusinessDay(BusinessDay oldBusinessDay)
      {
         if (oldBusinessDay == null)
            return;
         if (this.businessDay != null)
            if (this.businessDay.Contains(oldBusinessDay))
            {
               this.businessDay.Remove(oldBusinessDay);
               oldBusinessDay.SetDoctor((Doctor)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllBusinessDay()
      {
         if (businessDay != null)
         {
            System.Collections.ArrayList tmpBusinessDay = new System.Collections.ArrayList();
            foreach (BusinessDay oldBusinessDay in businessDay)
               tmpBusinessDay.Add(oldBusinessDay);
            businessDay.Clear();
            foreach (BusinessDay oldBusinessDay in tmpBusinessDay)
               oldBusinessDay.SetDoctor((Doctor)null);
            tmpBusinessDay.Clear();
         }
      }
      private Specialty specialty;
      private DoctorGrade doctorGrade;
   
   }
}