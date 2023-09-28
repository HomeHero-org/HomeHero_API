using AutoMapper;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto;
using HomeHero_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HomeHero_API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRep;
        private readonly IMapper _mapper;
        private ApiAnswer _apiAnswer;
        public UsersController(IUserRepository userRepository, IMapper mapper) {
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
            var listUsers = _userRep.GetUsers();
            var listUsersSummary = new List<UserSumarryDto>();
            foreach (var user in listUsers)
            {
                var userResult = _mapper.Map<UserSumarryDto>(user);
                userResult.LocationResidence = user.LocationResidence.City;
                userResult.Role = user.Role_User.NameRole;
                _apiAnswer.Result = userResult;
                listUsersSummary.Add(userResult);
            }
            return Ok(listUsersSummary);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody] UserRegisterDto newUser)
        {
            //Unique user valitation

            if (_userRep.existUser(newUser.Email))
            {
                _apiAnswer.StatusCode = HttpStatusCode.BadRequest;
                _apiAnswer.isSuccess = false;
                _apiAnswer.Messages.Add("That email is already registered in an account");
                return BadRequest(_apiAnswer);
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
            userResult.LocationResidence = user.LocationResidence.City;
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
            userResult.LocationResidence = user.LocationResidence.City;
            userResult.Role = user.Role_User.NameRole;
            _apiAnswer.Result = userResult;
            return Ok(_apiAnswer);
        }
        [HttpPatch("delete/{email}")]
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
                _apiAnswer.StatusCode = HttpStatusCode.BadRequest;
                _apiAnswer.isSuccess = false;
                _apiAnswer.Messages.Add("Any User is registered with the passed email");
                return BadRequest(_apiAnswer);
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
            _apiAnswer.Messages.Add("Succesful deleted the user registered with email -> "+ email);
            return Ok(_apiAnswer);
        }
    }
}
