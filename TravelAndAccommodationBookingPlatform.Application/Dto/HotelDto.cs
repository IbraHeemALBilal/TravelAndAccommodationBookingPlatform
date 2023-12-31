﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndAccommodationBookingPlatform.Application.Dto
{
    public class HotelDto
    {
        public string Name { get; set; }
        public int StarRating { get; set; }
        public string Owner { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }

    }
}
