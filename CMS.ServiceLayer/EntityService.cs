using CMS.ModelLayer;
using CMS.RepositoryLayer;

namespace CMS.ServiceLayer
{
    public class EntityService<T> : GenericRepository<T> where T : BaseEntity
    {
        public EntityService(CMSContext context) : base(context)
        {
        }
    }
}
