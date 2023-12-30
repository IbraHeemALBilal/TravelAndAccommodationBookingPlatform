using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Dto_Display;
using TravelAndAccommodationBookingPlatform.Application.Profiles;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using Xunit;

namespace TravelAndAccommodationBookingPlatform.Tests
{
    public class CityServiceTests
    {
        private readonly List<City> fakeCities;
        private readonly Mock<ICityRepository> _mockCityRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<ICityRepository>> _mockLogger;

        private readonly CityService _cityService;

        public CityServiceTests()
        {
            fakeCities = new List<City>
            {
                new City { CityId = 1, Name = "FakeCity1", Country = "FakeCountry1", PostOffice = "FakePostOffice1" },
                new City { CityId = 2, Name = "FakeCity2", Country = "FakeCountry2", PostOffice = "FakePostOffice2" },
            };

            _mockCityRepository = new Mock<ICityRepository>();
            var mapperConfig = new MapperConfiguration(ct =>
            {
                ct.AddProfile<CityProfile>();
            });
            _mapper = new Mapper(mapperConfig);
            _mockLogger = new Mock<ILogger<ICityRepository>>();

            _cityService = new CityService(
                _mockCityRepository.Object,
                _mapper,
                _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllCitiesAsync_ShouldReturnListOfCityDisplayDto()
        {
            // Arrange
            var mockCityDtos = new List<CityDisplayDto>
            {
                new CityDisplayDto { CityId = 1, Name = "FakeCity1", Country = "FakeCountry1", PostOffice = "FakePostOffice1" },
                new CityDisplayDto { CityId = 2, Name = "FakeCity2", Country = "FakeCountry2", PostOffice = "FakePostOffice2" },
            };

            _mockCityRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(fakeCities);

            // Act
            var result = await _cityService.GetAllCitiesAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<CityDisplayDto>>();
        }


        [Theory]
        [InlineData(1, "FakeCity", "FakeCountry", "FakePostOffice")]
        [InlineData(2, "AnotherCity", "AnotherCountry", "AnotherPostOffice")]
        public async Task GetCityByIdAsync_ShouldReturnCityDisplayDto(int fakeCityId, string cityName, string country, string postOffice)
        {
            // Arrange
            var fakeCity = new City { CityId = fakeCityId, Name = cityName, Country = country, PostOffice = postOffice };
            var fakeCityDisplayDto = new CityDisplayDto { CityId = fakeCityId, Name = cityName, Country = country, PostOffice = postOffice };

            _mockCityRepository.Setup(repo => repo.GetByIdAsync(fakeCityId)).ReturnsAsync(fakeCity);

            // Act
            var result = await _cityService.GetCityByIdAsync(fakeCityId);

            // Assert
            result.Should().NotBeNull().And.BeOfType<CityDisplayDto>().And.BeEquivalentTo(fakeCityDisplayDto);
        }
        [Fact]
        public async Task GetCityByIdAsync_ShouldReturnNullWhenCityNotFound()
        {
            // Arrange
            var fakeCityId = 999; 
            _mockCityRepository.Setup(repo => repo.GetByIdAsync(fakeCityId)).ReturnsAsync((City)null);

            // Act
            var result = await _cityService.GetCityByIdAsync(fakeCityId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task AddCityAsync_ShouldNotThrowException()
        {
            // Arrange
            var fakeCityDto = new CityDto { Name = "FakeCity", Country = "FakeCountry", PostOffice = "FakePostOffice" };

            // Act & Assert
            Func<Task> act = async () => await _cityService.AddCityAsync(fakeCityDto);

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UpdateCityAsync_ShouldReturnTrue_WhenCityExists()
        {
            // Arrange
            var fakeCityId = 1;
            var fakeCityDto = new CityDto { Name = "UpdatedFakeCity", Country = "UpdatedFakeCountry", PostOffice = "UpdatedFakePostOffice" };
            var existingCity = new City { CityId = fakeCityId, Name = "FakeCity", Country = "FakeCountry", PostOffice = "FakePostOffice" };

            _mockCityRepository.Setup(repo => repo.GetByIdAsync(fakeCityId)).ReturnsAsync(existingCity);

            // Act & Assert
            var result = await _cityService.UpdateCityAsync(fakeCityId, fakeCityDto);
            result.Should().Be(true);


        }
        [Fact]
        public async Task UpdateCityAsync_ShouldReturnFalse_WhenCityDoesNotExist()
        {
            // Arrange
            var nonExistentCityId = 999;
            var fakeCityDto = new CityDto { Name = "UpdatedFakeCity", Country = "UpdatedFakeCountry", PostOffice = "UpdatedFakePostOffice" };

            _mockCityRepository.Setup(repo => repo.GetByIdAsync(nonExistentCityId)).ReturnsAsync((City)null);

            // Act & Assert
            var result = await _cityService.UpdateCityAsync(nonExistentCityId, fakeCityDto);
            result.Should().Be(false);
        }



        [Fact]
        public async Task DeleteCityAsync_ShouldReturnTrue_WhenCityExists()
        {
            // Arrange
            var fakeCityId = 1;
            var existingCity = new City { CityId = fakeCityId, Name = "FakeCity", Country = "FakeCountry", PostOffice = "FakePostOffice" };

            _mockCityRepository.Setup(repo => repo.GetByIdAsync(fakeCityId)).ReturnsAsync(existingCity);

            // Act & Assert
            var result= await _cityService.DeleteCityAsync(fakeCityId);
            result.Should().Be(true);

        }
        [Fact]
        public async Task DeleteCityAsync_ShouldReturnFalse_WhenCityDoesNotExist()
        {
            // Arrange
            var nonExistentCityId = 999;

            _mockCityRepository.Setup(repo => repo.GetByIdAsync(nonExistentCityId)).ReturnsAsync((City)null);

            // Act & Assert
            var result = await _cityService.DeleteCityAsync(nonExistentCityId);
            result.Should().Be(false);
        }



        [Fact]
        public async Task GetTrendingDestinationsAsync_ShouldReturnListOfCityDisplayDto()
        {
            // Arrange
            var fakeTrendingCities = new List<City>
            {
                new City { CityId = 1, Name = "TrendingCity1", Country = "TrendingCountry1", PostOffice = "TrendingPostOffice1" },
                new City { CityId = 2, Name = "TrendingCity2", Country = "TrendingCountry2", PostOffice = "TrendingPostOffice2" },
            };
            var fakeTrendingCityDtos = new List<CityDisplayDto>
            {
                new CityDisplayDto { CityId = 1, Name = "TrendingCity1", Country = "TrendingCountry1", PostOffice = "TrendingPostOffice1" },
                new CityDisplayDto { CityId = 2, Name = "TrendingCity2", Country = "TrendingCountry2", PostOffice = "TrendingPostOffice2" },
            };

            _mockCityRepository.Setup(repo => repo.GetTrendingDestinationsAsync()).ReturnsAsync(fakeTrendingCities);

            // Act
            var result = await _cityService.GetTrendingDestinationsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<CityDisplayDto>>();
        }
    }
}
