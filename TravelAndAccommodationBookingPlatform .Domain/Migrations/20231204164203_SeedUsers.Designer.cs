﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAndAccommodationBookingPlatform.Domain;

#nullable disable

namespace TravelAndAccommodationBookingPlatform.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231204164203_SeedUsers")]
    partial class SeedUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.Amenity", b =>
                {
                    b.Property<int>("AmenityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AmenityId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("AmenityId");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"), 1L, 1);

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PostOffice")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("StarRating")
                        .HasColumnType("int");

                    b.HasKey("HotelId");

                    b.HasIndex("CityId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.HotelAmenity", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("HotelId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("HotelAmenities");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.HotelImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"), 1L, 1);

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ImageId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelImages");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<int>("AdultCapacity")
                        .HasColumnType("int");

                    b.Property<int>("ChildrenCapacity")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.RoomImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomImages");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 2,
                            PasswordHash = "$2a$10$935GtjSbMKLITYeGpbRmMeSxOXvCMuqVLXpxrMrDns6VhKadGLrrC",
                            Role = "RegularUser",
                            Username = "User2"
                        },
                        new
                        {
                            UserId = 3,
                            PasswordHash = "$2a$10$7oI9wXkCI6.B6y8XzLA2T.k8VucOnicd3L5D4qFk/KHPhlfrIDf/O",
                            Role = "RegularUser",
                            Username = "User3"
                        },
                        new
                        {
                            UserId = 4,
                            PasswordHash = "$2a$10$F7UGLRuyoSBqqiy6KHf7t.XL57GLantKmHS4.A2uFpdrWZtmTuvvu",
                            Role = "RegularUser",
                            Username = "User4"
                        },
                        new
                        {
                            UserId = 5,
                            PasswordHash = "$2a$10$aD1rXbOSFtWmcCMcIGV1pelAXOOioykIUua7WaHR9Hh0FGqjsmXDG",
                            Role = "RegularUser",
                            Username = "User5"
                        },
                        new
                        {
                            UserId = 6,
                            PasswordHash = "$2a$10$HGguLdYnvADhTa3QVYJyzOdOTPNbGwHjsk.aAGAHRYJC/VdH7c30W",
                            Role = "RegularUser",
                            Username = "User6"
                        },
                        new
                        {
                            UserId = 7,
                            PasswordHash = "$2a$10$OEepZjdJOogt3MxEg25w8..IT0yPAi/aoifQJVK6SlSX2ovN/67s2",
                            Role = "RegularUser",
                            Username = "User7"
                        },
                        new
                        {
                            UserId = 8,
                            PasswordHash = "$2a$10$/4Iwy48kwg//yOzpgw06NuqNiI9WASa7HqgOjNnyDueyqqX4MIBrC",
                            Role = "RegularUser",
                            Username = "User8"
                        },
                        new
                        {
                            UserId = 9,
                            PasswordHash = "$2a$10$8Uh5Otsh8wNfeZZp1MtabOL6WZkAlkSKh1gd88RQyN7sU8smYx8li",
                            Role = "RegularUser",
                            Username = "User9"
                        },
                        new
                        {
                            UserId = 10,
                            PasswordHash = "$2a$10$o6oSnR33XX3KT.T1aRgunebn3dzWnDdkW2uM9/FPQKUubyqGQZU7y",
                            Role = "RegularUser",
                            Username = "User10"
                        },
                        new
                        {
                            UserId = 11,
                            PasswordHash = "$2a$10$rNKecs.UK6qwWJhgvO/3k.IAos.kpXa1yv4RgXZskTPwe3eL.gWV6",
                            Role = "RegularUser",
                            Username = "User11"
                        },
                        new
                        {
                            UserId = 12,
                            PasswordHash = "$2a$10$aUJJa9odD37ORTGnSGbZ7epsZ4jLWkNejhnh8YZGL01x1yTWhsbOu",
                            Role = "RegularUser",
                            Username = "User12"
                        },
                        new
                        {
                            UserId = 13,
                            PasswordHash = "$2a$10$hw8WQJ6JPz5UGcGri3npieahE7F5Umz5nUhVRdEhSO5LU155QJlOm",
                            Role = "RegularUser",
                            Username = "User13"
                        },
                        new
                        {
                            UserId = 14,
                            PasswordHash = "$2a$10$wNOmKz6hl.bxudaXsQMZwuNN3yP54MKFa9ZQDeb.Lj9CCXzRjw51S",
                            Role = "RegularUser",
                            Username = "User14"
                        },
                        new
                        {
                            UserId = 15,
                            PasswordHash = "$2a$10$8nrtxkKV8sZM/Se6YAL39OQSR163XReXErEhAUqImP24nMVWhjnkS",
                            Role = "RegularUser",
                            Username = "User15"
                        },
                        new
                        {
                            UserId = 16,
                            PasswordHash = "$2a$10$digfFZ.dDLTderlh1i6zdecKstQAY2pIXWoCniZpIXnyycohUAWZC",
                            Role = "RegularUser",
                            Username = "User16"
                        },
                        new
                        {
                            UserId = 17,
                            PasswordHash = "$2a$10$0vi8jlj/ew4aC98oM6n1Q.yHsPzilwPxBVGUoITlzi2RbiXxm9TZW",
                            Role = "RegularUser",
                            Username = "User17"
                        },
                        new
                        {
                            UserId = 18,
                            PasswordHash = "$2a$10$N6v6lYh0Ij2nbjiX2OTFNO1msqYAGCMIDtSi9cpiqMJpFej5EWhb.",
                            Role = "RegularUser",
                            Username = "User18"
                        },
                        new
                        {
                            UserId = 19,
                            PasswordHash = "$2a$10$j1ervRWfv0Zg4GSNqJb8reM8keeL6CPWhLx9ytjh8rQgd6PRbwfO.",
                            Role = "RegularUser",
                            Username = "User19"
                        },
                        new
                        {
                            UserId = 20,
                            PasswordHash = "$2a$10$jQAByxmJ57MUPmfCPsImpOlkcTxMOLCJGmgPEg/NU6DJttTz8crSm",
                            Role = "RegularUser",
                            Username = "User20"
                        },
                        new
                        {
                            UserId = 1,
                            PasswordHash = "$2a$10$9ZWkEAfbtViqlvsIqkoy/OmYLu7THOQLopxoKNUQN2Dzqg86WSaLu",
                            Role = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.Booking", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Domain.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAndAccommodationBookingPlatform.Domain.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.Hotel", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Domain.Entities.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.HotelAmenity", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Domain.Entities.Amenity", "Amenity")
                        .WithMany("HotelAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAndAccommodationBookingPlatform.Domain.Entities.Hotel", "Hotel")
                        .WithMany("HotelAmenities")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.HotelImage", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Domain.Entities.Hotel", "Hotel")
                        .WithMany("HotelImages")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.Room", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.RoomImage", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Domain.Entities.Room", "Room")
                        .WithMany("RoomImages")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.Amenity", b =>
                {
                    b.Navigation("HotelAmenities");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("HotelAmenities");

                    b.Navigation("HotelImages");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.Room", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("RoomImages");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Domain.Entities.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
