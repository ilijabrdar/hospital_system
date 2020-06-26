using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Doctor;
using Model.PatientSecretary;

namespace bolnica.Controller.decorators
{
    public class AuthorityArticleDecorator : IArticleController
    {
        private IArticleController ArticleController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;
        public AuthorityArticleDecorator(IArticleController articleController, string role)
        {
            ArticleController = articleController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Director", "Doctor" };
            AuthorizedUsers["Edit"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Get"] = new List<String>() { "Director", "Doctor", "Secretary", "Patient" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Director", "Doctor", "Secretary", "Patient" };
            AuthorizedUsers["Save"] = new List<String>() { "Doctor" };
            AuthorizedUsers["SearchArticle"] = new List<String>() { "Director", "Doctor", "Secretary", "Patient" };
        }

        public void Delete(Article entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                ArticleController.Delete(entity);
        }

        public void Edit(Article entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                ArticleController.Edit(entity);
        }

        public Article Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return ArticleController.Get(id);
            else
                return null;
        }

        public IEnumerable<Article> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return ArticleController.GetAll();
            else
                return null;
        }

        public Article Save(Article entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return ArticleController.Save(entity);
            else
                return null;
        }

        public List<Article> SearchArticle(string criteria)
        {
            if (AuthorizedUsers["SearchArticle"].SingleOrDefault(x => x == Role) != null)
                return ArticleController.SearchArticle(criteria);
            else
                return null;
        }
    }
}