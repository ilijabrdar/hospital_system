/***********************************************************************
 * Module:  ArticleService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ArticleService
 ***********************************************************************/

using System;

namespace Service
{
   public class ArticleService// : IService
   {
      public Model.Doctor.Article[] SearchArticle(String criteria)
      {
         // TODO: implement
         return null;
      }

        public object Save()
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        private Repository.IArticleRepository _articleRepository;
   
   }
}