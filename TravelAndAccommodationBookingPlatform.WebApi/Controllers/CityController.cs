using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using Microsoft.AspNetCore.Authorization;

namespace TravelAndAccommodationBookingPlatform.WebApi.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCity([FromBody] CityDto cityDto)
        {
            await _cityService.AddCityAsync(cityDto);
            return Ok(new { message = "City Created successfully" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] CityDto cityDto)
        {
            var updateResult = await _cityService.UpdateCityAsync(id, cityDto);

            if (updateResult)
            {
                return Ok(new { message = "City updated successfully" });
            }
            else
            {
                return NotFound(new { message = $"City with ID {id} not found" });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var deletionResult = await _cityService.DeleteCityAsync(id);

            if (deletionResult)
            {
                return Ok(new { message = "City deleted successfully" });
            }
            else
            {
                return NotFound(new { message = $"City with ID {id} not found" });
            }
        }

        [HttpGet("trending")]
        [Authorize(Roles = "RegularUser")]
        public async Task<IActionResult> GetTrendingDestinations()
        {
            var trendingCities = await _cityService.GetTrendingDestinationsAsync();

            if (trendingCities.Any())
            {
                return Ok(trendingCities);
            }

            return NotFound();
        }
    }
}
