using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndAccommodationBookingPlatform.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}
