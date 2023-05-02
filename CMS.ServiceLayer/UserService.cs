using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.ServiceLayer
{
    public class UserService : EntityService<User>, IUserEntity
    {
        public UserService(CMSContext context) : base(context)
        {
        }
    }
}
