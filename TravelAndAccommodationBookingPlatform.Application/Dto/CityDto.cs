using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndAccommodationBookingPlatform.Application.Dto
{
    public class CityDto
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string PostOffice { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}
