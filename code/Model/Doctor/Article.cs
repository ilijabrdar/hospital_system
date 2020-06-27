using Repository;
using System;

namespace Model.Doctor
{
   public class Article : IIdentifiable<long>
    {
        public long Id;
        public DateTime DatePublished { get; set; }
        public Model.Users.Doctor Doctor { get; set; }
        public String Topic { get; set; }
        public String Text { get; set; }

    public Article(long id, DateTime datePublished, Users.Doctor doctor, string topic, string text) : this(id)
        {
            DatePublished = datePublished;
            Doctor = doctor;
            Topic = topic;
            Text = text;
        }

        public Article(DateTime datePublished, Users.Doctor doctor, string topic, string text)
        {
            DatePublished = datePublished;
            Doctor = doctor;
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