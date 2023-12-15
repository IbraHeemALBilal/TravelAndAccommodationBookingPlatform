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
            CreateMap<Hotel, HotelDisplayDto>()
                .ForMember(dest => dest.AveragePricePerNight, opt => opt.MapFrom(src => CalculateAveragePricePerNight(src)));

            CreateMap<HotelDisplayDto, Hotel>();
            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelDto, Hotel>();

        }
        private decimal CalculateAveragePricePerNight(Hotel hotel)
        {
            return hotel.Rooms.Any()
                ? hotel.Rooms.Average(room => room.PricePerNight)
                : 0; 
        }
    }
}
