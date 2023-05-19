using CMS.ModelLayer;

namespace CMS.ServiceLayer
{
    public class UserService : EntityService<User>, IUserEntity
    {
        public UserService(CMSContext context) : base(context)
        {
        }
    }
}
