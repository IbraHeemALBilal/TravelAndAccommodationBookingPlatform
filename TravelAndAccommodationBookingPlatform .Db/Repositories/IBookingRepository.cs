using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories
{
    public interface IBookingRepository
    {
        Task AddAsync(Booking entity);
        Task<List<Booking>> GetBookingsForRoomAsync(int roomId);
    }
}
