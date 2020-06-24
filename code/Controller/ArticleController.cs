using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class ArticleController : IArticleController
   {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService service)
        {
            _articleService = service;
        }

        public Article Save(Article entity)
        {
            return _articleService.Save(entity);
        }

        public void Delete(Article entity)
        {
            _articleService.Delete(entity);
        }

        public void Edit(Article entity)
        {
            _articleService.Edit(entity);
        }

        public Article Get(long id)
        {
            return _articleService.Get(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _articleService.GetAll();
        }
       //TODO: Tamara pretraga clanaka
        public List<Article> SearchArticle(string criteria)
        {
            throw new NotImplementedException();
        }

    }
}