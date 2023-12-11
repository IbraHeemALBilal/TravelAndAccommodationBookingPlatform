using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Dto_Display;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public interface IHotelService
    {
        Task<List<HotelDisplayDto>> GetAllHotelsAsync();
        Task<HotelDisplayDto> GetHotelByIdAsync(int id);
        Task AddHotelAsync(HotelDto hotelDto);
        Task UpdateHotelAsync(int id, HotelDto hotelDto);
        Task DeleteHotelAsync(int id);
        Task<List<HotelDisplayDto>> FilterHotelsAsync(HotelFilterBodyDto filterBody);
        Task<List<HotelDisplayDto>> GetVisitedHotelsByUserAsync(int userId);
        Task<List<HotelDisplayDto>> GetHotelsWithAvailableDealsAsync();


    }
}
