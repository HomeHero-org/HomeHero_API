﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models
{
    public class Request_Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestAreaID { get; set; }       
        public int RequestID_Request { get; set; }
        [ForeignKey("RequestID_Request")]
        public virtual Request Request_RA { get; set; }
        public int AreaID_Request { get; set; }
        [ForeignKey("AreaID_Request")]
        public virtual Area Area_RA { get; set; }
    }
}
