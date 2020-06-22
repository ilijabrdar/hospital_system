using Model.Doctor;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IArticleService : IService<Article, long>
    {
        List<Article> SearchArticle(String criteria);

        void DeleteArticlesByDoctor(Doctor doctor);
    }
}
