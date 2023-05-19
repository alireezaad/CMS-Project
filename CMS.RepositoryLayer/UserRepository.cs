using CMS.ModelLayer;

namespace CMS.RepositoryLayer
{
    class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CMSContext context) : base(context)
        {
        }
    }
}
