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
using FluentValidation.AspNetCore;
using FluentValidation;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Validators;

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
            services.AddControllers().AddFluentValidation();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddLogging();

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IDealRepository,DealRepository>();

            services.AddScoped<ICityService,CityService>();
            services.AddScoped<IHotelService,HotelService>();
            services.AddScoped<IRoomService,RoomService>();
            services.AddScoped<IBookingService,BookingService>();
            services.AddScoped<IDealService,DealService>();

            services.AddAutoMapper(typeof(CityProfile),typeof(HotelProfile)
                ,typeof(RoomProfile),typeof(BookingProfile),typeof(HotelImageProfile)
                ,typeof(ReviewProfile),typeof(RoomImageProfile),typeof(DealProfile));

            services.AddTransient<IValidator<CityDto>, CityDtoValidator>()
                 .AddTransient<IValidator<HotelDto>, HotelDtoValidator>()
                 .AddTransient<IValidator<HotelFilterBodyDto>, HotelFilterBodyDtoValidator>()
                 .AddTransient<IValidator<BookingDto>, BookingDtoValidator>()
                 .AddTransient<IValidator<DealDto>, DealDtoValidator>()
                 .AddTransient<IValidator<RoomDto>, RoomDtoValidator>();

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
