using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Domain.Enums;

namespace TravelAndAccommodationBookingPlatform.Domain.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public int AdultCapacity { get; set; }
        public int ChildrenCapacity { get; set; }
        public decimal PricePerNight { get; set; } 
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public RoomTypeEnum RoomType { get; set; }
        public List<RoomImage> RoomImages { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
