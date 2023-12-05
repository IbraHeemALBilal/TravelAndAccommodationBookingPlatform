using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndAccommodationBookingPlatform.Domain.Entities
{
    public class RoomImage
    {
        public int ImageId { get; set; }
        public int RoomId { get; set; }
        public string ImageUrl { get; set; }
        public Room Room { get; set; }
    }
}
