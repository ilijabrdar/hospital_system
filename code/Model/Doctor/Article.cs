/***********************************************************************
 * Module:  Article.cs
 * Author:  david
 * Purpose: Definition of the Class Model.Doctor.Article
 ***********************************************************************/

using Repository;
using System;

namespace Model.Doctor
{
   public class Article : IIdentifiable<long>
    {
      public DateTime DatePublished { get; set; }
      public String Topic { get; set; }
        public long Id { get; set; }
      public Article (long id, DateTime date, String tp)
        {
            this.Id = id;
            this.DatePublished = date;
            this.Topic = tp;
        }

        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}