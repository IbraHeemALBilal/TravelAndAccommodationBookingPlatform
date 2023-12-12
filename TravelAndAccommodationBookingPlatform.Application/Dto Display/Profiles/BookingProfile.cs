using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>().ReverseMap();
        }

    }
}
