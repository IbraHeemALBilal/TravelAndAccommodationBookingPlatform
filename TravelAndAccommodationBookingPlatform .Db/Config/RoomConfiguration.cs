﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db.Config
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room>builder)
        {
            builder.HasKey(r => r.RoomId);

            builder.Property(r => r.RoomId)
                .IsRequired()
                .ValueGeneratedOnAdd();


            builder.Property(r => r.AdultCapacity)
                .IsRequired();

            builder.Property(r => r.ChildrenCapacity)
                .IsRequired();

            builder.Property(r => r.RoomType)
             .IsRequired()
             .HasConversion<string>();

            builder.Property(r=>r.PricePerNight)
                .IsRequired();

            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(r => r.RoomImages)
                .WithOne(ri => ri.Room)
                .HasForeignKey(ri => ri.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(r => r.ModifiedAt)
                .IsRequired(false);

            builder.Property(r => r.NumberOfRooms)
                .IsRequired();

            builder.HasMany(r => r.Bookings)
               .WithOne(b => b.Room)
               .HasForeignKey(b => b.RoomId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
