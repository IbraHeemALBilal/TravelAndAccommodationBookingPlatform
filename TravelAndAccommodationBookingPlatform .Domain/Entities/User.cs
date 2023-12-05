using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Domain.Enums;
namespace TravelAndAccommodationBookingPlatform.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public List<Booking> Bookings { get; set; }

    }
}
