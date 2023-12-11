using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Config
{
    public class DealConfiguration : IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder.HasKey(d => d.DealId);

            builder.Property(d => d.DealId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(d => d.RoomId)
                .IsRequired();

            builder.Property(d => d.DealPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(d => d.StartDate)
                .IsRequired();

            builder.Property(d => d.EndDate)
                .IsRequired();

            builder.HasOne(d => d.Room)
                .WithMany(r => r.Deals)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
