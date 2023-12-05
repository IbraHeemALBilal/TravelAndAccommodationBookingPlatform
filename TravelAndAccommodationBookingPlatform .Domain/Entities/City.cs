using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndAccommodationBookingPlatform.Domain.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string PostOffice { get; set; }
        public List<Hotel> Hotels { get; set; }

    }
}
