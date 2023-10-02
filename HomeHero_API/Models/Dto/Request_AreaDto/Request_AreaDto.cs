using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeHero_API.Models.Dto.Request_AreaDto
{
    public class Request_AreaDto
    {
        [Key]
        public int RequestAreaID { get; set; }

        [ForeignKey("RequestID_Request")]
        public int RequestID_Request { get; set; }
        public string RequestTitle { get; set; }

        [ForeignKey("AreaID_Request")]
        public int AreaID_Request { get; set; }
        public string AreaName {  get; set; } 
    }
}
