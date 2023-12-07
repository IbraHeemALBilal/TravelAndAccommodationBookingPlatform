using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto_Display;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public class CityService
    {
        private readonly CityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CityService> _logger; 

        public CityService(CityRepository cityRepository, IMapper mapper, ILogger<CityService> logger)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<CityDisplayDto>> GetAllCitiesAsync()
        {
            try
            {
                var cities = await _cityRepository.GetAllAsync();
                var cityDtos = _mapper.Map<List<CityDisplayDto>>(cities);
                return cityDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllCitiesAsync: {ex.Message}");
                return new List<CityDisplayDto>();
            }
        }

        public async Task<CityDisplayDto> GetCityByIdAsync(int id)
        {
            try
            {
                var city = await _cityRepository.GetByIdAsync(id);
                return _mapper.Map<CityDisplayDto>(city);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetCityByIdAsync: {ex.Message}");
                return null;
            }
        }

        public async Task AddCityAsync(CityDto cityDto)
        {
            try
            {
                var city = _mapper.Map<City>(cityDto);
                await _cityRepository.AddAsync(city);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddCityAsync: {ex.Message}");
            }
        }

        public async Task UpdateCityAsync(int id, CityDto cityUpdateDto)
        {
            try
            {
                var existingCity = await _cityRepository.GetByIdAsync(id);

                if (existingCity == null)
                {
                    throw new InvalidOperationException($"City with ID {id} not found");
                }
                cityUpdateDto.ModifiedAt = DateTime.Now;
                _mapper.Map(cityUpdateDto, existingCity);

                await _cityRepository.UpdateAsync(existingCity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateCityAsync: {ex.Message}");
            }
        }

        public async Task DeleteCityAsync(int id)
        {
            try
            {
                var cityToDelete = await _cityRepository.GetByIdAsync(id);
                if (cityToDelete != null)
                {
                    await _cityRepository.DeleteAsync(cityToDelete);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteCityAsync: {ex.Message}");
            }
        }
    }
}
