using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Services;

namespace TravelAndAccommodationBookingPlatform.WebApi.Controllers
{
    [Route("api/deals")]
    [ApiController]
    [Authorize(Roles = "Admin")]
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
            await _dealService.CreateDealAsync(dealDto);
            return Ok("Deal created successfully");
        }
    }
}
