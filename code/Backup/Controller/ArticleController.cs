/***********************************************************************
 * Module:  ArticleService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ArticleService
 ***********************************************************************/

using System;

namespace Controller
{
   public class ArticleController : IController
   {
      public Model.Doctor.Article[] SearchArticle(String criteria)
      {
         // TODO: implement
         return null;
      }
   
      private Service.IService _service;
   
   }
}