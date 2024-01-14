using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Booking entity)
        {
            try
            {
                await _context.Bookings.AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while adding booking. See inner exception for details.", ex);
            }
        }
        public async Task<List<Booking>> GetBookingsForRoomAsync(int roomId)
        {
            try
            {
                var bookingsForRoom = await _context.Bookings
                    .Where(b => b.RoomId == roomId)
                    .ToListAsync();

                return bookingsForRoom;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while retrieving bookings for the room. See inner exception for details.", ex);
                return new List<Booking>();
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
                throw new InvalidOperationException("Error while saving changes. See inner exception for details.", ex);
            }
        }
    }
}
