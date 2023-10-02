using AutoMapper;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.AreaDto;
using HomeHero_API.Models.Dto.ContactDto;
using HomeHero_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeHero_API.Controllers
{
    [Route("api/area")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IAreaRepository _areaRep;
        private readonly IMapper _mapper;
        public AreasController(IAreaRepository areaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _areaRep = areaRepository;
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            var listArea = _areaRep.GetAreas();
            var listAreaDto = new List<AreaDto>();
            if (listArea == null)
            {
                return BadRequest("There are not areas");
            }

            foreach (var area in listArea)
            {
                listAreaDto.Add(_mapper.Map<AreaDto>(area));
            }
            return Ok(listAreaDto);
        }

        [HttpGet("{areaID:int}", Name = "GetAreaByID")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAreaByID(int areaID)
        {
            var area = _areaRep.GetArea(areaID);

            if (area == null)
            {
                return NotFound();
            }

            var areaDto = _mapper.Map<AreaDto>(area);
            return Ok(areaDto);
        }

        [HttpGet("{areaName}", Name = "GetAreaByName")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAreaByName(string areaName)
        {
            var area = _areaRep.GetArea(areaName);

            if(area == null)
            {
                return NotFound();
            }
            var areaDto = _mapper.Map<AreaDto>(area);
            return Ok(areaDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AreaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateArea([FromBody] CreateAreaDto newArea)
        {
            if (!ModelState.IsValid || newArea == null)
            {
                return BadRequest(ModelState);
            }
            if (_areaRep.GetArea(newArea.NameArea) != null)
            {
                ModelState.AddModelError("", " That Area already Exists");
                return StatusCode(400, ModelState);
            }
            if (!_areaRep.CreateArea(newArea))
            {
                ModelState.AddModelError("", $"Something failed saving the area -> {newArea.NameArea}");
                return StatusCode(500, ModelState);
            }
            var areaDto = _mapper.Map<AreaDto>(_areaRep.GetArea(newArea.NameArea));

            return CreatedAtRoute("GetAreaByName", new { areaName = newArea.NameArea }, areaDto);
        }

        [HttpDelete("delete/{areaName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteArea(string areaName)
        {
            var area = _areaRep.GetArea(areaName);

            if (area == null)
            {
                return NotFound();
            }

            if (!_areaRep.DeleteArea(area))
            {
                return StatusCode(500, "Error removing the area -> " + areaName);
            }
            var areaDto = _mapper.Map<AreaDto>(area);
            return Ok(new
            {
                Area = areaDto,
                Message = "Correctly deleted the selected Area"
            });
        }

        [HttpPatch("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateAreaDto updateArea)
        {
            var area = _areaRep.GetArea(updateArea.oldName);

            if (area == null)
            {
                return NotFound(updateArea.oldName + " can not be found in the Area data");
            }

            if (!_areaRep.UpdateArea(updateArea))
            {
                return StatusCode(500, "Error Updating de Area -> " + updateArea);
            }

            var areaDto = _mapper.Map<AreaDto>(area);

            return Ok(new
            {
                Message = "Correctly updated from -> "+ updateArea.oldName + " to -> AreaDto",
                AreaDto = areaDto
            });
        }
    }
}
