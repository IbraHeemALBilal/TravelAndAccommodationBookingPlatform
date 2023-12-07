using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Application.Dto;

namespace TravelAndAccommodationBookingPlatform.WebApi.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelController(HotelService hotelService)
        {
            _hotelService = hotelService ?? throw new ArgumentNullException(nameof(hotelService));
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
        public async Task<IActionResult> AddHotel([FromBody] HotelDto hotelDto)
        {
            try
            {
                await _hotelService.AddHotelAsync(hotelDto);
                return Ok(hotelDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelDto hotelDto)
        {
            try
            {
                await _hotelService.UpdateHotelAsync(id, hotelDto);

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateCity: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error", message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                await _hotelService.DeleteHotelAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
