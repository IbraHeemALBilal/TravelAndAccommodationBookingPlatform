using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllAsync()
        {
            try
            {
                return await _context.Cities.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<City>();
            }
        }
        public async Task<City> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Cities.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }
        public async Task AddAsync(City entity)
        {
            try
            {
                await _context.Cities.AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
            }
        }
        public async Task UpdateAsync(City entity)
        {
            try
            {
                _context.Cities.Update(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAsync: {ex.Message}");
            }
        }
        public async Task DeleteAsync(City entity)
        {
            try
            {
                _context.Cities.Remove(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteAsync: {ex.Message}");
            }
        }
        private async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SaveAsync: {ex.Message}");
            }
        }
        public async Task<List<City>> GetTrendingDestinationsAsync()
        {
            try
            {
                var trendingCityIds = await _context.Bookings
                   .Include(booking => booking.Room.Hotel) 
                   .Where(booking => booking.Room.Hotel != null)
                   .GroupBy(booking => booking.Room.Hotel.CityId)
                   .OrderByDescending(group => group.Count())
                   .Take(3)
                   .Select(group => group.Key)
                   .ToListAsync();

                var trendingDestinations = await _context.Cities
                    .Where(city => trendingCityIds.Contains(city.CityId))
                    .ToListAsync();

                return trendingDestinations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTrendingDestinations: {ex.Message}");
                return new List<City>();
            }
        }

    }
}
