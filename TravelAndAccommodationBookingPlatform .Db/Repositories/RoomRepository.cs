using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using TravelAndAccommodationBookingPlatform.Db.Repositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            try
            {
                return await _context.Rooms
                        .Include(room => room.RoomImages) 
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<Room>();
            }
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            try
            {
                var room = await _context.Rooms
                    .Include(r => r.Deals)
                    .FirstOrDefaultAsync(r => r.RoomId == id);

                if (room != null)
                {
                    await _context.Entry(room)
                        .Collection(r => r.RoomImages)
                        .LoadAsync();

                    var currentDate = DateTime.Now;
                    room.Deals = room.Deals.Where(deal =>
                        deal.StartDate <= currentDate && currentDate <= deal.EndDate)
                        .ToList();
                }

                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Room entity)
        {
            try
            {
                await _context.Rooms.AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
            }
        }

        public async Task UpdateAsync(Room entity)
        {
            try
            {
                _context.Rooms.Update(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAsync: {ex.Message}");
            }
        }

        public async Task DeleteAsync(Room entity)
        {
            try
            {
                _context.Rooms.Remove(entity);
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

        public async Task<Room> GetRoomWithDealsAsync(int id)
        {
            try
            {
                var room = await _context.Rooms
                    .Include(r => r.Deals)
                    .FirstOrDefaultAsync(r => r.RoomId == id);
                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetRoomWithDealsAsync: {ex.Message}");
                return null;
            }
        }

    }
}
