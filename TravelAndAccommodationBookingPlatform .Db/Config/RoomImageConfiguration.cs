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
    public class RoomImageConfiguration : IEntityTypeConfiguration<RoomImage>
    {
        public void Configure(EntityTypeBuilder<RoomImage> builder)
        {
            builder.HasKey(ri => ri.ImageId);

            builder.Property(ri => ri.ImageId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(ri => ri.ImageUrl)
                .IsRequired()
                .HasMaxLength(255); 
        }
    }
}
