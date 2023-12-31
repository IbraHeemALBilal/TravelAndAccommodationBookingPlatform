﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto;

namespace TravelAndAccommodationBookingPlatform.Application.Validators
{
    public class RoomDtoValidator : AbstractValidator<RoomDto>
    {
        public RoomDtoValidator()
        {
            RuleFor(dto => dto.AdultCapacity).GreaterThanOrEqualTo(0).WithMessage("Adult capacity should be a non-negative number.");
            RuleFor(dto => dto.ChildrenCapacity).GreaterThanOrEqualTo(0).WithMessage("Children capacity should be a non-negative number.");
            RuleFor(dto => dto.PricePerNight).GreaterThan(0).WithMessage("Price per night should be greater than 0.");
            RuleFor(dto => dto.HotelId).GreaterThan(0).WithMessage("Hotel ID should be greater than 0.");
            RuleFor(dto => dto.RoomType).IsInEnum().WithMessage("Invalid room type.");
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(dto => dto.NumberOfRooms).GreaterThan(0).WithMessage("Number of rooms should be greater than 0.");
        }
    }
}
