﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAndAccommodationBookingPlatform.Domain.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int StarRating { get; set; } 
        public string Owner { get; set; }
        public string Location { get; set; }
        public int CityId { get; set; }  
        public City City { get; set; }
        public List<HotelImage> HotelImages { get; set; }
        public List<Room> Rooms { get; set; }
        public List<HotelAmenity> HotelAmenities { get; set; }
    }
}
