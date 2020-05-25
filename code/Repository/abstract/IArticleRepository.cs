/***********************************************************************
 * Module:  IArticleRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IArticleRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.Doctor;
using System;

namespace Repository
{
   public interface IArticleRepository : IRepository<Article, long>, IGetterRepository<Article,long>
   {

   }
}