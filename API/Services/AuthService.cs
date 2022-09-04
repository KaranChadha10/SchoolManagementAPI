using API.DTOs;
using API.DTOs.Auth;
using API.Entities;
using API.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace API.Services
{
    public class AuthService : IAuthService
    {
        private readonly TokenConfiguration _appSettings;

        public AuthService(IConfiguration _configuration)
        {
            var Token = JsonSerializer.Deserialize<TokenConfiguration>(_configuration.GetSection("TokenConfiguration").Value);
            _appSettings = Token;

        }
        public JwtDTO GenerateToken(User user)
        {
            if (user.IsVerified)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role,user.UserType.Type),

                });

                var expDate = DateTime.UtcNow.AddHours(24);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = expDate,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Audience = _appSettings.Audience,
                    Issuer = _appSettings.Issuer
                };
                var tokenDesc = tokenHandler.CreateToken(tokenDescriptor);
                return new JwtDTO
                {
                    Token = tokenHandler.WriteToken(tokenDesc),
                    ExpDate = expDate,
                    IsAuthenticated = true,
                    UserId = user.Id,
                    UserName = user.Email,
                    UserRole = user.UserType.Type.ToString(),
                };
            }
            else
            {
                return new JwtDTO
                {
                    IsAuthenticated = false,
                    UserId = user.Id,
                    UserName = user.Email,
                    UserRole = user.UserType.Type.ToString(),
                };
            }
        }
    }
}
