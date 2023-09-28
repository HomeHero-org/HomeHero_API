using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto
{
    public class UserUpdateDto
    {
        public string email { get; set; }
        public string? RealUserID { get; set; }
        public string NamesUser { get; set; }
        public string SurnamesUser { get; set; }
        public char? SexUser { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public IFormFile? Curriculum { get; set; }

        [ForeignKey("LocationResidenceID")]
        public int LocationResidenceID { get; set; }

        [ForeignKey("RoleID_User")]
        public int RoleID_User { get; set; }
    }
}
