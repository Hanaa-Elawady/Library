using Library.Services.Mapping.DTOs.User;

namespace Library.Services.Services.User
{
    public interface IUserService
    {
        Task<AppUserDto> Login(LoginDto input);
        Task<AppUserDto> Register(RegisterDto input);
    }
}
