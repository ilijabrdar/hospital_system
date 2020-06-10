using bolnica.Repository;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class ArticleRepository : CSVRepository<Article, long>, IArticleRepository
    {
        private String FilePath;
        public ArticleRepository(ICSVStream<Article> stream, ISequencer<long> sequencer)
             : base(stream, sequencer)
        {
            
        }

        public IEnumerable<Article> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Article GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}