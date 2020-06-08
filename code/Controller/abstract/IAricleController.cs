using Controller;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    interface IArticleController :IController<Article,long>
    {
        List<Article> searchArticle(String criteria);
    }
}
