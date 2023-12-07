using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using TravelAndAccommodationBookingPlatform.Application.Services;
using AutoMapper;
using TravelAndAccommodationBookingPlatform.Application.Profiles;
using TravelAndAccommodationBookingPlatform.Db;


namespace TravelAndAccommodationBookingPlatform.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddLogging();

            services.AddScoped<CityRepository>();
            services.AddScoped<CityService>();

            services.AddScoped<HotelRepository>();
            services.AddScoped<HotelService>();

            services.AddScoped<RoomRepository>();
            services.AddScoped<RoomService>();

            services.AddAutoMapper(typeof(CityProfile));
            services.AddAutoMapper(typeof(HotelProfile));
            services.AddAutoMapper(typeof(RoomProfile));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DBConnection"));
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
