using CMS.ModelLayer;

namespace CMS.ServiceLayer
{
    public class CategoryService : EntityService<Category>, ICategoryService
    {
        public CategoryService(CMSContext context) : base(context)
        {
        }
    }
}
