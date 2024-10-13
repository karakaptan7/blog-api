using BlogApi.Models;

namespace BlogApi.Services
{
    public interface IUserService
    {
        ServiceResponse<UserResponseDto> Register(UserRegisterDto userRegisterDto);
        ServiceResponse<UserResponseDto> Login(UserLoginDto userLoginDto);
        IEnumerable<UserResponseDto> GetAll();
        UserResponseDto GetById(int id);
    }
}