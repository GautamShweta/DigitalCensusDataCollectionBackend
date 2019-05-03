using Shared.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
    {
    public class MemberRequestStatus
        {
        public int MemberRequestStatusId { get; set; }

        [Required]
        public RequestStatus Status { get; set; }

        public int MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; } 
        
        }
    }
