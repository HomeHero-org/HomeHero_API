using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }
        public int CodeRole { get; set; }
        public string NameRole { get; set; }
        public virtual ICollection<User> Users { get; set;}
    }
}
