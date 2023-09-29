using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto
{
    public class ContactDto
    {
        [Key]
        public int ContactID { get; set; }

        [ForeignKey("UserID_Contact")]
        public int UserID_Contact { get; set; }
        public string OwnerUserEmail { get; set; }
        public string NumPhone { get; set; }
    }
}
