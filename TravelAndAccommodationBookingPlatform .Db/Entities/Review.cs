using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }
        public User User { get; set; }
        public Hotel Hotel { get; set; }
    }
}
