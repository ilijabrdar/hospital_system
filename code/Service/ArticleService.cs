using bolnica.Service;
using Model.Doctor;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class ArticleService : IArticleService
   {
       private readonly IArticleRepository _repository;

        public ArticleService(IArticleRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Article entity)
        {
            _repository.Delete(entity);
        }

        public void DeleteArticlesByDoctor(Doctor doctor)
        {
            foreach (Article article in GetAll())
                if (article.Doctor.Id == doctor.Id)
                    Delete(article);
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
            return _repository.GetAllEager();
        }

        public Article Save(Article entity)
        {
            return _repository.Save(entity);
        }

        public List<Article> SearchArticle(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}