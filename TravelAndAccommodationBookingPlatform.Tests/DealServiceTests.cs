using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Profiles;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using Xunit;

namespace TravelAndAccommodationBookingPlatform.Tests
{
    public class DealServiceTests
    {
        private readonly Mock<IDealRepository> _mockDealRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<IDealRepository>> _mockLogger;
        private readonly DealService _dealService;

        public DealServiceTests()
        {
            _mockDealRepository = new Mock<IDealRepository>();
            var mapperConfig = new MapperConfiguration(ct =>
            {
                ct.AddProfile<DealProfile>();
            });
            _mapper = new Mapper(mapperConfig);
            _mockLogger = new Mock<ILogger<IDealRepository>>();

            _dealService = new DealService(_mockDealRepository.Object, _mapper, _mockLogger.Object);
        }

        [Fact]
        public async Task CreateDealAsync_ValidDealDto_CreatesDeal()
        {
            // Arrange
            var dealDto = new DealDto
            {
                RoomId = 1,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(5),
            };

            _mockDealRepository.Setup(repo => repo.GetDealByRoomAndDateAsync(dealDto.RoomId,dealDto.StartDate, dealDto.EndDate))
                              .ReturnsAsync((Deal)null);

            // Act
            await _dealService.CreateDealAsync(dealDto);

            // Assert
            _mockDealRepository.Verify(repo => repo.AddAsync(It.IsAny<Deal>()), Times.Once);
        }

        [Fact]
        public async Task CreateDealAsync_DealExistsForRoom_ThrowsArgumentException()
        {
            // Arrange
            var dealDto = new DealDto
            {
                RoomId = 1,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(5),
            };

            _mockDealRepository.Setup(repo => repo.GetDealByRoomAndDateAsync(dealDto.RoomId,dealDto.StartDate , dealDto.EndDate))
                              .ReturnsAsync(new Deal { DealId = 1 }); 

            // Act and Assert
            async Task Act() => await _dealService.CreateDealAsync(dealDto);

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(Act);
        }



        [Fact]
        public async Task DealExistsForRoomAsync_DealExists_ReturnsTrue()
        {
            // Arrange
            var roomId = 1;
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(5);

            _mockDealRepository.Setup(repo => repo.GetDealByRoomAndDateAsync(roomId, startDate, endDate))
                              .ReturnsAsync(new Deal { DealId = 1 });

            // Act
            var result = await _dealService.DealExistsForRoomAsync(roomId, startDate, endDate);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DealExistsForRoomAsync_NoDealExists_ReturnsFalse()
        {
            // Arrange
            var roomId = 1;
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(5);

            _mockDealRepository.Setup(repo => repo.GetDealByRoomAndDateAsync(roomId, startDate, endDate))
                              .ReturnsAsync((Deal)null);

            // Act
            var result = await _dealService.DealExistsForRoomAsync(roomId, startDate, endDate);

            // Assert
            Assert.False(result);
        }


    }
}
