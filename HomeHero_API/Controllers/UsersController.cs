﻿using AutoMapper;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.UserDto;
using HomeHero_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace HomeHero_API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRep;
        private readonly IMapper _mapper;
        private ApiAnswer _apiAnswer;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRep = userRepository;
            _apiAnswer = new ApiAnswer();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsers()
        {
            /*if(!validateToken(Request.Headers["Authorization"])){
                return BadRequest("The Token is Expired");
            }*/
            var listUsers = _userRep.GetUsers();
            var listUsersSummary = new List<UserSumarryDto>();
            foreach (var user in listUsers)
            {
                var userResult = _mapper.Map<UserSumarryDto>(user);
                userResult.Role = user.Role_User.NameRole;
                _apiAnswer.Result = userResult;
                listUsersSummary.Add(userResult);
            }
            return Ok(listUsersSummary);
        }

        [HttpGet("{UserID:int}", Name = "GetUserByID")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUserByID(int UserID)
        {
            var user = _userRep.GetUser(UserID);
            var userResult = _mapper.Map<UserSumarryDto>(user);
            userResult.LocationResidenceID = user.LocationResidence.CityID;
            userResult.Role = user.Role_User.NameRole;
            return Ok(userResult);
        }

        [HttpGet("{email}", Name = "GetUserByEmail")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _userRep.GetUser(email);
            var userResult = _mapper.Map<UserSumarryDto>(user);
            userResult.Role = user.Role_User.NameRole;
            return Ok(userResult);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto newUser)
        {
            //Unique user valitation

            if (_userRep.existUser(newUser.Email))
            {
                _apiAnswer.StatusCode = HttpStatusCode.Conflict;
                _apiAnswer.isSuccess = false;
                _apiAnswer.Messages.Add("That email is already registered in an account");
                return Conflict(_apiAnswer);
            }

            var user = await _userRep.Register(newUser);
            if (user == null)
            {
                _apiAnswer.StatusCode = HttpStatusCode.BadRequest;
                _apiAnswer.isSuccess = false;
                _apiAnswer.Messages.Add("Error during the register process");
                return BadRequest(_apiAnswer);
            }
            _apiAnswer.StatusCode = HttpStatusCode.OK;
            _apiAnswer.isSuccess = true;
            var userResult = _mapper.Map<UserSumarryDto>(user);
            userResult.LocationResidenceID = user.LocationResidence.CityID;
            userResult.Role = user.Role_User.NameRole;
            _apiAnswer.Result = userResult;
            return Ok(_apiAnswer);
        }

        [HttpPatch("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser([FromForm] UserUpdateDto userUpdate)
        {
            //Unique user valitation
            bool existUser = _userRep.existUser(userUpdate.email);

            if (!existUser)
            {
                _apiAnswer.StatusCode = HttpStatusCode.BadRequest;
                _apiAnswer.isSuccess = false;
                _apiAnswer.Messages.Add("Any User is registered with the passed email");
                return BadRequest(_apiAnswer);
            }

            var user = await _userRep.UpdateUser(userUpdate);
            if (user == null)
            {
                _apiAnswer.StatusCode = HttpStatusCode.BadRequest;
                _apiAnswer.isSuccess = false;
                _apiAnswer.Messages.Add("An Error Happended in the update process");
                return BadRequest(_apiAnswer);
            }
            _apiAnswer.StatusCode = HttpStatusCode.OK;
            _apiAnswer.isSuccess = true;
            _apiAnswer.Messages.Add("Succesful Update!");
            var userResult = _mapper.Map<UserSumarryDto>(user);
            userResult.Role = user.Role_User.NameRole;
            _apiAnswer.Result = userResult;
            return Ok(_apiAnswer);
        }

        [HttpDelete("delete/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(string email)
        {
            //Unique user valitation
            bool existUser = _userRep.existUser(email);

            if (!existUser)
            {
                _apiAnswer.StatusCode = HttpStatusCode.Conflict;
                _apiAnswer.isSuccess = false;
                _apiAnswer.Messages.Add("Any User is registered with the passed email");
                return Conflict(_apiAnswer);
            }

            if (!_userRep.DeleteUser(email))
            {
                _apiAnswer.StatusCode = HttpStatusCode.BadRequest;
                _apiAnswer.isSuccess = false;
                _apiAnswer.Messages.Add("An Error Happended in the delete process");
                return BadRequest(_apiAnswer);
            }

            _apiAnswer.StatusCode = HttpStatusCode.OK;
            _apiAnswer.isSuccess = true;
            _apiAnswer.Messages.Add("Succesful deleted the user registered with email -> " + email);
            return Ok(_apiAnswer);
        }

        [HttpPost("login")]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            var loginAnswer = await _userRep.Login(userLogin);

            if (loginAnswer == null || string.IsNullOrEmpty(loginAnswer.Token))
            {
                _apiAnswer.StatusCode = HttpStatusCode.BadRequest;
                _apiAnswer.isSuccess = false;
                _apiAnswer.Messages.Add("Incorrect username or password");
                return BadRequest(_apiAnswer);
            }
            var timeExpiration = TimeSpan.Zero;
            if (userLogin.RememberLogin) {
                timeExpiration = TimeSpan.FromDays(7);    
            }
            else {
                timeExpiration = TimeSpan.FromHours(20);
            }

            _apiAnswer.StatusCode = HttpStatusCode.OK;
            _apiAnswer.isSuccess = true;
            var user = (User)loginAnswer.User;
            var userSummary = _mapper.Map<UserSumarryDto>(user);
            userSummary.Role = user.Role_User.NameRole;
            loginAnswer.User = userSummary;
            _apiAnswer.Result = loginAnswer;

            string refreshToken = _userRep.CreateRefreshToken(user.Email, user.Role_User.CodeRole.ToString(),timeExpiration);
            CookieOptions cookieOptions = new CookieOptions
            {
                Path = "/",
                HttpOnly = true, // Para que solo sea accesible desde el servidor
                Secure = true,  // Secure = true es para HTTPS
                MaxAge = timeExpiration,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
            };
            Response.Cookies.Append("M3J", refreshToken, cookieOptions);
            return Ok(_apiAnswer);
        }

        [HttpGet("refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Refresh()
        {
            if (Request.Cookies.ContainsKey("M3J"))
            {
                string M3JCookie = Request.Cookies["M3J"];
                ClaimsPrincipal claims = _userRep.validateCookie(M3JCookie);
                string refreshedToken = _userRep.CreateToken(claims.FindFirst(ClaimTypes.Name).Value,claims.FindFirst(ClaimTypes.Role).Value);

                return Ok(new { accessToken = refreshedToken});
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("logout")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> logout()
        {
            if (Request.Cookies.ContainsKey("M3J"))
            {

                Response.Cookies.Delete("M3J",new CookieOptions {
                    HttpOnly = true, // Para que solo sea accesible desde el servidor
                    Secure = true,  // Secure = true es para HTTPS
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                });
                return NoContent();
            }
            else
            {
                return BadRequest("There is not a user to logout");
            }
        }


        private bool validateToken(String authorization)
        {
            if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                string tokenStr = authorization.Substring("Bearer ".Length);
                JwtSecurityToken token = new JwtSecurityToken(tokenStr);

                return token.ValidTo >= DateTime.UtcNow;
            }
            return false;
        }

    }
}
