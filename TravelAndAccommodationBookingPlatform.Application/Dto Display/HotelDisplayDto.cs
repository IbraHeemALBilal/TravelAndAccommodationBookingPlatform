using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Dto_Display
{
    public class HotelDisplayDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int StarRating { get; set; }
        public string Owner { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public decimal AveragePricePerNight { get; set; }
        public List<ReviewDisplayDto> Reviews { get; set; }
        public List<HotelImageDisplayDto> HotelImages { get; set; }
    }
}
