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
       private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository repository)
        {
            _articleRepository = repository;
        }

        public void Delete(Article entity)
        {
            _articleRepository.Delete(entity);
        }

        public void DeleteArticlesByDoctor(Doctor doctor)
        {
            foreach (Article article in GetAll())
                if (article.Doctor.Id == doctor.Id)
                    Delete(article);
        }

        public void Edit(Article entity)
        {
            _articleRepository.Edit(entity);
        }

        public Article Get(long id)
        {
            return _articleRepository.Get(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _articleRepository.GetAllEager();
        }

        public Article Save(Article entity)
        {
            return _articleRepository.Save(entity);
        }

        public List<Article> SearchArticle(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}