using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
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
    public class RoomServiceTests
    {
        private readonly Mock<IRoomRepository> _mockRoomRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<IRoomRepository>> _mockLogger;

        private readonly RoomService _roomService;

        public RoomServiceTests()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
            var mapperConfig = new MapperConfiguration(ct =>
            {
                ct.AddProfile<RoomProfile>();
            });
            _mapper = mapperConfig.CreateMapper(); 
            _mockLogger = new Mock<ILogger<IRoomRepository>>();

            _roomService = new RoomService(_mockRoomRepository.Object, _mapper, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllRoomsAsync_ReturnsListOfRoomDisplayDto()
        {
            // Arrange
            var expectedRooms = new List<Room>
            {
                new Room { RoomId = 2, Description = "Room 2 Description" },
                new Room { RoomId = 3, Description = "Room 3 Description" }
            };

            _mockRoomRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedRooms);
 
            // Act
            var result = await _roomService.GetAllRoomsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<RoomDisplayDto>>(result);
            Assert.Equal(expectedRooms.Count, result.Count);
        }

        [Fact]
        public async Task GetRoomByIdAsync_WithValidId_ReturnsRoomDisplayDto()
        {
            // Arrange
            var roomId = 1;
            var expectedRoom = new Room { RoomId = roomId };
            _mockRoomRepository.Setup(repo => repo.GetByIdAsync(roomId)).ReturnsAsync(expectedRoom);

            // Act
            var result = await _roomService.GetRoomByIdAsync(roomId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedRoom.RoomId, result?.RoomId);
        }
        [Fact]
        public async Task GetRoomByIdAsync_WhenRoomNotFound_ReturnsNull()
        {
            // Arrange
            var roomId = 1;

            _mockRoomRepository.Setup(repo => repo.GetByIdAsync(roomId)).ReturnsAsync((Room)null);

            // Act
            var result = await _roomService.GetRoomByIdAsync(roomId);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task AddRoomAsync_ValidInput_AddsRoom()
        {
            // Arrange
            var roomDto = new RoomDto();

            // Act
            await _roomService.AddRoomAsync(roomDto);

            // Assert
            _mockRoomRepository.Verify(repo => repo.AddAsync(It.IsAny<Room>()), Times.Once);
        }




        [Fact]
        public async Task UpdateRoomAsync_ShouldReturnTrue_WhenIdExists()
        {
            // Arrange
            var roomId = 1;
            var roomDto = new RoomDto();

            var existingRoom = new Room { RoomId = roomId };
            _mockRoomRepository.Setup(repo => repo.GetByIdAsync(roomId)).ReturnsAsync(existingRoom);

            // Act
            var result = await _roomService.UpdateRoomAsync(roomId, roomDto);

            // Assert
            result.Should().Be(true);
        }
        [Fact]
        public async Task UpdateRoomAsync_ShouldReturnFalse_WhenIdNotExists()
        {
            // Arrange
            var roomId = 1;
            var roomDto = new RoomDto();

            _mockRoomRepository.Setup(repo => repo.GetByIdAsync(roomId)).ReturnsAsync((Room)null);

            // Act
            var result = await _roomService.UpdateRoomAsync(roomId, roomDto);

            // Assert
            result.Should().Be(false);
        }



        [Fact]
        public async Task DeleteRoomAsync_ShouldReturnTrue_WhenIdExists()
        {
            // Arrange
            var roomId = 1;
            var existingRoom = new Room { RoomId = roomId };
            _mockRoomRepository.Setup(repo => repo.GetByIdAsync(roomId)).ReturnsAsync(existingRoom);

            // Act
            var result = await _roomService.DeleteRoomAsync(roomId);

            // Assert
            result.Should().Be(true);
        }
        [Fact]
        public async Task DeleteRoomAsync_ShouldReturnFalse_WhenIdNotExists()
        {
            // Arrange
            var roomId = 1;

            _mockRoomRepository.Setup(repo => repo.GetByIdAsync(roomId)).ReturnsAsync((Room)null);

            // Act
            var result = await _roomService.DeleteRoomAsync(roomId);

            // Assert
            result.Should().Be(false);
        }

    }
}
