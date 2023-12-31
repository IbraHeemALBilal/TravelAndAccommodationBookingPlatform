﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAndAccommodationBookingPlatform.Db;

#nullable disable

namespace TravelAndAccommodationBookingPlatform.Db.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231210160805_Adding Deals Table")]
    partial class AddingDealsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Amenity", b =>
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

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Booking", b =>
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

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

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

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Deal", b =>
                {
                    b.Property<int>("DealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DealId"), 1L, 1);

                    b.Property<decimal>("DealPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DealId");

                    b.HasIndex("RoomId");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

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

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.HotelAmenity", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("HotelId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("HotelAmenities");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.HotelImage", b =>
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

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<int>("AdultCapacity")
                        .HasColumnType("int");

                    b.Property<int>("ChildrenCapacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfRooms")
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

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.RoomImage", b =>
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

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.User", b =>
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
                            PasswordHash = "$2a$10$UuAVqw/uAUuax/TZc1tBtO6E1H0qsDsbWFOvSt4MLAdRBF95lj9ZG",
                            Role = "RegularUser",
                            Username = "User2"
                        },
                        new
                        {
                            UserId = 3,
                            PasswordHash = "$2a$10$fa6RUtaLL6n.hVNmQB0zK.DkMe/xDDdi5kkzrtKG8q1WNNlQbDozq",
                            Role = "RegularUser",
                            Username = "User3"
                        },
                        new
                        {
                            UserId = 4,
                            PasswordHash = "$2a$10$07jm5B5WmhkNFZw1zFYmOOZZfhEvQpOgGa4X3Q2NK9qg./ciAkuma",
                            Role = "RegularUser",
                            Username = "User4"
                        },
                        new
                        {
                            UserId = 5,
                            PasswordHash = "$2a$10$97ujgKzPJt2cnnCdy8RNdumiQrsfQyj4nxqF5KKlfJG1k3Z1Cyky6",
                            Role = "RegularUser",
                            Username = "User5"
                        },
                        new
                        {
                            UserId = 6,
                            PasswordHash = "$2a$10$K8LLMLQfK/NC4DBtoN6E1OoYszP15JP5IATdEXAeQDW8WYG/5ZdUm",
                            Role = "RegularUser",
                            Username = "User6"
                        },
                        new
                        {
                            UserId = 7,
                            PasswordHash = "$2a$10$e1lG079p5InQWlWVgriEnuFU0Tl9riHinHQl2tAkMJ5Zb2hEH07F2",
                            Role = "RegularUser",
                            Username = "User7"
                        },
                        new
                        {
                            UserId = 8,
                            PasswordHash = "$2a$10$HFBw0U6Ypkil.TA6asfiQe.jG5/duHiKBFZuvbeAm6S7TCIlsB4IC",
                            Role = "RegularUser",
                            Username = "User8"
                        },
                        new
                        {
                            UserId = 9,
                            PasswordHash = "$2a$10$U6hQWxT8K/FLXCcu6bncC.gLO2WyCfye1cb2T.n/QWn3ywCXCDR1e",
                            Role = "RegularUser",
                            Username = "User9"
                        },
                        new
                        {
                            UserId = 10,
                            PasswordHash = "$2a$10$.V9zcq9G7NXKlda5gdR0ze8k01Io0piE0fSiaGcMA39hMcF8fU3M6",
                            Role = "RegularUser",
                            Username = "User10"
                        },
                        new
                        {
                            UserId = 11,
                            PasswordHash = "$2a$10$fdbwlzji19LhhuOjB61lMulyKQTRts3/ibuymQrGZaBV60dDNeuli",
                            Role = "RegularUser",
                            Username = "User11"
                        },
                        new
                        {
                            UserId = 12,
                            PasswordHash = "$2a$10$cjhngMALbGCWrvJ2Ra9yluH1ULEMDbiIz5Na2NKNpvmIHBt5hkd4u",
                            Role = "RegularUser",
                            Username = "User12"
                        },
                        new
                        {
                            UserId = 13,
                            PasswordHash = "$2a$10$PV7DrZZgokXLcxf68HD9KOAOkfydDnJwMc48MDRizxyaAyx8HfXD6",
                            Role = "RegularUser",
                            Username = "User13"
                        },
                        new
                        {
                            UserId = 14,
                            PasswordHash = "$2a$10$.eGjOkpM4GRIT.mmoiFNgeQL6qavrGDRLTeZRt.dAP03jd5wn4Tg6",
                            Role = "RegularUser",
                            Username = "User14"
                        },
                        new
                        {
                            UserId = 15,
                            PasswordHash = "$2a$10$E90YDC/.jOGHOWeKiW1Soe.IcjPULEkSadaKdZlN/vEb59wXhTfVC",
                            Role = "RegularUser",
                            Username = "User15"
                        },
                        new
                        {
                            UserId = 16,
                            PasswordHash = "$2a$10$xtOqBE5aNEINvRH7QCKP9u1qD8dUse7dqzitu7MIvhYpHguCCareK",
                            Role = "RegularUser",
                            Username = "User16"
                        },
                        new
                        {
                            UserId = 17,
                            PasswordHash = "$2a$10$hXfRJqRxlKtxLi8El9QvgOHr5lFR8C.PhLBFB5sMixPi3U6j.8eFu",
                            Role = "RegularUser",
                            Username = "User17"
                        },
                        new
                        {
                            UserId = 18,
                            PasswordHash = "$2a$10$ufIJLVrpGegyxYBs7ervQufoPA1BqKS.6n6RlI7yTvBImGwhlda2i",
                            Role = "RegularUser",
                            Username = "User18"
                        },
                        new
                        {
                            UserId = 19,
                            PasswordHash = "$2a$10$bXrxtC4AFVWt7khjwODQoOJp4426yQ8EE8qANRhg9cOu0tLoPfJnu",
                            Role = "RegularUser",
                            Username = "User19"
                        },
                        new
                        {
                            UserId = 20,
                            PasswordHash = "$2a$10$7gz9q0OkPhX.UT.FqJC2B.t6.G.jJVVjJAM3/tM/99prwCpJOyCo.",
                            Role = "RegularUser",
                            Username = "User20"
                        },
                        new
                        {
                            UserId = 1,
                            PasswordHash = "$2a$10$CFTSwFwdNtFS2kW5MeYLZOJdfcMxYJDOPDO6.ak6EGRnbOlqP3jUa",
                            Role = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Booking", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Deal", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.Room", "Room")
                        .WithMany("Deals")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Hotel", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.HotelAmenity", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.Amenity", "Amenity")
                        .WithMany("HotelAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.Hotel", "Hotel")
                        .WithMany("HotelAmenities")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.HotelImage", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.Hotel", "Hotel")
                        .WithMany("HotelImages")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Review", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.Hotel", "Hotel")
                        .WithMany("Reviews")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Room", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.RoomImage", b =>
                {
                    b.HasOne("TravelAndAccommodationBookingPlatform.Db.Entities.Room", "Room")
                        .WithMany("RoomImages")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Amenity", b =>
                {
                    b.Navigation("HotelAmenities");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Hotel", b =>
                {
                    b.Navigation("HotelAmenities");

                    b.Navigation("HotelImages");

                    b.Navigation("Reviews");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.Room", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Deals");

                    b.Navigation("RoomImages");
                });

            modelBuilder.Entity("TravelAndAccommodationBookingPlatform.Db.Entities.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
