using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Domain.Entities;

namespace TravelAndAccommodationBookingPlatform.Domain.Config
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.BookingId);

            builder.Property(b => b.BookingId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(b => b.CheckInDate)
                .IsRequired();

            builder.Property(b => b.CheckOutDate)
                .IsRequired();

            builder.Property(b => b.TotalPrice)
                .IsRequired();


          }
    }
}
