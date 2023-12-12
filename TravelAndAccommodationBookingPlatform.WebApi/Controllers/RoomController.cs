using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Dto_Display;
using Microsoft.AspNetCore.Authorization;
using System.Data;


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
            try
            {
                var roomsDto = await _roomService.GetAllRoomsAsync();
                return Ok(roomsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            try
            {
                var roomDto = await _roomService.GetRoomByIdAsync(id);
                if (roomDto == null)
                {
                    return NotFound();
                }
                return Ok(roomDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDto roomDto)
        {
            try
            {
                await _roomService.AddRoomAsync(roomDto);
                return Ok(new { message = "Room Created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomDto roomDto)
        {
            try
            {
                await _roomService.UpdateRoomAsync(id,roomDto);
                return Ok(new { message = "Room updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                await _roomService.DeleteRoomAsync(id);
                return Ok(new { message = "Room deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

    }
}