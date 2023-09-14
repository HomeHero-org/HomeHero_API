using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationID { get; set; }

        public int UserID_Application { get; set; }

        [ForeignKey("UserID_Application")]
        public virtual User User_Application { get; set; }

        public int RequestID_Application { get; set; }
        [ForeignKey("RequestID_Application")]
        public virtual Request Request_Application { get; set; }
        public decimal RequestedPrice { get; set; }
    }
}
