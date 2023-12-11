using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Enums;

namespace TravelAndAccommodationBookingPlatform.Db.Entities
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
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int NumberOfRooms { get; set; }
        public List<RoomImage> RoomImages { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Deal> Deals { get; set; }

    }
}
