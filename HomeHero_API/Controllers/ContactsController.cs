using AutoMapper;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.ContactDto;
using HomeHero_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HomeHero_API.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRep;
        private readonly IMapper _mapper;
        public ContactsController(IContactRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contactRep = userRepository;
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "DefaultCache")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            var listContact = _contactRep.GetContacts();
            var listContactDto = new List<ContactDto>();
            if (listContact == null) {
                return BadRequest("There are not contacts");
            }

            foreach (var contact in listContact) {
                var contactDto = _mapper.Map<ContactDto>(contact);
                contactDto.OwnerUserEmail = contact.User_Contact.Email;
                listContactDto.Add(contactDto);
            }
            return Ok(listContactDto);
        }

        [HttpGet("{contactID:int}", Name = "GetContact")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetContact(int contactID)
        {
            var contact = _contactRep.GetContact(contactID);

            if (contact == null)
            {
                return NotFound();
            }

            var contactDto = _mapper.Map<ContactDto>(contact);
            contactDto.OwnerUserEmail = contact.User_Contact.Email;
            return Ok(contactDto);
        }

        [HttpGet("{userEmail}", Name = "GetUserContacts")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserContacts(string userEmail)
        {
            var listContact = _contactRep.GetUserContacts(userEmail);
            var listContactDto = new List<ContactDto>();
            if (listContact == null)
            {
                return BadRequest("There are not contacts");
            }

            foreach (var contact in listContact)
            {
                var contactDto = _mapper.Map<ContactDto>(contact);
                contactDto.OwnerUserEmail = contact.User_Contact.Email;
                listContactDto.Add(contactDto);
            }
            return Ok(listContactDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ContactDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateContact([FromBody] CreateContactDto newContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (newContact == null)
            {
                return BadRequest(ModelState);
            }
            if (_contactRep.existContact(newContact))
            {
                ModelState.AddModelError("", " That Movie already Exists");
                return StatusCode(404, ModelState);
            }
            if (!_contactRep.CreateContact(newContact))
            {
                ModelState.AddModelError("", $"Something failed saving the contact {newContact.NumPhone}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetContact", new { contactID = _contactRep.getLastID()},newContact);
        }

        [HttpDelete("delete/{contactID:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteContact(int contactID)
        {
            var contact = _contactRep.GetContact(contactID);

            if (contact == null)
            {
                return NotFound();
            }

            if (!_contactRep.DeleteContact(contact))
            {
                return StatusCode(500,"Error removing the contact -> " + contact.NumPhone);
            }

            return Ok("Correctly deleted contact: "+ contact.NumPhone + " IN " + contact.User_Contact.Email);
        }

        [HttpPatch("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateContactDto updateContact)
        {
            var contact = _contactRep.GetContact(updateContact.OwnerUserEmail,updateContact.OldNumberPhone);
            
            if (contact == null)
            {
                return NotFound("The selected email does not have in its numbers list the number -> " + updateContact.OldNumberPhone);
            }

            if (!_contactRep.UpdateContact(updateContact))
            {
                return StatusCode(500,"Error Updating de number -> "+ updateContact.OldNumberPhone);
            }

            var contactDto = _mapper.Map<ContactDto>(contact);
            contactDto.OwnerUserEmail = contact.User_Contact.Email;
            
            return Ok(new {
                Message = "Correctly updated!",
                ContactDto = contactDto
            });
        }
    }
}
