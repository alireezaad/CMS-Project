using CMS.ModelLayer;
using CMS.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.ServiceLayer
{
    public class EntityService<T> : GenericRepository<T> where T : BaseEntity
    {
        public EntityService(CMSContext context) : base(context)
        {
        }
    }
}
