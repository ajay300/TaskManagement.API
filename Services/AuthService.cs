using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.DTOs;
using TaskManagement.API.Models;

namespace TaskManagement.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserResponseDto> RegisterAsync(RegisterDto dto)
        {
            try
            { 
                var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email || x.Username == dto.Username);

                if (existingUser != null)
                {
                    throw new InvalidOperationException("This User is already Exists");
                }
                //HashCode the password
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);

                //Created new user
                var user = new User
                {
                    createdAt = DateTime.UtcNow,
                    Email = dto.Email,
                    Username = dto.Username,
                    PasswordHash = passwordHash

                };

                //Add to database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return new UserResponseDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    createdAt = user.createdAt
                };

            }
            catch
            {
                throw;
            }


            
        }
    }
}
