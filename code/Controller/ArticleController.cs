/***********************************************************************
 * Module:  ArticleService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ArticleService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class ArticleController : IArticleController
   {
        private readonly IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }

        public Article Save(Article entity)
        {
            return _service.Save(entity);
        }

        public void Delete(Article entity)
        {
            _service.Delete(entity);
        }

        public void Edit(Article entity)
        {
            _service.Edit(entity);
        }

        public Article Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _service.GetAll();
        }


        public List<Article> searchArticle(string criteria)
        {
            throw new NotImplementedException();
        }

    }
}