using CMS.ModelLayer;

namespace CMS.ServiceLayer
{
    public class ArticleService : EntityService<Article>, IArticleService
    {
        public ArticleService(CMSContext context) : base(context)
        {
        }
    }
}
