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
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
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
        public async Task<IActionResult> CraeateCity([FromBody] CityDto cityDto)
        {
            try
            {
                await _cityService.AddCityAsync(cityDto);
                return Ok(new { message = "City Created successfully" });
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

                return Ok(new { message = "City updated successfully" });
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
                return Ok(new { message = "City deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpGet("trending")]
        public async Task<IActionResult> GetTrendingDestinations()
        {
            try
            {
                var trendingCities = await _cityService.GetTrendingDestinationsAsync();

                if (trendingCities.Any())
                {
                    return Ok(trendingCities);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

    }
}