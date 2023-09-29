using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto
{
    public class CreateContactDto
    {
        [Required,MinLength(10)]
        public string NumPhone { get; set; }
        [Required,MinLength(8)]
        public string email { get; set; }

    }
}
