using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Services;

namespace TravelAndAccommodationBookingPlatform.WebApi.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
        {
            try
            {
                bool result = await _bookingService.CreateBookingAsync(bookingDto);

                if (result)
                {
                    return Ok(new { message = "Booking Created successfully" });
                }
                else
                {
                    return Conflict("Booking conflict detected. Cannot create the booking."); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
