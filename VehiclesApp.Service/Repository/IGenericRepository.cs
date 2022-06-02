using Microsoft.EntityFrameworkCore;

namespace VehiclesApp.Service.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetVehicleAsync(int id);
        DbSet<T> GetVehiclesAsync();
        Task AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
