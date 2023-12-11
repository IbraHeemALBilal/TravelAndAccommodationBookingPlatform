using AutoMapper;
using Microsoft.Extensions.Logging; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using TravelAndAccommodationBookingPlatform.Application.Dto_Display;
using TravelAndAccommodationBookingPlatform.Application.Dto;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public class RoomService:IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<IRoomRepository> _logger; 

        public RoomService(IRoomRepository roomRepository, IMapper mapper, ILogger<IRoomRepository> logger)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<RoomDisplayDto>> GetAllRoomsAsync()
        {
            try
            {
                var rooms = await _roomRepository.GetAllAsync();
                return _mapper.Map<List<RoomDisplayDto>>(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllRoomsAsync: {ex.Message}");
                return new List<RoomDisplayDto>();
            }
        }

        public async Task<RoomDisplayDto> GetRoomByIdAsync(int id)
        {
            try
            {
                var room = await _roomRepository.GetByIdAsync(id);
                return _mapper.Map<RoomDisplayDto>(room);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetRoomByIdAsync: {ex.Message}");
                return null;
            }
        }

        public async Task AddRoomAsync(RoomDto roomDto)
        {
            try
            {
                var roomEntity = _mapper.Map<Room>(roomDto);
                await _roomRepository.AddAsync(roomEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddRoomAsync: {ex.Message}");
            }
        }

        public async Task UpdateRoomAsync(int id, RoomDto roomDto)
        {
            try
            {
                var existingRoom = await _roomRepository.GetByIdAsync(id);

                if (existingRoom == null)
                {
                    throw new InvalidOperationException($"Room with ID {id} not found");
                }
                roomDto.ModifiedAt= DateTime.Now;
                _mapper.Map(roomDto, existingRoom);

                await _roomRepository.UpdateAsync(existingRoom);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateRoomAsync: {ex.Message}");
            }
        }

        public async Task DeleteRoomAsync(int id)
        {
            try
            {
                var roomToDelete = await _roomRepository.GetByIdAsync(id);
                if (roomToDelete != null)
                {
                    await _roomRepository.DeleteAsync(roomToDelete);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteRoomAsync: {ex.Message}");
            }
        }
    }
}
