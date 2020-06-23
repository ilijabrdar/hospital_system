using bolnica.Repository;
using Model.Doctor;
using System;

namespace Repository
{
   public interface IArticleRepository : IRepository<Article, long>, IEagerRepository<Article, long>
   {
   }
}