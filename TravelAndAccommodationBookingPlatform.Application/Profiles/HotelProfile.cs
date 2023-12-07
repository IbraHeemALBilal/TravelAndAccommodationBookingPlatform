using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto_Display;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Profiles
{
    public class HotelProfile:Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDisplayDto>();
            CreateMap<HotelDisplayDto, Hotel>();

            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelDto, Hotel>();

        }
    }
}
