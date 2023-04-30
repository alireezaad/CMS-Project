using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.RepositoryLayer
{
    class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(CMSContext context) : base(context)
        {
        }
    }
}
