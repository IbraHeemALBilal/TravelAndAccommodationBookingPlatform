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
using TravelAndAccommodationBookingPlatform.Db.Enums;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using Xunit;

namespace TravelAndAccommodationBookingPlatform.Tests
{
    public class HotelServiceTests
    {
        private readonly Mock<IHotelRepository> _mockHotelRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<IHotelRepository>> _mockLogger;

        private readonly HotelService _hotelService;

        public HotelServiceTests()
        {
            _mockHotelRepository = new Mock<IHotelRepository>();
            var mapperConfig = new MapperConfiguration(ct =>
            {
                ct.AddProfile<HotelProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _mockLogger = new Mock<ILogger<IHotelRepository>>();

            _hotelService = new HotelService(_mockHotelRepository.Object, _mapper, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllHotelsAsync_ShouldReturnListOfHotelDisplayDto()
        {
            // Arrange
            var fakeHotels = new List<Hotel>
            {
                new Hotel { HotelId = 1, Name = "FakeHotel1", StarRating = 4, Rooms = new List<Room>() },
                new Hotel { HotelId = 2, Name = "FakeHotel2", StarRating = 3, Rooms = new List<Room>() },
            };

            var fakeHotelDtos = new List<HotelDisplayDto>
            {
                new HotelDisplayDto { HotelId = 1, Name = "FakeHotel1", StarRating = 4 },
                new HotelDisplayDto { HotelId = 2, Name = "FakeHotel2", StarRating = 3 },
            };

            _mockHotelRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(fakeHotels);

            // Act
            var result = await _hotelService.GetAllHotelsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<HotelDisplayDto>>();
        }



        [Fact]
        public async Task GetHotelByIdAsync_ShouldReturnHotelDisplayDto()
        {
            // Arrange
            var fakeHotelId = 1;
            var fakeHotel = new Hotel { HotelId = fakeHotelId, Name = "FakeHotel", StarRating = 4, Rooms = new List<Room>() };
            var fakeHotelDto = new HotelDisplayDto { HotelId = fakeHotelId, Name = "FakeHotel", StarRating = 4 };

            _mockHotelRepository.Setup(repo => repo.GetByIdAsync(fakeHotelId)).ReturnsAsync(fakeHotel);

            // Act
            var result = await _hotelService.GetHotelByIdAsync(fakeHotelId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<HotelDisplayDto>();
        }
        [Fact]
        public async Task GetHotelByIdAsync_WhenHotelNotFound_ShouldReturnNull()
        {
            // Arrange
            var nonExistentHotelId = 999; 

            _mockHotelRepository.Setup(repo => repo.GetByIdAsync(nonExistentHotelId)).ReturnsAsync((Hotel)null);

            // Act
            var result = await _hotelService.GetHotelByIdAsync(nonExistentHotelId);

            // Assert
            result.Should().BeNull();
        }



        [Fact]
        public async Task AddHotelAsync_ShouldNotThrowException()
        {
            // Arrange
            var fakeHotelDto = new HotelDto { Name = "FakeHotel", StarRating = 4 };

            // Act & Assert
            Func<Task> act = async () => await _hotelService.AddHotelAsync(fakeHotelDto);
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UpdateHotelAsync_ShouldReturnTrue_WhenHotelExists()
        {
            // Arrange
            var fakeHotelId = 1;
            var fakeHotelDto = new HotelDto { Name = "UpdatedFakeHotel", StarRating = 5 };
            var existingHotel = new Hotel { HotelId = fakeHotelId, Name = "FakeHotel", StarRating = 4 };

            _mockHotelRepository.Setup(repo => repo.GetByIdAsync(fakeHotelId)).ReturnsAsync(existingHotel);

            // Act
            var result= await _hotelService.UpdateHotelAsync(fakeHotelId, fakeHotelDto);

            // Assert
            result.Should().Be(true);
        }
        [Fact]
        public async Task UpdateHotelAsync_ShouldReturnFalse_WhenHotelDoesNotExist()
        {
            // Arrange
            var nonExistentHotelId = 999;
            var fakeHotelDto = new HotelDto { Name = "UpdatedFakeHotel", StarRating = 5 };

            _mockHotelRepository.Setup(repo => repo.GetByIdAsync(nonExistentHotelId)).ReturnsAsync((Hotel)null);

            // Act
            var result = await _hotelService.UpdateHotelAsync(nonExistentHotelId, fakeHotelDto);

            // Assert
            result.Should().Be(false);
        }




        [Fact]
        public async Task DeleteHotelAsync_ShouldReturnTrue_WhenHotelExists()
        {
            // Arrange
            var fakeHotelId = 1;
            var existingHotel = new Hotel { HotelId = fakeHotelId, Name = "FakeHotel", StarRating = 4, Rooms = new List<Room>() };

            _mockHotelRepository.Setup(repo => repo.GetByIdAsync(fakeHotelId)).ReturnsAsync(existingHotel);

            // Act 
            var result= await _hotelService.DeleteHotelAsync(fakeHotelId);

            //Assert
            result.Should().Be(true);
        }
        [Fact]
        public async Task DeleteHotelAsync_ShouldReturnFalse_WhenHotelDoesNotExist()
        {
            // Arrange
            var nonExistentHotelId = 999; 

            _mockHotelRepository.Setup(repo => repo.GetByIdAsync(nonExistentHotelId)).ReturnsAsync((Hotel)null);

            // Act 
            var result = await _hotelService.DeleteHotelAsync(nonExistentHotelId);

            //Assert
            result.Should().Be(false);

        }



        [Fact]
        public async Task FilterHotelsAsync_ShouldReturnListOfHotelDisplayDto()
        {
            // Arrange
            var fakeFilterBody = new HotelFilterBodyDto();
            var fakeHotels = new List<Hotel>
            {
                new Hotel { HotelId = 1, Name = "FakeHotel1", StarRating = 4, Rooms = new List<Room>() },
                new Hotel { HotelId = 2, Name = "FakeHotel2", StarRating = 3, Rooms = new List<Room>() },
            };

            var fakeFilteredHotels = new List<Hotel>
            {
                new Hotel { HotelId = 1, Name = "FakeHotel1", StarRating = 4, Rooms = new List<Room>() },
            };

            var fakeHotelDtos = new List<HotelDisplayDto>
            {
                new HotelDisplayDto { HotelId = 1, Name = "FakeHotel1", StarRating = 4 },
            };

            _mockHotelRepository.Setup(repo => repo.GetAllWithRelatedDataAsync()).ReturnsAsync(fakeHotels);

            // Act
            var result = await _hotelService.FilterHotelsAsync(fakeFilterBody);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<HotelDisplayDto>>();
        }


        [Fact]
        public void ApplyFilters_ShouldApplyMinPriceFilter()
        {
            // Arrange
            var hotels = new List<Hotel>
            {
                new Hotel { Rooms = new List<Room> { new Room { PricePerNight = 150 } } },
                new Hotel { Rooms = new List<Room> { new Room { PricePerNight = 180 } } }
            };

            var filterBody = new HotelFilterBodyDto { MinPrice = 160 };

            // Act
            var filteredHotels = _hotelService.ApplyFilters(hotels, filterBody);

            // Assert
            filteredHotels.Should().HaveCount(1);
            filteredHotels.First().Rooms.Should().HaveCount(1);
            filteredHotels.First().Rooms.First().PricePerNight.Should().BeGreaterOrEqualTo(160);
        }

        [Fact]
        public void ApplyFilters_ShouldApplyStarRatingFilter()
        {
            // Arrange
            var hotels = new List<Hotel>
            {
                new Hotel { StarRating = 4 },
                new Hotel { StarRating = 3 }
            };

            var filterBody = new HotelFilterBodyDto { StarRating = 4 };

            // Act
            var filteredHotels = _hotelService.ApplyFilters(hotels, filterBody);

            // Assert
            filteredHotels.Should().HaveCount(1);
            filteredHotels.First().StarRating.Should().Be(4);
        }

        [Fact]
        public void ApplyFilters_ShouldNotApplyFilter_WhenFilterNotSpecified()
        {
            // Arrange
            var hotels = new List<Hotel>
            {
                new Hotel { Rooms = new List<Room> { new Room { PricePerNight = 150 } } },
                new Hotel { Rooms = new List<Room> { new Room { PricePerNight = 180 } } }
            };

            var filterBody = new HotelFilterBodyDto();

            // Act
            var filteredHotels = _hotelService.ApplyFilters(hotels, filterBody);

            // Assert
            filteredHotels.Should().BeEquivalentTo(hotels); 
        }
        [Fact]
        public void ApplyFilters_ShouldApplyRoomTypeFilter()
        {
            // Arrange
            var hotels = new List<Hotel>
            {
                new Hotel { Rooms = new List<Room> { new Room { RoomType = RoomTypeEnum.Boutique }, new Room { RoomType = RoomTypeEnum.Luxury } } },
                new Hotel { Rooms = new List<Room> { new Room { RoomType = RoomTypeEnum.Luxury }, new Room { RoomType = RoomTypeEnum.Boutique } } }
            };

            var filterBody = new HotelFilterBodyDto { RoomType = RoomTypeEnum.Luxury };

            // Act
            var filteredHotels = _hotelService.ApplyFilters(hotels, filterBody);

            // Assert
            filteredHotels.Should().HaveCount(2);
            filteredHotels.All(h => h.Rooms.Any(r => r.RoomType == filterBody.RoomType)).Should().BeTrue();
        }


        [Fact]
        public async Task GetVisitedHotelsByUserAsync_ShouldReturnListOfHotelDisplayDto()
        {
            // Arrange
            var fakeUserId = 1;
            var fakeVisitedHotels = new List<Hotel>
            {
                new Hotel { HotelId = 1, Name = "VisitedHotel1", StarRating = 4, Rooms = new List<Room>() },
                new Hotel { HotelId = 2, Name = "VisitedHotel2", StarRating = 3, Rooms = new List<Room>() },
            };

            var fakeVisitedHotelDtos = new List<HotelDisplayDto>
            {
                new HotelDisplayDto { HotelId = 1, Name = "VisitedHotel1", StarRating = 4 },
                new HotelDisplayDto { HotelId = 2, Name = "VisitedHotel2", StarRating = 3 },
            };

            _mockHotelRepository.Setup(repo => repo.GetVisitedHotelsByUserAsync(fakeUserId)).ReturnsAsync(fakeVisitedHotels);

            // Act
            var result = await _hotelService.GetVisitedHotelsByUserAsync(fakeUserId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<HotelDisplayDto>>();
        }

        [Fact]
        public async Task GetHotelsWithAvailableDealsAsync_ShouldReturnListOfHotelDisplayDto()
        {
            // Arrange
            var fakeHotelsWithDeals = new List<Hotel>
            {
                new Hotel { HotelId = 1, Name = "HotelWithDeal1", StarRating = 4, Rooms = new List<Room>() },
                new Hotel { HotelId = 2, Name = "HotelWithDeal2", StarRating = 3, Rooms = new List<Room>() },
            };

            var fakeHotelDtosWithDeals = new List<HotelDisplayDto>
            {
                new HotelDisplayDto { HotelId = 1, Name = "HotelWithDeal1", StarRating = 4 },
                new HotelDisplayDto { HotelId = 2, Name = "HotelWithDeal2", StarRating = 3 },
            };

            _mockHotelRepository.Setup(repo => repo.GetHotelsWithAvailableDealsAsync()).ReturnsAsync(fakeHotelsWithDeals);

            // Act
            var result = await _hotelService.GetHotelsWithAvailableDealsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<HotelDisplayDto>>();
        }

    }
}
