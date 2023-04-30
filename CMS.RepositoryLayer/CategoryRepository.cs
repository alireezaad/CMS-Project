using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.RepositoryLayer
{
    class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CMSContext context) : base(context)
        {
        }
    }
}
