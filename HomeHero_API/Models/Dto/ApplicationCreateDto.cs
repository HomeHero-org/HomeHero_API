using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models.Dto
{

    public class ApplicationCreateDto
    {
        [Required]
        public int UserID_Application { get; set; }

        [Required]
        public int RequestID_Application { get; set; }

        public decimal RequestedPrice { get; set; }
    }
}
