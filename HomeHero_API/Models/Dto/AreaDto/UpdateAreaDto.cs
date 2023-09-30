using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto.AreaDto
{
    public class UpdateAreaDto
    {
        [Required]
        public string oldName { get; set; }
        [Required]
        public string newName { get; set; }

    }
}
