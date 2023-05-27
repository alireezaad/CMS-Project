using CMS.ModelLayer;

namespace CMS.RepositoryLayer
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CMSContext context) : base(context)
        {
        }
    }
}
