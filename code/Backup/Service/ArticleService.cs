/***********************************************************************
 * Module:  ArticleService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ArticleService
 ***********************************************************************/

using System;

namespace Service
{
   public class ArticleService : IService
   {
      public Model.Doctor.Article[] SearchArticle(String criteria)
      {
         // TODO: implement
         return null;
      }
   
      private Repository.IArticleRepository _articleRepository;
   
   }
}