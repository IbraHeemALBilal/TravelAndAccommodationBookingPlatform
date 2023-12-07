using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Application.Dto;

using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using TravelAndAccommodationBookingPlatform.Db.Repositories;

namespace TravelAndAccommodationBookingPlatform.WebApi.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService, IMapper mapper)
        {
            _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var cities = await _cityService.GetAllCitiesAsync();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            try
            {
                var city = await _cityService.GetCityByIdAsync(id);
                if (city == null)
                {
                    return NotFound(); 
                }
                return Ok(city);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] CityDto cityDto)
        {
            try
            {
                await _cityService.AddCityAsync(cityDto);
                return Ok(cityDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] CityDto cityUpdateDto)
        {
            try
            {
                await _cityService.UpdateCityAsync(id, cityUpdateDto);

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateCity: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error", message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                await _cityService.DeleteCityAsync(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}