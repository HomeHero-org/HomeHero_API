using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto.AreaDto
{
    public class CreateAreaDto
    {
        [Required]
        public string NameArea { get; set; }
    }
}
