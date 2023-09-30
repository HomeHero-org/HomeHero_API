using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models.Dto.RequestDto
{

    public class RequestCreateDto
    {
        [Required]
        public int LocationServiceID { get; set; }
        [Required]
        public int UserId_Request { get; set; } = 3;
        public string RequestContent { get; set; }
        public DateTime PublicationReqDate { get; set; }
        [Required]
        public int ReqStateID_Request { get; set; } = 1;
        public int MembersNeeded { get; set; }
        public IFormFile RequestPicture { get; set; }

        public string RequestTitle { get; set; }
    }
}
