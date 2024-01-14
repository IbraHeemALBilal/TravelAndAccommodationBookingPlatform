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
                throw new InvalidOperationException($"Error in AddAsync: {ex.Message}", ex);
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
        public async Task<Deal> GetDealByRoomAndDateAsync(int roomId, DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _context.Deals
                    .FirstOrDefaultAsync(d => d.RoomId == roomId &&
                                ((d.StartDate >= startDate && d.StartDate <= endDate) ||
                                (d.EndDate >= startDate && d.EndDate <= endDate) ||
                                (d.StartDate <= startDate && d.EndDate >= startDate)||
                                (d.StartDate <= startDate && d.EndDate >= endDate)
                                ));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in GetDealByRoomAndDateAsync: {ex.Message}", ex);
            }
        }
    }
}
