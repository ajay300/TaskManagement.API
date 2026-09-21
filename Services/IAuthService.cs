using TaskManagement.API.DTOs;

namespace TaskManagement.API.Services
{
    public interface IAuthService
    {
        Task<UserResponseDto> RegisterAsync(RegisterDto dto);
    }
}
