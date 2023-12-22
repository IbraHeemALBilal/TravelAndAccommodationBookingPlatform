using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Enums;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Review> Reviews { get; set; }

        public bool VerifyPassword(string enteredPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, PasswordHash);
        }

    }
}
