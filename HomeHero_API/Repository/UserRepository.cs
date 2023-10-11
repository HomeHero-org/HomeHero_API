using HomeHero_API.Data;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.UserDto;
using HomeHero_API.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeHero_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _key;
        public UserRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _key = configuration.GetValue<string>("ApiSettings:SecretKey");
        }

        public bool DeleteUser(string email)
        {
            _context.User.Remove(_context.User.FirstOrDefault(u => u.Email == email));
            return _context.SaveChanges() >= 0 ? true : false;

        }

        public User GetUser(int id)
        {
            return _context.User
                .Include(u => u.LocationResidence)
                .Include(u => u.Role_User)
                .FirstOrDefault(u => u.UserId == id);
        }
        public User GetUser(string email)
        {
            return _context.User
                .Include(u => u.LocationResidence)
                .Include(u => u.Role_User)
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public ICollection<User> GetUsers()
        {
            return _context.User.Include(u => u.LocationResidence).Include(u => u.Role_User).ToList();
        }

        public bool existUser(string email)
        {
            var user = _context.User.FirstOrDefault(x => x.Email.Equals(email.Trim()));
            if (user == null) return false;
            return true;
        }

        public async Task<UserLoginResponseDto> Login(UserLoginDto userloginDto)
        {
            var user = _context.User.Include(u => u.Role_User).Include(u => u.LocationResidence).FirstOrDefault(
                u => u.Email.Equals(userloginDto.Email.Trim())
                );
            if (user == null || !VerifyPassword(userloginDto.Password, user.Password))
            {
                return new UserLoginResponseDto() { Token = "", User = null };
            }

            UserLoginResponseDto userLoginResponseDto = new UserLoginResponseDto()
            {
                User = user,
                Token = CreateToken(user.Email, user.Role_User.CodeRole.ToString()),
                RefresherToken = CreateRefreshToken(user.Email, user.Role_User.CodeRole.ToString())
            };
            return userLoginResponseDto;
        }

        public string CreateToken(string email, string codeRole)
        {
            var tokenManager = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, email.ToString()),
                        new Claim(ClaimTypes.Role, codeRole.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenManager.CreateToken(tokenDescriptor);
            return tokenManager.WriteToken(token);
        }
        public string CreateRefreshToken(string email, string codeRole)
        {
            var tokenManager = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, email.ToString()),
                        new Claim(ClaimTypes.Role, codeRole.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenManager.CreateToken(tokenDescriptor);
            return tokenManager.WriteToken(token);
        }

        public async Task<User> Register(UserRegisterDto userRegisterDto)
        {
            string hashedPassword = HashPassword(userRegisterDto.Password);
            var location = _context.Location.Add(
                    new Location
                    {
                        CityID = userRegisterDto.CityID
                    }
                );
            _context.SaveChanges();
            int idLoc = _context.Location.OrderByDescending(l => l.LocationID).FirstOrDefault().LocationID;

            var newUser = new User()
            {
                RoleID_User = userRegisterDto.RoleID_User,
                Email = userRegisterDto.Email,
                NamesUser = userRegisterDto.NamesUser,
                SurnamesUser = userRegisterDto.SurnamesUser,
                Password = hashedPassword,
                LocationResidenceID = idLoc
            };
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();
            return _context.User
                .Include(u => u.LocationResidence)
                .Include(u => u.Role_User)
                .FirstOrDefault(u => u.Email.Equals(userRegisterDto.Email));
        }

        public async Task<User> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == userUpdateDto.email);
            if (user == null)
            {
                return null;
            }
            if (!userUpdateDto.RealUserID.Trim().IsNullOrEmpty())
            {
                user.RealUserID = userUpdateDto.RealUserID.Trim();
            }
            if (!userUpdateDto.NamesUser.Trim().IsNullOrEmpty())
            {
                user.NamesUser = userUpdateDto.NamesUser.Trim();
            }
            if (!userUpdateDto.SurnamesUser.Trim().IsNullOrEmpty())
            {
                user.SurnamesUser = userUpdateDto.SurnamesUser.Trim();
            }
            if (userUpdateDto.SexUser != null)
            {
                user.SexUser = userUpdateDto.SexUser;
            }
            if (userUpdateDto.ProfilePicture != null && userUpdateDto.ProfilePicture.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    userUpdateDto.ProfilePicture.CopyTo(stream);
                    byte[] bytesImagen = stream.ToArray();
                    user.ProfilePicture = bytesImagen;
                }
            }
            if (userUpdateDto.Curriculum != null && userUpdateDto.Curriculum.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    userUpdateDto.Curriculum.CopyTo(stream);
                    byte[] bytesImagen = stream.ToArray();
                    user.Curriculum = bytesImagen;
                }
            }
            if (userUpdateDto.RoleID_User != user.RoleID_User)
            {
                user.RoleID_User = userUpdateDto.RoleID_User;
            }
            if (userUpdateDto.LocationResidenceID != user.LocationResidenceID)
            {
                user.LocationResidenceID = userUpdateDto.LocationResidenceID;
            }
            _context.SaveChanges();
            return _context.User
                .Include(u => u.LocationResidence)
                .Include(u => u.Role_User)
                .FirstOrDefault(u => u.Email.Equals(user.Email));

        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public ClaimsPrincipal validateCookie(string? m3JCookie)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_key);

            try
            {
                SecurityToken validatedToken;
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                };
                var principal = tokenHandler.ValidateToken(m3JCookie, tokenValidationParameters, out validatedToken);
                return principal;
            }
            catch (SecurityTokenException ex)
            {
                return null;
            }
        }
    }
}
