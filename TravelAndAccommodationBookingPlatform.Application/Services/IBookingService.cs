using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public interface IBookingService
    {
        Task<bool> CreateBookingAsync(BookingDto bookingDto);
        Task<decimal> CalculateTotalPriceAsync(int roomId, DateTime checkInDate, DateTime checkOutDate);
        Task<bool> CheckForBookingConflictAsync(BookingDto bookingDto);

    }
}
