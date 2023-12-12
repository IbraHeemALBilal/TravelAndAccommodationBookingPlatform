using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelAndAccommodationBookingPlatform.Application.Dto;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Db.Entities;

[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthenticationController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        if (_userService.ValidateUserCredentials(loginRequest.Username, loginRequest.Password))
        {
            var user = _userService.GetUserByUsername(loginRequest.Username);
            var token = GenerateJwtToken(user);
            return Ok(new { Token = token});
        }
        else
        {
            return Unauthorized(new { Message = "Invalid username or password." });
        }
    }

    private string GenerateJwtToken(User user)
    {
        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("UserId", user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["JwtSettings:ExpirationHours"])),
            Issuer = _configuration["JwtSettings:Issuer"],
            Audience = _configuration["JwtSettings:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
