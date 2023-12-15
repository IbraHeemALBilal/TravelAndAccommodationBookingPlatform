using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;
        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Hotel>> GetAllAsync()
        {
            try
            {
                return await _context.Hotels
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<Hotel>();
            }
        }
        public async Task<Hotel> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Hotels
                    .Include(h => h.HotelImages)
                    .Include(h => h.Reviews)
                    .Include(h => h.Rooms)
                    .FirstOrDefaultAsync(h => h.HotelId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }
        public async Task AddAsync(Hotel entity)
        {
            try
            {
                await _context.Hotels.AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
            }
        }
        public async Task UpdateAsync(Hotel entity)
        {
            try
            {
                _context.Hotels.Update(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAsync: {ex.Message}");
            }
        }
        public async Task DeleteAsync(Hotel entity)
        {
            try
            {
                _context.Hotels.Remove(entity);
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
        public async Task<List<Hotel>> GetAllWithRelatedDataAsync()
        {
            try
            {
                return await _context.Hotels
                    .Include(h => h.Rooms)
                    .Include(h => h.HotelAmenities)
                        .ThenInclude(ha => ha.Amenity)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllWithRelatedDataAsync: {ex.Message}");
                return new List<Hotel>();
            }
        }
        public async Task<List<Hotel>> GetVisitedHotelsByUserAsync(int userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.CheckInDate)
                .Select(b => b.Room.Hotel)
                .Distinct()
                .Take(3)
                .ToListAsync();
        }
        public async Task<List<Hotel>> GetHotelsWithAvailableDealsAsync()
        {
            try
            {
                return await _context.Hotels
                    .Include(h => h.Rooms)
                        .ThenInclude(r => r.Deals)
                    .Where(h => h.Rooms.Any(r => r.Deals.Any(d => d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now)))
                    .Take(3)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetHotelsWithAvailableDealsAsync: {ex.Message}");
                return new List<Hotel>();
            }
        }
    }
}
