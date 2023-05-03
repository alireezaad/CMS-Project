using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.ModelLayer;


namespace CMS.RepositoryLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        CMSContext db;
        DbSet<T> dbContext;

        public GenericRepository(CMSContext context)
        {
            db = context;
            dbContext = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbContext.ToListAsync();
        }

        public async Task<T> GetEntity(int id)
        {
            return await dbContext.FindAsync(id);
        }
        public Task<bool> Add(T entity)
        {
            try
            {
                dbContext.Add(entity);
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }

        public Task<bool> Update(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }
        public Task<bool> Delete(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Deleted;
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                T entity = await GetEntity(id);
                db.Entry(entity).State = EntityState.Deleted;
                return  true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
