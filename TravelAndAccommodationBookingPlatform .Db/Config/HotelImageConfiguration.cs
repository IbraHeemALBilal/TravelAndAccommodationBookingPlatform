using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Config
{
    public class HotelImageConfiguration : IEntityTypeConfiguration<HotelImage>
    {
        public void Configure(EntityTypeBuilder<HotelImage> builder)
        {
            builder.HasKey(hi => hi.ImageId);

            builder.Property(hi => hi.ImageId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(hi => hi.ImageUrl)
                .IsRequired()
                .HasMaxLength(255); 

        }
    }
}
