using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHero_API.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestID { get; set; }

        [ForeignKey("LocationServiceID")]
        public int LocationServiceID { get; set; }
        public virtual Location Location_Request { get; set; }

        [ForeignKey("UserId_Request")]
        public int UserId_Request { get; set; }
        public virtual User UserRequest { get; set; }
        public string RequestContent { get; set; }
        public DateTime PublicationReqDate { get; set; } 

        [ForeignKey("ReqStateID_Request")]
        public int ReqStateID_Request { get; set; }
        public virtual State RequestState { get; set; }

        [ForeignKey("AreaID_Request")]
        public int AreaID_Request { get; set; }
        public virtual Area AreaOfRequest { get; set; }

        public int MembersNeeded { get; set; }
        public byte[] RequestPicture { get; set; }
        public string RequestTitle { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public virtual ICollection<Application>? Applications { get; set; }
        public virtual ICollection<AttentionRequest>? AttentionRequests { get; set; } 
        public virtual ICollection<Complaint>? ReqComplaints { get; set; }
        public virtual ICollection<Qualification>? Qualifications { get; set; }
        public virtual ICollection<Request_Area>? Request_Areas { get; set; }
        public virtual ICollection<Chat>? Chats { get; set; }
        
    }
}
