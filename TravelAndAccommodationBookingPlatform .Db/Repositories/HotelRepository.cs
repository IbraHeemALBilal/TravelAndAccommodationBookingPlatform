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
                throw new InvalidOperationException($"Error in GetAllAsync: {ex.Message}", ex);
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
                throw new InvalidOperationException($"Error in GetByIdAsync: {ex.Message}", ex);
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
                throw new InvalidOperationException($"Error in AddAsync: {ex.Message}", ex);
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
                throw new InvalidOperationException($"Error in UpdateAsync: {ex.Message}", ex);
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
                throw new InvalidOperationException($"Error in DeleteAsync: {ex.Message}", ex);
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
                throw new InvalidOperationException($"Error in SaveAsync: {ex.Message}", ex);
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
                throw new InvalidOperationException($"Error in GetAllWithRelatedDataAsync: {ex.Message}", ex);
                return new List<Hotel>();
            }
        }
        public async Task<List<Hotel>> GetVisitedHotelsByUserAsync(int userId)
        {
            try
            {
                return await _context.Bookings
                    .Where(b => b.UserId == userId)
                    .OrderByDescending(b => b.CheckInDate)
                    .Select(b => b.Room.Hotel)
                    .Distinct()
                    .Take(3)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in GetVisitedHotelsByUserAsync: {ex.Message}", ex);
            }
        }
        public async Task<List<Hotel>> GetHotelsWithAvailableDealsAsync()
        {
             try
             {
                return await _context.Hotels
                     .Where(h => h.Rooms.Any(r => r.Deals.Any(d => d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now)))
                     .Select(h => new Hotel
                     {
                         HotelId = h.HotelId,
                         Name = h.Name,
                         StarRating = h.StarRating,
                         Owner = h.Owner,
                         Location = h.Location,
                         Description = h.Description,
                         CityId = h.CityId,
                         CreatedAt = h.CreatedAt,
                         ModifiedAt = h.ModifiedAt,
                         Rooms = h.Rooms.Where(r => r.Deals.Any(d => d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now))
                               .Select(r => new Room
                               {
                                   RoomId = r.RoomId,
                                   AdultCapacity = r.AdultCapacity,
                                   ChildrenCapacity = r.ChildrenCapacity,
                                   PricePerNight = r.PricePerNight,
                                   HotelId = r.HotelId,
                                   RoomType = r.RoomType,
                                   Description = r.Description,
                                   CreatedAt = r.CreatedAt,
                                   ModifiedAt = r.ModifiedAt,
                                   NumberOfRooms = r.NumberOfRooms,
                                   Deals = r.Deals.Where(d => d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now).ToList()
                               })
                               .ToList()
                     })
                     .ToListAsync();
             }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in GetHotelsWithAvailableDealsAsync: {ex.Message}", ex);
                return new List<Hotel>();
            }
        }
    }
}
