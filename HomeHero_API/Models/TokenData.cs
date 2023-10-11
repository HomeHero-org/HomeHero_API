using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models
{
    public class TokenData
    {
        [Key]
        public int TokenID { get; set; }
        public string TokenInfo {  get; set; }
    }
}
