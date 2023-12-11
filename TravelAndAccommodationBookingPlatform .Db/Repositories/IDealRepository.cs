using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories
{
    public interface IDealRepository
    {
        Task AddAsync(Deal entity);
        Task<Deal> GetDealByRoomAndDateAsync(int roomId);
    }
}
