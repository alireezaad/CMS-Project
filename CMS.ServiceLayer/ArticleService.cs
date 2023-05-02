using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.ServiceLayer
{
    public class ArticleService : EntityService<Article>, IArticleService
    {
        public ArticleService(CMSContext context) : base(context)
        {
        }
    }
}
