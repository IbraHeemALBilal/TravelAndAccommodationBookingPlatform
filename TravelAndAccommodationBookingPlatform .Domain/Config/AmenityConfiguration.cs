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
    public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
    {
        public void Configure(EntityTypeBuilder<Amenity> builder)
        {
            builder.HasKey(a => a.AmenityId);

            builder.Property(a => a.AmenityId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(a => a.HotelAmenities)
                .WithOne(ha => ha.Amenity)
                .HasForeignKey(ha => ha.AmenityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
