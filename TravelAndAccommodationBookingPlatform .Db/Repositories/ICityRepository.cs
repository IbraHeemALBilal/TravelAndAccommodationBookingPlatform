using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync();
        Task<City> GetByIdAsync(int id);
        Task AddAsync(City entity);
        Task UpdateAsync(City entity);
        Task DeleteAsync(City entity);
        Task<List<City>>GetTrendingDestinationsAsync();
    }

}
