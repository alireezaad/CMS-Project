using CMS.ModelLayer;
using System.Threading.Tasks;

namespace CMS.ServiceLayer
{
    public interface IUserEntity : IEntityService<User>
    {
        Task<int> GetAdminId(string PhoneNumber);

    }
}
