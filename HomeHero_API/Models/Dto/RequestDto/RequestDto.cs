using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models.Dto.RequestDto
{

    public class RequestDto
    {
        public int RequestID { get; set; }
        [Required]
        public int LocationServiceID { get; set;}
        public int Address { get; set; }
        [Required]
        public int UserId_Request { get; set; }
        public string RequestContent { get; set; }
        public DateTime PublicationReqDate { get; set; }
        [Required]
        public int ReqStateID_Request { get; set; }
        public int MembersNeeded { get; set; }
        public string RequestPicture { get; set; }
        public string RequestTitle { get; set; }
        //Names
        public string RequestArea { get; set; }
    }
}
