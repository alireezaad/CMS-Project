using CMS.ModelLayer;

namespace CMS.RepositoryLayer
{
    class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CMSContext context) : base(context)
        {
        }
    }
}
