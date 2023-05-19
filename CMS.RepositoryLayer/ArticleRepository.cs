using CMS.ModelLayer;

namespace CMS.RepositoryLayer
{
    class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(CMSContext context) : base(context)
        {
        }
    }
}
