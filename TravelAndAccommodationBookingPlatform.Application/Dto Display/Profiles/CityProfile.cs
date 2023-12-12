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
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDisplayDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
