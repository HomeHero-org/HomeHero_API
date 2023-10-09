using AutoMapper;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.RequestDto;
using HomeHero_API.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HomeHero_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        //inyeccion de dependencias
        private readonly ILogger<RequestController> _logger;
        private readonly IRequestRepository _requestRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public RequestController(ILogger<RequestController> logger, IRequestRepository requestRepo, IMapper mapper)
        {
            _logger = logger;
            _requestRepo = requestRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRequests()
        {
            try
            {
                _logger.LogInformation("Get all Request");
                IEnumerable<Request> requestList = await _requestRepo.GetAll();
                _response.Result = _mapper.Map<IEnumerable<RequestDto>>(requestList);
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


        [HttpGet("id:int", Name = "GetRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetRequest(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error: Get Request with id " + id);
                    _response.statusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccessful = false;
                    return BadRequest(_response);
                }
                var request = await _requestRepo.Get(x => x.RequestID == id);
                if (request == null)
                {
                    _response.statusCode = HttpStatusCode.NotFound;
                    _response.IsSuccessful = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<RequestDto>(request);
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
        public async Task<ActionResult<APIResponse>> CreateRequest([FromForm] RequestCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (createDto == null) return BadRequest(createDto);

                int idLocation = _requestRepo.CreateLocation(createDto.LocationServiceID);
                createDto.LocationServiceID = idLocation;

                Request model = _mapper.Map<Request>(createDto);
                model.CreatedTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;

                if (createDto.RequestPicture != null && createDto.RequestPicture.Length > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await createDto.RequestPicture.CopyToAsync(memoryStream);
                    var base64Image = Convert.ToBase64String(memoryStream.ToArray()); // Convert the image to Base64
                    model.RequestPicture = Convert.FromBase64String(base64Image); // Convert back to byte[] for DB storage
                }

                await _requestRepo.Create(model);

                _response.Result = model;
                _response.statusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetRequest", new { id = model.RequestID }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        //Con la interfaz no necesita el modelo
        public async Task<IActionResult> DeleteRequest(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccessful = false;
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var request = await _requestRepo.Get(v => v.RequestID == id);
                if (request == null)
                {
                    _response.IsSuccessful = false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _requestRepo.Remove(request);
                _response.statusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccessful = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return BadRequest(_response);


        }

        //Put todo el objeto
        //Patch solo una caracterisitica
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateRequest(int id, [FromBody] RequestUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.RequestID)
            {
                _response.IsSuccessful = false;
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            Request model = _mapper.Map<Request>(updateDto);
            await _requestRepo.Update(model);
            _response.statusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialRequest(int id, JsonPatchDocument<RequestUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0) return BadRequest();

            var request = await _requestRepo.Get(v => v.RequestID == id, tracked: false);
            if (request == null) return NotFound();
            RequestUpdateDto requestDto = _mapper.Map<RequestUpdateDto>(request);

            patchDto.ApplyTo(requestDto, ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Request model = _mapper.Map<Request>(requestDto);

            await _requestRepo.Update(model);
            _response.statusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }
    }
}

