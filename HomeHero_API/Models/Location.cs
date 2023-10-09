﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }
        public int CityID { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Request>? Requests { get; set; }
    }
}
