using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto.UserDto
{
    public class UserRegisterDto
    {
        [Required, MinLength(8), StringLength(100)]
        public string NamesUser { get; set; }

        [Required, MinLength(8), StringLength(100)]
        public string SurnamesUser { get; set; }
        [Required]
        public string Email { get; set; }
        [MinLength(8)]
        [Required]
        public string Password { get; set; }
        public int CityID { get; set; }

        [ForeignKey("RoleID_User")]
        public int RoleID_User { get; set; }

    }
}
