using AutoMapper;
using HomeHero_API.Models.Dto.AreaDto;
using HomeHero_API.Models.Dto.Request_AreaDto;
using HomeHero_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HomeHero_API.Controllers
{
    [Route("api/requestArea")]
    [ApiController]
    public class Requests_AreasController : ControllerBase
    {
        private readonly IRequest_AreaRepository _raRep;
        private readonly IMapper _mapper;
        public Requests_AreasController(IRequest_AreaRepository raRepository, IMapper mapper)
        {
            _mapper = mapper;
            _raRep = raRepository;
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            var listRA = _raRep.GetRequests_Areas();
            var listRADto = new List<Request_AreaDto>();
            if (listRA == null)
            {
                return BadRequest("There are not data");
            }

            foreach (var ra in listRA)
            {
                var raDto = _mapper.Map<Request_AreaDto>(ra);
                raDto.AreaName = ra.Area_RA.NameArea;
                raDto.RequestTitle = ra.Request_RA.RequestTitle;
                listRADto.Add(raDto);
            }
            return Ok(listRADto);
        }

        [HttpGet("{request_AreaID:int}", Name = "GetRA")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetRA(int request_AreaID)
        {
            var ra = _raRep.GetRA(request_AreaID);

            if (ra == null)
            {
                return NotFound();
            }

            var raDto = _mapper.Map<Request_AreaDto>(ra);
            raDto.AreaName = ra.Area_RA.NameArea;
            raDto.RequestTitle = ra.Request_RA.RequestTitle;

            return Ok(raDto);
        }

        [HttpGet("ByRequest/{requestID:int}", Name = "GetAreasByRequest")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAreasByRequest(int requestID)
        {
            var listRA = _raRep.GetAreasByRequest(requestID);
            var listRADto = new List<Request_AreaDto>();
            if (listRA == null)
            {
                return BadRequest("There are not data");
            }

            foreach (var ra in listRA)
            {
                var raDto = _mapper.Map<Request_AreaDto>(ra);
                raDto.AreaName = ra.Area_RA.NameArea;
                raDto.RequestTitle = ra.Request_RA.RequestTitle;
                listRADto.Add(raDto);
            }
            return Ok(listRADto);
        }

        [HttpGet("ByArea/{areaName}", Name = "GetRequestByArea")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetRequestByArea(string areaName)
        {
            var listRA = _raRep.GetRequestByArea(areaName);
            var listRADto = new List<Request_AreaDto>();
            if (listRA == null)
            {
                return BadRequest("There are not data");
            }

            foreach (var ra in listRA)
            {
                var raDto = _mapper.Map<Request_AreaDto>(ra);
                raDto.AreaName = ra.Area_RA.NameArea;
                raDto.RequestTitle = ra.Request_RA.RequestTitle;
                listRADto.Add(raDto);
            }
            return Ok(listRADto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Request_AreaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateArea([FromBody] CreateRequest_AreaDto newRA)
        {
            if (!ModelState.IsValid || newRA == null)
            {
                return BadRequest(ModelState);
            }
            if (_raRep.ExistRA(newRA))
            {
                ModelState.AddModelError("", " This Request <-> Area relation already Exists");
                return StatusCode(400, ModelState);
            }
            if (!_raRep.CreateRA(newRA))
            {
                ModelState.AddModelError("", "Something failed saving the Request <-> Area relation");
                return StatusCode(500, ModelState);
            }
            var lastID = _raRep.lastID();
            var ra = _raRep.GetRA(lastID);
            var raDto = _mapper.Map<Request_AreaDto>(ra);
            raDto.AreaName = ra.Area_RA.NameArea;
            raDto.RequestTitle = ra.Request_RA.RequestTitle;

            return CreatedAtRoute("GetRA", new { request_AreaID = lastID}, raDto);
        }

        [HttpDelete("delete/{request_areaID:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRA(int request_areaID)
        {
            var ra = _raRep.GetRA(request_areaID);

            if (ra == null)
            {
                return NotFound();
            }

            if (!_raRep.DeleteRA(ra))
            {
                return StatusCode(500, "Error removing the Request <-> Area relation");
            }
            var raDto = _mapper.Map<Request_AreaDto>(ra);
            raDto.AreaName = ra.Area_RA.NameArea;
            raDto.RequestTitle = ra.Request_RA.RequestTitle;
            return Ok(new
            {
                Area = raDto,
                Message = "Correctly deleted the selected Request <-> Area relation"
            });
        }

           
    }
}
