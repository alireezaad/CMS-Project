using CMS.ModelLayer;
using CMS.RepositoryLayer;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.ServiceLayer
{
    public class UserService : EntityService<User>, IUserEntity
    {
        private UserRepository _UserRepo;
        public UserService(CMSContext context) : base(context)
        {
            _UserRepo = new UserRepository(context);
        }

        public async Task<int> GetAdminId(string PhoneNumber)
        {

            var tempList =await _UserRepo.GetAll();
            return  tempList.FirstOrDefault(a => a.Phonenumber == PhoneNumber).UserId;
        }
    }
}
