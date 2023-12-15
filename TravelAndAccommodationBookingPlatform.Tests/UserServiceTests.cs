using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;
using Xunit;

namespace TravelAndAccommodationBookingPlatform.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetUserByUsername_ValidUsername_ReturnsUser()
        {
            // Arrange
            var username = "testuser";
            var expectedUser = new User { Username = username };

            var mockUserRepository = new Mock<IUserRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<IUserRepository>>();

            var userService = new UserService(
                mockUserRepository.Object,
                mockMapper.Object,
                mockLogger.Object);

            mockUserRepository.Setup(repo => repo.GetByUsername(username))
                              .Returns(expectedUser);

            // Act
            var result = userService.GetUserByUsername(username);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUser, result);
        }

        [Fact]
        public void ValidateUserCredentials_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            var username = "admin";
            var password = "adminpass";

            var mockUserRepository = new Mock<IUserRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<IUserRepository>>();

            var userService = new UserService(
                mockUserRepository.Object,
                mockMapper.Object,
                mockLogger.Object);

            mockUserRepository.Setup(repo => repo.GetByUsername(username))
                              .Returns(new User { Username = username, PasswordHash = "$2a$10$wEnIrH5ShlVpWcbIJpMDl.Ibzh/rlKI938/K7spUFyPoOhr06p.Im" });

            // Act
            var result = userService.ValidateUserCredentials(username, password);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void ValidateUserCredentials_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            var username = "admin";
            var password = "wrongpassword";

            var mockUserRepository = new Mock<IUserRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<IUserRepository>>();

            var userService = new UserService(
                mockUserRepository.Object,
                mockMapper.Object,
                mockLogger.Object);

            mockUserRepository.Setup(repo => repo.GetByUsername(username))
                              .Returns(new User { Username = username, PasswordHash = "$2a$10$wEnIrH5ShlVpWcbIJpMDl.Ibzh/rlKI938/K7spUFyPoOhr06p.Im" });

            // Act
            var result = userService.ValidateUserCredentials(username, password);

            // Assert
            Assert.False(result);
        }

    }
}
