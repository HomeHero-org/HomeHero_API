using AutoMapper;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.ApllicationDto;
using HomeHero_API.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HomeHero_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        //inyeccion de dependencias
        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationRepository _applicationRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public ApplicationController(ILogger<ApplicationController> logger, IApplicationRepository applicationRepo, IMapper mapper)
        {
            _logger = logger;
            _applicationRepo = applicationRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet("id:int", Name = "GetApplication")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetApplication(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error: Get Applications with id " + id);
                    _response.statusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccessful = false;
                    return BadRequest(_response);
                }
                var application = await _applicationRepo.Get(x => x.RequestID_Application == id);
                if (application == null)
                {
                    _response.statusCode = HttpStatusCode.NotFound;
                    _response.IsSuccessful = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ApplicationDto>(application);
                _response.statusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateApplication([FromForm] ApplicationCreateDto createDto)
        {
            try
            {
                
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (createDto == null) return BadRequest(createDto);
                Application model = _mapper.Map<Application>(createDto);
               
                
                await _applicationRepo.Create(model);
                _response.Result = model;
                _response.statusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetApplication", new { model.ApplicationID }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }              
    }
}

