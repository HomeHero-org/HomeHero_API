using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto.UserDto
{
    public class UserSumarryDto
    {
        public string NamesUser { get; set; }
        public string SurnamesUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int LocationResidenceID { get; set; }
        public string Role { get; set; }
    }
}
