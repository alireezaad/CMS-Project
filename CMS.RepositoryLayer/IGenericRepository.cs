using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.RepositoryLayer
{
    public interface IGenericRepository<T>:IDisposable
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetEntity(int id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Delete(int id);
        void Save();
    }
}
