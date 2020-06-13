using Repository;
using System;

namespace Model.Doctor
{
   public class Article : IIdentifiable<long>
    {
        public long Id;
        public DateTime DatePublished;
        public Model.Users.Doctor Doctor;

        public String Topic;
        public String Text;

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