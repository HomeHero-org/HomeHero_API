using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto.Request_AreaDto
{
    public class CreateRequest_AreaDto
    {
        [Required]
        public int RequestID_Request { get; set; }

        [Required]
        public int AreaID_Request { get; set; }
    }
}
