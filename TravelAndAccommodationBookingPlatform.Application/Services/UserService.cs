using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;
using TravelAndAccommodationBookingPlatform.Db.Repositories;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<IUserRepository> _logger;
        public UserService(IUserRepository userRepository 
            ,IMapper mapper 
            ,ILogger<IUserRepository> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public User GetUserByUsername(string username)
        {
            try
            {
                return _userRepository.GetByUsername(username);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user by username");
                throw;
            }
        }

        public bool ValidateUserCredentials(string username, string password)
        {
            try
            {
                var user = _userRepository.GetByUsername(username);
                return user != null && user.VerifyPassword(password);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating user credentials");
                throw;
            }
        }

    }
}
