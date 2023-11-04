using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Request>? Requests { get; set; }
    }
}
