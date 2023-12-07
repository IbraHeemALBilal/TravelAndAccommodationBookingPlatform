using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndAccommodationBookingPlatform.Db.Entities
{
    public class HotelImage
    {
        public int ImageId { get; set; }
        public int HotelId { get; set; }
        public string ImageUrl { get; set; }
        public Hotel Hotel { get; set; }
    }
}
