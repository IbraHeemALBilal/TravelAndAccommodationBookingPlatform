using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Enums;

namespace TravelAndAccommodationBookingPlatform.Application.Dto_Display
{
    public class RoomDisplayDto
    {
        public int RoomId { get; set; }
        public int AdultCapacity { get; set; }
        public int ChildrenCapacity { get; set; }
        public decimal PricePerNight { get; set; }
        public int HotelId { get; set; }
        public RoomTypeEnum RoomType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

}
