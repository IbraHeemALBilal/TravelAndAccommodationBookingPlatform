using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public interface IDealService
    {
        Task CreateDealAsync(DealDto dealDto);
        Task<bool> DealExistsForRoomAsync(int roomId, DateTime startDate, DateTime endDate);
    }
}
