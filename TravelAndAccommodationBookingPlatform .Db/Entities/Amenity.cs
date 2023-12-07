using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndAccommodationBookingPlatform.Db.Entities
{
    public class Amenity
    {
        public int AmenityId { get; set; }
        public string Name { get; set; }
        public List<HotelAmenity> HotelAmenities { get; set; }
    }
}
