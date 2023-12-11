using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Dto_Display;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public interface ICityService
    {
        Task<List<CityDisplayDto>> GetAllCitiesAsync();
        Task<CityDisplayDto> GetCityByIdAsync(int id);
        Task AddCityAsync(CityDto cityDto);
        Task UpdateCityAsync(int id, CityDto cityUpdateDto);
        Task DeleteCityAsync(int id);
        Task<List<CityDisplayDto>>GetTrendingDestinationsAsync();
    }
}
