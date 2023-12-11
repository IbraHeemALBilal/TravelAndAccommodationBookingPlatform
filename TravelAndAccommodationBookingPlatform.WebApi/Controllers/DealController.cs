using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Services;

namespace TravelAndAccommodationBookingPlatform.WebApi.Controllers
{
    [Route("api/deals")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly IDealService _dealService;

        public DealController(IDealService dealService)
        {
            _dealService = dealService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateDeal([FromBody] DealDto dealDto)
        {
            try
            {
                await _dealService.CreateDealAsync(dealDto);
                return Ok("Deal created successfully");
            }
            catch (ArgumentException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateDeal action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
