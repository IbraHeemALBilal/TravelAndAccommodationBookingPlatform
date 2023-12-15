using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Profiles;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using Xunit;

namespace TravelAndAccommodationBookingPlatform.Tests
{
    public class BookingServiceTests
    {
        private readonly Mock<IBookingRepository> _mockBookingRepository;
        private readonly Mock<IRoomRepository> _mockRoomRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<IBookingService>> _mockLogger;
        private readonly IBookingService _bookingService;

        public BookingServiceTests()
        {
            _mockBookingRepository = new Mock<IBookingRepository>();
            _mockRoomRepository = new Mock<IRoomRepository>();
            var mapperConfig = new MapperConfiguration(ct =>
            {
                ct.AddProfile<BookingProfile>();
            });
            _mapper = new Mapper(mapperConfig);
            _mockLogger = new Mock<ILogger<IBookingService>>();

            _bookingService = new BookingService(
                _mockBookingRepository.Object,
                _mockRoomRepository.Object,
                _mapper,
                _mockLogger.Object);
        }


        [Fact]
        public async Task CreateBookingAsync_ShouldCreateBooking()
        {
            // Arrange
            var bookingDto = new BookingDto
            {
                RoomId = 1,
                CheckInDate = DateTime.Now.AddDays(1),
                CheckOutDate = DateTime.Now.AddDays(5),
            };

            _mockBookingRepository.Setup(repo => repo.AddAsync(It.IsAny<Booking>()));
            _mockRoomRepository.Setup(repo => repo.GetRoomWithDealsAsync(bookingDto.RoomId))
                               .ReturnsAsync(new Room { PricePerNight = 100, Deals = new List<Deal>() });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingDto);

            // Assert
            result.Should().BeTrue();
            _mockBookingRepository.Verify(repo => repo.AddAsync(It.IsAny<Booking>()), Times.Once);
        }

        [Fact]
        public async Task CreateBookingAsync_ShouldDetectConflict()
        {
            // Arrange
            var bookingDto = new BookingDto
            {
                RoomId = 1,
                CheckInDate = DateTime.Now.AddDays(1),
                CheckOutDate = DateTime.Now.AddDays(5),
            };

            var existingBooking = new Booking
            {
                RoomId = 1,
                CheckInDate = DateTime.Now.AddDays(2),
                CheckOutDate = DateTime.Now.AddDays(4),
            };

            _mockBookingRepository.Setup(repo => repo.AddAsync(It.IsAny<Booking>()));
            _mockRoomRepository.Setup(repo => repo.GetRoomWithDealsAsync(bookingDto.RoomId))
                               .ReturnsAsync(new Room { PricePerNight = 100, Deals = new List<Deal>() });
            _mockBookingRepository.Setup(repo => repo.GetBookingsForRoomAsync(bookingDto.RoomId))
                                 .ReturnsAsync(new List<Booking> { existingBooking });

            // Act
            var result = await _bookingService.CreateBookingAsync(bookingDto);

            // Assert
            result.Should().BeFalse();
            _mockBookingRepository.Verify(repo => repo.AddAsync(It.IsAny<Booking>()), Times.Never);
        }



        [Fact]
        public async Task CalculateTotalPriceAsync_ShouldCalculatePriceWithDeal()
        {
            // Arrange
            var roomId = 1;
            var checkInDate = DateTime.Now.AddDays(1);
            var checkOutDate = DateTime.Now.AddDays(5);

            var roomWithDeal = new Room
            {
                PricePerNight = 100,
                Deals = new List<Deal>
                {
                    new Deal { DealPrice = 80, StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(2) }
                }
            };

            _mockRoomRepository.Setup(repo => repo.GetRoomWithDealsAsync(roomId)).ReturnsAsync(roomWithDeal);

            // Act
            var result = await _bookingService.CalculateTotalPriceAsync(roomId, checkInDate, checkOutDate);

            // Assert
            result.Should().Be(4 * 80); 
        }

        [Fact]
        public async Task CalculateTotalPriceAsync_ShouldCalculatePriceWithoutDeal()
        {
            // Arrange
            var roomId = 1;
            var checkInDate = DateTime.Now.AddDays(1);
            var checkOutDate = DateTime.Now.AddDays(5);

            var roomWithoutDeal = new Room { PricePerNight = 100, Deals = new List<Deal>() };

            _mockRoomRepository.Setup(repo => repo.GetRoomWithDealsAsync(roomId)).ReturnsAsync(roomWithoutDeal);

            // Act
            var result = await _bookingService.CalculateTotalPriceAsync(roomId, checkInDate, checkOutDate);

            // Assert
            result.Should().Be(4 * 100); 
        }



        [Fact]
        public async Task CheckForBookingConflictAsync_ShouldNotDetectConflict()
        {
            // Arrange
            var bookingDto = new BookingDto
            {
                RoomId = 1,
                CheckInDate = DateTime.Now.AddDays(1),
                CheckOutDate = DateTime.Now.AddDays(5),
            };

            var existingBooking = new Booking
            {
                RoomId = 1,
                CheckInDate = DateTime.Now.AddDays(6),
                CheckOutDate = DateTime.Now.AddDays(8),
            };

            _mockBookingRepository.Setup(repo => repo.GetBookingsForRoomAsync(bookingDto.RoomId))
                                 .ReturnsAsync(new List<Booking> { existingBooking });

            // Act
            var result = await _bookingService.CheckForBookingConflictAsync(bookingDto);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task CheckForBookingConflictAsync_ShouldDetectConflict()
        {
            // Arrange
            var bookingDto = new BookingDto
            {
                RoomId = 1,
                CheckInDate = DateTime.Now.AddDays(1),
                CheckOutDate = DateTime.Now.AddDays(5),
            };

            var existingBooking = new Booking
            {
                RoomId = 1,
                CheckInDate = DateTime.Now.AddDays(2),
                CheckOutDate = DateTime.Now.AddDays(4),
            };

            _mockBookingRepository.Setup(repo => repo.GetBookingsForRoomAsync(bookingDto.RoomId))
                                 .ReturnsAsync(new List<Booking> { existingBooking });

            // Act
            var result = await _bookingService.CheckForBookingConflictAsync(bookingDto);

            // Assert
            result.Should().BeTrue();
        }


        [Fact]
        public void CheckDateRangeOverlap_ShouldOverlap()
        {
            // Arrange
            var start1 = DateTime.Now.AddDays(1);
            var end1 = DateTime.Now.AddDays(5);
            var start2 = DateTime.Now.AddDays(3);
            var end2 = DateTime.Now.AddDays(7);

            // Act
            var result = _bookingService.CheckDateRangeOverlap(start1, end1, start2, end2);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void CheckDateRangeOverlap_ShouldNotOverlap()
        {
            // Arrange
            var start1 = DateTime.Now.AddDays(1);
            var end1 = DateTime.Now.AddDays(5);
            var start2 = DateTime.Now.AddDays(6);
            var end2 = DateTime.Now.AddDays(10);

            // Act
            var result = _bookingService.CheckDateRangeOverlap(start1, end1, start2, end2);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void CheckDateRangeOverlap_ShouldOverlap_WhenOneRangeWithinAnother()
        {
            // Arrange
            var start1 = DateTime.Now.AddDays(1);
            var end1 = DateTime.Now.AddDays(10);
            var start2 = DateTime.Now.AddDays(3);
            var end2 = DateTime.Now.AddDays(7);

            // Act
            var result = _bookingService.CheckDateRangeOverlap(start1, end1, start2, end2);

            // Assert
            result.Should().BeTrue();
        }
    }
}
