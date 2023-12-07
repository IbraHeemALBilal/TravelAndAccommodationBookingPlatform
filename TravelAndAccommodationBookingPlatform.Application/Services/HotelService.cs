using AutoMapper;
using Microsoft.Extensions.Logging; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Dto_Display;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public class HotelService
    {
        private readonly HotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<HotelService> _logger; 

        public HotelService(HotelRepository hotelRepository, IMapper mapper, ILogger<HotelService> logger)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<HotelDisplayDto>> GetAllHotelsAsync()
        {
            try
            {
                var hotels = await _hotelRepository.GetAllAsync();
                return _mapper.Map<List<HotelDisplayDto>>(hotels);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllHotelsAsync: {ex.Message}");
                return new List<HotelDisplayDto>();
            }
        }

        public async Task<HotelDisplayDto> GetHotelByIdAsync(int id)
        {
            try
            {
                var hotel = await _hotelRepository.GetByIdAsync(id);
                return _mapper.Map<HotelDisplayDto>(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetHotelByIdAsync: {ex.Message}");
                return null;
            }
        }

        public async Task AddHotelAsync(HotelDto hotelDto)
        {
            try
            {
                var hotelEntity = _mapper.Map<Hotel>(hotelDto);
                await _hotelRepository.AddAsync(hotelEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddHotelAsync: {ex.Message}");
            }
        }

        public async Task UpdateHotelAsync(int id, HotelDto hotelDto)
        {
            try
            {
                var existingHotel = await _hotelRepository.GetByIdAsync(id);

                if (existingHotel == null)
                {
                    throw new InvalidOperationException($"Hotel with ID {id} not found");
                }
                hotelDto.ModifiedAt=DateTime.Now;
                _mapper.Map(hotelDto, existingHotel);

                await _hotelRepository.UpdateAsync(existingHotel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateHotelAsync: {ex.Message}");
            }
        }

        public async Task DeleteHotelAsync(int id)
        {
            try
            {
                var hotelToDelete = await _hotelRepository.GetByIdAsync(id);
                if (hotelToDelete != null)
                {
                    await _hotelRepository.DeleteAsync(hotelToDelete);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteHotelAsync: {ex.Message}");
            }
        }
    }
}
