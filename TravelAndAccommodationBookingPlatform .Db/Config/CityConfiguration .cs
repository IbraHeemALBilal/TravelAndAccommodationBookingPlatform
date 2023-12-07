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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.CityId);

            builder.Property(c => c.CityId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Country)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.PostOffice)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); 

            builder.Property(c => c.ModifiedAt)
                .IsRequired(false);

            builder.HasMany(c => c.Hotels)
                .WithOne(h => h.City)
                .HasForeignKey(h => h.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            //SeedData(builder);
        }
        private static void SeedData(EntityTypeBuilder<City> builder)
        {
            var cities = new List<City>
            {
                new City { CityId = 1, Name = "Jerusalem", Country = "Palestine", PostOffice = "12345" },
                new City { CityId = 2, Name = "Ramallah", Country = "Palestine", PostOffice = "54321" },
                new City { CityId = 3, Name = "Bethlehem", Country = "Palestine", PostOffice = "67890" },
                new City { CityId = 4, Name = "Hebron", Country = "Palestine", PostOffice = "98765" },
                new City { CityId = 5, Name = "Nablus", Country = "Palestine", PostOffice = "45678" },
                new City { CityId = 6, Name = "Gaza City", Country = "Palestine", PostOffice = "23456" },
                new City { CityId = 7, Name = "Jenin", Country = "Palestine", PostOffice = "34567" },
                new City { CityId = 8, Name = "Tulkarm", Country = "Palestine", PostOffice = "87654" },
                new City { CityId = 9, Name = "Qalqilya", Country = "Palestine", PostOffice = "78901" },
                new City { CityId = 10, Name = "Beit Lahia", Country = "Palestine", PostOffice = "56789" },
            };

            builder.HasData(cities);
        }
    }
}
