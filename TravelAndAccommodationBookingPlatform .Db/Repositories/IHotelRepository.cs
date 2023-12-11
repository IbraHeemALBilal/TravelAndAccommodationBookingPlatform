using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(int id);
        Task AddAsync(Hotel entity);
        Task UpdateAsync(Hotel entity);
        Task DeleteAsync(Hotel entity);
        Task<List<Hotel>> GetAllWithRelatedDataAsync();
        Task<List<Hotel>> GetVisitedHotelsByUserAsync(int userId);
        Task<List<Hotel>> GetHotelsWithAvailableDealsAsync();

    }
}
