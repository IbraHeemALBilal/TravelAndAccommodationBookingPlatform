using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Enums;

namespace TravelAndAccommodationBookingPlatform.Application.Dto
{
    public class HotelFilterBodyDto
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? StarRating { get; set; }
        public List<int>? AmenitiesIds { get; set; }
        public RoomTypeEnum? RoomType { get; set; }
    }
}
