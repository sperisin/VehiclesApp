using Microsoft.EntityFrameworkCore;
using VehiclesApp.Service.Models;

namespace VehiclesApp.Service.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await appDbContext.AddAsync(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (entity != null)
            {
                appDbContext.Remove(entity);
                await appDbContext.SaveChangesAsync();
            }
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            var entityTemp = appDbContext.Attach(entity);
            entityTemp.State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> GetVehicleAsync(int id)
        {
            return await appDbContext.Set<T>().FindAsync(id);
        }
        public DbSet<T> GetVehiclesAsync()
        {
            return appDbContext.Set<T>();
        }
    }
}
