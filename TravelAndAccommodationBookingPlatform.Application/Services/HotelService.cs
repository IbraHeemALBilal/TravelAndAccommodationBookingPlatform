﻿using AutoMapper;
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
    public class HotelService:IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<IHotelService> _logger; 

        public HotelService(IHotelRepository hotelRepository, IMapper mapper, ILogger<IHotelService> logger)
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
        public async Task<bool> UpdateHotelAsync(int id, HotelDto hotelDto)
        {
            try
            {
                var existingHotel = await _hotelRepository.GetByIdAsync(id);

                if (existingHotel == null)
                {
                    return false; 
                }
                _mapper.Map(hotelDto, existingHotel);
                existingHotel.ModifiedAt = DateTime.Now;

                await _hotelRepository.UpdateAsync(existingHotel);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateHotelAsync: {ex.Message}");
                return false; 
            }
        }
        public async Task<bool> DeleteHotelAsync(int id)
        {
            try
            {
                var hotelToDelete = await _hotelRepository.GetByIdAsync(id);

                if (hotelToDelete == null)
                {
                    return false;
                }

                await _hotelRepository.DeleteAsync(hotelToDelete);

                return true; 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteHotelAsync: {ex.Message}");
                return false; 
            }
        }
        public async Task<List<HotelDisplayDto>> FilterHotelsAsync(HotelFilterBodyDto filterBody)
        {
            try
            {
                var allHotels = await _hotelRepository.GetAllWithRelatedDataAsync();
                var filteredHotels = ApplyFilters(allHotels, filterBody);

                return _mapper.Map<List<HotelDisplayDto>>(filteredHotels);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in FilterHotelsAsync: {ex.Message}");
                return new List<HotelDisplayDto>();
            }
        }
        public IEnumerable<Hotel> ApplyFilters(IEnumerable<Hotel> hotels, HotelFilterBodyDto filterBody)
        {
            if (filterBody.MinPrice.HasValue || filterBody.MaxPrice.HasValue)
            {
                hotels = hotels.Where(h =>
                    h.Rooms.Any(r =>
                        (!filterBody.MinPrice.HasValue || r.PricePerNight >= filterBody.MinPrice.Value) &&
                        (!filterBody.MaxPrice.HasValue || r.PricePerNight <= filterBody.MaxPrice.Value)
                    )
                );
            }

            if (filterBody.StarRating.HasValue)
            {
                hotels = hotels.Where(h => h.StarRating == filterBody.StarRating.Value);
            }

            if (filterBody.AmenitiesIds != null && filterBody.AmenitiesIds.Any())
            {
                hotels = hotels.Where(h => filterBody.AmenitiesIds.All(amenityId =>
                    h.HotelAmenities.Any(ha => ha.AmenityId == amenityId)));
            }

            if (filterBody.RoomType.HasValue)
            {
                hotels = hotels.Where(h => h.Rooms.Any(r => r.RoomType == filterBody.RoomType.Value));
            }

            return hotels;
        }
        public async Task<List<HotelDisplayDto>> GetVisitedHotelsByUserAsync(int userId)
        {
            try
            {
                var visitedHotels = await _hotelRepository.GetVisitedHotelsByUserAsync(userId);
                return _mapper.Map<List<HotelDisplayDto>>(visitedHotels);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetVisitedHotelsByUserAsync: {ex.Message}");
                return new List<HotelDisplayDto>();
            }
        }
        public async Task<List<HotelDisplayDto>> GetHotelsWithAvailableDealsAsync()
        {
            try
            {
                var hotels = await _hotelRepository.GetHotelsWithAvailableDealsAsync();
                return _mapper.Map<List<HotelDisplayDto>>(hotels);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetHotelsWithAvailableDealsAsync: {ex.Message}");
                return new List<HotelDisplayDto>();
            }
        }

    }
}
