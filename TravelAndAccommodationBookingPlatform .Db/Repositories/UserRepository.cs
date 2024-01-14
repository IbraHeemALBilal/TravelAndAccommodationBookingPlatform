using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public User GetByUsername(string username)
        {
            try
            {
                return _context.Users.FirstOrDefault(u => u.Username == username);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error in GetByUsername: {ex.Message}", ex);
            }
        }
    }
}
