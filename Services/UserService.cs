using BlogApi.Data;
using BlogApi.Models;
using System.Security.Cryptography;
using System.Text;

namespace BlogApi.Services
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }

        public ServiceResponse<UserResponseDto> Register(UserRegisterDto userRegisterDto)
        {
            if (_context.User.Any(u => u.Username == userRegisterDto.Username))
            {
                return new ServiceResponse<UserResponseDto> { Success = false, Message = "Username already exists." };
            }

            var user = new User
            {
                Username = userRegisterDto.Username,
                PasswordHash = HashPassword(userRegisterDto.Password),
                Email = userRegisterDto.Email
            };

            _context.User.Add(user);
            _context.SaveChanges();

            return new ServiceResponse<UserResponseDto>
            {
                Success = true,
                Data = new UserResponseDto { Id = user.Id, Username = user.Username, Email = user.Email }
            };
        }

        public ServiceResponse<UserResponseDto> Login(UserLoginDto userLoginDto)
        {
            var user = _context.User.SingleOrDefault(u => u.Username == userLoginDto.Username);
            if (user == null || !VerifyPassword(userLoginDto.Password, user.PasswordHash))
            {
                return new ServiceResponse<UserResponseDto>
                {
                    Success = false,
                    Message = "Invalid username or password.",
                };
            }

            return new ServiceResponse<UserResponseDto>
            {
                Success = true,
                Data = new UserResponseDto { Id = user.Id, Username = user.Username, Email = user.Email }
            };
        }

        public UserResponseDto GetById(int id)
        {
            var user = _context.User.Find(id);
            if (user == null)
            {
                return null;
            }

            return new UserResponseDto { Id = user.Id, Username = user.Username, Email = user.Email };
        }

        public IEnumerable<UserResponseDto> GetAll()
        {
            return _context.User.Select(u => new UserResponseDto { Id = u.Id, Username = u.Username, Email = u.Email })
                .ToList();
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return hash == storedHash;
        }
    }
}