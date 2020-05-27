/***********************************************************************
 * Module:  ArticleService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ArticleService
 ***********************************************************************/

using bolnica.Repository;
using Model.Doctor;
using System;

namespace Repository
{
   public class ArticleRepository : CSVRepository<Article,long>, IArticleRepository
   {
      private String FilePath;

        public ArticleRepository(ICSVStream<Article> stream, ISequencer<long> sequencer)
             : base(stream, sequencer)
        {
            
        }

     
    }
}