/***********************************************************************
 * Module:  ArticleService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ArticleService
 ***********************************************************************/

using bolnica.Service;
using Model.Doctor;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class ArticleService : IArticleService
   {
       private IArticleRepository _repository;

        public ArticleService(IArticleRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Article entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(Article entity)
        {
            _repository.Edit(entity);
        }

        public Article Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _repository.GetAll();
        }

        public Article Save(Article entity)
        {
            return _repository.Save(entity);
        }

        public Article[] searchArticle(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}