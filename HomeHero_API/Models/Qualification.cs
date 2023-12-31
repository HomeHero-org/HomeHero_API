﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models
{
    public class Qualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QualificationID { get; set; }
        public decimal QualificationNumber { get; set; }       
        public int HelperUserID { get; set; }
        [ForeignKey("HelperUserID")]
        public virtual User HelperUser { get; set; }
        public int ApplicantUserID { get; set; }
        [ForeignKey("ApplicantUserID")]
        public virtual User ApplicantUser { get; set; }
        public int RequestID_Qualification { get; set; }
        [ForeignKey("RequestID_Qualification")]
        public virtual Request Request_Qualification { get; set; }
        public string Comment { get; set; }
    }
}
