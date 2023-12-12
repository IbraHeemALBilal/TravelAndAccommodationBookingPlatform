using BCrypt.Net;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HotelAmenity> HotelAmenities { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Deal> Deals { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
