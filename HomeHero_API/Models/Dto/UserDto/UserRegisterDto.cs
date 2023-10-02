using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto.UserDto
{
    public class UserRegisterDto
    {
        public string NamesUser { get; set; }
        [Required, StringLength(100)]
        public string SurnamesUser { get; set; }
        [Required,MinLength(8)]
        public string Email { get; set; }
        [MinLength(8)]
        [Required]
        public string Password { get; set; }
        [ForeignKey("LocationResidenceID")]
        public int LocationResidenceID { get; set; }

        [ForeignKey("RoleID_User")]
        public int RoleID_User { get; set; }

    }
}
