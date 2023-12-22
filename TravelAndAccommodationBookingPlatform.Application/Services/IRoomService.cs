using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Dto_Display;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public interface IRoomService
    {
        Task<List<RoomDisplayDto>> GetAllRoomsAsync();
        Task<RoomDisplayDto> GetRoomByIdAsync(int id);
        Task AddRoomAsync(RoomDto roomDto);
        Task<bool> UpdateRoomAsync(int id, RoomDto roomDto);
        Task<bool> DeleteRoomAsync(int id);
    }
}
