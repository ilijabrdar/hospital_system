using Repository;
using System;

namespace Model.Doctor
{
   public class Article : IIdentifiable<long>
    {
        public long Id;
        public DateTime DatePublished;
        public String Topic;
        public String Text;

      public Article (long id, DateTime date, String topic, String txt)
        {
            this.Id = id;
            this.DatePublished = date;
            this.Topic = topic;
            this.Text = txt;
        }

        public Article(DateTime datePublished, string topic, string text)
        {
            DatePublished = datePublished;
            Topic = topic;
            Text = text;
        }

        public Article (long id)
        {
            this.Id = id;
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