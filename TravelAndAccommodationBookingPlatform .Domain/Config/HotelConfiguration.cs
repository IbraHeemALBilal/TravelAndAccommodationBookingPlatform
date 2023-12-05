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
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.HotelId);

            builder.Property(h => h.HotelId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(h => h.StarRating)
                .IsRequired();

            builder.Property(h => h.Owner)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(h => h.Location)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(h => h.HotelImages)
                .WithOne(hi => hi.Hotel)
                .HasForeignKey(hi => hi.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(h => h.HotelAmenities)
                .WithOne(ha => ha.Hotel)
                .HasForeignKey(ha => ha.HotelId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
        
}