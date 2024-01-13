using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories
{
    public class DealRepository:IDealRepository
    {
        private readonly ApplicationDbContext _context;
        public DealRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Deal entity)
        {
            try
            {
                await _context.Deals.AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
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
        public async Task<Deal> GetDealByRoomAndDateAsync(int roomId, DateTime startDate, DateTime endDate)
        {
            return await _context.Deals
                .FirstOrDefaultAsync(d => d.RoomId == roomId &&
                            ((d.StartDate >= startDate && d.StartDate <= endDate) ||
                             (d.EndDate >= startDate && d.EndDate <= endDate)));
        }
    }
}
