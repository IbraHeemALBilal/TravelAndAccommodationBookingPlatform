using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndAccommodationBookingPlatform.Domain.Entities
{
    public class HotelAmenity
    {
        public int HotelId { get; set; }
        public int AmenityId { get; set; }
        public Hotel Hotel { get; set; }
        public Amenity Amenity { get; set; }
    }
}
