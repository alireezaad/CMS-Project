using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.ServiceLayer
{
    public class CategoryService : EntityService<Category>, ICategoryService
    {
        public CategoryService(CMSContext context) : base(context)
        {
        }
    }
}
