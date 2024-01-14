using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using Microsoft.AspNetCore.Authorization;

namespace TravelAndAccommodationBookingPlatform.WebApi.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var roomsDto = await _roomService.GetAllRoomsAsync();
            return Ok(roomsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var roomDto = await _roomService.GetRoomByIdAsync(id);

            if (roomDto == null)
            {
                return NotFound();
            }

            return Ok(roomDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDto roomDto)
        {
            await _roomService.AddRoomAsync(roomDto);
            return Ok(new { message = "Room Created successfully" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomDto roomDto)
        {
            var updateResult = await _roomService.UpdateRoomAsync(id, roomDto);

            if (updateResult)
            {
                return Ok(new { message = "Room updated successfully" });
            }
            else
            {
                return NotFound(new { message = $"Room with ID {id} not found" });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var deletionResult = await _roomService.DeleteRoomAsync(id);

            if (deletionResult)
            {
                return Ok(new { message = "Room deleted successfully" });
            }
            else
            {
                return NotFound(new { message = $"Room with ID {id} not found" });
            }
        }
    }
}
