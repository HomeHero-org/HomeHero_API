using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto.AreaDto
{
    public class AreaDto
    {
        [Key]
        public int AreaID { get; set; }
        public string NameArea { get; set; }
    }
}
