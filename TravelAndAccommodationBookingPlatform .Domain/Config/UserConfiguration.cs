using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Domain.Entities;
using TravelAndAccommodationBookingPlatform.Domain.Enums;
using BCrypt.Net;

namespace TravelAndAccommodationBookingPlatform.Domain.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Username).IsRequired().HasMaxLength(255);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Role).IsRequired().HasConversion<string>();

            builder.HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //SeedUsers(builder);


        }
        private static void SeedUsers(EntityTypeBuilder<User> builder)
        {
            var users = new List<User>();

            for (int i = 2; i <= 20; i++)
            {
                var password = $"pass{i}";
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                var user = new User
                {
                    UserId = i,
                    Username = $"User{i}",
                    PasswordHash = hashedPassword,
                    Role = UserRole.RegularUser,
                };

                users.Add(user);
            }
            var adminUser = new User
            {
                UserId = 1,
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("adminpass"),
                Role = UserRole.Admin,
            };
            users.Add(adminUser);

            builder.HasData(users);
        }
    }
}
