using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AreaID { get; set; }
        public string NameArea { get; set; }

        [NotMapped]
        public virtual ICollection<Request>? Request_Areas { get; set; }

    }
}
