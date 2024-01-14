using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using Microsoft.AspNetCore.Authorization;

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
            var hotelsDto = await _hotelService.GetAllHotelsAsync();
            return Ok(hotelsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotelDto = await _hotelService.GetHotelByIdAsync(id);

            if (hotelDto == null)
            {
                return NotFound();
            }

            return Ok(hotelDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateHotel([FromBody] HotelDto hotelDto)
        {
            await _hotelService.AddHotelAsync(hotelDto);
            return Ok(new { message = "Hotel Created successfully" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelDto hotelDto)
        {
            var updateResult = await _hotelService.UpdateHotelAsync(id, hotelDto);

            if (updateResult)
            {
                return Ok(new { message = "Hotel updated successfully" });
            }
            else
            {
                return NotFound(new { message = $"Hotel with ID {id} not found" });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var deletionResult = await _hotelService.DeleteHotelAsync(id);

            if (deletionResult)
            {
                return Ok(new { message = "Hotel deleted successfully" });
            }
            else
            {
                return NotFound(new { message = $"Hotel with ID {id} not found" });
            }
        }

        [HttpGet("filter")]
        [Authorize(Roles = "RegularUser")]
        public async Task<IActionResult> FilterHotels([FromQuery] HotelFilterBodyDto filterBody)
        {
            var filteredHotels = await _hotelService.FilterHotelsAsync(filterBody);
            return Ok(filteredHotels);
        }

        [HttpGet("deals")]
        [Authorize(Roles = "RegularUser")]
        public async Task<IActionResult> GetHotelsWithAvailableDeals()
        {
            var hotelsWithDealsDto = await _hotelService.GetHotelsWithAvailableDealsAsync();
            return Ok(hotelsWithDealsDto);
        }

        [HttpGet("visited-by-user/{userId}")]
        [Authorize(Roles = "RegularUser")]
        public async Task<IActionResult> GetVisitedHotelsByUser(int userId)
        {
            var visitedHotels = await _hotelService.GetVisitedHotelsByUserAsync(userId);
            return Ok(visitedHotels);
        }
    }
}
