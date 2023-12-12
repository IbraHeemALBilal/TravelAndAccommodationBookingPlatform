using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAndAccommodationBookingPlatform.Db.Entities;

namespace TravelAndAccommodationBookingPlatform.Application.Services
{
    public interface IUserService
    {
        User GetUserByUsername(string username);
        bool ValidateUserCredentials(string username, string password);
    }
}
