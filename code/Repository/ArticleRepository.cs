using bolnica.Repository;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ArticleRepository : CSVRepository<Article, long>, IArticleRepository
    {
        public IDoctorRepository _doctorRepository;
        public ArticleRepository(ICSVStream<Article> stream, ISequencer<long> sequencer)
             : base(stream, sequencer)
        {
        }

        public IEnumerable<Article> GetAllEager()
        {
            List<Article> articles = new List<Article>();
            foreach(Article article in GetAll().ToList())
            {
                articles.Add(GetEager(article.GetId()));
            }
            return articles;
        }

        public Article GetEager(long id)
        {
            Article article = Get(id);
            article.Doctor = _doctorRepository.GetEager(article.Doctor.GetId());

            return article;
        }
    }
}