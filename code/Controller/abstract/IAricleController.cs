using Controller;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IArticleController :IController<Article,long>
    {
        List<Article> SearchArticle(String criteria);
    }
}
