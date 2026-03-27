using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Project.Application.JwtSetting;
using Project.Application.Contract;
using Project.Infrastructure.Contracts;
using Project.Application.DTOs;
using Project.Infrastructure.Entities;

namespace Project.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserRepository _repo;

        public AuthService(IOptions<JwtSettings> jwtSettings, IUserRepository repo)
        {
            _jwtSettings = jwtSettings.Value;
            _repo = repo;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _repo.GetByUsernameAsync(dto.Username);

            if (existingUser != null)
                throw new Exception("User already exists");

            var user = new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Role = dto.Role
            };

            await _repo.AddAsync(user);

            return GenerateToken(user.Id.ToString(), user.Username, user.Role);
        }

        public async Task<string> LoginAsync(LoginDtos dto)
        {
            var user = await _repo.GetByUsernamePasswordAsync(dto.Username, dto.Password);

            if (user == null)
                throw new Exception("Invalid credentials");

            return GenerateToken(user.Id.ToString(), user.Username, user.Role);
        }

        public string GenerateToken(string userId, string username, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),

                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Key)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}