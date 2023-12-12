using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace TravelAndAccommodationBookingPlatform.WebApi.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    [Authorize]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var hotelsDto = await _hotelService.GetAllHotelsAsync();
                return Ok(hotelsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            try
            {
                var hotelDto = await _hotelService.GetHotelByIdAsync(id);
                if (hotelDto == null)
                {
                    return NotFound();
                }
                return Ok(hotelDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetHotelById: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateHotel([FromBody] HotelDto hotelDto)
        {
            try
            {
                await _hotelService.AddHotelAsync(hotelDto);
                return Ok(new { message = "Hotel Created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelDto hotelDto)
        {
            try
            {
                await _hotelService.UpdateHotelAsync(id, hotelDto);

                return Ok(new { message = "Hotel updated successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateCity: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error", message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                await _hotelService.DeleteHotelAsync(id);
                return Ok(new { message = "Hotel deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpGet("filter")]
        [Authorize(Roles = "RegularUser")]
        public async Task<IActionResult> FilterHotels([FromQuery] HotelFilterBodyDto filterBody)
        {
            try
            {
                var filteredHotels = await _hotelService.FilterHotelsAsync(filterBody);
                return Ok(filteredHotels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpGet("deals")]
        [Authorize(Roles = "RegularUser")]
        public async Task<IActionResult> GetHotelsWithAvailableDeals()
        {
            try
            {
                var hotelsWithDealsDto = await _hotelService.GetHotelsWithAvailableDealsAsync();
                return Ok(hotelsWithDealsDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetHotelsWithAvailableDeals action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("visited-by-user/{userId}")]
        [Authorize(Roles = "RegularUser")]
        public async Task<IActionResult> GetVisitedHotelsByUser(int userId)
        {
            try
            {
                var visitedHotels = await _hotelService.GetVisitedHotelsByUserAsync(userId);
                return Ok(visitedHotels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


    }
}
