using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.RepositoryLayer
{
    class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CMSContext context) : base(context)
        {
        }
    }
}
