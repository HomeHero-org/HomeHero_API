using HomeHero_API.Models;
using HomeHero_API.Models.Dto.UserDto;
using System.Security.Claims;

namespace HomeHero_API.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        User GetUser(string email);
        bool existUser(string email);
        Task<UserLoginResponseDto> Login(UserLoginDto userloginDto);
        Task<User> Register(UserRegisterDto userRegisterDto);
        bool DeleteUser (string email);
        Task<User> UpdateUser (UserUpdateDto userUpdateDto);
        string CreateToken(string email, string codeRole);
        string CreateRefreshToken(string email, string codeRole, TimeSpan timeExpiration);
        ClaimsPrincipal validateCookie(string? m3JCookie);
    }
}
